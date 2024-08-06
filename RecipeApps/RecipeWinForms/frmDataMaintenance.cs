namespace RecipeWinForms
{
    public partial class frmDataMaintenance : Form
    {

        private enum TableTypeEnum { Users, Cuisine, Ingredient, Measurement, Course }
        DataTable dtList = new();
        TableTypeEnum currentTableType = TableTypeEnum.Users;
        string deleteColName = "deletecol";
        public frmDataMaintenance()
        {
            InitializeComponent();
            btnSave.Click += BtnSave_Click;
            this.FormClosing += FrmDataMaintenance_FormClosing;
            gDataMaint.DataError += GDataMaint_DataError;
            gDataMaint.CellContentClick += GDataMaint_CellContentClick;
            SetUpRadioButtons();
            BindData(currentTableType);
        }

        private void GDataMaint_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Wrong data type", Application.ProductName);
        }

        private void BindData(TableTypeEnum tableType)
        {
            currentTableType = tableType;
            dtList = DataMaintenance.GetDataList(currentTableType.ToString());
            gDataMaint.Columns.Clear();
            gDataMaint.DataSource = dtList;
            DataGridViewButtonColumn col = new();
            WindowsFormsUtility.AddDeleteButtonToGrid(gDataMaint, deleteColName);
            WindowsFormsUtility.FormatGridForEdit(gDataMaint, tableType.ToString());
        }

        private bool Save()
        {
            bool b = false;
            Cursor = Cursors.WaitCursor;
            try
            {
                DataMaintenance.SaveDataList(dtList, currentTableType.ToString());
                b = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            return b;
        }

        private void Delete(int rowIndex)
        {
            int id = WindowsFormsUtility.GetIdFromGrid(gDataMaint, rowIndex, currentTableType.ToString() + "Id");

            string confirmMessage = currentTableType == TableTypeEnum.Users
                ? "Are you sure you want to delete this user and all related recipes, meals, and cookbooks?"
                : "Are you sure you want to delete?";
            var response = MessageBox.Show(confirmMessage, "Confirm Delete", MessageBoxButtons.YesNo);
            if (response == DialogResult.No)
            {
                return;
            }
            if (id != 0)
            {
                try
                {
                    DataMaintenance.DeleteRow(currentTableType.ToString(), id);
                    BindData(currentTableType);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Application.ProductName);
                }
            }
            else if (id == 0 && rowIndex < gDataMaint.Rows.Count)
            {
                gDataMaint.Rows.Remove(gDataMaint.Rows[rowIndex]);
            }
        }

        private void SetUpRadioButtons()
        {
            foreach (Control c in tblChoices.Controls)
            {
                if (c is RadioButton)
                {
                    c.Click += C_Click;
                }
            }
            optUsers.Tag = TableTypeEnum.Users;
            optCuisine.Tag = TableTypeEnum.Cuisine;
            optIngredients.Tag = TableTypeEnum.Ingredient;
            optMeasurements.Tag = TableTypeEnum.Measurement;
            optCourses.Tag = TableTypeEnum.Course;
        }

        private void C_Click(object? sender, EventArgs e)
        {
            if (sender is Control && ((Control)sender).Tag is TableTypeEnum)
            {
                BindData((TableTypeEnum)((Control)sender).Tag);
            }
        }

        private void FrmDataMaintenance_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (SQLUtility.TableHasChanges(dtList))
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

        private void GDataMaint_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (gDataMaint.Columns[e.ColumnIndex].Name == deleteColName)
            {
                Delete(e.RowIndex);
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            Save();
        }

    }
}
