using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizCuisine : bizObject<bizCuisine>
    {
        private int _cuisineid;
        private string _cuisinename = "";

        public List<bizCuisine> Search(string cuisinenameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "CuisineName", cuisinenameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int CuisineId
        {
            get { return _cuisineid; }
            set
            {
                if (_cuisineid != value)
                {
                    _cuisineid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string CuisineName
        {
            get { return _cuisinename; }
            set
            {
                if (_cuisinename != value)
                {
                    _cuisinename = value;
                    InvokePropertyChanged();
                }
            }
        }

    }
}
