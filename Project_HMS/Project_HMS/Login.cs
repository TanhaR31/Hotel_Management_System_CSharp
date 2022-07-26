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
    public partial class Login : Form
    {
        private DataAccess Da { get; set; }
        public Login()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string sql = "select * from login where UId = " + this.txtUserid.Text + " and Password = '" + this.txtPassword.Text + "';";
            try
            {
                DataSet ds = this.Da.ExecuteQuery(sql);
                if(ds.Tables[0].Rows.Count == 1)
                {
                    MessageBox.Show("Login Valid");
                    if(ds.Tables[0].Rows[0][3].ToString().Equals("Owner"))
                    {

                    }
                    else
                    {
                        ManagerDashboard md = new ManagerDashboard();
                        md.Visible = true;                                            
                    }
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Login Invalid");
                    this.lblWrong.Visible = true;
                    this.txtUserid.Text = "";
                    this.txtPassword.Text = "";
                }                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error: " + exc.Message);
            }
            this.Da.Sqlcon.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserid.Text = "";
            this.txtPassword.Text = "";
        }
    }
}
