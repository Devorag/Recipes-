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
                int cookbookId = Cookbooks.AutoCreate(usersId);
                MessageBox.Show("Cookbook created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                OpenCookbookList(cookbookId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating cookbook: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            CreateCookbook();
        }

        private void OpenCookbookList(int cookbookId)
        {
            OpenForm(typeof(frmCookbookList));
        }

        private void OpenForm(Type frmType)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmType);
            }
        }
    }
}
