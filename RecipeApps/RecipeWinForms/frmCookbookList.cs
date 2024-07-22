using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCookbookList : Form
    {
        public frmCookbookList()
        {
            InitializeComponent();
            this.Activated += FrmCookbookList_Activated;
            btnNewCookbook.Click += BtnNewCookbook_Click;
            gCookbooks.CellDoubleClick += GCookbooks_CellDoubleClick;
            gCookbooks.KeyDown += GCookbooks_KeyDown;
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

        private void ShowCookbooksForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gCookbooks, rowindex, "CookbookId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmNewCookbook), id);
            }
        }

        private void GCookbooks_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            ShowCookbooksForm(e.RowIndex);
        }

        private void BtnNewCookbook_Click(object? sender, EventArgs e)
        {
            ShowCookbooksForm(-1);
        }


        private void GCookbooks_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gCookbooks.SelectedRows.Count > 0)
            {
                ShowCookbooksForm(gCookbooks.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }

    }
}
