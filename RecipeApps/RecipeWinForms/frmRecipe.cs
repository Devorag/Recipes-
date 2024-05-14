using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }

        public void ShowForm(int recipeid)
        {
            string sql = "select * from recipe r where r.RecipeId = " + recipeid.ToString();
            DataTable dt = SQLUtility.GetDataTable(sql);
            lblName.DataBindings.Add("Text", dt, "RecipeName");
            lblCalories.DataBindings.Add("Text", dt, "Calories");
            txtDateDrafted.DataBindings.Add("Text", dt, "DateDrafted");
            txtDatePublished.DataBindings.Add("Text", dt, "DatePublished");
            txtDateArchived.DataBindings.Add("Text", dt, "DateArchived");
            txtStatus.DataBindings.Add("Text", dt, "RecipeStatus");
            txtPicture.DataBindings.Add("Text", dt, "RecipePicture");
            this.Show();
        }


    }
}
