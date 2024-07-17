using CPUFramework;

namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        BindingSource bindingSource = new BindingSource();
        DataTable dtRecipes = new DataTable();
        int recipeId = 0;
        private string currentRecipe;
        public enum RecipeStatus { Drafted, Published, Archived};
        
        public frmChangeStatus()
        {
            InitializeComponent();
            this.Activated += FrmChangeStatus_Activated;
            this.recipeId = recipeId;
            btnDraft.Click += BtnDraft_Click;
            btnPublish.Click += BtnPublish_Click;
            btnArchive.Click += BtnArchive_Click;
        }

        private void FrmChangeStatus_Activated(object? sender, EventArgs e)
        {
            LoadRecipeData(recipeId);
        }

        private DataTable RecipeStatusGet(int recipeId = 0, string recipeName = null, bool all = false)
        {
            using (SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStatusGet"))
            {
                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
                SQLUtility.SetParamValue(cmd, "@RecipeName", recipeName);
                SQLUtility.SetParamValue(cmd, "@All", all ? 1 : 0);
                return SQLUtility.GetDataTable(cmd);
            }
        }

        private void LoadCurrentStatus()
        {
            DataTable dtStatus = RecipeStatusGet(recipeId);
            if (dtStatus.Rows.Count > 0)
            {
                DataRow row = dtStatus.Rows[0];
                lblRecipe.Text = row["RecipeName"].ToString();
                lblCurrentStatus.Text = row["RecipeStatus"].ToString();
            }
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {

        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {

        }

        private void BtnDraft_Click(object? sender, EventArgs e)
        {

        }

        private void LoadRecipeData(int recipeIdval)
        {
            
            BindFormData();
        }

        private void BindFormData()
        {
            dtRecipes = Recipes.Load(recipeId);
            bindingSource.DataSource = dtRecipes;
            if (dtRecipes.Rows.Count > 0)
            {
                WindowsFormsUtility.SetControlBinding(lblRecipe, bindingSource);
                WindowsFormsUtility.SetControlBinding(lblCurrentStatus, bindingSource);
                WindowsFormsUtility.SetControlBinding(lblDateDrafted, bindingSource);
                WindowsFormsUtility.SetControlBinding(lblDatePublished, bindingSource);
                WindowsFormsUtility.SetControlBinding(lblDateArchived, bindingSource);
            }
        }

        private void PromptAndChangeStatus(RecipeStatus newStatus)
        {
            string statusName = Enum.GetName(typeof(RecipeStatus), newStatus);
            var result = MessageBox.Show($"Are you sure you want to change this recipe to {statusName}?", "Change Recipe Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                ChangeRecipeStatus(newStatus);
            }
        }

        private void ChangeRecipeStatus(RecipeStatus newStatus)
        {
            if(dtRecipes.Rows.Count > 0)
            {
                DataRow row = dtRecipes.Rows[0];
                row["RecipeStatus"] = (int)newStatus;

                try
                {
                    Recipes.UpdateRecipeStatus(recipeId, (int)newStatus);
                    BindFormData();
                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show($"Failed to update recipe status: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
