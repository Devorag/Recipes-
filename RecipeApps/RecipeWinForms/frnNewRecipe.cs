using System.Diagnostics;

namespace RecipeWinForms
{
    public partial class frmNewRecipe : Form
    {
        DataTable dtRecipes = new DataTable();
        DataTable dtRecipeIngredient = new DataTable();
        DataTable dtRecipeSteps = new DataTable();
        BindingSource bindingSource = new BindingSource();
        string deleteColName = "deletecol";
        int recipeId = 0;

        public frmNewRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += new EventHandler(btnSave_Click);
            btnChangeStatus.Click += BtnChangeStatus_Click;
            lstCuisineName.SelectedIndexChanged += LstCuisine_SelectedIndexChanged;
            lstUsersName.SelectedIndexChanged += LstUserName_SelectedIndexChanged;
            btnSaveIngredient.Click += BtnSaveIngredient_Click;
            btnSaveStep.Click += BtnSaveStep_Click;
            gSteps.CellContentClick += GSteps_CellContentClick;
            gIngredient.CellContentClick += GIngredient_CellContentClick;
            this.FormClosing += frmNewRecipe_FormClosing;
            tbChildRecords.SelectedIndexChanged += TbChildRecords_SelectedIndexChanged;
            this.Shown += FrmNewRecipe_Shown;
        }

        private void FrmNewRecipe_Shown(object? sender, EventArgs e)
        {
            LoadRecipeIngredients();
            LoadRecipeSteps();
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
                newRow["DateDrafted"] = DateTime.Now.ToString("dd MMM, yyyy");
                newRow["RecipeStatus"] = "Drafted";
                dtRecipes.Rows.Add(newRow);
                
            }
            DataTable dtCuisine = Recipes.GetCuisineList();
            WindowsFormsUtility.SetListBinding(lstCuisineName, dtCuisine, dtRecipes, "Cuisine");

            DataTable dtUsers = Recipes.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsersName, dtUsers, dtRecipes, "Users");


            WindowsFormsUtility.SetControlBinding(txtRecipeName, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtCalories, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblRecipeStatus, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateDrafted, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDatePublished, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateArchived, bindingSource);

            this.Text = GetRecipeDesc();

            SetButtonsEnabledBasedOnNewRecord();
            LoadRecipeIngredients();

            dtRecipes.AcceptChanges();
        }

        private void LoadRecipeIngredients()
        {
            dtRecipeIngredient = RecipeIngredient.LoadByRecipeId(recipeId);
            gIngredient.Columns.Clear();

            WindowsFormsUtility.AddComboBoxToGrid(gIngredient, DataMaintenance.GetDataList("Measurement"), "UnitOfMeasure", "MeasurementType");
            WindowsFormsUtility.AddComboBoxToGrid(gIngredient, DataMaintenance.GetDataList("Ingredient"), "Ingredient", "IngredientName");

            gIngredient.DataSource = dtRecipeIngredient;
            WindowsFormsUtility.AddDeleteButtonToGrid(gIngredient, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gIngredient, "RecipeIngredient");
        }


        private void LoadRecipeSteps()
        {
            dtRecipeSteps = RecipeSteps.LoadByRecipeId(recipeId);
            gSteps.Columns.Clear();
            gSteps.DataSource = dtRecipeSteps;
            WindowsFormsUtility.AddComboBoxToGrid(gSteps, DataMaintenance.GetDataList("Steps"), "RecipeSteps", "Instructions");
            WindowsFormsUtility.AddDeleteButtonToGrid(gSteps, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gSteps, "RecipeSteps");
        }

        private void SaveRecipeIngredient()
        {
            try
            {
                RecipeIngredient.SaveDataTable(dtRecipeIngredient, recipeId);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void SaveRecipeSteps()
        {
            try
            {
                RecipeSteps.SaveDataTable(dtRecipeSteps, recipeId);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void DeleteRecipeIngredient(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gIngredient, rowIndex, "RecipeIngredientId");
            if (id > 0)
            {
                try
                {
                    RecipeIngredient.Delete(id);
                    LoadRecipeIngredients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gSteps.Rows.Count)
            {
                gSteps.Rows.RemoveAt(rowIndex);
            }
        }

        private void DeleteRecipeSteps(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gSteps, rowIndex, "RecipeStepsId");
            if(id > 0)
            {
                try
                {
                    RecipeSteps.Delete(id);
                    LoadRecipeSteps();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if(id < gSteps.Rows.Count)
            {
                gSteps.Rows.RemoveAt(rowIndex);
            }
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

        private void ClearCuisineError()
        {
            DataRow row = dtRecipes.Rows[0];
            bool isCuisineSelected = row["CuisineId"] != DBNull.Value;

            if (isCuisineSelected)
            {
                errorProvider.SetError(lstCuisineName, string.Empty);
            }
        }

        private void ClearUserError()
        {
            DataRow row = dtRecipes.Rows[0];
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (isUserSelected)
            {
                errorProvider.SetError(lstUsersName, string.Empty);
            }
        }

        private void ValidateForm()
        {
            DataRow row = dtRecipes.Rows[0];

            errorProvider.SetError(lstCuisineName, string.Empty);
            errorProvider.SetError(lstUsersName, string.Empty);

            bool isCuisineSelelected = row["CuisineId"] != DBNull.Value;
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (!isCuisineSelelected)
            {
                errorProvider.SetError(lstCuisineName, "Please selece a cuisine.");
                throw new Exception("Please select a cuisine.");
            }

            if (!isUserSelected)
            {
                errorProvider.SetError(lstUsersName, "Please select a user.");
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
            btnSaveIngredient.Enabled = b;
            btnSaveStep.Enabled = b;
            btnChangeStatus.Enabled = b;
        }

        private string GetRecipeDesc()
        {
            string value = "New Recipe";
            int pkValue = SQLUtility.GetValueFromFirstRowAsInt(dtRecipes, "RecipeId");
            if (pkValue > 0)
            {
                value = "Recipe - " + SQLUtility.GetValueFromFirstRowAsString(dtRecipes, "RecipeName");
            }
            return value;
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

                currentRow["CuisineId"] = lstCuisineName.SelectedValue ?? DBNull.Value;
                currentRow["UsersId"] = lstUsersName.SelectedValue ?? DBNull.Value;

                lstCuisineName.BindingContext[dtRecipes].EndCurrentEdit();
                lstUsersName.BindingContext[dtRecipes].EndCurrentEdit();

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

        private void TbChildRecords_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tbChildRecords.SelectedTab == tbSteps)
            {
                LoadRecipeSteps();
            }
            if (tbChildRecords.SelectedTab == tbIngredients)
            {
                LoadRecipeIngredients();
            }
        }

        private void BtnChangeStatus_Click(object? sender, EventArgs e)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(typeof(frmChangeStatus), recipeId);
            }
            this.Close();
        }

        private void LstUserName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearUserError();
        }

        private void LstCuisine_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearCuisineError();
        }

        private void BtnSaveStep_Click(object? sender, EventArgs e)
        {
            SaveRecipeSteps();
        }

        private void BtnSaveIngredient_Click(object? sender, EventArgs e)
        {
            SaveRecipeIngredient();
        }

        private void GIngredient_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gIngredient.Columns[deleteColName].Index && e.RowIndex >= 0)
            {
                DeleteRecipeIngredient(e.RowIndex);
            }
        }

        private void GSteps_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gSteps.Columns[deleteColName].Index && e.RowIndex >= 0)
            {
                DeleteRecipeSteps(e.RowIndex);
            }
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
        }
    }
}
