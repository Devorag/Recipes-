using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeSystem
{
    public class bizUsers : bizObject<bizUsers>
    {
        private int _usersid;
        private string _firstname = "";
        private string _lastname = "";
        private string _usersname = "";

        public List<bizUsers> Search(string usersnameval)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand(this.GetSprocName);
            SQLUtility.SetParamValue(cmd, "UsersName", usersnameval);
            DataTable dt = SQLUtility.GetDataTable(cmd);
            return this.GetListFromDataTable(dt);
        }

        public int UsersId
        {
            get { return _usersid; }
            set
            {
                if (_usersid != value)
                {
                    _usersid = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string FirstName
        {
            get { return _firstname; }
            set
            {
                if (_firstname != value)
                {
                    _firstname = value;
                    InvokePropertyChanged();
                }
            }
        }

        public string LastName
        {
            get { return _lastname; }
            set
            {
                if (_lastname != value)
                {
                    _lastname = value;
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

    }
}
