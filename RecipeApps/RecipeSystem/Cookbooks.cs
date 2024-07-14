namespace RecipeSystem
{
    public class Cookbooks
    {
        public static DataTable GetCookbooksList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookGet");
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
