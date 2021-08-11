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
            conn.Close();

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

        private void updatevisible (bool a)
        {
            
            label7.Visible = a;
            label8.Visible = a;
            label9.Visible = a;
            label10.Visible = a;
            label11.Visible = a;
            label12.Visible = a;
            nameboxpic.Visible = a;
            namebox.Visible = a;
            idboxpic.Visible = a;
            idbox.Visible = a;
            categoriesbox.Visible = a;
            categoriesboxpic.Visible = a;
            amountbox.Visible = a;
            amountboxpic.Visible = a;
            pricebox.Visible = a;
            priceboxpic.Visible = a;
            statusboxpic.Visible = a;
            statusbox.Visible = a;
            

        }
        private void producttable_CellClick (object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                string a = producttable.Rows[e.RowIndex].Cells[0].Value.ToString();
                string b = producttable.Rows[e.RowIndex].Cells[1].Value.ToString();
                string c = producttable.Rows[e.RowIndex].Cells[2].Value.ToString();
                string f = producttable.Rows[e.RowIndex].Cells[4].Value.ToString();
                string d = producttable.Rows[e.RowIndex].Cells[3].Value.ToString();
                string g = producttable.Rows[e.RowIndex].Cells[5].Value.ToString();

                namebox.Text = a;            
                idbox.Text = b;       
                categoriesbox.Text = g;                
                amountbox.Text = c;                
                statusbox.Text = f;                
                pricebox.Text = d;

                
            }
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
            add.Visible = x;
            Cancel.Visible = x;
            


        }

        private void addbt_Click(object sender, EventArgs e)
        {
            //visible
            deletebtn.Visible = false;
            addproduct(true);
            productbuttion(false);
            updatevisible(false);
            SaveandUpdate.Visible = false;
            updatecancle.Visible = false;
            deletcancle.Visible = false;

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
                int am;

                  


                if (int.TryParse(amount, out am) && int.TryParse(price, out am))
                    {


                    dbconn("insert into Product (Name,ID, amount, Price,Status,Categories) values('" + name + "','" + id + "','" + amount + "', '" + price + "', '" + status + "','" + categories + "')");

                            if (row == 1)
                            {
                                MessageBox.Show("Product added Successfully");
                            
                                textBox1.Clear();
                                textBox2.Clear();
                                textBox3.Clear();
                                textBox4.Clear();
                                textBox5.Clear();
                                row = 0;
                            }

                            else
                            {
                                MessageBox.Show("Try Again");
                            }
                            

                     }
                else
                {
                    MessageBox.Show("INVALID Data type");
                }
                
                

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

        private void editbt_Click(object sender, EventArgs e)
        {
            updatevisible(true);
            SaveandUpdate.Visible = true;
            updatecancle.Visible = true;
            deletebtn.Visible = false;
            deletcancle.Visible = false;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            updatevisible(false);
            productbuttion(true);
            table1();
            updatecancle.Visible = false;
            SaveandUpdate.Visible = false;
        }

        int row;
        private void dbconn (string q)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
            conn.Open();
            string qu = q; 
            SqlCommand cmd = new SqlCommand(qu, conn);
            row = cmd.ExecuteNonQuery();
            conn.Close();
        }
        private void SaveandUpdate_Click(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(namebox.Text)
                || String.IsNullOrEmpty(idbox.Text)
                || String.IsNullOrEmpty(amountbox.Text)
                || String.IsNullOrEmpty(pricebox.Text)
                || String.IsNullOrEmpty(statusbox.Text)
               )
            {
                MessageBox.Show(" Please Provide all informations");
            }
            else
            {
                int check;

                if (int.TryParse(amountbox.Text, out check) && int.TryParse(pricebox.Text, out check))
                {

                   dbconn("update  Product set Name= '" + namebox.Text + "' , amount = '" + amountbox.Text + "', Price='" + pricebox.Text + "' ," +
                       "Status='" + statusbox.Text + "', Categories='" + categoriesbox.Text + "' where id ='" + idbox.Text + "'");
                    if (row == 1)
                    {
                        MessageBox.Show("Product info updated Successfully");
                        namebox.Clear();
                        idbox.Clear();
                        categoriesbox.Clear();
                        amountbox.Clear();
                        statusbox.SelectedItem = null;
                        pricebox.Clear();
                        table1();
                        row = 0;


                    }
                    else
                    {
                        MessageBox.Show("Try Again");
                    }

                   
                }
                else
                {
                    MessageBox.Show("INVALID Data type","WARNING");
                }
            }
        }

        private void deletebt_Click(object sender, EventArgs e)
        {
            //visible
            deletebtn.Visible = true;
            updatevisible(true);
            SaveandUpdate.Visible = false;
            updatecancle.Visible = false;
            deletcancle.Visible = true;
            //visible end



        }

        private void deleteancle_Click(object sender, EventArgs e)
        {
            updatevisible(false);
            deletebtn.Visible = false;
            deletcancle.Visible = false;
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {

            if ( idbox.Text == "")
            {
                MessageBox.Show("Select the row you want to delete.");
            }
            else
            {
               
                string dq = "delete from Product where ID ='" +idbox.Text + "'";
                dbconn(dq);
                table1();
                namebox.Clear();
                idbox.Clear();
                categoriesbox.Clear();
                amountbox.Clear();
                statusbox.SelectedItem = null;
                pricebox.Clear();
                table1();
                row = 0;

            }
        }
    }
}
