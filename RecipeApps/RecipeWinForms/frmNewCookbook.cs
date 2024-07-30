using RecipeSystem;

namespace RecipeWinForms
{
    public partial class frmNewCookbook : Form
    {
        DataTable dtCookbook = new();
        DataTable dtCookbookRecipe = new();
        BindingSource bindingSource = new BindingSource();

        string deleteColName = "deletecol";
        int cookbookId = 0;
        int recipeId = 0;

        public frmNewCookbook()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
            btnSaveRecipe.Click += BtnSaveRecipe_Click;
            this.FormClosing += FrmNewCookbook_FormClosing;
            gCookbookRecipe.CellContentClick += GCookbookRecipe_CellContentClick;
            gCookbookRecipe.DataError += GCookbookRecipe_DataError;
            lstUsersName.SelectedIndexChanged += LstUsersName_SelectedIndexChanged;
            this.Shown += FrmNewCookbook_Shown;
        }

        private void GCookbookRecipe_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Wrong Data Type", Application.ProductName);
        }

        private void FrmNewCookbook_Shown(object? sender, EventArgs e)
        {
            LoadCookbookRecipe();
        }

        public void LoadForm(int cookbookidval)
        {
            cookbookId = cookbookidval;
            this.Tag = cookbookId;
            dtCookbook = Cookbooks.Load(cookbookId);
            bindingSource.DataSource = dtCookbook;

            if (cookbookId == 0)
            {
                DataRow newRow = dtCookbook.NewRow();
                newRow["DateCreated"] = DBNull.Value;
                dtCookbook.Rows.Add(newRow);
            }

            DataTable dtUsers = Recipes.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsersName, dtUsers, dtCookbook, "Users");

            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtPrice, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateCreated, bindingSource);
            ckActive.DataBindings.Add("Checked", dtCookbook, "Active", true, DataSourceUpdateMode.OnPropertyChanged);

            this.Text = GetCookbookDesc();
            LoadCookbookRecipe();
            SetButtonsEnabledBasedOnNewRecord();

            dtCookbook.AcceptChanges();
        }

        private void LoadCookbookRecipe()
        {
            dtCookbookRecipe = CookbookRecipe.LoadByCookbookId(cookbookId);
            gCookbookRecipe.Columns.Clear();
            gCookbookRecipe.DataSource = dtCookbookRecipe;

            DataTable dtRecipes = Cookbooks.GetRecipesList();
            WindowsFormsUtility.AddComboBoxToGrid(gCookbookRecipe, dtRecipes, "Recipe", "RecipeName");
            WindowsFormsUtility.AddDeleteButtonToGrid(gCookbookRecipe, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gCookbookRecipe, "CookbookRecipe");

        }

        private void SaveCookbookRecipe()
        {
            try
            {
                CookbookRecipe.SaveDataTable(dtCookbookRecipe, cookbookId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
        }

        private void DeleteCookbookRecipe(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gCookbookRecipe, rowIndex, "CookbookRecipeId");
            if (id > 0)
            {
                try
                {
                    CookbookRecipe.Delete(id);
                    LoadCookbookRecipe();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id < gCookbookRecipe.Rows.Count)
            {
                gCookbookRecipe.Rows.RemoveAt(rowIndex);
            }
        }

        private void SetButtonsEnabledBasedOnNewRecord()
        {
            bool b = cookbookId == 0 ? false : true;
            btnDelete.Enabled = b;
            btnSaveRecipe.Enabled = b;
        }

        private string GetCookbookDesc()
        {
            string value = "New Cookbook";
            int pkValue = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "CookbookId");
            if (pkValue > 0)
            {
                value = "Cookbook - " + SQLUtility.GetValueFromFirstRowAsString(dtCookbook, "CookbookName");
            }
            return value;
        }

        private void ValidateForm()
        {
            DataRow row = dtCookbook.Rows[0];

            errorProvider.SetError(lstUsersName, string.Empty);
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (!isUserSelected)
            {
                errorProvider.SetError(lstUsersName, "Please select a user.");
                throw new Exception("Please select a user.");
            }

        }


        private void ClearUserError()
        {
            DataRow row = dtCookbook.Rows[0];
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (isUserSelected)
            {
                errorProvider.SetError(lstUsersName, string.Empty);
            }
        }


        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                ValidateForm();

                if (dtCookbook.Rows[0]["DateCreated"] == DBNull.Value)
                {
                    dtCookbook.Rows[0]["DateCreated"] = DateTime.Now.ToString("dd MMM yyyy");
                }

                bool isActive = ckActive.Checked;
                Cookbooks.Save(dtCookbook, isActive);
                b = true;
                bindingSource.ResetBindings(false);
                cookbookId = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "CookbookId");
                this.Tag = cookbookId;
                SetButtonsEnabledBasedOnNewRecord();
                this.Text = GetCookbookDesc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cookbook");
            }
            finally
            {
                Application.UseWaitCursor = false;
            }
            return b;
        }

        private void Delete()
        {

            var response = MessageBox.Show("Are you sure you want to delete this cookbook?", "Recipes", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Cookbooks.Delete(dtCookbook, "Can't delete cookbook");
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

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            Delete();
        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (dtCookbook.Rows.Count > 0)
            {
                this.BindingContext[dtCookbook].EndCurrentEdit();

                DataRow currentRow = dtCookbook.Rows[0];
                currentRow["UsersId"] = lstUsersName.SelectedValue ?? DBNull.Value;

                lstUsersName.BindingContext[dtCookbook].EndCurrentEdit();
            }

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

        private void LstUsersName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearUserError();
        }


        private void BtnSaveRecipe_Click(object? sender, EventArgs e)
        {
            SaveCookbookRecipe();
        }

        private void FrmNewCookbook_FormClosing(object? sender, FormClosingEventArgs e)
        {
            bindingSource.EndEdit();
            if (SQLUtility.TableHasChanges(dtCookbook))
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

        private void GCookbookRecipe_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gCookbookRecipe.Columns[deleteColName].Index && e.RowIndex >= 0)
            {
                DeleteCookbookRecipe(e.RowIndex);
            }
        }
    }
}
