
namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        BindingSource bindingSource = new BindingSource();
        DataTable dtRecipes = new DataTable();
        int recipeId = 0;
        string currentRecipe;
        string currentStatus;
        public frmChangeStatus()
        {
            InitializeComponent();
            this.recipeId = recipeId;
            btnDraft.Click += BtnDraft_Click;
            btnPublish.Click += BtnPublish_Click;
            btnArchive.Click += BtnArchive_Click;
        }

        public void LoadForm(int recipeIdVal)
        {
            this.recipeId = recipeIdVal;
            LoadRecipeForm(recipeIdVal);
            LoadCurrentStatus();
        }

        private void LoadCurrentStatus()
        {
            try
            {
                DataTable dtStatus = Recipes.RecipeStatusGet(recipeId);
                if (dtStatus.Rows.Count > 0)
                {
                    DataRow row = dtStatus.Rows[0];
                    lblRecipe.Text = row["RecipeName"].ToString();
                    currentStatus = row["RecipeStatus"].ToString();
                    lblCurrentStatus.Text = "Current Status: " + currentStatus;
                    UpdateStatusDate(currentStatus);
                    DisableCurrentStatusButton();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading recipe status: " + ex.Message);
            }
        }

        private void ChangeStatus(string newStatus)
        {
            try
            {
                string message = Recipes.ChangeRecipeStatus(recipeId, newStatus);
                MessageBox.Show(message);
                OpenRecipeForm();
                this.Close();

                if (message.Contains("changed"))
                {
                    currentStatus = newStatus;
                    lblCurrentStatus.Text = currentStatus;
                    UpdateStatusDate(newStatus);
                    DisableCurrentStatusButton();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing status: " + ex.Message);
            }
        }

        private void UpdateStatusDate(string status)
        {
            string dateFormatted = DateTime.Now.ToString("dd MMM, yyyy");

            switch (status)
            {
                case "Drafted":
                    lblDateDrafted.Text = dateFormatted;
                    break;
                case "Published":
                    lblDatePublished.Text = dateFormatted;
                    break;
                case "Archived":
                    lblDateArchived.Text = dateFormatted;
                    break;
            }
        }
        private void LoadRecipeForm(int recipeIdval)
        {
            recipeId = recipeIdval;
            this.Tag = recipeId;
            dtRecipes = Recipes.Load(recipeId);
            bindingSource.DataSource = dtRecipes;
            if (recipeId == 0)
            {
                dtRecipes.Rows.Add();
            }
            WindowsFormsUtility.SetControlBinding(lblDateDrafted, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDatePublished, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateArchived, bindingSource);
        }
        private void DisableCurrentStatusButton()
        {
            btnDraft.Enabled = currentStatus != "Drafted";
            btnPublish.Enabled = currentStatus != "Published";
            btnArchive.Enabled = currentStatus != "Archived";
        }

        private bool ConfirmStatusChange(string status)
        {
            return MessageBox.Show($"Are you sure you want to change this recipe to {status}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes;
        }

        private void OpenRecipeForm()
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmNewRecipe), recipeId);
            }
        }

        private void BtnArchive_Click(object? sender, EventArgs e)
        {
            if (currentStatus != "Archived" && ConfirmStatusChange("Archived"))
            {
                ChangeStatus("Archived");
            }
        }

        private void BtnPublish_Click(object? sender, EventArgs e)
        {
            if (currentStatus != "Published" && ConfirmStatusChange("Published"))
            {
                ChangeStatus("Published");
            }
        }

        private void BtnDraft_Click(object? sender, EventArgs e)
        {
            if (currentStatus != "Drafted" && ConfirmStatusChange("Drafted"))
            {
                ChangeStatus("Drafted");
            }
        }
    }
}
