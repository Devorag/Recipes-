using CPUFramework;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmCreateCookbook : Form
    {
        int usersId;
        int cookbookId;
        public frmCreateCookbook()
        {
            InitializeComponent();
            LoadForm();
            btnCreate.Click += BtnCreate_Click;
        }

        private void LoadForm()
        {
            DataTable dtUsersName = Recipes.GetUsersList();
            lstUsersName.DataSource = dtUsersName;
            lstUsersName.ValueMember = "UsersId";
            lstUsersName.DisplayMember = "UsersName";
        }

        private void BtnCreate_Click(object? sender, EventArgs e)
        {
            if (lstUsersName.SelectedValue != null && int.TryParse(lstUsersName.SelectedValue.ToString(), out int usersId))
            {
                DataRowView selectedUser = (DataRowView)lstUsersName.SelectedItem;

                try
                {
                    Cookbooks.CreateCookbook(usersId, cookbookId);
                    MessageBox.Show("Cookbook created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenCookbookList(cookbookId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating cookbook: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a valid user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OpenCookbookList(int cookbookId)
        {
            OpenForm(typeof(frmCookbookList));
        }

        private void OpenForm(Type frmType)
        {
            if (this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmType);
            }
        }
    }
}
