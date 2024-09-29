using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizRecipeSteps : bizObject<bizRecipeSteps>
    {
        private int _recipestepsid;
        private int _recipeid;
        private string _instructions = "";

        public List<bizRecipeSteps> LoadByRecipeId(int recipeId)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStepsGet");
            cmd.Parameters["@RecipeId"].Value = recipeId;
            var dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int RecipeStepsId
        {
            get { return _recipestepsid; }
            set
            {
                if (_recipestepsid != value)
                {
                    _recipestepsid = value;
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

        public string Instructions
        {
            get { return _instructions; }
            set
            {
                if (_instructions != value)
                {
                    _instructions = value;
                    InvokePropertyChanged();
                }
            }
        }
    }
}
