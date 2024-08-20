namespace RecipeSystem
{
    public class bizRecipeIngredient : bizObject<bizRecipeIngredient>
    {
        private int _recipeingredientid;
        private int _recipeid;
        private int _ingredientid;
        private int _unitofmeasureid;
        private int? _measurementamount;
        private int? _ingredientsequence;
        private string _ingredientname = "";

        public List<bizRecipeIngredient> LoadByRecipeId(int recipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeIngredientGet");
            cmd.Parameters["@RecipeId"].Value = recipeId;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int RecipeIngredientId
        {
            get { return _recipeingredientid; }
            set
            {
                if (_recipeingredientid != value)
                {
                    _recipeingredientid = value;
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
        public int IngredientId
        {
            get { return _ingredientid; }
            set
            {
                if (_ingredientid != value)
                {
                    _ingredientid = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int UnitOfMeasureId
        {
            get { return _unitofmeasureid; }
            set
            {
                if (_unitofmeasureid != value)
                {
                    _unitofmeasureid = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int? MeasurementAmount
        {
            get { return _measurementamount; }
            set
            {
                if (_measurementamount != value)
                {
                    _measurementamount = value;
                    InvokePropertyChanged();
                }
            }
        }
        public int? IngredientSequence
        {
            get { return _ingredientsequence; }
            set
            {
                if (_ingredientsequence != value)
                {
                    _ingredientsequence = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string IngredientName
        {
            get { return _ingredientname; }
            set
            {
                if (_ingredientname != value)
                {
                    _ingredientname = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
