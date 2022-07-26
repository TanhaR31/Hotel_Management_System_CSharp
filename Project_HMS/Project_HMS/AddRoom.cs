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
    public partial class AddRoom : Form
    {
        private DataAccess Da { get; set; }

        public AddRoom()
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
            string sql1 = "select RId from Room order by RId desc;";
            DataTable dt1 = this.Da.ExecuteQueryTable(sql1);
            string I = dt1.Rows[0]["RId"].ToString();
            var ID = Convert.ToDouble(I);
            id = ID + 1;
            txtRId.Text = Convert.ToString(id);
        }

        private void AddRoom_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvRoom_DoubleClick(object sender, EventArgs e)
        {
            this.txtRId.Text = this.dgvRoom.CurrentRow.Cells["RId"].Value.ToString();
            this.txtCategory.Text = this.dgvRoom.CurrentRow.Cells["Category"].Value.ToString();
            this.txtIsBooked.Text = this.dgvRoom.CurrentRow.Cells["IsBooked"].Value.ToString();
            this.txtRCost.Text = this.dgvRoom.CurrentRow.Cells["RoomCost"].Value.ToString();
        }

        private void ClearContent()
        {
            this.txtCategory.Text = "";
            this.txtIsBooked.Text = "";
            this.txtRCost.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtRId.Text) || String.IsNullOrEmpty(this.txtCategory.Text) ||
                String.IsNullOrEmpty(this.txtIsBooked.Text) || String.IsNullOrEmpty(this.txtRCost.Text))
                {
                    MessageBox.Show("To add Room please fill all the information.");
                    return;
                }

                var sql = "select * from Room where RId = " + this.txtRId.Text + ";";
                var ds = this.Da.ExecuteQuery(sql);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    //Update
                    string query = "update Room set Category = '" + this.txtCategory.Text + "', IsBooked = '" +
                                   this.txtIsBooked.Text + "', RoomCost = " + this.txtRCost.Text + " where RId = " +
                                   this.txtRId.Text + ";";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Room Updated Successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Room Upgradation Failed.");
                    }
                }
                else
                {
                    //Insert
                    string query = "insert into Room values (" + this.txtRId.Text + ", '" + this.txtCategory.Text + "', '" +
                               this.txtIsBooked.Text + "', " + this.txtRCost.Text + ", NULL);";

                    int count = this.Da.ExecuteDML(query);

                    if (count == 1)
                    {
                        MessageBox.Show("Room Inserted.");                       
                    }
                    else
                    {
                        MessageBox.Show("Room Insertion Failed.");
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
                var id = this.dgvRoom.CurrentRow.Cells["RId"].Value.ToString();

                string sql = "delete from Room where RId = '" + id + "';";
                int count = this.Da.ExecuteDML(sql);

                if (count == 1)
                {
                    MessageBox.Show("Room " + id + " has been deleted.");
                }
                else
                {
                    MessageBox.Show("Room Deletion Failed.");
                }

                this.PopulateGridView();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}
