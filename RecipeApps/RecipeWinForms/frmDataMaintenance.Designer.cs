namespace RecipeWinForms
{
    partial class frmDataMaintenance
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
            tblChoices = new TableLayoutPanel();
            optUsers = new RadioButton();
            optCuisine = new RadioButton();
            optIngredients = new RadioButton();
            optMeasurements = new RadioButton();
            optCourses = new RadioButton();
            gDataMaint = new DataGridView();
            btnSave = new Button();
            tblMain.SuspendLayout();
            tblChoices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gDataMaint).BeginInit();
            SuspendLayout();
            // 
            // tblMain
            // 
            tblMain.ColumnCount = 2;
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.95674F));
            tblMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.04326F));
            tblMain.Controls.Add(tblChoices, 0, 0);
            tblMain.Controls.Add(gDataMaint, 1, 0);
            tblMain.Controls.Add(btnSave, 1, 1);
            tblMain.Dock = DockStyle.Fill;
            tblMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tblMain.Location = new Point(0, 0);
            tblMain.Name = "tblMain";
            tblMain.RowCount = 2;
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 44.1431656F));
            tblMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55.8568344F));
            tblMain.Size = new Size(1202, 922);
            tblMain.TabIndex = 0;
            // 
            // tblChoices
            // 
            tblChoices.ColumnCount = 1;
            tblChoices.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tblChoices.Controls.Add(optUsers, 0, 0);
            tblChoices.Controls.Add(optCuisine, 0, 1);
            tblChoices.Controls.Add(optIngredients, 0, 2);
            tblChoices.Controls.Add(optMeasurements, 0, 3);
            tblChoices.Controls.Add(optCourses, 0, 4);
            tblChoices.Dock = DockStyle.Fill;
            tblChoices.Location = new Point(3, 3);
            tblChoices.Name = "tblChoices";
            tblChoices.RowCount = 6;
            tblMain.SetRowSpan(tblChoices, 2);
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 12F));
            tblChoices.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tblChoices.Size = new Size(306, 916);
            tblChoices.TabIndex = 0;
            // 
            // optUsers
            // 
            optUsers.AutoSize = true;
            optUsers.Dock = DockStyle.Fill;
            optUsers.Location = new Point(3, 3);
            optUsers.Name = "optUsers";
            optUsers.Size = new Size(300, 103);
            optUsers.TabIndex = 0;
            optUsers.TabStop = true;
            optUsers.Text = "Users";
            optUsers.UseVisualStyleBackColor = true;
            // 
            // optCuisine
            // 
            optCuisine.AutoSize = true;
            optCuisine.Dock = DockStyle.Fill;
            optCuisine.Location = new Point(3, 112);
            optCuisine.Name = "optCuisine";
            optCuisine.Size = new Size(300, 103);
            optCuisine.TabIndex = 1;
            optCuisine.TabStop = true;
            optCuisine.Text = "Cuisines";
            optCuisine.UseVisualStyleBackColor = true;
            // 
            // optIngredients
            // 
            optIngredients.AutoSize = true;
            optIngredients.Dock = DockStyle.Fill;
            optIngredients.Location = new Point(3, 221);
            optIngredients.Name = "optIngredients";
            optIngredients.Size = new Size(300, 103);
            optIngredients.TabIndex = 2;
            optIngredients.TabStop = true;
            optIngredients.Text = "Ingredients";
            optIngredients.UseVisualStyleBackColor = true;
            // 
            // optMeasurements
            // 
            optMeasurements.AutoSize = true;
            optMeasurements.Dock = DockStyle.Fill;
            optMeasurements.Location = new Point(3, 330);
            optMeasurements.Name = "optMeasurements";
            optMeasurements.Size = new Size(300, 103);
            optMeasurements.TabIndex = 3;
            optMeasurements.TabStop = true;
            optMeasurements.Text = "Measurements";
            optMeasurements.UseVisualStyleBackColor = true;
            // 
            // optCourses
            // 
            optCourses.AutoSize = true;
            optCourses.Dock = DockStyle.Fill;
            optCourses.Location = new Point(3, 439);
            optCourses.Name = "optCourses";
            optCourses.Size = new Size(300, 103);
            optCourses.TabIndex = 4;
            optCourses.TabStop = true;
            optCourses.Text = "Courses";
            optCourses.UseVisualStyleBackColor = true;
            // 
            // gDataMaint
            // 
            gDataMaint.BackgroundColor = SystemColors.Control;
            gDataMaint.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gDataMaint.Dock = DockStyle.Fill;
            gDataMaint.Location = new Point(315, 3);
            gDataMaint.Name = "gDataMaint";
            gDataMaint.RowHeadersWidth = 62;
            gDataMaint.RowTemplate.Height = 33;
            gDataMaint.Size = new Size(884, 401);
            gDataMaint.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(1008, 846);
            btnSave.Margin = new Padding(3, 3, 10, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(184, 66);
            btnSave.TabIndex = 2;
            btnSave.Text = "&Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // frmDataMaintenance
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1202, 922);
            Controls.Add(tblMain);
            Name = "frmDataMaintenance";
            Text = "Data Maintenance";
            tblMain.ResumeLayout(false);
            tblChoices.ResumeLayout(false);
            tblChoices.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gDataMaint).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tblMain;
        private TableLayoutPanel tblChoices;
        private RadioButton optUsers;
        private RadioButton optCuisine;
        private RadioButton optIngredients;
        private RadioButton optMeasurements;
        private RadioButton optCourses;
        private DataGridView gDataMaint;
        private Button btnSave;
    }
}