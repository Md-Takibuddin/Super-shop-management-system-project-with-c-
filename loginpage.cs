using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SUNNAH_STATION_PROJECT
{
    public partial class loginpage : Form
    {
        public loginpage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                conn.Open();
                string checkemail = "SELECT * FROM Signup WHERE Email = '" + txtUserName.Text + "' and Password = '"+txtpassword.Text+"'";
                SqlCommand cmd = new SqlCommand(checkemail, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    new welcome().Show();
                    this.Hide();
                    
                    

                }
                else
                {
                    MessageBox.Show("The User name or password you entered is incorrect, try again");
                    txtpassword.Clear();
                    txtUserName.Clear();
                    txtUserName.Focus();
                }
                conn.Close();


            }
            catch
            {
                MessageBox.Show ("Invalid Email Or Password");
            }
         

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           new signup().Show();
           this.Hide();
        }

        
    }
}
