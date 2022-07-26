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
    public partial class ExtraService : Form
    {
        private DataAccess Da { get; set; }

        public ExtraService()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        private void PopulateGridView(string sql = "select * from ServicePackage;")
        {
            try
            {
                DataSet ds1 = this.Da.ExecuteQuery(sql);
                this.dgvService.AutoGenerateColumns = false;
                this.dgvService.DataSource = ds1.Tables[0];
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
            string sql1 = "select SId from ServicePackage order by SId desc;";
            DataTable dt1 = this.Da.ExecuteQueryTable(sql1);
            string I = dt1.Rows[0]["SId"].ToString();
            var ID = Convert.ToDouble(I);
            id = ID + 1;
            txtSId.Text = Convert.ToString(id);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtSId.Text) || String.IsNullOrEmpty(this.txtSName.Text) ||
                String.IsNullOrEmpty(this.txtSCost.Text))
                {
                    MessageBox.Show("To add Service please fill all the information.");
                    return;
                }

                var sql = "select * from ServicePackage where SId = " + this.txtSId.Text + ";";
                var ds = this.Da.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //Update
                    string query = "update ServicePackage set SName = '" + this.txtSName.Text + "', SPackageCost = " + this.txtSCost.Text + " where SId = " + this.txtSId.Text + ";";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Service Package Updated Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Service Package Upgradation Failed.");
                    }
                }
                else
                {
                    //Insert
                    string query = "insert into ServicePackage values (" + this.txtSId.Text + ", '" + this.txtSName.Text + "', " + this.txtSCost.Text + ");";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Service Package Inserted.");
                    }
                    else
                    {
                        MessageBox.Show("Service Package Insertion Failed.");
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
                var id = this.dgvService.CurrentRow.Cells["SId"].Value.ToString();

                string sql = "delete from ServicePackage where SId = '" + id + "';";
                int count = this.Da.ExecuteDML(sql);

                if (count == 1)
                {
                    MessageBox.Show("Service Package " + id + " has been deleted.");
                }
                else
                {
                    MessageBox.Show("Service Package Deletion Failed.");
                }

                this.PopulateGridView();
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void dgvService_DoubleClick(object sender, EventArgs e)
        {
            this.txtSId.Text = this.dgvService.CurrentRow.Cells["SId"].Value.ToString();
            this.txtSName.Text = this.dgvService.CurrentRow.Cells["SName"].Value.ToString();
            this.txtSCost.Text = this.dgvService.CurrentRow.Cells["SPackageCost"].Value.ToString();
        }

        private void ClearContent()
        {
            this.txtSName.Text = "";
            this.txtSCost.Text = "";
            this.AutoIdGenerate();
        }

        private void ExtraService_FormClosed(object sender, FormClosedEventArgs e)
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
