namespace RecipeWinForms
{
    partial class frmRecipe
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
            tableLayoutPanel1 = new TableLayoutPanel();
            lblCaptionName = new Label();
            lblCaptionCalories = new Label();
            lblCaptionDateDrafted = new Label();
            lblCaptionDatePublished = new Label();
            lblCaptionDateArchived = new Label();
            lblCaptionStatus = new Label();
            lblCaptionPicture = new Label();
            lblName = new Label();
            lblCalories = new Label();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            txtStatus = new TextBox();
            txtPicture = new TextBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblCaptionName, 0, 0);
            tableLayoutPanel1.Controls.Add(lblCaptionCalories, 0, 1);
            tableLayoutPanel1.Controls.Add(lblCaptionDateDrafted, 0, 2);
            tableLayoutPanel1.Controls.Add(lblCaptionDatePublished, 0, 3);
            tableLayoutPanel1.Controls.Add(lblCaptionDateArchived, 0, 4);
            tableLayoutPanel1.Controls.Add(lblCaptionStatus, 0, 5);
            tableLayoutPanel1.Controls.Add(lblCaptionPicture, 0, 6);
            tableLayoutPanel1.Controls.Add(lblName, 1, 0);
            tableLayoutPanel1.Controls.Add(lblCalories, 1, 1);
            tableLayoutPanel1.Controls.Add(txtDateDrafted, 1, 2);
            tableLayoutPanel1.Controls.Add(txtDatePublished, 1, 3);
            tableLayoutPanel1.Controls.Add(txtDateArchived, 1, 4);
            tableLayoutPanel1.Controls.Add(txtStatus, 1, 5);
            tableLayoutPanel1.Controls.Add(txtPicture, 1, 6);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(737, 434);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCaptionName
            // 
            lblCaptionName.Anchor = AnchorStyles.Left;
            lblCaptionName.AutoSize = true;
            lblCaptionName.Location = new Point(3, 4);
            lblCaptionName.Name = "lblCaptionName";
            lblCaptionName.Size = new Size(155, 32);
            lblCaptionName.TabIndex = 0;
            lblCaptionName.Text = "Recipe Name";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 44);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(98, 32);
            lblCaptionCalories.TabIndex = 1;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionDateDrafted
            // 
            lblCaptionDateDrafted.Anchor = AnchorStyles.Left;
            lblCaptionDateDrafted.AutoSize = true;
            lblCaptionDateDrafted.Location = new Point(3, 84);
            lblCaptionDateDrafted.Name = "lblCaptionDateDrafted";
            lblCaptionDateDrafted.Size = new Size(151, 32);
            lblCaptionDateDrafted.TabIndex = 2;
            lblCaptionDateDrafted.Text = "Date Drafted";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.Anchor = AnchorStyles.Left;
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Location = new Point(3, 124);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(175, 32);
            lblCaptionDatePublished.TabIndex = 3;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.Anchor = AnchorStyles.Left;
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Location = new Point(3, 164);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(164, 32);
            lblCaptionDateArchived.TabIndex = 4;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // lblCaptionStatus
            // 
            lblCaptionStatus.Anchor = AnchorStyles.Left;
            lblCaptionStatus.AutoSize = true;
            lblCaptionStatus.Location = new Point(3, 204);
            lblCaptionStatus.Name = "lblCaptionStatus";
            lblCaptionStatus.Size = new Size(155, 32);
            lblCaptionStatus.TabIndex = 5;
            lblCaptionStatus.Text = "Recipe Status";
            // 
            // lblCaptionPicture
            // 
            lblCaptionPicture.AutoSize = true;
            lblCaptionPicture.Location = new Point(3, 247);
            lblCaptionPicture.Margin = new Padding(3, 7, 3, 0);
            lblCaptionPicture.Name = "lblCaptionPicture";
            lblCaptionPicture.Size = new Size(164, 32);
            lblCaptionPicture.TabIndex = 6;
            lblCaptionPicture.Text = "Recipe Picture";
            // 
            // lblName
            // 
            lblName.BackColor = Color.WhiteSmoke;
            lblName.BorderStyle = BorderStyle.FixedSingle;
            lblName.Dock = DockStyle.Fill;
            lblName.Location = new Point(184, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(550, 40);
            lblName.TabIndex = 7;
            // 
            // lblCalories
            // 
            lblCalories.BackColor = Color.WhiteSmoke;
            lblCalories.BorderStyle = BorderStyle.FixedSingle;
            lblCalories.Dock = DockStyle.Fill;
            lblCalories.Location = new Point(184, 40);
            lblCalories.Name = "lblCalories";
            lblCalories.Size = new Size(550, 40);
            lblCalories.TabIndex = 8;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDateDrafted.Location = new Point(184, 83);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(550, 39);
            txtDateDrafted.TabIndex = 9;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDatePublished.Location = new Point(184, 123);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(550, 39);
            txtDatePublished.TabIndex = 10;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDateArchived.Location = new Point(184, 163);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(550, 39);
            txtDateArchived.TabIndex = 11;
            // 
            // txtStatus
            // 
            txtStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtStatus.Location = new Point(184, 203);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(550, 39);
            txtStatus.TabIndex = 12;
            // 
            // txtPicture
            // 
            txtPicture.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPicture.Location = new Point(184, 317);
            txtPicture.Name = "txtPicture";
            txtPicture.Size = new Size(550, 39);
            txtPicture.TabIndex = 13;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 434);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "frmRecipe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCaptionName;
        private Label lblCaptionCalories;
        private Label lblCaptionDateDrafted;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private Label lblCaptionStatus;
        private Label lblCaptionPicture;
        private FileSystemWatcher fileSystemWatcher1;
        private Label lblName;
        private Label lblCalories;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private TextBox txtStatus;
        private TextBox txtPicture;
    }
}