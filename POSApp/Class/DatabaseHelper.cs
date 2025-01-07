using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp.Class
{
    public static class DatabaseHelper
    {
        private static readonly string FolderPath = @"C:\POS";
        private static readonly string DbPath = Path.Combine(FolderPath, "POS.sqlite");

        public static void CreateDatabase()
        {
            MessageBox.Show(DbPath.ToString());
            try
            {
                // Create the folder if it doesn't exist
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // Check if the database file already exists
                if (File.Exists(DbPath))
                {
                    MessageBox.Show("Database already exists!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create the SQLite database file
                SQLiteConnection.CreateFile(DbPath);

                // Connect to the database and create tables
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    
                    connection.Open();

                    // Create multiple tables
                    string[] tableQueries = new string[]
                    {
                        // Inventory Table
                        @"
                        CREATE TABLE IF NOT EXISTS Inventory (
                            InventoryId INTEGER PRIMARY KEY,
                            Specification VARCHAR(55) NOT NULL,
                            Units INT NOT NULL,
                            ProductId INT NOT NULL,
                            LocationId INT NOT NULL,
                            Status INT NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now')),
                            FOREIGN KEY (ProductId) REFERENCES Products(ProductId),
                            FOREIGN KEY (LocationId) REFERENCES Locations(LocationId)
                        );",
                        
                        // Products Table
                        @"
                        CREATE TABLE IF NOT EXISTS Products (
                            Id INTEGER PRIMARY KEY,
                            Barcode VARCHAR(100) NOT NULL,
                            Name VARCHAR(100) NOT NULL,
                            Description VARCHAR(100) NOT NULL,
                            SupplierPrice  DECIMAL(18, 2) NOT NULL,
                            RetailPrice  DECIMAL(18, 2) NOT NULL,
                            WholesalePrice  DECIMAL(18, 2) NOT NULL,
                            ReorderLevel  INTEGER NOT NULL,
                            Remarks VARCHAR(100) NOT NULL,
                            IsVat  INTEGER NOT NULL,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now')),        
                            CategoryId  INTEGER NOT NULL,
                            FOREIGN KEY (CategoryId) REFERENCES Category(CategoryId)
                        );",
                        
                        // Category Table
                        @"
                        CREATE TABLE IF NOT EXISTS Category (
                            CategoryId INTEGER PRIMARY KEY,
                            Name VARCHAR(100) NOT NULL,
                            Status  INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))     
                        );",

                        // Locations Table
                        @"
                        CREATE TABLE IF NOT EXISTS Locations (
                            LocationId INTEGER PRIMARY KEY,
                            Name VARCHAR(50) NOT NULL,
                            Password VARCHAR(100) NOT NULL,
                            Status INTEGER NOT NULL,
                            DateCreated DATETIME DEFAULT (DATETIME('now'))   
                        );"
                    };

                    // Execute each table creation query
                    foreach (string query in tableQueries)
                    {
                        using (var command = new SQLiteCommand(query, connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }

                    connection.Close();
                }

                MessageBox.Show("Database created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating database: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static async Task SyncProducts(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Products>(
                apiUrl,
                authToken,
                "Products",
                async (product, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the product already exists
                    string checkQuery = "SELECT COUNT(1) FROM Products WHERE Id = @Id";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@Id", product.Id);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Products (Id, Barcode, Name, Description, SupplierPrice, RetailPrice, WholesalePrice, ReorderLevel, Remarks, IsVat, Status, CategoryId)
                                            VALUES (@Id, @Barcode, @Name, @Description, @SupplierPrice, @RetailPrice, @WholesalePrice, @ReorderLevel, @Remarks, @IsVat, @Status, @CategoryId);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Products
                            SET Barcode = @Barcode,
                                Name = @Name,
                                Description = @Description,
                                SupplierPrice = @SupplierPrice,
                                RetailPrice = @RetailPrice,
                                WholesalePrice = @WholesalePrice,
                                ReorderLevel = @ReorderLevel,
                                Remarks = @Remarks,
                                IsVat = @IsVat,
                                Status = @Status,
                                CategoryId = @CategoryId
                            WHERE Id = @Id;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@Id", product.Id);
                    command.Parameters.AddWithValue("@Barcode", product.Barcode);
                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SupplierPrice", product.SupplierPrice);
                    command.Parameters.AddWithValue("@RetailPrice", product.RetailPrice);
                    command.Parameters.AddWithValue("@WholesalePrice", product.WholesalePrice);
                    command.Parameters.AddWithValue("@ReorderLevel", product.ReorderLevel);
                    command.Parameters.AddWithValue("@Remarks", product.Remarks ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IsVat", product.IsVat);
                    command.Parameters.AddWithValue("@Status", product.Status);
                    command.Parameters.AddWithValue("@CategoryId", product.CategoryId);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncLocations(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Locations>(
                apiUrl,
                authToken,
                "Locations",
                async (location, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the location already exists
                    string checkQuery = "SELECT COUNT(1) FROM Locations WHERE LocationId = @LocationId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@LocationId", location.LocationId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Locations (LocationId, Name, Password, Status)
                                            VALUES (@LocationId, @Name, @Password, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Locations
                            SET Name = @Name,
                                Password = @Password,
                                Status = @Status
                            WHERE LocationId = @LocationId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@LocationId", location.LocationId);
                    command.Parameters.AddWithValue("@Name", location.Name);
                    command.Parameters.AddWithValue("@Password", location.Password);
                    command.Parameters.AddWithValue("@Status", location.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncCategory(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Category>(
                apiUrl,
                authToken,
                "Category",
                async (category, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the category already exists
                    string checkQuery = "SELECT COUNT(1) FROM Category WHERE CategoryId = @CategoryId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Category (CategoryId, Name, Status)
                                            VALUES (@CategoryId, @Name, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Category
                            SET Name = @Name,
                                Status = @Status
                            WHERE CategoryId = @CategoryId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@CategoryId", category.CategoryId);
                    command.Parameters.AddWithValue("@Name", category.Name);
                    command.Parameters.AddWithValue("@Status", category.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncInventory(string apiUrl, string authToken)
        {

            await SyncDataFromApi<Inventory>(
                apiUrl,
                authToken,
                "Inventory",
                async (inventory, command) =>
                {
                    // Clear parameters at the beginning of each operation
                    command.Parameters.Clear();

                    // Check if the inventory already exists
                    string checkQuery = "SELECT COUNT(1) FROM Inventory WHERE InventoryId = @InventoryId";
                    command.CommandText = checkQuery;
                    command.Parameters.AddWithValue("@InventoryId", inventory.InventoryId);

                    long count = (long)(await command.ExecuteScalarAsync());

                    if (count == 0)
                    {
                        command.CommandText = @"
                                            INSERT INTO Inventory (InventoryId, Specification, Units, ProductId, LocationId, Status)
                                            VALUES (@InventoryId, @Specification, @Units, @ProductId, @LocationId, @Status);";
                    }
                    else
                    {
                        command.CommandText = @"
                            UPDATE Inventory
                            SET Specification = @Specification,
                                Units = @Units,
                                ProductId = @ProductId, 
                                LocationId = @LocationId,
                                Status = @Status
                            WHERE InventoryId = @InventoryId;";
                    }

                    // Clear parameters before re-adding them for the INSERT or UPDATE query
                    command.Parameters.Clear();

                    // Add all required parameters
                    command.Parameters.AddWithValue("@InventoryId", inventory.InventoryId);
                    command.Parameters.AddWithValue("@Specification", inventory.Specification ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Units", inventory.Units);
                    command.Parameters.AddWithValue("@ProductId", inventory.ProductId);
                    command.Parameters.AddWithValue("@LocationId", inventory.LocationId);
                    command.Parameters.AddWithValue("@Status", inventory.Status);

                    await command.ExecuteNonQueryAsync();
                }
            );

        }

        public static async Task SyncDataFromApi<T>(
            string apiUrl,
            string authToken,
            string tableName,
            Func<T, SQLiteCommand, Task> mapToDatabaseCommand)
        {
            try
            {
                // Fetch data from the Web API with Authorization header
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);

                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();

                        // Deserialize JSON to a list of objects of type T
                        var items = JsonSerializer.Deserialize<List<T>>(jsonResponse);

                        if (items == null || items.Count == 0)
                        {
                            MessageBox.Show($"No data to sync for {tableName}.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Connect to SQLite database
                        using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                        {
                            connection.Open();

                            foreach (var item in items)
                            {
                                using (var command = new SQLiteCommand(connection))
                                {
                                    // Call the mapping function to insert/update data
                                    await mapToDatabaseCommand(item, command);
                                    command.ExecuteNonQuery();
                                }
                            }

                            connection.Close();
                        }

                        MessageBox.Show($"Data for {tableName} synced successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"Failed to fetch data for {tableName}. Status: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error syncing data for {tableName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable GetInventory()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            P.Barcode, 
                            P.Name, 
                            I.Units, 
                            I.Specification, 
                            P.RetailPrice 
                        FROM Inventory I 
                        INNER JOIN Products P ON I.ProductId = P.Id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        using (var adapter = new SQLiteDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching inventory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dataTable;
        }

        public static Products GetProductById(int productId)
        {
            try
            {
                using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
                {
                    connection.Open();

                    string query = @"
                        SELECT Id, Barcode, Name, Description, RetailPrice, IsVat 
                        FROM Products 
                        WHERE Id = @Id;";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", productId);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Map database row to Product object
                                return new Products
                                {
                                    Id = reader.GetInt32(0),
                                    Barcode = reader.GetString(1),
                                    Name = reader.GetString(2),
                                    Description = reader.IsDBNull(3) ? null : reader.GetString(3),
                                    RetailPrice = reader.GetDecimal(4),
                                    IsVat = reader.GetInt32(5) // Check if IsVat is 1
                                };
                            }
                        }
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
    }
}
