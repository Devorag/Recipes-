namespace RecipeWinForms
{
    partial class frmSearch
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
            tblSearch = new TableLayoutPanel();
            txtRecipeName = new TextBox();
            lblRecipeName = new Label();
            btnSearch = new Button();
            gRecipes = new DataGridView();
            tblMain.SuspendLayout();
            tblSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(tblSearch, 0, 0);
            tblMain.Controls.Add(gRecipes, 0, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle());
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(896, 612);
            tblMain.TabIndex = 0;

            // 
            // tblSearch
            // 
            tblSearch.AutoSize = true;
            tblSearch.ColumnCount = 3;
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.ColumnStyles.Add(new ColumnStyle());
            tblSearch.Controls.Add(txtRecipeName, 1, 0);
            tblSearch.Controls.Add(lblRecipeName, 0, 0);
            tblSearch.Controls.Add(btnSearch, 2, 0);
            tblSearch.Location = new Point(3, 3);
            tblSearch.Name = "tblSearch";
            tblSearch.RowCount = 1;
            tblSearch.RowStyles.Add(new RowStyle());
            tblSearch.Size = new Size(435, 48);
            tblSearch.TabIndex = 0;
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left;
            txtRecipeName.Location = new Point(164, 4);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(150, 39);
            txtRecipeName.TabIndex = 0;
            // 
            // lblRecipeName
            // 
            lblRecipeName.Anchor = AnchorStyles.Left;
            lblRecipeName.AutoSize = true;
            lblRecipeName.Location = new Point(3, 8);
            lblRecipeName.Name = "lblRecipeName";
            lblRecipeName.Size = new Size(155, 32);
            lblRecipeName.TabIndex = 1;
            lblRecipeName.Text = "Recipe Name";
            // 
            // btnSearch
            // 
            btnSearch.AutoSize = true;
            btnSearch.Location = new Point(320, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 42);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // gRecipes
            // 
            gRecipes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gRecipes.Dock = DockStyle.Fill;
            gRecipes.Location = new Point(3, 57);
            gRecipes.Name = "gRecipes";
            gRecipes.RowHeadersWidth = 62;
            gRecipes.RowTemplate.Height = 33;
            gRecipes.Size = new Size(890, 552);
            gRecipes.TabIndex = 1;
            // 
            // frmSearch
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 612);
            Controls.Add(tblMain);
            Name = "frmSearch";
            Text = "frmSearch";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblSearch.ResumeLayout(false);
            tblSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gRecipes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblSearch;
        private TextBox txtRecipeName;
        private Label lblRecipeName;
        private Button btnSearch;
        private DataGridView gRecipes;
    }
}