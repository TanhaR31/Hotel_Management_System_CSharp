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
    public partial class BillHistory : Form
    {
        private DataAccess Da { get; set; }

        public BillHistory()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }

        private void PopulateGridView()
        {
            try
            {
                string sql = "select * from Booking;";
                DataSet ds1 = this.Da.ExecuteQuery(sql);
                this.dgvBooking.AutoGenerateColumns = false;
                this.dgvBooking.DataSource = ds1.Tables[0];
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void BillHistory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void dgvBooking_DoubleClick(object sender, EventArgs e)
        {
            this.txtBId.Text = this.dgvBooking.CurrentRow.Cells["BId"].Value.ToString();
            this.txtRId.Text = this.dgvBooking.CurrentRow.Cells["RId"].Value.ToString();
            this.txtCName.Text = this.dgvBooking.CurrentRow.Cells["CName"].Value.ToString();
            this.txtPhone.Text = this.dgvBooking.CurrentRow.Cells["CPhone"].Value.ToString();
            this.dtpCheckIn.Text = this.dgvBooking.CurrentRow.Cells["CheckIn"].Value.ToString();
            this.dtpCheckOut.Text = this.dgvBooking.CurrentRow.Cells["CheckOut"].Value.ToString();
            this.txtAdvance.Text = this.dgvBooking.CurrentRow.Cells["Advance"].Value.ToString();
            this.txtRemaining.Text = this.dgvBooking.CurrentRow.Cells["Remaining"].Value.ToString();
            this.txtTotal.Text = this.dgvBooking.CurrentRow.Cells["Total"].Value.ToString();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double rv = 0;
                string remain = this.txtRemaining.Text;
                var R = Convert.ToDouble(remain);
                string npay = this.txtNPaid.Text;
                var N = Convert.ToDouble(npay);
                rv = N - R;
                txtReturn.Text = Convert.ToString(rv);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }


        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                int x = 100, y = 100; //start position

                //Image newImage = Image.FromFile("logo.png");
                int width = 80, height = 50;
                //int ix = x, iy = y; //image position
                //e.Graphics.DrawImage(newImage, ix, iy, width, height);

                x += 0; //left align texts with logo image
                y += height + 30; //some space below logo

                var header = new Font("Calibri", 21, FontStyle.Bold);
                int hdy = (int)header.GetHeight(e.Graphics); //30; //line height spacing

                var fnt = new Font("Times new Roman", 14, FontStyle.Bold);
                int dy = (int)fnt.GetHeight(e.Graphics); //20; //line height spacing

                e.Graphics.DrawString("Hotel Dream", header, Brushes.Black, new PointF(x, y)); y += hdy+hdy;
                e.Graphics.DrawString("Bill Id : " + txtBId.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Room Id : " + txtRId.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Customer Name : " + txtCName.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Phone No : " + txtPhone.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Check In : " + dtpCheckIn.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Check Out : " + dtpCheckOut.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Total : " + txtTotal.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Advance : " + txtAdvance.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Now Paid Amount : " + txtNPaid.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
                e.Graphics.DrawString("Returned Amount : " + txtReturn.Text, fnt, Brushes.Black, new PointF(x, y)); y += dy;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //Update In Room Table
                string update = "UPDATE Room SET IsBooked = 'No' WHERE RId = " + this.txtRId.Text + "";
                int count1 = this.Da.ExecuteDML(update);

                if (count1 == 1)
                {
                    MessageBox.Show("Data Updated In Room Table Successfully.");                   
                }
                else
                {
                    MessageBox.Show("Data Upgradation Failed In Room Table.");
                }

                //Update In Booking Table
                string update1 = "UPDATE Booking SET Advance = "+this.txtTotal.Text+", Remaining = "+0+" WHERE BId = " + this.txtBId.Text + "";
                int count2 = this.Da.ExecuteDML(update1);

                if (count2 == 1)
                {
                    MessageBox.Show("Data Updated In Booking Table Successfully.");
                    this.PopulateGridView();
                }
                else
                {
                    MessageBox.Show("Data Upgradation Failed In Booking Table.");
                }
                this.ClearContent();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
        }

        private void ClearContent()
        {
            this.txtBId.Text = "";
            this.txtRId.Text = "";
            this.dtpCheckIn.Text = "";
            this.txtCName.Text = "";
            this.txtPhone.Text = "";
            this.txtTotal.Text = "";
            this.txtAdvance.Text = "";
            this.txtRemaining.Text = "";
            this.txtNPaid.Text = "";
            this.txtReturn.Text = "";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerDashboard md = new ManagerDashboard();
            md.Visible = true;
            this.Visible = false;
        }
    }
}
