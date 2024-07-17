namespace RecipeSystem
{
    public class Recipes
    {
        public static DataTable SearchRecipes()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeList");
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
            SqlCommand cmd = SQLUtility.GetSQLCommand("UserGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtRecipes)
        {
            //SQLUtility.DebugPrintDataTable(dtRecipes);
            if (dtRecipes.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe save method because there are no rows in the table");
            }
            DataRow r = dtRecipes.Rows[0];
            SQLUtility.SaveDataRow(r, "UpdateRecipe");


            //SQLUtility.ExecuteSQL(sql);
        }

        public static void Delete(DataTable dtRecipes, string message)
        {
            int id = (int)dtRecipes.Rows[0]["RecipeId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeDelete");
            SQLUtility.SetParamValue(cmd, "@RecipeId", id);
            SQLUtility.SetParamValue(cmd, "@Message", message); // Set the @Message parameter

            try
            {
                SQLUtility.ExecuteSQL(cmd);
            }
            catch (SqlException ex)
            {
                // Parse the constraint violation message
                string userMessage = SQLUtility.ParseConstraintMsg(ex.Message);

                // Display the user-friendly error message
                DisplayMessageToUser(userMessage);
            }
        }

        private static void DisplayMessageToUser(string message)
        {
            Console.WriteLine(message);
        }


        public static DataTable GetRecipeById(int recipeId)
        {
            string sql = $"select * from recipes where recipeid = {recipeId}";
            return SQLUtility.GetDataTable(sql);
        }

        public static void UpdateRecipeStatus(int recipeId, int newStatus)
        {
            using(SqlCommand cmd = new SqlCommand("ChangeRecipeStatus")) 
            {
                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
                SQLUtility.SetParamValue(cmd, "@NewStatus", newStatus);
                SQLUtility.ExecuteSQL(cmd);
            }
        }

    }
}








