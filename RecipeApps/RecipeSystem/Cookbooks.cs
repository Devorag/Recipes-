namespace RecipeSystem
{
    public class Cookbooks
    {
        public static void CreateCookbookBasedOnPrevious( )
        {

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
