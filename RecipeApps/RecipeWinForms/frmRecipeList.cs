using System.Data;

namespace RecipeWinForms
{
    public partial class frmRecipeList : Form
    {
        public frmRecipeList()
        {
            InitializeComponent();
            this.Activated += FrmRecipeList_Activated;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick1;
            gRecipes.KeyDown += GRecipes_KeyDown;
            btnNew.Click += BtnNew_Click;
        }

        private void FrmRecipeList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            gRecipes.DataSource = Recipes.SearchRecipes();
            WindowsFormsUtility.FormatGridForSearchResults(gRecipes, "Recipe");
        }


        private void ShowRecipesForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = WindowsFormsUtility.GetIdFromGrid(gRecipes, rowindex, "RecipeId");
            }
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmNewRecipe), id);
            }
        }

        private void GRecipes_CellDoubleClick1(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipesForm(e.RowIndex);
        }


        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipesForm(-1);
        }

        private void GRecipes_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && gRecipes.SelectedRows.Count > 0)
            {
                ShowRecipesForm(gRecipes.SelectedRows[0].Index);
                e.SuppressKeyPress = true;
            }
        }
    }
}
