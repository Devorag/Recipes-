using System.Data;
using System.Diagnostics;
using CPUFramework;
using CPUWindowsFormFramework;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipes;
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }



        public void ShowForm(int recipeid)
        {
            string sql = "select r.*, u.Username , C.Cuisinetype from users u join recipe r on u.UsersId = r.UsersId " +
                "join cuisine c on c.CuisineId = r.CuisineId " +
                "where r.RecipeId = " + recipeid.ToString();
            dtRecipes = SQLUtility.GetDataTable(sql);
            if (recipeid == 0)
            {
                dtRecipes.Rows.Add();
            }
            DataTable dtCuisine = SQLUtility.GetDataTable("select CuisineId, CuisineType from cuisine");
            //WindowsFormsUtility.SetListBinding(lstCuisine, dtCuisine, dtRecipes, "CuisineType");
            lstCuisine.DataSource = dtCuisine;
            lstCuisine.ValueMember = "CuisineId";
            lstCuisine.DisplayMember = "CuisineType";
            lstCuisine.DataBindings.Add("SelectedValue", dtRecipes, "CuisineId");
            DataTable dtUsers = SQLUtility.GetDataTable("select UsersId, UserName from users");
            WindowsFormsUtility.SetListBinding(lstUserName, dtUsers, dtRecipes, "Users");
            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtRecipes);

            this.Show();
        }

        private void Save()
        {
            SQLUtility.DebugPrintDataTable(dtRecipes);
            DataRow r = dtRecipes.Rows[0];
            int id = (int)r["RecipeId"];
            string sql = "";
            if (id > 0)
            {
                sql = string.Join(Environment.NewLine, $"update recipe set",
                    $"CuisineId = '{r["CuisineId"]}',",
                    $"UsersId = '{r["UsersId"]}',",
                    $"RecipeName = '{r["Recipename"]}',",
                    $"Calories = '{r["Calories"]}',",
                    $"DateDrafted = '{r["DateDrafted"]}',",
                    $"DatePublished = '{r["DatePublished"]}',",
                    $"DateArchived = '{r["DateArchived"]}'",
                    $"where RecipeId = {r["RecipeId"]}");
            }
            else
            {
                sql = "insert recipe(CusineId, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)";
                sql += $"Select '{r["CuisineId"]}', '{r["UsersId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["DateDrafted"]}', '{r["DatePublished"]}', '{r["DateArchived"]}'";
            }
            Debug.Print("--------");

            SQLUtility.ExecuteSQL(sql);
        }

        private void Delete()
        {
            int id = (int)dtRecipes.Rows[0]["RecipeId"];
            string sql = "Delete recipe where RecipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
            this.Close();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }


    }
}
