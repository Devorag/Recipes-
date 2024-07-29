
namespace RecipeSystem
{
    public class CookbookRecipe
    {
        public static DataTable LoadByCookbookId(int cookbookId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeGet");
            cmd.Parameters["@CookbookId"].Value = cookbookId;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveDataTable(DataTable dt, int cookbookId)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["CookbookId"] = cookbookId;
            }
            SQLUtility.SaveDataTable(dt, "CookbookRecipeUpdate");
        }

        public static void Delete(int cookbookRecipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeDelete");
            cmd.Parameters["@CookbookRecipeId"].Value = cookbookRecipeId;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
