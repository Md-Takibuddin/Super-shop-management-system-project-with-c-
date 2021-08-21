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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new loginpage().Show();
            this.Hide();
        }

        private void signup2_Click(object sender, EventArgs e)
        {
            string Name, Email, Password, SecurityCode;
            Name = textname.Text;
            Email = textemail.Text;
            Password = textpassword.Text;
            SecurityCode = textsc.Text;
           


            if (   String.IsNullOrEmpty(textname.Text)
                || String.IsNullOrEmpty(textemail.Text)
                || String.IsNullOrEmpty(textpassword.Text)
                || String.IsNullOrEmpty(textsc.Text)
               )
            {
                MessageBox.Show(" Please fill full form.");
            }
            else
            {

                SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                conn.Open();
                string checkcode = " delete from code where scode = '" + textsc.Text + "'";
                SqlCommand cmd = new SqlCommand(checkcode, conn);

                int checksc = cmd.ExecuteNonQuery();

                if (checksc == 1)
                {
                    try
                    {
                        string query = "insert into Signup (Name,Email, Password, SecurityCode) values('" + Name + "','" + Email + "', '" + Password + "', '" + SecurityCode + "')";
                        SqlCommand cmd1 = new SqlCommand(query, conn);
                        cmd1.ExecuteNonQuery();
                        MessageBox.Show(" Congratulations. Your Signup is successful.");
                        conn.Close();
                        textname.Clear();
                        textemail.Clear();
                        textpassword.Clear();
                        textsc.Clear();
                    }
                    catch
                    {
                        MessageBox.Show("E-mail ID already Exist.");
                        string query = "insert into code (scode) values('" + SecurityCode + "')";
                        SqlCommand cmd2 = new SqlCommand(query, conn);
                        cmd2.ExecuteNonQuery();

                    }

                }
                else
                {
                    MessageBox.Show("Invalid Code. Try Again");
                }
            }
            

        }
    }
}
