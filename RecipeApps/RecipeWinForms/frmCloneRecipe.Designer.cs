namespace RecipeWinForms
{
    partial class frmCloneRecipe
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
            btnClone = new Button();
            lstRecipe = new ComboBox();
            tblMain.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(btnClone, 0, 1);
            tblMain.Controls.Add(lstRecipe, 0, 0);
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblMain.Size = new Size(818, 221);
            tblMain.TabIndex = 0;
            // 
            // btnClone
            // 
            btnClone.Location = new Point(275, 130);
            btnClone.Margin = new Padding(275, 20, 300, 20);
            btnClone.Name = "btnClone";
            btnClone.Size = new Size(243, 69);
            btnClone.TabIndex = 1;
            btnClone.Text = "&Clone";
            btnClone.UseVisualStyleBackColor = true;
            // 
            // lstRecipe
            // 
            lstRecipe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lstRecipe.FormattingEnabled = true;
            lstRecipe.Location = new Point(3, 67);
            lstRecipe.Name = "lstRecipe";
            lstRecipe.Size = new Size(515, 40);
            lstRecipe.TabIndex = 0;
            // 
            // frmCloneRecipe
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1234, 730);
            Controls.Add(tblMain);
            Name = "frmCloneRecipe";
            Text = "Clone a Recipe";
            tblMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private ComboBox lstRecipe;
        private Button btnClone;
    }
}