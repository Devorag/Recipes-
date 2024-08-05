namespace RecipeSystem
{
    public class Recipes
    {
        public static DataTable SearchRecipes()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetRecipeList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable Load(int recipeId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetCuisineList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CuisineGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable GetUsersList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("UsersGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static DataTable RecipeStatusGet(int recipeId = 0, string recipeName = null, bool all = false)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStatusGet");

            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipeName);
            SQLUtility.SetParamValue(cmd, "@All", 1);
            return SQLUtility.GetDataTable(cmd);
        }

        public static string ChangeRecipeStatus(int recipeId, string newStatus)
        {
            using (SqlCommand cmd = SQLUtility.GetSQLCommand("ChangeRecipeStatus"))
            {
                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
                SQLUtility.SetParamValue(cmd, "@NewStatus", newStatus);
                SQLUtility.SetParamValue(cmd, "@Message", DBNull.Value);

                SQLUtility.ExecuteSQL(cmd);
                string message = Convert.ToString(cmd.Parameters["@Message"].Value);
                return message;
            }
        }

        public static void Save(DataTable dtRecipes)
        {
            if (dtRecipes.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe save method because there are no rows in the table");
            }
            DataRow r = dtRecipes.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipeUpdate");
        }

        public static string Delete(DataTable dtRecipes)
        {
            int id = (int)dtRecipes.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.SetParamValue(cmd, "@Message", DBNull.Value);
            SQLUtility.ExecuteSQL(cmd);

            string message = Convert.ToString(cmd.Parameters["@Message"].Value);
            return message;
        }

        private static void DisplayMessageToUser(string message)
        {
            Console.WriteLine(message);
        }

    }
}








