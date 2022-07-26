using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project_HMS
{
    public partial class FoodMenu : Form
    {
        private DataAccess Da { get; set; }

        public FoodMenu()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        private void PopulateGridView(string sql = "select * from FoodPackage;")
        {
            try
            {
                DataSet ds1 = this.Da.ExecuteQuery(sql);
                this.dgvFood.AutoGenerateColumns = false;
                this.dgvFood.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void AutoIdGenerate()
        {
            double id = 0;

            //ID
            string sql1 = "select FId from FoodPackage order by FId desc;";
            DataTable dt1 = this.Da.ExecuteQueryTable(sql1);
            string I = dt1.Rows[0]["FId"].ToString();
            var ID = Convert.ToDouble(I);
            id = ID + 1;
            txtFId.Text = Convert.ToString(id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtFId.Text) || String.IsNullOrEmpty(this.txtFName.Text) ||
                String.IsNullOrEmpty(this.txtFCost.Text))
                {
                    MessageBox.Show("To add Food please fill all the information.");
                    return;
                }

                var sql = "select * from FoodPackage where FId = " + this.txtFId.Text + ";";
                var ds = this.Da.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //Update
                    string query = "update FoodPackage set FName = '" + this.txtFName.Text + "', FPackageCost = " + this.txtFCost.Text + " where FId = " + this.txtFId.Text + ";";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Food Package Updated Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Food Package Upgradation Failed.");
                    }
                }
                else
                {
                    //Insert
                    string query = "insert into FoodPackage values (" + this.txtFId.Text + ", '" + this.txtFName.Text + "', " + this.txtFCost.Text + ");";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Food Package Inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Food Package Insertion Failed.");
                    }
                }

                this.PopulateGridView();
                this.ClearContent();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var id = this.dgvFood.CurrentRow.Cells["FId"].Value.ToString();

                string sql = "delete from FoodPackage where FId = '" + id + "';";
                int count = this.Da.ExecuteDML(sql);

                if (count == 1)
                {
                    MessageBox.Show("Food Package " + id + " has been deleted.");
                }
                else
                {
                    MessageBox.Show("Food Package Deletion Failed.");
                }

                this.PopulateGridView();
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void dgvFood_DoubleClick(object sender, EventArgs e)
        {
            this.txtFId.Text = this.dgvFood.CurrentRow.Cells["FId"].Value.ToString();
            this.txtFName.Text = this.dgvFood.CurrentRow.Cells["FName"].Value.ToString();
            this.txtFCost.Text = this.dgvFood.CurrentRow.Cells["FPackageCost"].Value.ToString();
        }

        private void ClearContent()
        {
            this.txtFName.Text = "";
            this.txtFCost.Text = "";
            this.AutoIdGenerate();
        }

        private void FoodMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}
