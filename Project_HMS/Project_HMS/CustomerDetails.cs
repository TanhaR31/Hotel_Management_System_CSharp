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
    public partial class CustomerDetails : Form
    {
        private DataAccess Da { get; set; }

        public CustomerDetails()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }

        private void PopulateGridView(string sql = "select * from Booking;")
        {
            try
            {
                DataSet ds1 = this.Da.ExecuteQuery(sql);
                this.dgvCustomer.AutoGenerateColumns = false;
                this.dgvCustomer.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.txtCName.Text) || String.IsNullOrEmpty(this.txtAdd.Text) || String.IsNullOrEmpty(this.txtNID.Text) || String.IsNullOrEmpty(this.txtPhone.Text) )
                {
                    MessageBox.Show("To Update please fill all the information.");
                    return;
                }
                string query = "update Booking set CName = '" + this.txtCName.Text + "', CPhone = '" + this.txtPhone.Text + "', CAdd = '" + this.txtAdd.Text + "', CNID = '" + this.txtNID.Text + "' where CNID = " + this.txtNID.Text + ";";

                int count = this.Da.ExecuteDML(query);

                if (count == 1)
                {
                    MessageBox.Show("Customer Info Updated Successfully.");
                }
                else
                {
                    MessageBox.Show("Customer Upgradation Failed.");
                }

                this.PopulateGridView();
                this.ClearContent();
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

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            this.txtCName.Text = this.dgvCustomer.CurrentRow.Cells["CName"].Value.ToString();
            this.txtPhone.Text = this.dgvCustomer.CurrentRow.Cells["CPhone"].Value.ToString();
            this.txtAdd.Text = this.dgvCustomer.CurrentRow.Cells["CAdd"].Value.ToString();
            this.txtNID.Text = this.dgvCustomer.CurrentRow.Cells["CNID"].Value.ToString();
        }

        private void ClearContent()
        {
            this.txtCName.Text = "";
            this.txtPhone.Text = "";
            this.txtAdd.Text = "";
            this.txtNID.Text = "";
        }

        private void CustomerDetails_FormClosed(object sender, FormClosedEventArgs e)
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
