namespace RecipeWinForms
{
    public partial class frmLogin : Form
    {
        bool loginSuccess = false;
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        public bool ShowLogin()
        {
            this.ShowDialog();
            return loginSuccess;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string connstringkey = "";
#if DEBUG       
                connstringkey = "devconn";
#else
                connstringkey = "liveconn";
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Login. Please try again.", Application.ProductName);
            }
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}
