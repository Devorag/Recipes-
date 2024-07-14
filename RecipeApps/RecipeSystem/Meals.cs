namespace RecipeSystem
{
    public class Meals
    {
        public static DataTable GetMealList()
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("MealGet");
            return SQLUtility.GetDataTable(cmd);
        }
    }
}
