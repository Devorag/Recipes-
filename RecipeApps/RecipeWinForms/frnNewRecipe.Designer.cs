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
            lstCuisineName = new ComboBox();
            txtCalories = new TextBox();
            lstUsersName = new ComboBox();
            tblDates = new TableLayoutPanel();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblNumCalories = new Label();
            lblUser = new Label();
            lblCuisine = new Label();
            tblStatus = new TableLayoutPanel();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            tblChildRecords = new TableLayoutPanel();
            tbChildRecords = new TabControl();
            tbIngredients = new TabPage();
            tblIngredients = new TableLayoutPanel();
            btnSaveIngredient = new Button();
            gIngredient = new DataGridView();
            tbSteps = new TabPage();
            tblSteps = new TableLayoutPanel();
            btnSaveStep = new Button();
            gSteps = new DataGridView();
            lblDisplay = new Label();
            lblDateDrafted = new Label();
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
            tbSteps.SuspendLayout();
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
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.ColumnStyles.Add(new ColumnStyle());
            tblMain.Controls.Add(tblHeader, 0, 0);
            tblMain.Controls.Add(lblRecipeName, 0, 1);
            tblMain.Controls.Add(lblCurrentStatus, 0, 5);
            tblMain.Controls.Add(lblStatus, 0, 7);
            tblMain.Controls.Add(txtRecipeName, 1, 1);
            tblMain.Controls.Add(lstCuisineName, 1, 3);
            tblMain.Controls.Add(txtCalories, 1, 4);
            tblMain.Controls.Add(lstUsersName, 1, 2);
            tblMain.Controls.Add(tblDates, 1, 6);
            tblMain.Controls.Add(lblNumCalories, 0, 4);
            tblMain.Controls.Add(lblUser, 0, 2);
            tblMain.Controls.Add(lblCuisine, 0, 3);
            tblMain.Controls.Add(tblStatus, 1, 7);
            tblMain.Controls.Add(tblChildRecords, 0, 8);
            tblMain.Controls.Add(lblDisplay, 1, 5);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 9;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 7.86934328F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 52.7839355F));
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
            tblHeader.Size = new Size(821, 93);
            tblHeader.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(218, 6);
            btnDelete.Margin = new Padding(6);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(200, 84);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(6, 6);
            btnSave.Margin = new Padding(6);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(200, 84);
            btnSave.TabIndex = 2;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnChangeStatus
            // 
            btnChangeStatus.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnChangeStatus.Location = new Point(538, 3);
            btnChangeStatus.Margin = new Padding(3, 3, 3, 2);
            btnChangeStatus.Name = "btnChangeStatus";
            btnChangeStatus.Size = new Size(280, 91);
            btnChangeStatus.TabIndex = 3;
            btnChangeStatus.Text = "Change Status...";
            btnChangeStatus.UseVisualStyleBackColor = true;
            // 
            // lblRecipeName
            // 
            lblRecipeName.AutoSize = true;
            lblRecipeName.Dock = DockStyle.Fill;
            lblRecipeName.Location = new Point(6, 99);
            lblRecipeName.Margin = new Padding(6, 0, 3, 0);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(216, 66);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.Text = "Recipe Name";
            lblRecipeName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Location = new Point(6, 363);
            lblCurrentStatus.Margin = new Padding(6, 0, 3, 0);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(216, 66);
            lblCurrentStatus.TabIndex = 5;
            lblCurrentStatus.Text = "Current Status";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(6, 484);
            lblStatus.Margin = new Padding(6, 0, 3, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(216, 66);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Status Dates";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Dock = DockStyle.Fill;
            txtRecipeName.Location = new Point(228, 102);
            txtRecipeName.Multiline = true;
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(596, 60);
            txtRecipeName.TabIndex = 7;
            // 
            // lstCuisineName
            // 
            lstCuisineName.FormattingEnabled = true;
            lstCuisineName.Location = new Point(228, 234);
            lstCuisineName.Name = "lstCuisineName";
            lstCuisineName.Size = new Size(596, 40);
            lstCuisineName.TabIndex = 9;
            // 
            // txtCalories
            // 
            txtCalories.Location = new Point(228, 300);
            txtCalories.Multiline = true;
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(596, 60);
            txtCalories.TabIndex = 10;
            // 
            // lstUsersName
            // 
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(228, 168);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(596, 40);
            lstUsersName.TabIndex = 8;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 3;
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 185F));
            tblDates.Controls.Add(lblDrafted, 0, 0);
            tblDates.Controls.Add(lblPublished, 1, 0);
            tblDates.Controls.Add(lblArchived, 2, 0);
            tblDates.Dock = DockStyle.Fill;
            tblDates.Location = new Point(228, 432);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 1;
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.Size = new Size(596, 49);
            tblDates.TabIndex = 11;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Location = new Point(3, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(199, 49);
            lblDrafted.TabIndex = 0;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Location = new Point(208, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(199, 49);
            lblPublished.TabIndex = 1;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Location = new Point(413, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(180, 49);
            lblArchived.TabIndex = 2;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNumCalories
            // 
            lblNumCalories.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblNumCalories.AutoSize = true;
            lblNumCalories.Location = new Point(6, 297);
            lblNumCalories.Margin = new Padding(6, 0, 3, 0);
            lblNumCalories.Name = "lblNumCalories";
            lblNumCalories.Size = new Size(216, 66);
            lblNumCalories.TabIndex = 4;
            lblNumCalories.Text = "Num Calories";
            lblNumCalories.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(6, 165);
            lblUser.Margin = new Padding(6, 0, 3, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(216, 66);
            lblUser.TabIndex = 3;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(6, 231);
            lblCuisine.Margin = new Padding(6, 0, 3, 0);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(216, 66);
            lblCuisine.TabIndex = 2;
            lblCuisine.Text = "Cuisine";
            lblCuisine.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tblStatus
            // 
            tblStatus.ColumnCount = 3;
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblStatus.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 187F));
            tblStatus.Controls.Add(lblDatePublished, 1, 0);
            tblStatus.Controls.Add(lblDateArchived, 2, 0);
            tblStatus.Controls.Add(lblDateDrafted, 0, 0);
            tblStatus.Location = new Point(228, 487);
            tblStatus.Name = "tblStatus";
            tblStatus.RowCount = 1;
            tblStatus.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblStatus.Size = new Size(596, 60);
            tblStatus.TabIndex = 13;
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.BackColor = SystemColors.ButtonShadow;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Location = new Point(207, 0);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(198, 60);
            lblDatePublished.TabIndex = 1;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.BackColor = SystemColors.ButtonShadow;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Location = new Point(411, 0);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(182, 60);
            lblDateArchived.TabIndex = 2;
            // 
            // tblChildRecords
            // 
            tblChildRecords.ColumnCount = 1;
            tblMain.SetColumnSpan(tblChildRecords, 2);
            tblChildRecords.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblChildRecords.Controls.Add(tbChildRecords, 0, 0);
            tblChildRecords.Dock = DockStyle.Fill;
            tblChildRecords.Location = new Point(3, 553);
            tblChildRecords.Name = "tblChildRecords";
            tblChildRecords.RowCount = 1;
            tblChildRecords.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblChildRecords.Size = new Size(821, 438);
            tblChildRecords.TabIndex = 14;
            // 
            // tbChildRecords
            // 
            tbChildRecords.Controls.Add(tbIngredients);
            tbChildRecords.Controls.Add(tbSteps);
            tbChildRecords.Dock = DockStyle.Fill;
            tbChildRecords.Location = new Point(3, 3);
            tbChildRecords.Name = "tbChildRecords";
            tbChildRecords.SelectedIndex = 0;
            tbChildRecords.Size = new Size(815, 432);
            tbChildRecords.TabIndex = 0;
            // 
            // tbIngredients
            // 
            tbIngredients.Controls.Add(tblIngredients);
            tbIngredients.Location = new Point(4, 41);
            tbIngredients.Name = "tbIngredients";
            tbIngredients.Padding = new Padding(3);
            tbIngredients.Size = new Size(807, 387);
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
            tblIngredients.Size = new Size(801, 381);
            tblIngredients.TabIndex = 0;
            // 
            // btnSaveIngredient
            // 
            btnSaveIngredient.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveIngredient.Location = new Point(3, 3);
            btnSaveIngredient.Name = "btnSaveIngredient";
            btnSaveIngredient.Size = new Size(112, 67);
            btnSaveIngredient.TabIndex = 0;
            btnSaveIngredient.Text = "Save";
            btnSaveIngredient.UseVisualStyleBackColor = true;
            // 
            // gIngredient
            // 
            gIngredient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gIngredient.Dock = DockStyle.Fill;
            gIngredient.Location = new Point(3, 76);
            gIngredient.Name = "gIngredient";
            gIngredient.RowHeadersWidth = 62;
            gIngredient.RowTemplate.Height = 33;
            gIngredient.Size = new Size(795, 302);
            gIngredient.TabIndex = 1;
            // 
            // tbSteps
            // 
            tbSteps.Controls.Add(tblSteps);
            tbSteps.Location = new Point(4, 34);
            tbSteps.Name = "tbSteps";
            tbSteps.Padding = new Padding(3);
            tbSteps.Size = new Size(807, 394);
            tbSteps.TabIndex = 1;
            tbSteps.Text = "Steps";
            tbSteps.UseVisualStyleBackColor = true;
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
            tblSteps.Size = new Size(801, 388);
            tblSteps.TabIndex = 0;
            // 
            // btnSaveStep
            // 
            btnSaveStep.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnSaveStep.Location = new Point(3, 3);
            btnSaveStep.Name = "btnSaveStep";
            btnSaveStep.Size = new Size(112, 67);
            btnSaveStep.TabIndex = 0;
            btnSaveStep.Text = "Save";
            btnSaveStep.UseVisualStyleBackColor = true;
            // 
            // gSteps
            // 
            gSteps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gSteps.Dock = DockStyle.Fill;
            gSteps.Location = new Point(3, 76);
            gSteps.Name = "gSteps";
            gSteps.RowHeadersWidth = 62;
            gSteps.RowTemplate.Height = 33;
            gSteps.Size = new Size(795, 309);
            gSteps.TabIndex = 1;
            // 
            // lblDisplay
            // 
            lblDisplay.AutoSize = true;
            lblDisplay.BackColor = SystemColors.ButtonShadow;
            lblDisplay.Dock = DockStyle.Fill;
            lblDisplay.Location = new Point(228, 363);
            lblDisplay.Name = "lblDisplay";
            lblDisplay.Size = new Size(596, 66);
            lblDisplay.TabIndex = 15;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.BackColor = SystemColors.ButtonShadow;
            lblDateDrafted.Dock = DockStyle.Fill;
            lblDateDrafted.Location = new Point(3, 0);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(198, 60);
            lblDateDrafted.TabIndex = 3;
            lblDateDrafted.TextAlign = ContentAlignment.MiddleCenter;
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
            tbSteps.ResumeLayout(false);
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
        private ComboBox lstUsersName;
        private ComboBox lstCuisineName;
        private TextBox txtCalories;
        private TableLayoutPanel tblDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private TableLayoutPanel tblStatus;
        private TableLayoutPanel tblChildRecords;
        private TabControl tbChildRecords;
        private TabPage tbIngredients;
        private TabPage tbSteps;
        private TableLayoutPanel tblIngredients;
        private Button btnSaveIngredient;
        private DataGridView gIngredient;
        private TableLayoutPanel tblSteps;
        private Button btnSaveStep;
        private DataGridView gSteps;
        private Label lblDisplay;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private Label lblDateDrafted;
    }
}