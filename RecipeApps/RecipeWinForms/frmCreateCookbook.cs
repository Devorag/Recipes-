using CPUFramework;
using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCreateCookbook : Form
    {
        public frmCreateCookbook()
        {
            InitializeComponent();
            LoadForm();
            btnCreate.Click += BtnCreate_Click;
        }

        public void LoadForm()
        {
            DataTable dtUsersName = Recipes.GetUsersList();

            lstUsersName.DataSource = dtUsersName;
            lstUsersName.ValueMember = "UsersId";
            lstUsersName.DisplayMember = "UsersName";
        }
        private void BtnCreate_Click(object? sender, EventArgs e)
        {

        }
    }
}
