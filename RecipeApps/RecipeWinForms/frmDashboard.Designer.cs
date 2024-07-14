namespace RecipeWinForms
{
    partial class frmDashboard
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
            lblTitlle = new Label();
            tblButtons = new TableLayoutPanel();
            btnRecipeList = new Button();
            btnMealList = new Button();
            btnCookbookList = new Button();
            lblDesc = new Label();
            tblGrid = new TableLayoutPanel();
            gDashboard = new DataGridView();
            pageSetupDialog1 = new PageSetupDialog();
            label2 = new Label();
            tblMain.SuspendLayout();
            tblButtons.SuspendLayout();
            tblGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gDashboard).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(lblTitlle, 0, 0);
            tblMain.Controls.Add(tblButtons, 0, 3);
            tblMain.Controls.Add(lblDesc, 0, 1);
            tblMain.Controls.Add(tblGrid, 0, 2);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 4;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 12.3164282F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 31.1135273F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 56.5700378F));
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.Size = new Size(1087, 859);
            tblMain.TabIndex = 0;
            // 
            // lblTitlle
            // 
            lblTitlle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblTitlle.AutoSize = true;
            lblTitlle.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblTitlle.Location = new Point(3, 43);
            lblTitlle.Name = "lblTitlle";
            lblTitlle.Size = new Size(1081, 48);
            lblTitlle.TabIndex = 0;
            lblTitlle.Text = "Hearty Hearth Desktop App ";
            lblTitlle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.3636322F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.272728F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.36364F));
            tblButtons.Controls.Add(btnRecipeList, 0, 0);
            tblButtons.Controls.Add(btnMealList, 1, 0);
            tblButtons.Controls.Add(btnCookbookList, 2, 0);
            tblButtons.Location = new Point(3, 748);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(1081, 107);
            tblButtons.TabIndex = 3;
            // 
            // btnRecipeList
            // 
            btnRecipeList.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRecipeList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnRecipeList.Location = new Point(102, 4);
            btnRecipeList.Margin = new Padding(20, 3, 3, 3);
            btnRecipeList.Name = "btnRecipeList";
            btnRecipeList.Size = new Size(288, 100);
            btnRecipeList.TabIndex = 0;
            btnRecipeList.Text = "Recipe List";
            btnRecipeList.UseVisualStyleBackColor = true;
            // 
            // btnMealList
            // 
            btnMealList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnMealList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMealList.Location = new Point(396, 4);
            btnMealList.Name = "btnMealList";
            btnMealList.Size = new Size(288, 100);
            btnMealList.TabIndex = 1;
            btnMealList.Text = "Meal List";
            btnMealList.UseVisualStyleBackColor = true;
            // 
            // btnCookbookList
            // 
            btnCookbookList.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCookbookList.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCookbookList.Location = new Point(690, 4);
            btnCookbookList.Margin = new Padding(3, 3, 20, 3);
            btnCookbookList.Name = "btnCookbookList";
            btnCookbookList.Size = new Size(288, 100);
            btnCookbookList.TabIndex = 2;
            btnCookbookList.Text = "Cookbook List";
            btnCookbookList.UseVisualStyleBackColor = true;
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.Dock = DockStyle.Fill;
            lblDesc.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            lblDesc.Location = new Point(3, 91);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(1081, 232);
            lblDesc.TabIndex = 2;
            lblDesc.Text = "Welcome to the Hearty Hearth desktop app. In this app you can \r\ncreate recipes and cookbooks. You can also......";
            lblDesc.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblGrid
            // 
            tblGrid.ColumnCount = 3;
            tblGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblGrid.Controls.Add(gDashboard, 1, 0);
            tblGrid.Dock = DockStyle.Fill;
            tblGrid.Location = new Point(3, 326);
            tblGrid.Name = "tblGrid";
            tblGrid.RowCount = 2;
            tblGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblGrid.Size = new Size(1081, 416);
            tblGrid.TabIndex = 4;
            // 
            // gDashboard
            // 
            gDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gDashboard.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            gDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gDashboard.Dock = DockStyle.Fill;
            gDashboard.Location = new Point(273, 3);
            gDashboard.Name = "gDashboard";
            gDashboard.RowHeadersWidth = 62;
            tblGrid.SetRowSpan(gDashboard, 2);
            gDashboard.RowTemplate.Height = 33;
            gDashboard.Size = new Size(534, 410);
            gDashboard.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1088, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 1;
            label2.Text = "label2";
            // 
            // frmDashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1087, 859);
            Controls.Add(label2);
            Controls.Add(tblMain);
            Name = "frmDashboard";
            Text = "Dashboard";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblButtons.ResumeLayout(false);
            tblGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gDashboard).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblTitlle;
        private Label lblDesc;
        private TableLayoutPanel tblButtons;
        private PageSetupDialog pageSetupDialog1;
        private Label label2;
        private Button btnRecipeList;
        private Button btnMealList;
        private Button btnCookbookList;
        private TableLayoutPanel tblGrid;
        private DataGridView gDashboard;
    }
}