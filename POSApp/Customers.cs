using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSApp
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tenders tenders = new Tenders();
            tenders.Show();
            this.Close();
        }
    }
}
