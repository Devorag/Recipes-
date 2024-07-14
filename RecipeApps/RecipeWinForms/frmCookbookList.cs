namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbookList_Activated;
            BindData();
        }

        private void FrmCookbookList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            gCookbooks.DataSource = Cookbooks.GetCookbooksList();
            WindowsFormsUtility.FormatGridForSearchResults(gCookbooks, "Cookbook");
        }
    }
}
