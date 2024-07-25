namespace RecipeSystem
{
    public class Cookbooks
    {
        public static int  AutoCreate(int usersId)
        {
            int cookbookId;
            SqlCommand cmd = SQLUtility.GetSQLCommand("CreateCookbook");
            SQLUtility.SetParamValue(cmd, "@UsersId", usersId);
            SQLUtility.SetParamValue(cmd, "@CookbookId", 0);

            SQLUtility.ExecuteSQL(cmd);

            cookbookId = (int)cmd.Parameters["@CookbookId"].Value;
            return cookbookId;
        }

        public static DataTable GetRecipesList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeList");
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable GetCookbooksList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookList");
            return SQLUtility.GetDataTable(cmd);
        }

        public static DataTable Load(int cookbookId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookId);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void Save(DataTable dtCookbook)
        {
            if (dtCookbook.Rows.Count == 0)
            {
                throw new Exception("Cannot call Cookbook save method because there are no rows in the table");
            }
            DataRow r = dtCookbook.Rows[0];
            
            SQLUtility.SaveDataRow(r, "UpdateCookbook");
        }


        public static void Delete(DataTable dtCookbook, string message)
        {
            int id = (int)dtCookbook.Rows[0]["CookbookId"];
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookDelete");
            SQLUtility.SetParamValue(cmd, "@CookbookId", id);
            SQLUtility.SetParamValue(cmd, "@Message", message);

            try
            {
                SQLUtility.ExecuteSQL(cmd);
            }
            catch (SqlException ex)
            {
                string userMessage = SQLUtility.ParseConstraintMsg(ex.Message);
                DisplayMessageToUser(userMessage);
            }
        }
        private static void DisplayMessageToUser(string message)
        {
            Console.WriteLine(message);
        }
    }
}
