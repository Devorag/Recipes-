
using System.Diagnostics;


namespace RecipeSystem
{
    public class Recipes
    {
        public static DataTable SearchRecipes(string recipename)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            cmd.Parameters["@RecipeName"].Value = recipename;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeid)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            cmd.Parameters["@RecipeId"].Value = recipeid;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            cmd.Parameters["@All"].Value = 1;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
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
                    $"DateDrafted = '{r["DateDrafted"]}'",
                    //$"DatePublished = '{r["DatePublished"]}',",
                    //$"DateArchived = '{r["DateArchived"]}'",
                    $"where RecipeId = {r["RecipeId"]}");
            }
            else if (id == 0)
            {
                //sql = "insert recipe(CuisineId, UsersId, RecipeName, Calories, DateDrafted, DatePublished, DateArchived)";
                //sql += $"Select '{r["CuisineId"]}', '{r["UsersId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["DateDrafted"]}', '{r["DatePublished"]}', '{r["DateArchived"]}'";
                sql = "insert recipe(CuisineId, UsersId, RecipeName, Calories, DateDrafted)";
                sql += $"Select '{r["CuisineId"]}', '{r["UsersId"]}', '{r["RecipeName"]}', '{r["Calories"]}', '{r["DateDrafted"]}'";
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
