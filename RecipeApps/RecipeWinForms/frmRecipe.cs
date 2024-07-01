
namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        DataTable dtRecipes = new DataTable();
        public frmRecipe()
        {
            InitializeComponent();
            btnDelete.Click += BtnDelete_Click;
            btnSave.Click += new EventHandler(btnSave_Click);
            lstCuisine.SelectedIndexChanged += LstCuisine_SelectedIndexChanged;
            lstUserName.SelectedIndexChanged += LstUserName_SelectedIndexChanged;
        }

        private void LstUserName_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearUserError();
        }

        private void LstCuisine_SelectedIndexChanged(object? sender, EventArgs e)
        {
            ClearCuisineError();
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
                ValidateForm();
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

        private void ClearCuisineError()
        {
            DataRow row = dtRecipes.Rows[0];
            bool isCuisineSelected = row["CuisineId"] != DBNull.Value;

            if(isCuisineSelected)
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
                DataRow currentRow = dtRecipes.Rows[0];
                SetDateField(currentRow, "DatePublished", txtDatePublished.Text);
                SetDateField(currentRow, "DateArchived", txtDateArchived.Text);

                Validate();

                Save();
            }
        }

        private void ValidateForm()
        {
            DataRow row = dtRecipes.Rows[0];

            bool isCuisineSelelected = row["CuisineId"] != DBNull.Value;
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (!isCuisineSelelected)
            {
                errorProvider.SetError(lstCuisine, "Please selece a cuisine.");
                throw new Exception("Please select a cuisine.");
            }
            else
            {
                errorProvider.SetError(lstCuisine, string.Empty);
            }

            if (!isUserSelected)
            {
                errorProvider.SetError(lstUserName, "Please select a user.");
                throw new Exception("Please select a user.");
            }
            else
            {
                errorProvider.SetError(lstUserName, string.Empty);
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


    }
}
