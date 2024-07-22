using CPUFramework;

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        public frmCloneRecipe()
        {
            InitializeComponent();
            LoadForm();
            btnClone.Click += btnClone_Click;
        }

        public void LoadForm()
        {
            DataTable dtRecipeName = GetRecipeList();

            lstRecipe.DataSource = dtRecipeName;
            lstRecipe.ValueMember = "RecipeId";
            lstRecipe.DisplayMember = "RecipeName";
        }
        private void CloneRecipe(int recipeId)
        {
            try
            {
                SqlCommand cmd = SQLUtility.GetSQLCommand("CloneRecipe");

                SQLUtility.SetParamValue(cmd, "@RecipeId", recipeId);
                SQLUtility.SetParamValue(cmd, "@NewRecipeId", DBNull.Value); // Output parameter
                SQLUtility.SetParamValue(cmd, "@Message", DBNull.Value); // Output parameter

                // Execute the stored procedure
                SQLUtility.ExecuteSQL(cmd);

                // Retrieve output parameter values
                int newRecipeId = Convert.ToInt32(cmd.Parameters["@NewRecipeId"].Value);
                string message = Convert.ToString(cmd.Parameters["@Message"].Value);

                if (newRecipeId > 0)
                {
                    MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    OpenRecipeList(newRecipeId);
                }
                else
                {
                    MessageBox.Show("Failed to clone the recipe. " + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DataTable GetRecipeList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("RecipeGet");
            SQLUtility.SetParamValue(cmd, "@All", 1);
            SQLUtility.SetParamValue(cmd, "@IncludeBlank", 1);
            dt = SQLUtility.GetDataTable(cmd);
            return dt;

        }


        private void OpenRecipeList(int recipeId)
        {
            OpenForm(typeof(frmRecipeList));
        }

        private void OpenForm(Type frmType)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmType);
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            if (lstRecipe.SelectedValue != null && int.TryParse(lstRecipe.SelectedValue.ToString(), out int recipeId))
            {
                CloneRecipe(recipeId);
            }
            else
            {
                MessageBox.Show("Please select a valid recipe to clone.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
