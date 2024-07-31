namespace RecipeWinForms
{
    partial class frmNewCookbook
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
            tblMain = new TableLayoutPanel();
            tblOptions = new TableLayoutPanel();
            btnDelete = new Button();
            lblUser = new Label();
            lblActive = new Label();
            txtCookbookName = new TextBox();
            lblCookbookName = new Label();
            lblPrice = new Label();
            btnSave = new Button();
            lstUsersName = new ComboBox();
            tblNum = new TableLayoutPanel();
            txtPrice = new TextBox();
            lblDateCreated = new Label();
            ckActive = new CheckBox();
            lblText = new Label();
            btnSaveRecipe = new Button();
            gCookbookRecipe = new DataGridView();
            errorProvider = new ErrorProvider(components);
            tblMain.SuspendLayout();
            tblOptions.SuspendLayout();
            tblNum.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(tblOptions, 0, 0);
            tblMain.Controls.Add(btnSaveRecipe, 0, 1);
            tblMain.Controls.Add(gCookbookRecipe, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Margin = new Padding(20, 3, 3, 3);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 3;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 6.952381F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 48.0952377F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tblMain.Size = new Size(859, 1050);
            tblMain.TabIndex = 0;
            // 
            // tblOptions
            // 
            tblOptions.ColumnCount = 2;
            tblOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.71795F));
            tblOptions.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.28205F));
            tblOptions.Controls.Add(btnDelete, 1, 0);
            tblOptions.Controls.Add(lblUser, 0, 2);
            tblOptions.Controls.Add(lblActive, 0, 5);
            tblOptions.Controls.Add(txtCookbookName, 1, 1);
            tblOptions.Controls.Add(lblCookbookName, 0, 1);
            tblOptions.Controls.Add(lblPrice, 0, 4);
            tblOptions.Controls.Add(btnSave, 0, 0);
            tblOptions.Controls.Add(lstUsersName, 1, 2);
            tblOptions.Controls.Add(tblNum, 1, 4);
            tblOptions.Controls.Add(ckActive, 1, 5);
            tblOptions.Controls.Add(lblText, 1, 3);
            tblOptions.Dock = DockStyle.Fill;
            tblOptions.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblOptions.Location = new Point(3, 3);
            tblOptions.Name = "tblOptions";
            tblOptions.RowCount = 6;
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20.1824017F));
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20.182394F));
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20.182394F));
            tblOptions.RowStyles.Add(new RowStyle());
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 19.2704163F));
            tblOptions.RowStyles.Add(new RowStyle(SizeType.Percent, 20.182394F));
            tblOptions.Size = new Size(853, 466);
            tblOptions.TabIndex = 0;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(282, 3);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(226, 71);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "&Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Dock = DockStyle.Fill;
            lblUser.Location = new Point(10, 154);
            lblUser.Margin = new Padding(10, 0, 3, 0);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(266, 77);
            lblUser.TabIndex = 3;
            lblUser.Text = "User";
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblActive
            // 
            lblActive.AutoSize = true;
            lblActive.Dock = DockStyle.Fill;
            lblActive.Location = new Point(10, 386);
            lblActive.Margin = new Padding(10, 0, 3, 0);
            lblActive.Name = "lblActive";
            lblActive.Size = new Size(266, 80);
            lblActive.TabIndex = 5;
            lblActive.Text = "Active";
            lblActive.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtCookbookName
            // 
            txtCookbookName.BorderStyle = BorderStyle.FixedSingle;
            txtCookbookName.Location = new Point(282, 80);
            txtCookbookName.Multiline = true;
            txtCookbookName.Name = "txtCookbookName";
            txtCookbookName.Size = new Size(568, 71);
            txtCookbookName.TabIndex = 6;
            // 
            // lblCookbookName
            // 
            lblCookbookName.AutoSize = true;
            lblCookbookName.Dock = DockStyle.Fill;
            lblCookbookName.Location = new Point(10, 77);
            lblCookbookName.Margin = new Padding(10, 0, 3, 0);
            lblCookbookName.Name = "lblCookbookName";
            lblCookbookName.Size = new Size(266, 77);
            lblCookbookName.TabIndex = 2;
            lblCookbookName.Text = "Cookbook Name";
            lblCookbookName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Dock = DockStyle.Fill;
            lblPrice.Location = new Point(10, 313);
            lblPrice.Margin = new Padding(10, 0, 3, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(266, 73);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Price";
            lblPrice.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(30, 3);
            btnSave.Margin = new Padding(30, 3, 3, 3);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(209, 71);
            btnSave.TabIndex = 0;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // lstUsersName
            // 
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(282, 157);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(568, 40);
            lstUsersName.TabIndex = 9;
            // 
            // tblNum
            // 
            tblNum.ColumnCount = 2;
            tblNum.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblNum.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblNum.Controls.Add(txtPrice, 0, 0);
            tblNum.Controls.Add(lblDateCreated, 1, 0);
            tblNum.Dock = DockStyle.Fill;
            tblNum.Location = new Point(282, 316);
            tblNum.Name = "tblNum";
            tblNum.RowCount = 1;
            tblNum.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblNum.Size = new Size(568, 67);
            tblNum.TabIndex = 10;
            // 
            // txtPrice
            // 
            txtPrice.BorderStyle = BorderStyle.FixedSingle;
            txtPrice.Dock = DockStyle.Fill;
            txtPrice.Location = new Point(3, 3);
            txtPrice.Multiline = true;
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(278, 61);
            txtPrice.TabIndex = 0;
            // 
            // lblDateCreated
            // 
            lblDateCreated.AutoSize = true;
            lblDateCreated.BackColor = SystemColors.ControlDark;
            lblDateCreated.BorderStyle = BorderStyle.FixedSingle;
            lblDateCreated.Dock = DockStyle.Fill;
            lblDateCreated.Location = new Point(287, 0);
            lblDateCreated.Name = "lblDateCreated";
            lblDateCreated.Size = new Size(278, 67);
            lblDateCreated.TabIndex = 1;
            lblDateCreated.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ckActive
            // 
            ckActive.AutoSize = true;
            ckActive.Checked = true;
            ckActive.CheckState = CheckState.Checked;
            ckActive.Dock = DockStyle.Fill;
            ckActive.Location = new Point(282, 389);
            ckActive.Name = "ckActive";
            ckActive.Size = new Size(568, 74);
            ckActive.TabIndex = 11;
            ckActive.UseVisualStyleBackColor = true;
            // 
            // lblText
            // 
            lblText.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblText.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblText.Location = new Point(614, 261);
            lblText.Margin = new Padding(3, 30, 80, 20);
            lblText.Name = "lblText";
            lblText.Size = new Size(159, 32);
            lblText.TabIndex = 8;
            lblText.Text = "Date Created:";
            // 
            // btnSaveRecipe
            // 
            btnSaveRecipe.AutoSize = true;
            btnSaveRecipe.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveRecipe.Location = new Point(3, 475);
            btnSaveRecipe.Name = "btnSaveRecipe";
            btnSaveRecipe.Size = new Size(214, 66);
            btnSaveRecipe.TabIndex = 1;
            btnSaveRecipe.Text = "Save";
            btnSaveRecipe.UseVisualStyleBackColor = true;
            // 
            // gCookbookRecipe
            // 
            gCookbookRecipe.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbookRecipe.Dock = DockStyle.Fill;
            gCookbookRecipe.Location = new Point(3, 547);
            gCookbookRecipe.Name = "gCookbookRecipe";
            gCookbookRecipe.RowHeadersWidth = 62;
            gCookbookRecipe.RowTemplate.Height = 33;
            gCookbookRecipe.Size = new Size(853, 500);
            gCookbookRecipe.TabIndex = 2;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmNewCookbook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(859, 1050);
            Controls.Add(tblMain);
            Name = "frmNewCookbook";
            Text = "Cookbook";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblOptions.ResumeLayout(false);
            tblOptions.PerformLayout();
            tblNum.ResumeLayout(false);
            tblNum.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbookRecipe).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblOptions;
        private Button btnSave;
        private Button btnDelete;
        private Label lblCookbookName;
        private Label lblUser;
        private Label lblPrice;
        private Label lblActive;
        private TextBox txtCookbookName;
        private Label lblText;
        private ComboBox lstUsersName;
        private TableLayoutPanel tblNum;
        private TextBox txtPrice;
        private Label lblDateCreated;
        private CheckBox ckActive;
        private ErrorProvider errorProvider;
        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView gCookbookRecipe;
        private Button btnSaveRecipe;
    }
}