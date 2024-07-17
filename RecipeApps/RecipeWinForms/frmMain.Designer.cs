namespace RecipeWinForms
{
    partial class frmMain
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
            tsMain = new ToolStrip();
            menuMain = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            menuDashboard = new ToolStripMenuItem();
            menuRecipes = new ToolStripMenuItem();
            menuListRecipes = new ToolStripMenuItem();
            menuNewRecipe = new ToolStripMenuItem();
            menuCloneRecipe = new ToolStripMenuItem();
            menuMeals = new ToolStripMenuItem();
            menuListMeals = new ToolStripMenuItem();
            menuCookbooks = new ToolStripMenuItem();
            menuListCookbooks = new ToolStripMenuItem();
            menuNewCookbook = new ToolStripMenuItem();
            menuAutoCreate = new ToolStripMenuItem();
            menuDataMaintenance = new ToolStripMenuItem();
            menuEditData = new ToolStripMenuItem();
            menuWindows = new ToolStripMenuItem();
            menuWindowsTile = new ToolStripMenuItem();
            menuWindowsCascade = new ToolStripMenuItem();
            toolStripComboBox1 = new ToolStripComboBox();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // tsMain
            // 
            tsMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            tsMain.ImageScalingSize = new Size(24, 24);
            tsMain.Location = new Point(0, 42);
            tsMain.Name = "tsMain";
            tsMain.Padding = new Padding(0, 0, 3, 0);
            tsMain.Size = new Size(1340, 25);
            tsMain.TabIndex = 0;
            tsMain.Text = "toolStrip1";
            // 
            // menuMain
            // 
            menuMain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuMain.ImageScalingSize = new Size(24, 24);
            menuMain.Items.AddRange(new ToolStripItem[] { menuFile, menuRecipes, menuMeals, menuCookbooks, menuDataMaintenance, menuWindows, toolStripComboBox1 });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(8, 3, 0, 3);
            menuMain.Size = new Size(1340, 42);
            menuMain.TabIndex = 1;
            menuMain.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuDashboard });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(67, 36);
            menuFile.Text = "File";
            // 
            // menuDashboard
            // 
            menuDashboard.Name = "menuDashboard";
            menuDashboard.Size = new Size(233, 40);
            menuDashboard.Text = "Dashboard";
            // 
            // menuRecipes
            // 
            menuRecipes.DropDownItems.AddRange(new ToolStripItem[] { menuListRecipes, menuNewRecipe, menuCloneRecipe });
            menuRecipes.Name = "menuRecipes";
            menuRecipes.Size = new Size(110, 36);
            menuRecipes.Text = "Recipes";
            // 
            // menuListRecipes
            // 
            menuListRecipes.Name = "menuListRecipes";
            menuListRecipes.Size = new Size(279, 40);
            menuListRecipes.Text = "List";
            // 
            // menuNewRecipe
            // 
            menuNewRecipe.Name = "menuNewRecipe";
            menuNewRecipe.Size = new Size(279, 40);
            menuNewRecipe.Text = "New Recipe";
            // 
            // menuCloneRecipe
            // 
            menuCloneRecipe.Name = "menuCloneRecipe";
            menuCloneRecipe.Size = new Size(279, 40);
            menuCloneRecipe.Text = "Clone A Recipe";
            // 
            // menuMeals
            // 
            menuMeals.DropDownItems.AddRange(new ToolStripItem[] { menuListMeals });
            menuMeals.Name = "menuMeals";
            menuMeals.Size = new Size(93, 36);
            menuMeals.Text = "Meals";
            // 
            // menuListMeals
            // 
            menuListMeals.Name = "menuListMeals";
            menuListMeals.Size = new Size(153, 40);
            menuListMeals.Text = "List";
            // 
            // menuCookbooks
            // 
            menuCookbooks.DropDownItems.AddRange(new ToolStripItem[] { menuListCookbooks, menuNewCookbook, menuAutoCreate });
            menuCookbooks.Name = "menuCookbooks";
            menuCookbooks.Size = new Size(149, 36);
            menuCookbooks.Text = "Cookbooks";
            // 
            // menuListCookbooks
            // 
            menuListCookbooks.Name = "menuListCookbooks";
            menuListCookbooks.Size = new Size(282, 40);
            menuListCookbooks.Text = "List";
            // 
            // menuNewCookbook
            // 
            menuNewCookbook.Name = "menuNewCookbook";
            menuNewCookbook.Size = new Size(282, 40);
            menuNewCookbook.Text = "New Cookbook";
            // 
            // menuAutoCreate
            // 
            menuAutoCreate.Name = "menuAutoCreate";
            menuAutoCreate.Size = new Size(282, 40);
            menuAutoCreate.Text = "Auto Create";
            // 
            // menuDataMaintenance
            // 
            menuDataMaintenance.DropDownItems.AddRange(new ToolStripItem[] { menuEditData });
            menuDataMaintenance.Name = "menuDataMaintenance";
            menuDataMaintenance.Size = new Size(225, 36);
            menuDataMaintenance.Text = "Data Maintenance";
            // 
            // menuEditData
            // 
            menuEditData.Name = "menuEditData";
            menuEditData.Size = new Size(214, 40);
            menuEditData.Text = "Edit Data";
            // 
            // menuWindows
            // 
            menuWindows.DropDownItems.AddRange(new ToolStripItem[] { menuWindowsTile, menuWindowsCascade });
            menuWindows.Name = "menuWindows";
            menuWindows.Size = new Size(127, 36);
            menuWindows.Text = "Windows";
            // 
            // menuWindowsTile
            // 
            menuWindowsTile.Name = "menuWindowsTile";
            menuWindowsTile.Size = new Size(205, 40);
            menuWindowsTile.Text = "Tile";
            // 
            // menuWindowsCascade
            // 
            menuWindowsCascade.Name = "menuWindowsCascade";
            menuWindowsCascade.Size = new Size(205, 40);
            menuWindowsCascade.Text = "Cascade";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(156, 36);
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1340, 1007);
            Controls.Add(tsMain);
            Controls.Add(menuMain);
            Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            IsMdiContainer = true;
            MainMenuStrip = menuMain;
            Margin = new Padding(4);
            Name = "frmMain";
            Text = "Hearty Hearth";
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip tsMain;
        private MenuStrip menuMain;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuRecipes;
        private ToolStripMenuItem menuDashboard;
        private ToolStripMenuItem menuListRecipes;
        private ToolStripMenuItem menuNewRecipe;
        private ToolStripMenuItem menuCloneRecipe;
        private ToolStripMenuItem menuMeals;
        private ToolStripMenuItem menuListMeals;
        private ToolStripMenuItem menuCookbooks;
        private ToolStripMenuItem menuListCookbooks;
        private ToolStripMenuItem menuNewCookbook;
        private ToolStripMenuItem menuAutoCreate;
        private ToolStripMenuItem menuDataMaintenance;
        private ToolStripMenuItem menuEditData;
        private ToolStripMenuItem menuWindows;
        private ToolStripComboBox toolStripComboBox1;
        private ToolStripMenuItem menuWindowsTile;
        private ToolStripMenuItem menuWindowsCascade;
    }
}