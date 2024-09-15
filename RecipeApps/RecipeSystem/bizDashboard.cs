namespace RecipeSystem
{
    public class bizDashboard : bizObject<bizDashboard>
    {
        private string _type = "";
        private int? _number;

        public string Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? Number
        {
            get { return _number; }
            set
            {
                if (_number != value)
                {
                    _number = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
