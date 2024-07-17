namespace RecipeWinForms
{
    partial class frmCreateCookbook
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
            tblMain = new TableLayoutPanel();
            btnCreate = new Button();
            lstUsersName = new ComboBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(btnCreate, 1, 0);
            tblMain.Controls.Add(lstUsersName, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 1;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(839, 273);
            tblMain.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Anchor = AnchorStyles.Top;
            btnCreate.Location = new Point(449, 100);
            btnCreate.Margin = new Padding(3, 100, 3, 3);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(359, 63);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "&Create Cookbook";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // lstUsersName
            // 
            lstUsersName.Anchor = AnchorStyles.Top;
            lstUsersName.FormattingEnabled = true;
            lstUsersName.Location = new Point(60, 100);
            lstUsersName.Margin = new Padding(3, 100, 3, 3);
            lstUsersName.Name = "lstUsersName";
            lstUsersName.Size = new Size(298, 40);
            lstUsersName.TabIndex = 1;
            // 
            // frmCreateCookbook
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 273);
            Controls.Add(tblMain);
            Name = "frmCreateCookbook";
            Text = "Auto-Create a Cookbook";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Button btnCreate;
        private ComboBox lstUsersName;
    }
}