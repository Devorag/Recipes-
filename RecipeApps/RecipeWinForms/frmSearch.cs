using CPUFramework;
using CPUWindowsFormFramework;
using System.Data;
using System.Diagnostics;


namespace RecipeWinForms
{
    public partial class frmSearch : Form
    {
        public frmSearch()
        {
            InitializeComponent();
            btnSearch.Click += BtnSearch_Click;
            gRecipes.CellDoubleClick += GRecipes_CellDoubleClick1;
            btnNew.Click += BtnNew_Click;
            WindowsFormsUtility.FormatGridForSearchResults(gRecipes);
        }


        private void SearchForRecipe(string recipename)
        {
            string sql = "select RecipeId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived from recipe r where r.RecipeName like '%" + recipename + "%'";
            Debug.Print(sql);
            DataTable dt = SQLUtility.GetDataTable(sql);
            gRecipes.DataSource = dt;
            gRecipes.Columns["RecipeId"].Visible = false;
        }


        private void ShowRecipesForm(int rowindex)
        {
            int id = 0;
            if (rowindex > -1)
            {
                id = (int)gRecipes.Rows[rowindex].Cells["RecipeId"].Value;
            }
            frmRecipe frm = new frmRecipe();
            frm.ShowForm(id);
        }

        private void GRecipes_CellDoubleClick1(object? sender, DataGridViewCellEventArgs e)
        {
            ShowRecipesForm(e.RowIndex);
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchForRecipe(txtRecipeName.Text);
        }

        private void BtnNew_Click(object? sender, EventArgs e)
        {
            ShowRecipesForm(-1);
        }
    }
}
