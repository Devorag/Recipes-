
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
            //SQLUtility.DebugPrintDataTable(dtRecipes);
            if (dtRecipes.Rows.Count == 0)
            {
                throw new Exception("Cannot call Recipe save method because there are no rows in the table");
            }
            DataRow r = dtRecipes.Rows[0];
            SQLUtility.SaveDataRow(r, "RecipesUpdate");


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




    }
}








