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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new loginpage().Show();
            this.Hide();
        }

        private void productbuttion (bool y)
        {
            producttable.Visible = y;
            addbt.Visible = y;
            editbt.Visible = y;
            deletebt.Visible = y;
            refrashbt.Visible = y;
        }

        private void table1()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
            conn.Open();

            string query = "select * from Product";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];

            producttable.DataSource = dt;
            producttable.Refresh();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            //visible 
            productbuttion(true);

            //visible-end 


            //create table 

            table1();
            
            //create table end


        }

        private void producttable_CellClick (object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addproduct(bool x)
        {
            panel1.Visible = x;
            Nametextbox.Visible = x;
            textBox1.Visible = x;
            label2.Visible = x;
            textBox2.Visible = x;
            label3.Visible = x;
            textBox3.Visible = x;
            label4.Visible = x;
            textBox4.Visible = x;
            label5.Visible = x;
            textBox5.Visible = x;
            label6.Visible = x;
            comboBox1.Visible = x;
        }

        private void addbt_Click(object sender, EventArgs e)
        {

            //visible

            addproduct(true);
            productbuttion(false);
                  
            //visible end

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name, id, amount, status, categories, price;

            name = textBox1.Text;
            id = textBox2.Text;
            categories = textBox3.Text;
            amount = textBox4.Text;
            price = textBox5.Text;
            status = comboBox1.Text;


            if (String.IsNullOrEmpty(textBox1.Text)
                || String.IsNullOrEmpty(textBox2.Text)
                || String.IsNullOrEmpty(textBox4.Text)
                || String.IsNullOrEmpty(textBox5.Text)
                || String.IsNullOrEmpty(comboBox1.Text)
               )
            {
                MessageBox.Show(" Please Provide all informations");
            }
            else
            {

                    SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                    conn.Open();
                    string query1 = "insert into Product (Name,ID, amount, Price,Status,Categories) values('" + name + "','" + id + "','" + amount + "', '" + price + "', '" + status + "','" + categories + "')";
                    SqlCommand cmd = new SqlCommand(query1, conn);
                    int row = cmd.ExecuteNonQuery();
                    if (row == 1)
                    {
                        MessageBox.Show("Product added Successfully");

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox5.Clear();

                    }
                    else
                    {
                        MessageBox.Show("Try Again ");
                    }
                    conn.Close();
                
                

            }


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            addproduct(false);
            productbuttion(true);
            table1();
        }
        private void refrashbt_Click(object sender, EventArgs e)
        {
                table1();

        }
    }
}
