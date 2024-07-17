namespace RecipeSystem
{
    public class RecipeSteps
    {
        public static DataTable LoadByRecipeId(int recipeId)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStepsGet");
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
            SQLUtility.SaveDataTable(dt, "RecipeStepsUpdate");
        }

        public static void Delete(int recipeStepsId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStepsDelete");
            cmd.Parameters["@RecipeStepsId"].Value = recipeStepsId;
            SQLUtility.ExecuteSQL(cmd);
        }
    }
}
