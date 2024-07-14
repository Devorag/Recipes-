namespace RecipeWinForms
{
    public partial class frmMealList : Form
    {
        public frmMealList()
        {
            InitializeComponent();
            this.Activated += FrmMealList_Activated;
            BindData();

        }

        private void FrmMealList_Activated(object? sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            gMeals.DataSource = Meals.GetMealList();
            WindowsFormsUtility.FormatGridForSearchResults(gMeals, "Meal");
        }
    }
}
