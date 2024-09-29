namespace RecipeSystem
{
    public class bizMeal : bizObject<bizMeal>
    {   
        public bizMeal()
        {

        }

        private int _mealid;
        private string _mealname = "";
        private string _usersname = "";
        private int? _numcalories;
        private int? _numcourses;
        private int? _numrecipes;
        private string _mealdescription = "";
 

        public int mealId
        {
            get { return _mealid;  } 
            set
            {
                if( _mealid != value)
                {
                    _mealid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? NumCalories
        {
            get { return _numcalories; }
            set
            {
                if (_numcalories != value)
                {
                    _numcalories = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? NumCourses
        {
            get { return _numcourses; }
            set
            {
                if (_numcourses != value)
                {
                    _numcourses = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int? NumRecipes
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

        public string MealName
        {
            get { return _mealname; }
            set
            {
                if (_mealname != value)
                {
                    _mealname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string UsersName
        {
            get { return _usersname; }
            set
            {
                if (_usersname != value)
                {
                    _usersname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string MealDescription
        {
            get { return _mealdescription; } 
            set
            {
                if (_mealdescription != value)
                {
                    _mealdescription = value;
                    InvokePropertyChanged();
                }
            }
        }
    }

}

