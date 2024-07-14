
using CPUFramework;
using System.Diagnostics.Tracing;

namespace RecipeWinForms
{
    public partial class frmNewRecipe : Form
    {
        DataTable dtRecipes = new DataTable();
        BindingSource bindingSource = new BindingSource();
        int recipeId = 0;
        public frmNewRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += new EventHandler(btnSave_Click);
            lstCuisine.SelectedIndexChanged += LstCuisine_SelectedIndexChanged;
            lstUserName.SelectedIndexChanged += LstUserName_SelectedIndexChanged;
            this.FormClosing += frmNewRecipe_FormClosing;
        }

        private void frmNewRecipe_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindingSource.EndEdit();
            if (SQLUtility.TableHasChanges(dtRecipes))
            {
                var res = MessageBox.Show($"Do you want to save changes to {this.Text} before closing the form?", Application.ProductName, MessageBoxButtons.YesNoCancel);
                switch (res)
                {
                    case DialogResult.Yes:
                        bool b = Save();
                        if (b == false)
                        {
                            e.Cancel = true;
                            this.Activate();
                        }
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        this.Activate();
                        break;
                }
            }
            if (dtRecipes.Rows.Count > 0)
            {
                DataRow currentRow = dtRecipes.Rows[0];
                SetDateField(currentRow, "DatePublished", txtPublished.Text);
                SetDateField(currentRow, "DateArchived", txtArchived.Text);
            }
        }

        private void LstUserName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearUserError();
        }

        private void LstCuisine_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearCuisineError();
        }

        public void LoadForm(int recipeidval)
        {
            recipeId = recipeidval;
            this.Tag = recipeId;
            dtRecipes = Recipes.Load(recipeId);
            bindingSource.DataSource = dtRecipes;
            if (recipeId == 0)
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

            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtDrafted, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtPublished, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtArchived, bindingSource);

            //this.FormClosing += new FormClosingEventHandler(frmNewRecipe_FormClosing);
            this.Show();
        }


        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                ValidateForm();
                Recipes.Save(dtRecipes);
                b = true;
                bindingSource.ResetBindings(false);
                recipeId = SQLUtility.GetValueFromFirstRowAsInt(dtRecipes, "RecipeId");
                this.Tag = recipeId;
                SetButtonsEnabledBasedOnNewRecord();
                this.Text = GetRecipeDesc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Recipes");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void Delete()
        {
            string allowedDelete = SQLUtility.GetValueFromFirstRowAsString(dtRecipes, "IsDeleteAllowed");
            if (allowedDelete != "")
            {
                MessageBox.Show(allowedDelete, Application.ProductName);
                return;
            }

            var response = MessageBox.Show("Are you sure you want to delete this recipe?", "Recipes", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipes.Delete(dtRecipes, "Can't delete recipe with current date drafted or that has not been archived in over 30 days");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
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

        private void ClearCuisineError()
        {
            DataRow row = dtRecipes.Rows[0];
            bool isCuisineSelected = row["CuisineId"] != DBNull.Value;

            if (isCuisineSelected)
            {
                errorProvider.SetError(lstCuisine, string.Empty);
            }
        }

        private void ClearUserError()
        {
            DataRow row = dtRecipes.Rows[0];
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (isUserSelected)
            {
                errorProvider.SetError(lstUserName, string.Empty);
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
                this.BindingContext[dtRecipes].EndCurrentEdit();

                DataRow currentRow = dtRecipes.Rows[0];

                currentRow["CuisineId"] = lstCuisine.SelectedValue ?? DBNull.Value;
                currentRow["UsersId"] = lstUserName.SelectedValue ?? DBNull.Value;

                lstCuisine.BindingContext[dtRecipes].EndCurrentEdit();
                lstUserName.BindingContext[dtRecipes].EndCurrentEdit();

                SetDateField(currentRow, "DatePublished", txtPublished.Text);
                SetDateField(currentRow, "DateArchived", txtArchived.Text);

                try
                {
                    ValidateForm();
                    Save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validation Error");
                }
            }
        }

        private void ValidateForm()
        {
            DataRow row = dtRecipes.Rows[0];

            errorProvider.SetError(lstCuisine, string.Empty);
            errorProvider.SetError(lstUserName, string.Empty);

            bool isCuisineSelelected = row["CuisineId"] != DBNull.Value;
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (!isCuisineSelelected)
            {
                errorProvider.SetError(lstCuisine, "Please selece a cuisine.");
                throw new Exception("Please select a cuisine.");
            }

            if (!isUserSelected)
            {
                errorProvider.SetError(lstUserName, "Please select a user.");
                throw new Exception("Please select a user.");
            }

            DateTime dateDrafted = Convert.ToDateTime(row["DateDrafted"]);
            DateTime currentDate = DateTime.Now;

            if (dateDrafted.Date > currentDate.Date)
            {
                throw new Exception("Date Drafted cannot be future date");
            }
            else if (dateDrafted.Date == currentDate.Date && dateDrafted.TimeOfDay > currentDate.TimeOfDay)
            {
                throw new Exception("Date Drafted cannot be a future time");
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = recipeId == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSave.Enabled = b;
        }

        private string GetRecipeDesc()
        {
            string value = "New Recipe";
            int pkValue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipes, "RecipeId");
            if (pkValue > 0)
            {
                value = SQLUtility.GetValueFromFirstRowAsString(dtRecipes, "RecipeName");
            }
            return value;
        }
    }
}
