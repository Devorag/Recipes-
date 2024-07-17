using CPUFramework;
using RecipeSystem;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmNewCookbook : Form
    {
        BindingSource bindingSource = new BindingSource();
        int cookbookId = 0;
        DataTable dtCookbook = new();
        public frmNewCookbook()
        {
            InitializeComponent();
            LoadForm(cookbookId);
            btnSave.Click += BtnSave_Click;
            btnDelete.Click += BtnDelete_Click;
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
                newRow["DateCreated"] = DateTime.Now.ToString("dd MMM yyyy");
                dtCookbook.Rows.Add(newRow);
            }

;           DataTable dtUsers = Recipes.GetUsersList();
            WindowsFormsUtility.SetListBinding(lstUsersName, dtUsers, dtCookbook, "Users");

            WindowsFormsUtility.SetControlBinding(txtCookbookName, bindingSource);
            WindowsFormsUtility.SetControlBinding(txtPrice, bindingSource);
            WindowsFormsUtility.SetControlBinding(lblDateCreated, bindingSource);

            this.Text = GetCookbookDesc();

            this.Show();
        }


        private string GetCookbookDesc()
        {
            string value = "New Cookbook";
            int pkValue = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "CookbookId");
            if (pkValue > 0)
            {
                value = SQLUtility.GetValueFromFirstRowAsString(dtCookbook, "CookbookName");
            }
            return value;
        }

        private void ValidateForm()
        {
            DataRow row = dtCookbook.Rows[0];

            //errorProvider.SetError(lstUsersName, string.Empty);
            bool isUserSelected = row["UsersId"] != DBNull.Value;

            if (!isUserSelected)
            {
                //errorProvider.SetError(lstUsersName, "Please select a user.");
                throw new Exception("Please select a user.");
            }
        }

        private bool Save()
        {
            bool b = false;
            Application.UseWaitCursor = true;
            try
            {
                ValidateForm();
                Recipes.Save(dtCookbook);
                b = true;
                bindingSource.ResetBindings(false);
                cookbookId = SQLUtility.GetValueFromFirstRowAsInt(dtCookbook, "CookbookId");
                this.Tag = cookbookId;
                //SetButtonsEnabledBasedOnNewRecord();
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

            var response = MessageBox.Show("Are you sure you want to delete this recipe?", "Recipes", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            Application.UseWaitCursor = true;
            try
            {
                Recipes.Delete(dtCookbook, "Can't delete cookbook");
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
        }

    }
}
