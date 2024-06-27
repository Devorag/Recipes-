
namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipes = new DataTable();
        public frmRecipe()
        {
            InitializeComponent();
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

            this.FormClosing += new FormClosingEventHandler(frmRecipe_FormClosing);
            this.btnSave.Click += new EventHandler(btnSave_Click);

            this.Show();
        }

        private void frmRecipe_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dtRecipes.Rows.Count > 0)
            {
                DataRow currentRow = dtRecipes.Rows[0];
                SetDateField(currentRow, "DatePublished", txtDatePublished.Text);
                SetDateField(currentRow, "DateArchived", txtDateArchived.Text);
            }
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

        private void SetDateField(DataRow row, string columnName, string textBoxValue)
        {
            if (string.IsNullOrWhiteSpace(textBoxValue))
            {
                row[columnName] = DBNull.Value;
            }
            else
            {
                DateTime dateValue;
                if (DateTime.TryParse(textBoxValue, out dateValue))
                {
                    if (dateValue == DateTime.MinValue)
                    {
                        row[columnName] = DBNull.Value;
                    }
                    else
                    {
                        row[columnName] = dateValue;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid date format.", "Validation Error");
                }
            }
        }


        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }

        private void btnSave_Click(object? sender, EventArgs e)
        {
            if (dtRecipes.Rows.Count > 0)
            {
                DataRow currentRow = dtRecipes.Rows[0];
                SetDateField(currentRow, "DatePublished", txtDatePublished.Text);
                SetDateField(currentRow, "DateArchived", txtDateArchived.Text);
            }
            if (ValidateFields())
            {
                Save();
            }
        }

        private bool ValidateFields()
        {
            if (lstCuisine.SelectedValue == null || lstUserName.SelectedValue == null)
            {
                MessageBox.Show("Cuisine and User cannot be blank.", "Validation error");
                return false;
            }
            return true;
        }

    }
}
