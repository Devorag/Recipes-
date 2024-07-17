namespace RecipeWinForms
{
    partial class frmChangeStatus
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
            lblRecipe = new Label();
            lblCurrentStatus = new Label();
            tblDates = new TableLayoutPanel();
            lblStatusDates = new Label();
            lblDrafted = new Label();
            lblPublished = new Label();
            lblArchived = new Label();
            lblDateDrafted = new Label();
            lblDatePublished = new Label();
            lblDateArchived = new Label();
            tblButtons = new TableLayoutPanel();
            btnDraft = new Button();
            btnPublish = new Button();
            btnArchive = new Button();
            tblMain.SuspendLayout();
            tblDates.SuspendLayout();
            tblButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 1;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tblMain.Controls.Add(lblRecipe, 0, 0);
            tblMain.Controls.Add(lblCurrentStatus, 0, 1);
            tblMain.Controls.Add(tblDates, 0, 2);
            tblMain.Controls.Add(tblButtons, 0, 4);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 5;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tblMain.Size = new Size(1079, 735);
            tblMain.TabIndex = 0;
            // 
            // lblRecipe
            // 
            lblRecipe.AutoSize = true;
            lblRecipe.Dock = DockStyle.Fill;
            lblRecipe.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lblRecipe.Location = new Point(3, 0);
            lblRecipe.Name = "lblRecipe";
            lblRecipe.Size = new Size(1073, 110);
            lblRecipe.TabIndex = 0;
            lblRecipe.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Dock = DockStyle.Fill;
            lblCurrentStatus.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            lblCurrentStatus.Location = new Point(3, 110);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(1073, 110);
            lblCurrentStatus.TabIndex = 1;
            lblCurrentStatus.Text = "Current Status: ";
            lblCurrentStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblDates
            // 
            tblDates.ColumnCount = 4;
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDates.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tblDates.Controls.Add(lblStatusDates, 0, 1);
            tblDates.Controls.Add(lblDrafted, 1, 0);
            tblDates.Controls.Add(lblPublished, 2, 0);
            tblDates.Controls.Add(lblArchived, 3, 0);
            tblDates.Controls.Add(lblDateDrafted, 1, 1);
            tblDates.Controls.Add(lblDatePublished, 2, 1);
            tblDates.Controls.Add(lblDateArchived, 3, 1);
            tblDates.Dock = DockStyle.Fill;
            tblDates.Location = new Point(3, 223);
            tblDates.Name = "tblDates";
            tblDates.RowCount = 2;
            tblMain.SetRowSpan(tblDates, 2);
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tblDates.Size = new Size(1073, 214);
            tblDates.TabIndex = 2;
            // 
            // lblStatusDates
            // 
            lblStatusDates.AutoSize = true;
            lblStatusDates.Dock = DockStyle.Fill;
            lblStatusDates.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblStatusDates.Location = new Point(3, 107);
            lblStatusDates.Name = "lblStatusDates";
            lblStatusDates.Size = new Size(262, 107);
            lblStatusDates.TabIndex = 0;
            lblStatusDates.Text = "Status Dates";
            lblStatusDates.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDrafted
            // 
            lblDrafted.AutoSize = true;
            lblDrafted.Dock = DockStyle.Fill;
            lblDrafted.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDrafted.Location = new Point(271, 0);
            lblDrafted.Name = "lblDrafted";
            lblDrafted.Size = new Size(262, 107);
            lblDrafted.TabIndex = 1;
            lblDrafted.Text = "Drafted";
            lblDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPublished
            // 
            lblPublished.AutoSize = true;
            lblPublished.Dock = DockStyle.Fill;
            lblPublished.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPublished.Location = new Point(539, 0);
            lblPublished.Name = "lblPublished";
            lblPublished.Size = new Size(262, 107);
            lblPublished.TabIndex = 2;
            lblPublished.Text = "Published";
            lblPublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblArchived
            // 
            lblArchived.AutoSize = true;
            lblArchived.Dock = DockStyle.Fill;
            lblArchived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblArchived.Location = new Point(807, 0);
            lblArchived.Name = "lblArchived";
            lblArchived.Size = new Size(263, 107);
            lblArchived.TabIndex = 3;
            lblArchived.Text = "Archived";
            lblArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateDrafted
            // 
            lblDateDrafted.AutoSize = true;
            lblDateDrafted.BorderStyle = BorderStyle.FixedSingle;
            lblDateDrafted.Dock = DockStyle.Fill;
            lblDateDrafted.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateDrafted.Location = new Point(271, 107);
            lblDateDrafted.Name = "lblDateDrafted";
            lblDateDrafted.Size = new Size(262, 107);
            lblDateDrafted.TabIndex = 4;
            lblDateDrafted.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDatePublished
            // 
            lblDatePublished.AutoSize = true;
            lblDatePublished.BorderStyle = BorderStyle.FixedSingle;
            lblDatePublished.Dock = DockStyle.Fill;
            lblDatePublished.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDatePublished.Location = new Point(539, 107);
            lblDatePublished.Name = "lblDatePublished";
            lblDatePublished.Size = new Size(262, 107);
            lblDatePublished.TabIndex = 5;
            lblDatePublished.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDateArchived
            // 
            lblDateArchived.AutoSize = true;
            lblDateArchived.BorderStyle = BorderStyle.FixedSingle;
            lblDateArchived.Dock = DockStyle.Fill;
            lblDateArchived.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblDateArchived.Location = new Point(807, 107);
            lblDateArchived.Name = "lblDateArchived";
            lblDateArchived.Size = new Size(263, 107);
            lblDateArchived.TabIndex = 6;
            lblDateArchived.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tblButtons
            // 
            tblButtons.ColumnCount = 3;
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tblButtons.Controls.Add(btnDraft, 0, 0);
            tblButtons.Controls.Add(btnPublish, 1, 0);
            tblButtons.Controls.Add(btnArchive, 2, 0);
            tblButtons.Dock = DockStyle.Fill;
            tblButtons.Location = new Point(3, 443);
            tblButtons.Name = "tblButtons";
            tblButtons.RowCount = 1;
            tblButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tblButtons.Size = new Size(1073, 289);
            tblButtons.TabIndex = 3;
            // 
            // btnDraft
            // 
            btnDraft.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDraft.Location = new Point(80, 60);
            btnDraft.Margin = new Padding(80, 60, 3, 3);
            btnDraft.Name = "btnDraft";
            btnDraft.Size = new Size(224, 85);
            btnDraft.TabIndex = 0;
            btnDraft.Text = "Draft";
            btnDraft.UseVisualStyleBackColor = true;
            // 
            // btnPublish
            // 
            btnPublish.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnPublish.Location = new Point(407, 60);
            btnPublish.Margin = new Padding(50, 60, 3, 3);
            btnPublish.Name = "btnPublish";
            btnPublish.Size = new Size(224, 85);
            btnPublish.TabIndex = 1;
            btnPublish.Text = "Publish";
            btnPublish.UseVisualStyleBackColor = true;
            // 
            // btnArchive
            // 
            btnArchive.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnArchive.Location = new Point(744, 60);
            btnArchive.Margin = new Padding(30, 60, 3, 3);
            btnArchive.Name = "btnArchive";
            btnArchive.Size = new Size(224, 85);
            btnArchive.TabIndex = 2;
            btnArchive.Text = "Archive";
            btnArchive.UseVisualStyleBackColor = true;
            // 
            // frmChangeStatus
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1079, 735);
            Controls.Add(tblMain);
            Name = "frmChangeStatus";
            Text = "Change Status";
            tblMain.ResumeLayout(false);
            tblMain.PerformLayout();
            tblDates.ResumeLayout(false);
            tblDates.PerformLayout();
            tblButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private Label lblRecipe;
        private Label lblCurrentStatus;
        private TableLayoutPanel tblDates;
        private Label lblStatusDates;
        private Label lblDrafted;
        private Label lblPublished;
        private Label lblArchived;
        private Label lblDateDrafted;
        private Label lblDatePublished;
        private Label lblDateArchived;
        private TableLayoutPanel tblButtons;
        private Button btnDraft;
        private Button btnPublish;
        private Button btnArchive;
    }
}