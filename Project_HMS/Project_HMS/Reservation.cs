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
    public partial class Reservation : Form
    {
        private DataAccess Da { get; set; }

        public Reservation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }

        private void PopulateGridView(string sql = "select * from Room;")
        {
            try
            {               
                DataSet ds1 = this.Da.ExecuteQuery(sql);
                this.dgvRoom.AutoGenerateColumns = false;
                this.dgvRoom.DataSource = ds1.Tables[0];

                string fdsql = "select * from FoodPackage;";
                DataSet ds2 = this.Da.ExecuteQuery(fdsql);
                this.dgvFood.AutoGenerateColumns = false;
                this.dgvFood.DataSource = ds2.Tables[0];

                string svsql = "select * from ServicePackage;";
                DataSet ds3 = this.Da.ExecuteQuery(svsql);
                this.dgvService.AutoGenerateColumns = false;
                this.dgvService.DataSource = ds3.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sql = "select * from Room where Category like '" + this.txtAutoSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

        private void Reservation_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AutoIdGenerate()
        {
            double id = 0;

            //ID
            string sql1 = "select BId from Booking order by BId desc;";
            DataTable dt1 = this.Da.ExecuteQueryTable(sql1);
            string I = dt1.Rows[0]["BId"].ToString();
            var ID = Convert.ToDouble(I);
            id = ID + 1;
            txtBId.Text = Convert.ToString(id);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(this.txtBId.Text) || String.IsNullOrEmpty(this.txtRId.Text) || String.IsNullOrEmpty(this.dtpCheckIn.Text) || 
                    String.IsNullOrEmpty(this.dtpCheckOut.Text) || String.IsNullOrEmpty(this.txtDay.Text) || String.IsNullOrEmpty(this.txtFId.Text) || 
                    String.IsNullOrEmpty(this.txtSId.Text) || String.IsNullOrEmpty(this.txtCName.Text) || String.IsNullOrEmpty(this.txtAdd.Text) || 
                    String.IsNullOrEmpty(this.txtPhone.Text) || String.IsNullOrEmpty(this.txtNID.Text) || String.IsNullOrEmpty(this.txtTotal.Text) || 
                    String.IsNullOrEmpty(this.txtAdv.Text) || String.IsNullOrEmpty(this.txtRemaining.Text))
                {
                    MessageBox.Show("For reservation please fill all the information.");
                    return;
                }
                else
                {
                    string query = "insert into Booking values (" + this.txtBId.Text + ", " + this.txtRId.Text + ", '" + this.dtpCheckIn.Text + "', '" +
                        this.dtpCheckOut.Text + "', " + this.txtFId.Text + ", " +
                        this.txtSId.Text + ", '" + this.txtCName.Text + "', '" + this.txtAdd.Text + "', '" +
                        this.txtPhone.Text + "', '" + this.txtNID.Text + "', " + this.txtTotal.Text + ", " +
                        this.txtAdv.Text + ", " + this.txtRemaining.Text + ");";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Data Inserted In Booking Table.");
                        
                        try
                        {
                            //Update In Room Table
                            string update = "UPDATE Room SET IsBooked = 'Yes', BId = " + this.txtBId.Text + " WHERE RId = " + this.txtRId.Text + "";
                            int count1 = this.Da.ExecuteDML(update);

                            if (count1 == 1)
                            {
                                MessageBox.Show("Data Updated In Room Table Successfully.");
                            }
                            else
                            {
                                MessageBox.Show("Data Upgradation Failed In Room Table.");
                            }
                        }
                        catch (Exception exc)
                        {
                            MessageBox.Show("Error: " + exc.Message);
                        }

                        this.ClearContent();
                        this.AutoIdGenerate();
                        this.PopulateGridView();
                    }
                    else
                    {
                        MessageBox.Show("Data Insertion Failed In Booking Table.");
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnTCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double total = 0;               
                string day = this.txtDay.Text;

                var D = Convert.ToDouble(day);
                //Room Cost
                string sql1 = "select RoomCost from room where RId = " + this.txtRId.Text + ";";
                DataTable dt1 = this.Da.ExecuteQueryTable(sql1);
                string RoomCost = dt1.Rows[0]["RoomCost"].ToString();
                var RCost = Convert.ToDouble(RoomCost);
                total = total + RCost * D;
                //Food Cost
                string sql2 = "select FPackageCost from FoodPackage where FId = " + this.txtFId.Text + ";";
                DataTable dt2 = this.Da.ExecuteQueryTable(sql2);
                string FoodCost = dt2.Rows[0]["FPackageCost"].ToString();
                var FCost = Convert.ToDouble(FoodCost);
                total = total + FCost * D;
                //Service Cost
                string sql3 = "select SPackageCost from ServicePackage where SId = " + this.txtSId.Text + ";";
                DataTable dt3 = this.Da.ExecuteQueryTable(sql3);
                string ServiceCost = dt3.Rows[0]["SPackageCost"].ToString();
                var SCost = Convert.ToDouble(ServiceCost);
                total = total + SCost;
                //total
                txtTotal.Text = Convert.ToString(total);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }

        }

        private void btnRCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double remain = 0;
                //total
                string total = this.txtTotal.Text;
                var T = Convert.ToDouble(total);
                //advance
                string adv = this.txtAdv.Text;
                var A = Convert.ToDouble(adv);

                remain = T - A;
                //remaining
                txtRemaining.Text = Convert.ToString(remain);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ClearContent()
        {
            this.txtRId.Text = "";
            this.dtpCheckIn.Text = "";
            this.dtpCheckOut.Text = "";
            this.txtDay.Text = "";
            this.txtFId.Text = "";
            this.txtSId.Text = "";
            this.txtCName.Text = "";
            this.txtAdd.Text = "";
            this.txtPhone.Text = "";
            this.txtNID.Text = "";
            this.txtTotal.Text = "";
            this.txtAdv.Text = "";
            this.txtRemaining.Text = "";
            this.txtAutoSearch.Text = "";

            //this.txtId.ReadOnly = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearContent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}
