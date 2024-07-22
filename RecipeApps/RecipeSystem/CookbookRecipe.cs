
namespace RecipeSystem
{
    public class CookbookRecipe
    {
        public static DataTable LoadByRecipeId(int recipeId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeGet");
            cmd.Parameters["@RecipeId"].Value = recipeId;
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveDataTable(DataTable dt, int recipeId)
        {
            foreach (DataRow r in dt.Select("", "", DataViewRowState.Added))
            {
                r["RecipeId"] = recipeId;
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
