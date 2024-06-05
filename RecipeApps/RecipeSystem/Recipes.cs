using System.Data;
using System.Diagnostics;


namespace RecipeSystem
{
    public class Recipes
    {
        public static DataTable SearchRecipes(string recipename)
        {
            string sql = "select RecipeId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived from recipe r where r.RecipeName like '%" + recipename + "%'";

            DataTable dt = SQLUtility.GetDataTable(sql);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            string sql = "select r.*, u.Username , C.Cuisinetype from users u join recipe r on u.UsersId = r.UsersId " +
            "join cuisine c on c.CuisineId = r.CuisineId " +
            "where r.RecipeId = " + recipeid.ToString();
            return SQLUtility.GetDataTable(sql);
        }

        public static DataTable GetCuisineList()
        {
            return SQLUtility.GetDataTable("select CuisineId, CuisineType from cuisine");
        }

        public static DataTable GetUsersList()
        {
            return SQLUtility.GetDataTable("select UsersId, UserName from users");
        }

        public static void Save(DataTable dtRecipes)
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
                sql = "insert recipe(CuisineId, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)";
                sql += $"Select '{r["CuisineId"]}', '{r["UsersId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["DateDrafted"]}', '{r["DatePublished"]}', '{r["DateArchived"]}'";
            }
            Debug.Print("--------");

            SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtRecipes)
        {
            int id = (int)dtRecipes.Rows[0]["RecipeId"];
            string sql = "Delete recipe where RecipeId = " + id;
            SQLUtility.ExecuteSQL(sql);
        }

    }
}
