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
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            AddRoom ar = new AddRoom();
            ar.Visible = true;
            this.Visible = false;
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {
            Reservation rs = new Reservation();
            rs.Visible = true;
            this.Visible = false;
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            CustomerDetails cd = new CustomerDetails();
            cd.Visible = true;
            this.Visible = false;
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            FoodMenu fm = new FoodMenu();
            fm.Visible = true;
            this.Visible = false;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            ExtraService es = new ExtraService();
            es.Visible = true;
            this.Visible = false;
        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            BillHistory bh = new BillHistory();
            bh.Visible = true;
            this.Visible = false;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login lg = new Login();
            lg.Visible = true;
            this.Visible = false;
        }

        private void ManagerDashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
