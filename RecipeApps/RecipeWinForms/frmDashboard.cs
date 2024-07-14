using CPUFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeWinForms
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
            this.Activated += FrmDashboard_Activated;
            this.Load += FrmDashboard_Load;
            btnCookbookList.Click += BtnCookbookList_Click;
            btnRecipeList.Click += BtnRecipeList_Click;
            btnMealList.Click += BtnMealList_Click;
        }

        private void FrmDashboard_Load(object? sender, EventArgs e)
        {
            DataTable dt = GetDashboardList();
            gDashboard.DataSource = dt;
            GridSetup();
        }

        private void FrmDashboard_Activated(object? sender, EventArgs e)
        {

            WindowsFormsUtility.FormatGridForSearchResults(gDashboard, "Dashboard");
        }


        private void GridSetup()
        {
            gDashboard.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            
            gDashboard.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 9.75F, FontStyle.Bold);
            gDashboard.RowHeadersVisible = false;

        }

        private void OpenForm(Type frmType)
        {
            if(this.MdiParent != null && this.MdiParent is frmMain)
            {
                ((frmMain)this.MdiParent).OpenForm(frmType);
            }
        }

        public static DataTable GetDashboardList()
        {
            DataTable dt = new();
            SqlCommand cmd = SQLUtility.GetSQLCommand("DashboardGet");
            dt = SQLUtility.GetDataTable(cmd);
            return dt;
        }

        private void BtnRecipeList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmRecipeList));
        }

        private void BtnCookbookList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmCookbookList));
        }

        private void BtnMealList_Click(object? sender, EventArgs e)
        {
            OpenForm(typeof(frmMealList));
        }
    }
}
