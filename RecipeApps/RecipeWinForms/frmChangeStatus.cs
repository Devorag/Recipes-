using CPUFramework;
using System.Linq.Expressions;

namespace RecipeWinForms
{
    public partial class frmChangeStatus : Form
    {
        BindingSource bindingSource = new BindingSource();
        DataTable dtRecipes = new DataTable();
        int recipeId = 0;
        private string currentRecipe;
        private string currentStatus;

        public frmChangeStatus()
        {
            InitializeComponent();
            this.recipeId = recipeId;
            btnDraft.Click += BtnDraft_Click;
            btnPublish.Click += BtnPublish_Click;
            btnArchive.Click += BtnArchive_Click;
        }

        private DataTable RecipeStatusGet(int recipeId = 0, string recipeName = null, bool all = false)
        {
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeStatusGet");

            SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
            SQLUtility.SetParamValue(cmd, "@RecipeName", recipeName);
            SQLUtility.SetParamValue(cmd, "@All", 1);
            return SQLUtility.GetDataTable(cmd);
        }

        private void LoadCurrentStatus()
        {
            try
            {
                DataTable dtStatus = RecipeStatusGet(recipeId);
                if (dtStatus.Rows.Count > 0)
                {
                    DataRow row = dtStatus.Rows[0];
                    lblRecipe.Text = row["RecipeName"].ToString();
                    currentStatus = "Current Status: " + row["RecipeStatus"].ToString();
                    lblCurrentStatus.Text = currentStatus;
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
                using (SqlCommand cmd = SQLUtility.GetSQLCommand("dbo.ChangeRecipeStatus"))
                {
                    SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
                    SQLUtility.SetParamValue(cmd, "@NewStatus", newStatus);
                    SQLUtility.SetParamValue(cmd, "@Message", DBNull.Value); // Output parameter

                    SQLUtility.ExecuteSQL(cmd);
                    string message = Convert.ToString(cmd.Parameters["@Message"].Value);

                    MessageBox.Show(message);

                    if (message.Contains("changed"))
                    {
                        currentStatus = newStatus;
                        lblCurrentStatus.Text = currentStatus;
                        UpdateStatusDate(newStatus);
                        DisableCurrentStatusButton();
                    }
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


        public void LoadForm(int recipeIdVal)
        {
            LoadRecipeForm(recipeIdVal);
            LoadCurrentStatus();
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
            WindowsFormsUtility.SetControlBinding(lblRecipe, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblCurrentStatus, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateDrafted, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDatePublished, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateArchived, bindingSource);
        }

        private void DisableCurrentStatusButton()
        {
            btnDraft.Enabled = lblCurrentStatus.Text != "Drafted";
            btnPublish.Enabled = lblCurrentStatus.Text != "Published";
            btnArchive.Enabled = lblCurrentStatus.Text != "Archived";
        }

        private bool ConfirmStatusChange(string status)
        {
            return MessageBox.Show($"Are you sure you want to change this recipe to {status}?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes;
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
