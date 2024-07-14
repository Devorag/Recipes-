using System.Windows.Forms;

namespace RecipeWinForms
{
    partial class frmNewRecipe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            fileSystemWatcher1 = new FileSystemWatcher();
            errorProvider = new ErrorProvider(components);
            tblMain = new TableLayoutPanel();
            tblHeader = new TableLayoutPanel();
            btnDelete = new Button();
            btnSave = new Button();
            btnChangeStatus = new Button();
            lblRecipeName = new Label();
            lblCurrentStatus = new Label();
            lblStatus = new Label();
            txtRecipeName = new TextBox();
            lstCuisine = new ComboBox();
            txtCalories = new TextBox();
            lstUserName = new ComboBox();
            tblDates = new TableLayoutPanel();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblNumCalories = new Label();
            txtCurrent = new TextBox();
            lblUser = new Label();
            lblCuisine = new Label();
            tblStatus = new TableLayoutPanel();
            txtDrafted = new TextBox();
            txtPublished = new TextBox();
            txtArchived = new TextBox();
            tblChildRecords = new TableLayoutPanel();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredient = new Button();
            gIngredient = new DataGridView();
            tabPage2 = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveStep = new Button();
            gSteps = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            tblMain.SuspendLayout();
            tblHeader.SuspendLayout();
            tblDates.SuspendLayout();
            tblStatus.SuspendLayout();
            tblChildRecords.SuspendLayout();
            tbChildRecords.SuspendLayout();
            tbIngredients.SuspendLayout();
            tblIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gIngredient).BeginInit();
            tabPage2.SuspendLayout();
            tblSteps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gSteps).BeginInit();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblHeader, 0, 0);
            tblMain.Controls.Add(lblRecipeName, 0, 1);
            tblMain.Controls.Add(lblCurrentStatus, 0, 5);
            tblMain.Controls.Add(lblStatus, 0, 7);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lstCuisine, 1, 3);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lstUserName, 1, 2);
            tblMain.Controls.Add(tblDates, 1, 6);
            tblMain.Controls.Add(lblNumCalories, 0, 4);
            tblMain.Controls.Add(txtCurrent, 1, 5);
            tblMain.Controls.Add(lblUser, 0, 2);
            tblMain.Controls.Add(lblCuisine, 0, 3);
            tblMain.Controls.Add(tblStatus, 1, 7);
            tblMain.Controls.Add(tblChildRecords, 0, 8);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4623013F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 16.4623013F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 67.0754F));
            tblMain.Size = new Size(827, 994);
            tblMain.TabIndex = 0;
            // 
            // tblHeader
            // 
            tblHeader.ColumnCount = 3;
            tblMain.SetColumnSpan(tblHeader, 2);
            tblHeader.ColumnStyles.Add(new ColumnStyle());
            tblHeader.ColumnStyles.Add(new ColumnStyle());
            tblHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblHeader.Controls.Add(btnDelete, 1, 0);
            tblHeader.Controls.Add(btnSave, 0, 0);
            tblHeader.Controls.Add(btnChangeStatus, 2, 0);
            tblHeader.Location = new Point(3, 3);
            tblHeader.Name = "tblHeader";
            tblHeader.RowCount = 1;
            tblHeader.RowStyles.Add(new RowStyle());
            tblHeader.Size = new Size(821, 104);
            tblHeader.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Dock = DockStyle.Fill;
            btnDelete.Location = new Point(218, 6);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 92);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(6, 6);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 92);
            btnSave.TabIndex = 2;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangeStatus.Location = new Point(580, 3);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(238, 98);
            btnChangeStatus.TabIndex = 3;
            btnChangeStatus.Text = "&Change Status...";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.BorderStyle = BorderStyle.FixedSingle;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Location = new Point(6, 110);
            lblRecipeName.Margin = new Padding(6, 0, 3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(167, 84);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.BorderStyle = BorderStyle.FixedSingle;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Location = new Point(6, 446);
            lblCurrentStatus.Margin = new Padding(6, 0, 3, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(167, 78);
            lblCurrentStatus.TabIndex = 5;
            lblCurrentStatus.Text = "Current Status";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(6, 579);
            lblStatus.Margin = new Padding(6, 0, 3, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(167, 76);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status Dates";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(179, 113);
            txtRecipeName.Multiline = true;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(645, 78);
            txtRecipeName.TabIndex = 7;
            // 
            // lstCuisine
            // 
            lstCuisine.Dock = DockStyle.Fill;
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(179, 280);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(645, 40);
            lstCuisine.TabIndex = 9;
            // 
            // txtCalories
            // 
            txtCalories.Dock = DockStyle.Fill;
            txtCalories.Location = new Point(179, 363);
            txtCalories.Multiline = true;
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(645, 80);
            txtCalories.TabIndex = 10;
            // 
            // lstUserName
            // 
            lstUserName.Dock = DockStyle.Fill;
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(179, 197);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(645, 40);
            lstUserName.TabIndex = 8;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 3;
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tblDates.Controls.Add(lblDrafted, 0, 0);
            tblDates.Controls.Add(lblPublished, 1, 0);
            tblDates.Controls.Add(lblArchived, 2, 0);
            tblDates.Location = new Point(179, 527);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 1;
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.Size = new Size(518, 49);
            tblDates.TabIndex = 11;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(175, 49);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(184, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(175, 49);
            lblPublished.TabIndex = 1;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(365, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(150, 49);
            lblArchived.TabIndex = 2;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNumCalories
            // 
            lblNumCalories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNumCalories.AutoSize = true;
            lblNumCalories.BorderStyle = BorderStyle.FixedSingle;
            lblNumCalories.Location = new Point(6, 360);
            lblNumCalories.Margin = new Padding(6, 0, 3, 0);
            lblNumCalories.Name = "lblNumCalories";
            lblNumCalories.Size = new Size(167, 86);
            lblNumCalories.TabIndex = 4;
            lblNumCalories.Text = "Num Calories";
            lblNumCalories.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCurrent
            // 
            txtCurrent.Location = new Point(179, 449);
            txtCurrent.Multiline = true;
            txtCurrent.Name = "txtCurrent";
            txtCurrent.Size = new Size(515, 72);
            txtCurrent.TabIndex = 12;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.BorderStyle = BorderStyle.FixedSingle;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(6, 194);
            lblUser.Margin = new Padding(6, 0, 3, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(167, 83);
            lblUser.TabIndex = 3;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCuisine.AutoSize = true;
            lblCuisine.BorderStyle = BorderStyle.FixedSingle;
            lblCuisine.Location = new Point(6, 277);
            lblCuisine.Margin = new Padding(6, 0, 3, 0);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(167, 83);
            lblCuisine.TabIndex = 2;
            lblCuisine.Text = "Cuisine";
            lblCuisine.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tblStatus
            // 
            tblStatus.ColumnCount = 3;
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 155F));
            tblStatus.Controls.Add(txtDrafted, 0, 0);
            tblStatus.Controls.Add(txtPublished, 1, 0);
            tblStatus.Controls.Add(txtArchived, 2, 0);
            tblStatus.Location = new Point(179, 582);
            tblStatus.Name = "tblStatus";
            tblStatus.RowCount = 1;
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatus.Size = new Size(518, 70);
            tblStatus.TabIndex = 13;
            // 
            // txtDrafted
            // 
            txtDrafted.Dock = DockStyle.Fill;
            txtDrafted.Location = new Point(3, 3);
            txtDrafted.Multiline = true;
            txtDrafted.Name = "txtDrafted";
            txtDrafted.Size = new Size(175, 64);
            txtDrafted.TabIndex = 0;
            // 
            // txtPublished
            // 
            txtPublished.Dock = DockStyle.Fill;
            txtPublished.Location = new Point(184, 3);
            txtPublished.Multiline = true;
            txtPublished.Name = "txtPublished";
            txtPublished.Size = new Size(175, 64);
            txtPublished.TabIndex = 1;
            // 
            // txtArchived
            // 
            txtArchived.Dock = DockStyle.Fill;
            txtArchived.Location = new Point(365, 3);
            txtArchived.Multiline = true;
            txtArchived.Name = "txtArchived";
            txtArchived.Size = new Size(150, 64);
            txtArchived.TabIndex = 2;
            // 
            // tblChildRecords
            // 
            tblChildRecords.ColumnCount = 1;
            tblMain.SetColumnSpan(tblChildRecords, 2);
            tblChildRecords.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblChildRecords.Controls.Add(tbChildRecords, 0, 0);
            tblChildRecords.Dock = DockStyle.Fill;
            tblChildRecords.Location = new Point(3, 658);
            tblChildRecords.Name = "tblChildRecords";
            tblChildRecords.RowCount = 1;
            tblChildRecords.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblChildRecords.Size = new Size(821, 333);
            tblChildRecords.TabIndex = 14;
            // 
            // tbChildRecords
            // 
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tabPage2);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(3, 3);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(815, 327);
            tbChildRecords.TabIndex = 0;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 41);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(807, 282);
            tbIngredients.TabIndex = 0;
            tbIngredients.Text = "Ingredients";
            tbIngredients.UseVisualStyleBackColor = true;
            // 
            // tblIngredients
            // 
            tblIngredients.ColumnCount = 1;
            tblIngredients.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblIngredients.Controls.Add(btnSaveIngredient, 0, 0);
            tblIngredients.Controls.Add(gIngredient, 0, 1);
            tblIngredients.Dock = DockStyle.Fill;
            tblIngredients.Location = new Point(3, 3);
            tblIngredients.Name = "tblIngredients";
            tblIngredients.RowCount = 2;
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 19.202898F));
            tblIngredients.RowStyles.Add(new RowStyle(SizeType.Percent, 80.7971039F));
            tblIngredients.Size = new Size(801, 276);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredient
            // 
            btnSaveIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveIngredient.Location = new Point(3, 3);
            btnSaveIngredient.Name = "btnSaveIngredient";
            btnSaveIngredient.Size = new Size(112, 47);
            btnSaveIngredient.TabIndex = 0;
            btnSaveIngredient.Text = "Save";
            btnSaveIngredient.UseVisualStyleBackColor = true;
            // 
            // gIngredient
            // 
            gIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredient.Dock = DockStyle.Fill;
            gIngredient.Location = new Point(3, 56);
            gIngredient.Name = "gIngredient";
            gIngredient.RowHeadersWidth = 62;
            gIngredient.RowTemplate.Height = 33;
            gIngredient.Size = new Size(795, 217);
            gIngredient.TabIndex = 1;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(tblSteps);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(807, 289);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Steps";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // tblSteps
            // 
            tblSteps.ColumnCount = 1;
            tblSteps.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblSteps.Controls.Add(btnSaveStep, 0, 0);
            tblSteps.Controls.Add(gSteps, 0, 1);
            tblSteps.Dock = DockStyle.Fill;
            tblSteps.Location = new Point(3, 3);
            tblSteps.Name = "tblSteps";
            tblSteps.RowCount = 2;
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 18.84058F));
            tblSteps.RowStyles.Add(new RowStyle(SizeType.Percent, 81.1594238F));
            tblSteps.Size = new Size(801, 283);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveStep
            // 
            btnSaveStep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveStep.Location = new Point(3, 3);
            btnSaveStep.Name = "btnSaveStep";
            btnSaveStep.Size = new Size(112, 47);
            btnSaveStep.TabIndex = 0;
            btnSaveStep.Text = "Save";
            btnSaveStep.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 56);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 62;
            gSteps.RowTemplate.Height = 33;
            gSteps.Size = new Size(795, 224);
            gSteps.TabIndex = 1;
            // 
            // frmNewRecipe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(827, 994);
            Controls.Add(tblMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmNewRecipe";
            Text = "Recipe";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblHeader.ResumeLayout(false);
            tblDates.ResumeLayout(false);
            tblDates.PerformLayout();
            tblStatus.ResumeLayout(false);
            tblStatus.PerformLayout();
            tblChildRecords.ResumeLayout(false);
            tbChildRecords.ResumeLayout(false);
            tbIngredients.ResumeLayout(false);
            tblIngredients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gIngredient).EndInit();
            tabPage2.ResumeLayout(false);
            tblSteps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gSteps).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private FileSystemWatcher fileSystemWatcher1;
        private ErrorProvider errorProvider;
        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblHeader;
        private Button btnDelete;
        private Button btnSave;
        private Button btnChangeStatus;
        private Label lblRecipeName;
        private Label lblCuisine;
        private Label lblUser;
        private Label lblNumCalories;
        private Label lblCurrentStatus;
        private Label lblStatus;
        private TextBox txtRecipeName;
        private ComboBox lstUserName;
        private ComboBox lstCuisine;
        private TextBox txtCalories;
        private TableLayoutPanel tblDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TextBox txtCurrent;
        private TableLayoutPanel tblStatus;
        private TextBox txtDrafted;
        private TextBox txtPublished;
        private TextBox txtArchived;
        private TableLayoutPanel tblChildRecords;
        private TabControl tbChildRecords;
        private TabPage tbIngredients;
        private TabPage tabPage2;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredient;
        private DataGridView gIngredient;
        private TableLayoutPanel tblSteps;
        private Button btnSaveStep;
        private DataGridView gSteps;
    }
}