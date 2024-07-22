namespace RecipeSystem
{
    public class Cookbooks
    {
        public static void CreateCookbook(int usersId, int cookbookId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CreateCookbook");
            SQLUtility.SetParamValue(cmd, "@UsersId", usersId);
            SQLUtility.SetParamValue(cmd, "@CookbookId", cookbookId);

            // Execute the stored procedure
            SQLUtility.ExecuteSQL(cmd);

            // Retrieve the output parameter value
            cookbookId = (int)cmd.Parameters["@CookbookId"].Value;
        }

        public static void CreateOlympicsBasedOnPrevious(int seasonid, int cityid, int year, int basedonolympicsid)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("OlympicsCreateBasedOnPrevious");
            SQLUtility.SetParamValue(cmd, "@SeasonId", seasonid);
            SQLUtility.SetParamValue(cmd, "@CityId", cityid);
            SQLUtility.SetParamValue(cmd, "@OlympicYear", year);
            SQLUtility.SetParamValue(cmd, "@BaseOlympicsId", basedonolympicsid);
            SQLUtility.ExecuteSQL(cmd);
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

    }
}
