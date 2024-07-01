using System.Windows.Forms;

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipe));
            tableLayoutPanel1 = new TableLayoutPanel();
            lblCuisine = new Label();
            lblUser = new Label();
            lblCaptionRecipeName = new Label();
            lblCaptionCalories = new Label();
            lblCaptionDateDrafted = new Label();
            lblCaptionDatePublished = new Label();
            lblCaptionDateArchived = new Label();
            txtRecipeName = new TextBox();
            txtCalories = new TextBox();
            txtDateDrafted = new TextBox();
            txtDatePublished = new TextBox();
            txtDateArchived = new TextBox();
            lstUserName = new ComboBox();
            lstCuisine = new ComboBox();
            fileSystemWatcher1 = new FileSystemWatcher();
            toolStrip1 = new ToolStrip();
            btnSave = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            btnDelete = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            errorProvider = new ErrorProvider(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(lblCuisine, 0, 0);
            tableLayoutPanel1.Controls.Add(lblUser, 0, 1);
            tableLayoutPanel1.Controls.Add(lblCaptionRecipeName, 0, 2);
            tableLayoutPanel1.Controls.Add(lblCaptionCalories, 0, 3);
            tableLayoutPanel1.Controls.Add(lblCaptionDateDrafted, 0, 4);
            tableLayoutPanel1.Controls.Add(lblCaptionDatePublished, 0, 5);
            tableLayoutPanel1.Controls.Add(lblCaptionDateArchived, 0, 6);
            tableLayoutPanel1.Controls.Add(txtRecipeName, 1, 2);
            tableLayoutPanel1.Controls.Add(txtCalories, 1, 3);
            tableLayoutPanel1.Controls.Add(txtDateDrafted, 1, 4);
            tableLayoutPanel1.Controls.Add(txtDatePublished, 1, 5);
            tableLayoutPanel1.Controls.Add(txtDateArchived, 1, 6);
            tableLayoutPanel1.Controls.Add(lstUserName, 1, 1);
            tableLayoutPanel1.Controls.Add(lstCuisine, 1, 0);
            tableLayoutPanel1.Location = new Point(0, 65);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel1.Size = new Size(737, 367);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblCuisine
            // 
            lblCuisine.Anchor = AnchorStyles.Left;
            lblCuisine.AutoSize = true;
            lblCuisine.Location = new Point(3, 4);
            lblCuisine.Name = "lblCuisine";
            lblCuisine.Size = new Size(92, 32);
            lblCuisine.TabIndex = 0;
            lblCuisine.Text = "Cuisine";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 44);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(61, 32);
            lblUser.TabIndex = 1;
            lblUser.Text = "User";
            // 
            // lblCaptionRecipeName
            // 
            lblCaptionRecipeName.Anchor = AnchorStyles.Left;
            lblCaptionRecipeName.AutoSize = true;
            lblCaptionRecipeName.Location = new Point(3, 84);
            lblCaptionRecipeName.Name = "lblCaptionRecipeName";
            lblCaptionRecipeName.Size = new Size(155, 32);
            lblCaptionRecipeName.TabIndex = 2;
            lblCaptionRecipeName.Text = "Recipe Name";
            // 
            // lblCaptionCalories
            // 
            lblCaptionCalories.Anchor = AnchorStyles.Left;
            lblCaptionCalories.AutoSize = true;
            lblCaptionCalories.Location = new Point(3, 124);
            lblCaptionCalories.Name = "lblCaptionCalories";
            lblCaptionCalories.Size = new Size(98, 32);
            lblCaptionCalories.TabIndex = 3;
            lblCaptionCalories.Text = "Calories";
            // 
            // lblCaptionDateDrafted
            // 
            lblCaptionDateDrafted.Anchor = AnchorStyles.Left;
            lblCaptionDateDrafted.AutoSize = true;
            lblCaptionDateDrafted.Location = new Point(3, 164);
            lblCaptionDateDrafted.Name = "lblCaptionDateDrafted";
            lblCaptionDateDrafted.Size = new Size(151, 32);
            lblCaptionDateDrafted.TabIndex = 4;
            lblCaptionDateDrafted.Text = "Date Drafted";
            // 
            // lblCaptionDatePublished
            // 
            lblCaptionDatePublished.Anchor = AnchorStyles.Left;
            lblCaptionDatePublished.AutoSize = true;
            lblCaptionDatePublished.Location = new Point(3, 204);
            lblCaptionDatePublished.Name = "lblCaptionDatePublished";
            lblCaptionDatePublished.Size = new Size(175, 32);
            lblCaptionDatePublished.TabIndex = 5;
            lblCaptionDatePublished.Text = "Date Published";
            // 
            // lblCaptionDateArchived
            // 
            lblCaptionDateArchived.AutoSize = true;
            lblCaptionDateArchived.Location = new Point(3, 247);
            lblCaptionDateArchived.Margin = new Padding(3, 7, 3, 0);
            lblCaptionDateArchived.Name = "lblCaptionDateArchived";
            lblCaptionDateArchived.Size = new Size(164, 32);
            lblCaptionDateArchived.TabIndex = 6;
            lblCaptionDateArchived.Text = "Date Archived";
            // 
            // txtRecipeName
            // 
            txtRecipeName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtRecipeName.Location = new Point(184, 83);
            txtRecipeName.Name = "txtRecipeName";
            txtRecipeName.Size = new Size(550, 39);
            txtRecipeName.TabIndex = 9;
            // 
            // txtCalories
            // 
            txtCalories.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtCalories.Location = new Point(184, 123);
            txtCalories.Name = "txtCalories";
            txtCalories.Size = new Size(550, 39);
            txtCalories.TabIndex = 10;
            // 
            // txtDateDrafted
            // 
            txtDateDrafted.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDateDrafted.Location = new Point(184, 163);
            txtDateDrafted.Name = "txtDateDrafted";
            txtDateDrafted.Size = new Size(550, 39);
            txtDateDrafted.TabIndex = 11;
            // 
            // txtDatePublished
            // 
            txtDatePublished.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDatePublished.Location = new Point(184, 203);
            txtDatePublished.Name = "txtDatePublished";
            txtDatePublished.Size = new Size(550, 39);
            txtDatePublished.TabIndex = 12;
            // 
            // txtDateArchived
            // 
            txtDateArchived.Location = new Point(184, 243);
            txtDateArchived.Name = "txtDateArchived";
            txtDateArchived.Size = new Size(550, 39);
            txtDateArchived.TabIndex = 13;
            // 
            // lstUserName
            // 
            lstUserName.FormattingEnabled = true;
            lstUserName.Location = new Point(184, 43);
            lstUserName.Name = "lstUserName";
            lstUserName.Size = new Size(274, 40);
            lstUserName.TabIndex = 14;
            // 
            // lstCuisine
            // 
            lstCuisine.FormattingEnabled = true;
            lstCuisine.Location = new Point(184, 3);
            lstCuisine.Name = "lstCuisine";
            lstCuisine.Size = new Size(274, 40);
            lstCuisine.TabIndex = 15;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(24, 24);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnSave, toolStripSeparator1, btnDelete, toolStripSeparator3 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(737, 41);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btnSave
            // 
            btnSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnSave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.ImageTransparentColor = Color.Magenta;
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(68, 36);
            btnSave.Text = "Save";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // btnDelete
            // 
            btnDelete.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btnDelete.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDelete.Image = (Image)resources.GetObject("btnDelete.Image");
            btnDelete.ImageTransparentColor = Color.Magenta;
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(88, 36);
            btnDelete.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmRecipe
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(737, 434);
            Controls.Add(toolStrip1);
            Controls.Add(tableLayoutPanel1);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "frmRecipe";
            Text = "frmRecipe";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblCuisine;
        private Label lblUser;
        private Label lblCaptionRecipeName;
        private Label lblCaptionCalories;
        private Label lblCaptionDateDrafted;
        private Label lblCaptionDatePublished;
        private Label lblCaptionDateArchived;
        private FileSystemWatcher fileSystemWatcher1;
        private TextBox txtRecipeName;
        private TextBox txtCalories;
        private TextBox txtDateDrafted;
        private TextBox txtDatePublished;
        private TextBox txtDateArchived;
        private ToolStrip toolStrip1;
        private ToolStripButton btnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnDelete;
        private ToolStripSeparator toolStripSeparator3;
        private ComboBox lstUserName;
        private ComboBox lstCuisine;
        private ErrorProvider errorProvider;
    }
}