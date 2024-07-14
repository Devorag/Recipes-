namespace RecipeSystem
{
    public static  class DataMaintenance
    {
        public static DataTable GetDataList(string tableName,bool includeBlank = false)
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand(tableName + "Get");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            if(includeBlank == true)
            {
                SQLUtility.SetParamValue(cmd, "@IncludeBlank", includeBlank);
            }
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        public static void SaveDataList(DataTable dt, string tableName)
        {
            SQLUtility.SaveDataTable(dt, tableName + "Update");
        }

        public static void DeleteRow(string tableName, int id)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(tableName + "Delete");
            SQLUtility.SetParamValue(cmd, $"@{tableName}Id", id);
            SQLUtility.ExecuteSQL(cmd);
        }

    }
}
