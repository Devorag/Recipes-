
namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipes = new DataTable();
        public frmRecipe()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
        }

        public void ShowForm(int recipeid)
        {
            dtRecipes = Recipes.Load(recipeid);
            if (recipeid == 0)
            {
                DataRow newRow = dtRecipes.NewRow();
                newRow["DateDrafted"] = DateTime.Now;
                dtRecipes.Rows.Add(newRow);
            }
            DataTable dtCuisine = Recipes.GetCuisineList();
            //WindowsFormsUtility.SetListBinding(lstCuisine, dtCuisine, dtRecipes, "CuisineType");
            lstCuisine.DataSource = dtCuisine;
            lstCuisine.ValueMember = "CuisineId";
            lstCuisine.DisplayMember = "CuisineType";
            lstCuisine.DataBindings.Add("SelectedValue", dtRecipes, "CuisineId");

            DataTable dtUsers = Recipes.GetUsersList();
            //WindowsFormsUtility.SetListBinding(lstUserName, dtUsers, dtRecipes, "Users");
            lstUserName.DataSource = dtUsers;
            lstUserName.ValueMember = "UsersId";
            lstUserName.DisplayMember = "UserName";
            lstUserName.DataBindings.Add("SelectedValue", dtRecipes, "UsersId");

            WindowsFormsUtility.SetControlBinding(txtRecipeName, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtCalories, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDateDrafted, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDatePublished, dtRecipes);
            WindowsFormsUtility.SetControlBinding(txtDateArchived, dtRecipes);

            this.Show();
        }

        private void Save()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipes.Save(dtRecipes);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Recipes");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void Delete()
        {
            Application.UseWaitCursor = true;
            try
            {
                Recipes.Delete(dtRecipes);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipes");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }


    }
}
