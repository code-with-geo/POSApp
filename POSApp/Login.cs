namespace POSApp
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Visible = false;
        }
    }
}
