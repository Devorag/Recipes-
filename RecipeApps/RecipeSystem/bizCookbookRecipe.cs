namespace RecipeSystem
{
    public class bizCookbookRecipe : bizObject<bizCookbookRecipe>
    {
        public bizCookbookRecipe()
        {

        }

        private int _cookbookrecipeid;
        private int _cookbookid;
        private int _recipeid;
        private int? _recipesequence;
        private string _recipeName = "";
        private int? _calories;

        public List<bizCookbookRecipe> LoadByCookbookId(int cookbookId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("CookbookRecipeGet");
            cmd.Parameters["@CookbookId"].Value = cookbookId;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public List<bizCookbookRecipe> Search(string cookbookname)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CookbookName", cookbookname);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int CookbookRecipeId
        {
            get { return _cookbookrecipeid; }
            set
            {
                if (_cookbookrecipeid != value)
                {
                    _cookbookrecipeid = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int CookbookId
        {
            get { return _cookbookid; }
            set
            {
                if (_cookbookid != value)
                {
                    _cookbookid = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int RecipeId
        {
            get { return _recipeid; }
            set
            {
                if (_recipeid != value)
                {
                    _recipeid = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int? RecipeSequence
        {
            get { return _recipesequence; }
            set
            {
                if (_recipesequence != value)
                {
                    _recipesequence = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string RecipeName
        {
            get { return _recipeName; }
            set
            {
                if (_recipeName != value)
                {
                    _recipeName = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? Calories
        {
            get { return _calories; }
            set
            {
                if (_calories != value)
                {
                    _calories = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}

