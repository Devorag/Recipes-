namespace RecipeWinForms
{
    public partial class frmCreateCookbook : Form
    {
        int cookbookId;
        public frmCreateCookbook()
        {
            InitializeComponent();
            LoadForm();
            btnCreate.Click += BtnCreate_Click;
        }

        private void LoadForm()
        {
            DataTable dtUsers = Recipes.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsersName, dtUsers, null, "Users");
        }

        public void CreateCookbook()
        {
            int usersId = WindowsFormsUtility.GetIdFromComboBox(lstUsersName);
            try
            {
                object result = Cookbooks.AutoCreate(usersId);
                if (result == DBNull.Value || result == null)
                {
                    throw new InvalidOperationException("Cookbook creation failed: No valid ID returned.");
                }

                int cookbookId;
                if (!int.TryParse(result.ToString(), out cookbookId))
                {
                    throw new InvalidOperationException("Cookbook creation failed: Invalid ID returned.");
                }

                OpenForm();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating cookbook: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCreate.Enabled = true;
            }
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            btnCreate.Enabled = false;
            CreateCookbook();
        }

        private void OpenForm()
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmCookbookList), cookbookId);
            }
        }
    }
}
