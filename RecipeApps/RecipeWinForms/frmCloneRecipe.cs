using CPUFramework;
using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmCloneRecipe : Form
    {
        int newRecipeId; 

        public frmCloneRecipe()
        {
            InitializeComponent();
            LoadForm();
            btnClone.Click += btnClone_Click;
        }
        public void LoadForm()
        {
            DataTable dtRecipeName = Recipes.GetRecipeList();

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
                SQLUtility.SetParamValue(cmd, "@NewRecipeId", DBNull.Value); 
                SQLUtility.SetParamValue(cmd, "@Message", DBNull.Value);
                SQLUtility.ExecuteSQL(cmd);

                newRecipeId = (int)(cmd.Parameters["@NewRecipeId"].Value);
                string message = (cmd.Parameters["@Message"].Value).ToString();

                if (newRecipeId > 0)
                {
                    OpenRecipeForm(newRecipeId);
                    this.Close();
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

        private void OpenRecipeForm(int newRecipeId)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmNewRecipe), newRecipeId);
            }
            this.Close();
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
