using RecipeWinForms.Properties;
using System.Configuration;

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
#if DEBUG
            this.Text = this.Text + " - DEV";
#endif       
            txtUserId.Text = Settings.Default.userid;
            this.ShowDialog();
            return loginSuccess;
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            try
            {
                string connStringKey = "";
#if DEBUG
                connStringKey = "devconn";
                
#else
                connStringKey = "liveconn";
              
#endif
                string connString = ConfigurationManager.ConnectionStrings[connStringKey].ConnectionString;
                DBManager.SetConnectionString(connString, true, txtUserId.Text, txtPassword.Text);
                loginSuccess = true;
                Settings.Default.userid = txtUserId.Text;
                Settings.Default.Save();
                this.Close();
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
