using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizRecipe : bizObject<bizRecipe>
    {
        public bizRecipe() 
        {

        }

        private int _recipeId;
        private int _cuisineId;
        private int _usersId;
        private string _recipename = "";
        private int? _calories;
        private string _recipestatus = "";
        private DateTime? _datedrafted;
        private DateTime? _datepublished;
        private DateTime? _datearchived;
        private List<bizCuisine> _lstcuisine;
        private List<bizUsers> _lstusers;
        private List<bizRecipeIngredient> _lstrecipeingredient;
        private List<bizRecipeSteps> _lstrecipesteps;
        public List<bizRecipe> Search(string recipename)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "RecipeName", recipename);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }
        public List<bizCuisine> CuisineList
        {
            get
            {
                if (_lstcuisine == null)
                {
                    _lstcuisine = new bizCuisine().GetList(true);
                }
                return _lstcuisine;
            }
        }
        public List<bizUsers> UsersList
        {
            get
            {
                if (_lstusers == null)
                {
                    _lstusers = new bizUsers().GetList(true);
                }
                return _lstusers;
            }
        }
        public bizCuisine? Cuisine
        {
            get => _lstcuisine?.FirstOrDefault(c => c.CuisineId == this.CuisineId);
            set {
                this.CuisineId = value == null ? 0 : value.CuisineId;
                InvokePropertyChanged();
            }
        }
        public bizUsers? Users
        {
            get => _lstusers?.FirstOrDefault(u => u.UsersId == this.UsersId);
            set {
                this.UsersId = value == null ? 0 : value.UsersId;
                InvokePropertyChanged();
            }
        }
        public List<bizRecipeIngredient> RecipeIngredientList
        {
            get {
                if(_lstrecipeingredient == null)
                {
                    _lstrecipeingredient = new bizRecipeIngredient().LoadByRecipeId(this.RecipeId);
                }
                return _lstrecipeingredient;
            }
        }
        public List<bizRecipeSteps> RecipeStepsList
        {
            get
            {
                if (_lstrecipesteps == null)
                {
                    _lstrecipesteps = new bizRecipeSteps().LoadByRecipeId(this.RecipeId);
                }
                return _lstrecipesteps;
            }
        }

        public int RecipeId
        {
            get { return _recipeId; }
            set
            {
                if (_recipeId != value)
                {
                    _recipeId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int CuisineId
        {
            get { return _cuisineId; }
            set
            {
                if (_cuisineId != value)
                {
                    _cuisineId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public int UsersId
        {
            get { return _usersId; }
            set
            {
                if (_usersId != value)
                {
                    _usersId = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string RecipeName
        {
            get { return _recipename; }
            set
            {
                if (_recipename != value)
                {
                    _recipename = value;
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

        public string RecipeStatus
        {
            get { return _recipestatus; }
            set
            {
                if (_recipestatus != value)
                {
                    _recipestatus= value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DateDrafted
        {
            get { return _datedrafted; }
            set
            {
                if (_datedrafted != value)
                {
                    _datedrafted = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DatePublished
        {
            get { return _datepublished; }
            set
            {
                if (_datepublished != value)
                {
                    _datepublished = value;
                    InvokePropertyChanged();
                }
            }
        }

        public DateTime? DateArchived
        {
            get { return _datearchived; }
            set
            {
                if (_datearchived != value)
                {
                    _datearchived = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
