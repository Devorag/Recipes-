namespace RecipeSystem
{
    public class bizCookbook :  bizObject<bizCookbook>
    {   
        public bizCookbook()
        {

        }

        private int _cookbookid;
        private string _cookbookname = "";
        private string _author = "";
        private int? _numrecipes;
        private decimal? _price;
        private string _skillleveldescription = "";

        public List<bizCookbook> Search(string cookbookname)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CookbookName", cookbookname);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int cookbookId
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
        public int? numRecipes
        {
            get { return _numrecipes; }
            set
            {
                if (_numrecipes != value)
                {
                    _numrecipes = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string cookbookname
        {
            get { return _cookbookname; }
            set
            {
                if (_cookbookname != value)
                {
                    _cookbookname = value;
                    InvokePropertyChanged();
                }
            }
        }
        public decimal? price
        {
            get { return _price; }
            set
            {
                if (_price != value)
                {
                    _price = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                if (_author != value)
                {
                    _author = value;
                    InvokePropertyChanged();
                }
            }
        }
        public string skillLevelDescription
        {
            get { return _skillleveldescription; }
            set
            {
                if (_skillleveldescription != value)
                {
                    _skillleveldescription = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
