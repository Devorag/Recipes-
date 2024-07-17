namespace RecipeWinForms
{
    partial class frmCookbookList
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
            gCookbooks = new DataGridView();
            btnNewCookbook = new Button();
            tblMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gCookbooks).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblMain.Controls.Add(gCookbooks, 0, 1);
            tblMain.Controls.Add(btnNewCookbook, 0, 0);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 85F));
            tblMain.Size = new Size(800, 450);
            tblMain.TabIndex = 0;
            // 
            // gCookbooks
            // 
            gCookbooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gCookbooks.Dock = DockStyle.Fill;
            gCookbooks.Location = new Point(3, 70);
            gCookbooks.Name = "gCookbooks";
            gCookbooks.RowHeadersWidth = 62;
            gCookbooks.RowTemplate.Height = 33;
            gCookbooks.Size = new Size(794, 377);
            gCookbooks.TabIndex = 0;
            // 
            // btnNewCookbook
            // 
            btnNewCookbook.Location = new Point(10, 10);
            btnNewCookbook.Margin = new Padding(10, 10, 3, 10);
            btnNewCookbook.Name = "btnNewCookbook";
            btnNewCookbook.Size = new Size(156, 47);
            btnNewCookbook.TabIndex = 1;
            btnNewCookbook.Text = "New Cookbook";
            btnNewCookbook.UseVisualStyleBackColor = true;
            // 
            // frmCookbookList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tblMain);
            Name = "frmCookbookList";
            Text = "Cookbook List";
            tblMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gCookbooks).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private DataGridView gCookbooks;
        private Button btnNewCookbook;
    }
}