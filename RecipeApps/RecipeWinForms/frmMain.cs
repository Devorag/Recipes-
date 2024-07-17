namespace RecipeWinForms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            menuListRecipes.Click += MenuListRecipes_Click;
            menuListMeals.Click += MenuListMeals_Click;
            menuListCookbooks.Click += MenuListCookbooks_Click;
            menuNewCookbook.Click += MenuNewCookbook_Click;
            menuNewRecipe.Click += MenuNewRecipe_Click;
            menuDashboard.Click += MenuDashboard_Click;
            menuWindowsTile.Click += MenuWindowsTile_Click;
            menuWindowsCascade.Click += MenuWindowsCascade_Click;
            menuEditData.Click += MenuEditData_Click;
            menuCloneRecipe.Click += MenuCloneRecipe_Click;
            menuAutoCreate.Click += MenuAutoCreate_Click;
            this.Shown += FrmMain_Shown;
        }

        private void MenuNewCookbook_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmNewCookbook));
        }

        private void MenuAutoCreate_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCreateCookbook));      
        }

        private void MenuCloneRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCloneRecipe));
        }

        private void MenuEditData_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDataMaintenance));
        }

        private void FrmMain_Shown(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }

        public void OpenForm(Type frmType, int pkValue = 0)
        {
            bool b = WindowsFormsUtility.IsFormOpen(frmType);

            if(b == false)
            {
                Form? newFrm = new();
                if(frmType == typeof(frmNewRecipe))
                {
                    frmNewRecipe f = new();
                    newFrm = f;
                    f.LoadForm(pkValue);
                }
                else if(frmType == typeof(frmRecipeList))
                {
                    frmRecipeList f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmDataMaintenance))
                {
                    frmDataMaintenance f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmDashboard))
                {
                    frmDashboard f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmCookbookList))
                {
                    frmCookbookList f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmMealList))
                {
                    frmMealList f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmCloneRecipe))
                {
                    frmCloneRecipe f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmCreateCookbook))
                {
                    frmCreateCookbook f = new();
                    newFrm = f;
                }
                else if(frmType == typeof(frmNewCookbook))
                {
                    frmNewCookbook f = new();
                    newFrm = f;
                }
                if(newFrm != null)
                {
                    newFrm.MdiParent = this;
                    newFrm.WindowState = FormWindowState.Maximized;
                    newFrm.FormClosed += NewFrm_FormClosed;
                    newFrm.TextChanged += NewFrm_TextChanged;
                    newFrm.Show();
                }
                WindowsFormsUtility.SetupNav(tsMain);
            }
        }

        private void NewFrm_TextChanged(object? sender, EventArgs e)
        {
            WindowsFormsUtility.SetupNav(tsMain);
        }

        private void NewFrm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            WindowsFormsUtility.SetupNav(tsMain);
        }

        private void MenuWindowsCascade_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void MenuWindowsTile_Click(object? sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void MenuNewRecipe_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmNewRecipe));
        }

        private void MenuListCookbooks_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }

        private void MenuListMeals_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }

        private void MenuListRecipes_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }

        private void MenuDashboard_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmDashboard));
        }
    }
}
