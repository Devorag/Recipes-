
namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        BindingSource bindingSource = new BindingSource();
        DataTable dtRecipes = new DataTable();
        int recipeId = 0;
        string currentRecipe;
        string currentStatus;
        string newStatus;
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
                DataTable dtStatus = Recipes.GetRecipeList();
                if (dtStatus.Rows.Count > 0)
                {
                    DataRow row = dtStatus.Rows[0];
                    lblRecipe.Text = row["RecipeName"].ToString();
                    currentStatus = row["RecipeStatus"].ToString();
                    lblCurrentStatus.Text = "Current Status: " + currentStatus;
                    UpdateStatusDate(row);
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

                if (message.Contains("changed"))
                {
                    DataTable dtStatus = Recipes.RecipeStatusGet(recipeId);
                    if (dtStatus.Rows.Count > 0)
                    {
                        DataRow row = dtStatus.Rows[0];
                        currentStatus = newStatus;
                        lblCurrentStatus.Text = "Current Status: " + currentStatus;
                        UpdateStatusDate(row); 
                        DisableCurrentStatusButton();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing status: " + ex.Message);
            }
        }

        private bool IsBackwardStatusChange(string currentStatus, string newStatus)
        {
            return (currentStatus == "Archived" && newStatus == "Published") ||
                   (currentStatus == "Archived" && newStatus == "Drafted") ||
                   (currentStatus == "Published" && newStatus == "Drafted");
        }

        private string ConvertDateToString(object date)
        {
            return date == DBNull.Value ? string.Empty : Convert.ToDateTime(date).ToString("M/d/yyyy");
        }

        private void SetLabelText(Label label, string date, bool clearIfBackward)
        {
            if (clearIfBackward && string.IsNullOrEmpty(date))
            {
                label.Text = string.Empty;
            }
            else
            {
                label.Text = date;
            }
        }

        private void UpdateStatusDate(DataRow row)
        {
            string dateDrafted = ConvertDateToString(row["DateDrafted"]);
            string datePublished = ConvertDateToString(row["DatePublished"]);
            string dateArchived = ConvertDateToString(row["DateArchived"]);

            bool clearIfBackward = IsBackwardStatusChange(currentStatus, newStatus);

            SetLabelText(lblDateDrafted, dateDrafted, clearIfBackward);
            SetLabelText(lblDatePublished, datePublished, clearIfBackward);
            SetLabelText(lblDateArchived, dateArchived, clearIfBackward);
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
