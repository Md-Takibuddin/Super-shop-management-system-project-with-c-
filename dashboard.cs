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



        public void productbuttion (bool y)
        {
            producttable.Visible = y;
            addbt.Visible = y;
            editbt.Visible = y;
            deletebt.Visible = y;
            refrashbt.Visible = y;
            searchcom.Visible = y;
            searchbox.Visible = y;
            Productsearchicon.Visible = y;
            panel2.Visible = y;
        }

        public void table1()
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

            //create table 
            table1();
            //create table end

            //visible 
            productbuttion(true);
            ordertable.Visible = false;
            placeaorderbtn.Visible = false;
            editaorder.Visible = false;
            deleteaorder.Visible = false;
            placeaordervisible(false);
            addproduct(false);

            dashboardvisibale(false);
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            Ordersearchicon.Visible = false;
            OrderSearchbox.Visible = false;
            OrderSearchcom.Visible = false;
            panel3.Visible = false;
            ordereditsavebtn.Visible = false;
            ordereditcancle.Visible = false;
            clearedit();
            //visible-end 


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
            idbox.Visible = a;
            categoriesbox.Visible = a;
            categoriesboxpic.Visible = a;
            amountbox.Visible = a;
            amountboxpic.Visible = a;
            pricebox.Visible = a;
            priceboxpic.Visible = a;            
            statusbox.Visible = a;
            statusboxpic.Visible = a;
            idboxpic.Visible = a;


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
            //panel1.Visible = x;
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
        
        //product insertion
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
            //visible
            updatevisible(true);
            
            SaveandUpdate.Visible = true;
            updatecancle.Visible = true;
            deletebtn.Visible = false;
            deletcancle.Visible = false;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //visible
            updatevisible(false);
            productbuttion(true);
            table1();
            updatecancle.Visible = false;
            SaveandUpdate.Visible = false;
        }

        int row;

        private void dbconn (string q)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                conn.Open();
                string qu = q;
                SqlCommand cmd = new SqlCommand(qu, conn);
                row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Provided ID already exist.");
            }
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
            deletcancle.Visible = true;
            SaveandUpdate.Visible = false;
            updatecancle.Visible = false;
            
            //visible end



        }

        private void deleteancle_Click(object sender, EventArgs e)
        {
            //visible
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

        private void productallvisibal(bool x)
        {
            deletebtn.Visible = x;
            addproduct(x);
            productbuttion(x);
            updatevisible(x);
            SaveandUpdate.Visible = x;
            updatecancle.Visible = x;
            deletcancle.Visible = x;
        }

        private void ordertable1()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
            conn.Open();

            string query = "SELECT TOP (1000) [Oid] ,[Cname],[CMnumber],[Caddress],[Pid],[qty],[bill],[Paidamount],[due],[date],[paymathod],[status],[Adnote]FROM[SSDB].[dbo].[Orderinfo]";

            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

            SqlDataAdapter adp = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            adp.Fill(ds);

            DataTable dt = ds.Tables[0];
            ordertable.DataSource = dt;
            ordertable.Refresh();
            conn.Close();
        }

        private void placeaordervisible(bool y)
        {
            label13.Visible = y;
            label14.Visible = y;
            label15.Visible = y;
            label16.Visible = y;
            label17.Visible = y;
            label18.Visible = y;
            label19.Visible = y;
            label20.Visible = y;
            label21.Visible = y;
            label22.Visible = y;
            label23.Visible = y;
            label24.Visible = y;
            label25.Visible = y;
            orderidtxt.Visible = y;
            dateTimePickerOrder.Visible = y;
            cnametxt.Visible = y;
            cmnumbertxt.Visible = y;
            caddresstxt.Visible = y;
            pidtxt.Visible = y;
            qtytxt.Visible = y;
            billtxt.Visible = y;
            paidamounttxt.Visible = y;
            duetxt.Visible = y;
            notetxt.Visible = y;
            paycombox.Visible = y;
            statcomboxx.Visible = y;
            ordersavebtn.Visible = y;
            addordercanclebtn.Visible = y;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //visibale
            productbuttion(false);
            ordertable1();
            clearedit();
            ordertable.Visible = true;
            placeaorderbtn.Visible = true;
            editaorder.Visible = true;
            deleteaorder.Visible = true;
            placeaordervisible(false) ;
            addproduct(false);
            SaveandUpdate.Visible = false;
            updatecancle.Visible = false;
            deletebtn.Visible = false;
            deletcancle.Visible = false;
            deletebtn.Visible = false;
            updatevisible(false);
            deletcancle.Visible = false;
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            Ordersearchicon.Visible = true;
            OrderSearchbox.Visible = true;
            OrderSearchcom.Visible = true;
            panel3.Visible = true;
            dashboardvisibale(false);





        }

        private void placeaorderbtn_Click(object sender, EventArgs e)
        {
            //visible
            placeaordervisible(true);
            ordertable.Visible = false;
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            Ordersearchicon.Visible = false;
            OrderSearchbox.Visible = false;
            OrderSearchcom.Visible = false;
            panel3.Visible = false;

        }

        private void ordersavebtn_Click(object sender, EventArgs e)
        {
           

            if (String.IsNullOrEmpty(orderidtxt.Text)
                || String.IsNullOrEmpty(dateTimePickerOrder.Text)
                || String.IsNullOrEmpty(cnametxt.Text)
                || String.IsNullOrEmpty(caddresstxt.Text)
                || String.IsNullOrEmpty(pidtxt.Text)
                || String.IsNullOrEmpty(qtytxt.Text)
                || String.IsNullOrEmpty(billtxt.Text)
                || String.IsNullOrEmpty(paidamounttxt.Text)
                || String.IsNullOrEmpty(paycombox.Text)
                || String.IsNullOrEmpty(statcomboxx.Text)
               )
            {
                MessageBox.Show(" Please Provide all informations");
            }
            else
            {

                int check;

                if (int.TryParse(qtytxt.Text, out check) && int.TryParse(billtxt.Text, out check) && int.TryParse(paidamounttxt.Text, out check) && int.TryParse(duetxt.Text, out check))
                {


                    dbconn("insert into Orderinfo(Oid, Cname, CMnumber, Caddress, Pid, qty, bill, Paidamount, due, date, paymathod, status, Adnote,checkcon)" +
                        " values('" + orderidtxt.Text + "', '" + cnametxt.Text + "','" + cmnumbertxt.Text + "', '" + caddresstxt.Text + "', '" + pidtxt.Text + "', '" + qtytxt.Text + "', '" + billtxt.Text + "', '" + paidamounttxt.Text + "', '" + duetxt.Text + "', '" + dateTimePickerOrder.Text + "', '" + paycombox.Text + "', '" + statcomboxx.Text + "', '" + notetxt.Text + "','0')");

                    if (row == 1)
                    {

                        MessageBox.Show("Order added Successfully.");
                        row = 0;
                    
                     
                        string st1 = statcomboxx.Text;
                        string st2 = "Confirmed";
                         

                        if (String.Compare(st1, st2) == 0)
                        {
                            

                           dbconn("UPDATE Product set amount = amount - '"+qtytxt.Text+"' where ID = '" + pidtxt.Text + "';");
                           dbconn("UPDATE Orderinfo set checkcon = '1' where oid ='" + orderidtxt.Text + "';");
                          

                        }
                        
                        clearedit();
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

        private void addordercanclebtn_Click(object sender, EventArgs e)
        {
            placeaordervisible(false);
            ordertable.Visible = true;
            ordertable1();
            clearedit();
            OrderSearchbox.Visible = true;
            OrderSearchcom.Visible = true;
            panel3.Visible = true;
            Ordersearchicon.Visible = true;
        }

        private void clearedit()
        {
            orderidtxt.Clear();
            cnametxt.Clear();
            cmnumbertxt.Clear();
            caddresstxt.Clear();
            pidtxt.Clear();
            qtytxt.Clear();
            billtxt.Clear();
            paidamounttxt.Clear();
            duetxt.Clear();
            notetxt.Clear();
            paycombox.SelectedItem = null;
            statcomboxx.SelectedItem = null;
        }


        string Oid_v, Cname_v, CMnumber_v, Caddress_v, Pid_v, qty_v, bill_v, Paidamount_v,date_v, paymathod_v, due_v = "",   status_v, Adnote_v="";

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        public void dashboardvisibale(bool x)
        {

            totalproduct.Visible = x;
            totalorder.Visible = x;
            totalreceived.Visible = x;
            pendingnumber.Visible = x;
            confirmednumber.Visible = x;
            placednumber.Visible = x;
            deliverednumber.Visible = x;
            pictureBox5.Visible = x;
           
            dashbordtopbar.Visible = x;
        }

        public void dashboardclick()
        {
            ordertable.Visible = false;
            placeaorderbtn.Visible = false;
            editaorder.Visible = false;
            deleteaorder.Visible = false;
            Ordersearchicon.Visible = false;
            OrderSearchbox.Visible = false;
            OrderSearchcom.Visible = false;
            panel3.Visible = false;
            productbuttion(false);
            dashboardvisibale(true);


            //total Product
        
            SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
            conn.Open();

            string query1 = "select * from Product";
            SqlCommand cmd1 = new SqlCommand(query1, conn);
            cmd1.ExecuteNonQuery();
            SqlDataAdapter adp1 = new SqlDataAdapter(cmd1);
            DataSet ds1 = new DataSet();
            adp1.Fill(ds1);
            DataTable dt_tp = ds1.Tables[0];
            totalproduct.Text = dt_tp.Rows.Count.ToString();

            //-------------


            //total order

            string query2 = "SELECT * FROM Orderinfo";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            cmd2.ExecuteNonQuery();
            SqlDataAdapter adp2 = new SqlDataAdapter(cmd2);
            DataSet ds2 = new DataSet();
            adp2.Fill(ds2);
            DataTable dt_to = ds2.Tables[0];
            totalorder.Text = dt_to.Rows.Count.ToString();

            //-------------

            //total paidamount
            ordertable1();
            string query3 = "select sum (Paidamount) from orderinfo;";
            SqlCommand cmd3 = new SqlCommand(query3, conn);
            cmd3.ExecuteNonQuery();
            SqlDataAdapter adp3 = new SqlDataAdapter(cmd3);
            DataSet ds3 = new DataSet();
            adp3.Fill(ds3);
            DataTable dt_tr = ds3.Tables[0];
            ordertable.DataSource = dt_tr;
            //ordertable.Refresh();
            totalreceived.Text = Convert.ToString(ordertable.Rows[0].Cells[0].Value);

            //----------------
            string query4 = "SELECT * FROM Orderinfo where status = 'Pending';";
            SqlCommand cmd4 = new SqlCommand(query4, conn);
            cmd4.ExecuteNonQuery();
            SqlDataAdapter adp4 = new SqlDataAdapter(cmd4);
            DataSet ds4 = new DataSet();
            adp4.Fill(ds4);
            DataTable dt_4 = ds4.Tables[0];
            pendingnumber.Text = dt_4.Rows.Count.ToString();
            //----------------
            string query5 = "SELECT * FROM Orderinfo where status = 'Confirmed';";
            SqlCommand cmd5 = new SqlCommand(query5, conn);
            cmd5.ExecuteNonQuery();
            SqlDataAdapter adp5 = new SqlDataAdapter(cmd5);
            DataSet ds5 = new DataSet();
            adp5.Fill(ds5);
            DataTable dt_5 = ds5.Tables[0];
            confirmednumber.Text = dt_5.Rows.Count.ToString();
            //----------------
            string query6 = "SELECT * FROM Orderinfo where status = 'Placed';";
            SqlCommand cmd6 = new SqlCommand(query6, conn);
            cmd6.ExecuteNonQuery();
            SqlDataAdapter adp6 = new SqlDataAdapter(cmd6);
            DataSet ds6 = new DataSet();
            adp6.Fill(ds6);
            DataTable dt_6 = ds6.Tables[0];
            placednumber.Text = dt_6.Rows.Count.ToString();
            //----------------
            string query7 = "SELECT * FROM Orderinfo where status = 'Delivered';";
            SqlCommand cmd7 = new SqlCommand(query7, conn);
            cmd7.ExecuteNonQuery();
            SqlDataAdapter adp7 = new SqlDataAdapter(cmd7);
            DataSet ds7 = new DataSet();
            adp7.Fill(ds7);
            DataTable dt_7 = ds7.Tables[0];
            deliverednumber.Text = dt_7.Rows.Count.ToString();


            conn.Close();
        }
        
        private void button4_Click_1(object sender, EventArgs e)
        {
            dashboardclick();
            dashboardvisibale(true);


            //visibale
            addproduct(false);
            placeaordervisible(false);
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            ordertable.Visible = false;
            updatevisible(false);
            SaveandUpdate.Visible = false;
            updatecancle.Visible = false;
            deletebtn.Visible = false;
            updatevisible(false);
            deletcancle.Visible = false;
            orderedit.Visible = false;
            ordereditcancle.Visible = false;
            ordereditsavebtn.Visible = false;


        }

        private void OrderSearchbox_TextChanged(object sender, EventArgs e)
        {
            SearchOrder(OrderSearchbox.Text);
        }

        public void SearchOrder(String Osearch)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                conn.Open();
                string sq = "select * from Orderinfo where " + OrderSearchcom.Text + " like'%" + Osearch + "%'";

                SqlCommand cmd = new SqlCommand(sq, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                ordertable.DataSource = dt;

                conn.Close();
            }
            catch
            {
                MessageBox.Show("select a colume name ");
            }

        }

        private void searchbox_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(searchbox.Text);
        }

        public void SearchProduct(String search)
        {
            try
            {
                SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                conn.Open();
                string sq = "select * from Product where " + searchcom.Text + " like'%" + search + "%'";

                SqlCommand cmd = new SqlCommand(sq, conn);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adp = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                adp.Fill(ds);

                DataTable dt = ds.Tables[0];
                producttable.DataSource = dt;
                conn.Close();
            }
            catch
            {
                MessageBox.Show("select a colume name");
            }
        }

      

        private void ordereditsavebtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(orderidtxt.Text)
               || String.IsNullOrEmpty(dateTimePickerOrder.Text)
               || String.IsNullOrEmpty(cnametxt.Text)
               || String.IsNullOrEmpty(caddresstxt.Text)
               || String.IsNullOrEmpty(pidtxt.Text)
               || String.IsNullOrEmpty(qtytxt.Text)
               || String.IsNullOrEmpty(billtxt.Text)
               || String.IsNullOrEmpty(paidamounttxt.Text)
               || String.IsNullOrEmpty(paycombox.Text)
               || String.IsNullOrEmpty(statcomboxx.Text)
              )
            {
                MessageBox.Show(" Please Provide all informations");
            }
            else
            {


                int check;
                row = 0;

                if (int.TryParse(qtytxt.Text, out check) && int.TryParse(billtxt.Text, out check) && int.TryParse(paidamounttxt.Text, out check) && int.TryParse(duetxt.Text, out check))
                {


                    dbconn("update Orderinfo set Oid='" + orderidtxt.Text + "' , Cname='" + cnametxt.Text + "', CMnumber='" + cmnumbertxt.Text + "', Caddress='" + caddresstxt.Text + "', Pid='" + pidtxt.Text + "', qty='" + qtytxt.Text + "', bill='" + billtxt.Text + "', Paidamount='" +
                        paidamounttxt.Text + "', due='" + duetxt.Text + "', paymathod='" + paycombox.Text + "', status='" + statcomboxx.Text + "', Adnote= '" + notetxt.Text + "' where Oid='" + orderidtxt.Text + "'");
                    
                    if (row == 1)
                    {

                        MessageBox.Show("Order info Updated Successfully.");

                        string st1 = statcomboxx.Text;
                        string st2 = "Confirmed";
                  
                       int checkcon = 2;
                      
                      try
                        {
                            SqlConnection conn = new SqlConnection(@"Data Source=TAKIBS-WORK-STA;Initial Catalog=SSDB;Integrated Security=True");
                            var sql = "select checkcon from Orderinfo where Oid = @Oid";
                            using (var cmd = new SqlCommand(sql, conn))
                            {
                                cmd.Parameters.AddWithValue("@Oid", int.Parse(orderidtxt.Text));
                                conn.Open();
                                checkcon = (int)cmd.ExecuteScalar();
                                conn.Close();
                            }
                        }
                        catch
                        {
                            MessageBox.Show("error");
                        }

                        
                        if (String.Compare(st1, st2) == 0 && checkcon ==0)
                        {
                            
                            dbconn("UPDATE Product set amount = amount - '" + qtytxt.Text + "' where ID = '" + pidtxt.Text + "';");
                            dbconn("UPDATE Orderinfo set checkcon = '1' where oid = '" + orderidtxt.Text + "';");


                        }

                        clearedit();
                        row = 0;

                    }

                    else
                    {
                        MessageBox.Show("You can not change order id");
                    }


                }
                else
                {
                    MessageBox.Show("INVALID Data type");
                }



            }




        }

        private void ordertable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Oid_v        = ordertable.Rows[e.RowIndex].Cells[0].Value.ToString();
                Cname_v      = ordertable.Rows[e.RowIndex].Cells[1].Value.ToString();
                CMnumber_v   = ordertable.Rows[e.RowIndex].Cells[2].Value.ToString();
                Caddress_v   = ordertable.Rows[e.RowIndex].Cells[3].Value.ToString();
                Pid_v        = ordertable.Rows[e.RowIndex].Cells[4].Value.ToString();
                qty_v        = ordertable.Rows[e.RowIndex].Cells[5].Value.ToString();
                bill_v       = ordertable.Rows[e.RowIndex].Cells[6].Value.ToString();
                Paidamount_v = ordertable.Rows[e.RowIndex].Cells[7].Value.ToString();
                date_v       = ordertable.Rows[e.RowIndex].Cells[9].Value.ToString();
                paymathod_v = ordertable.Rows[e.RowIndex].Cells[10].Value.ToString();
                due_v        = ordertable.Rows[e.RowIndex].Cells[8].Value.ToString();
                status_v     = ordertable.Rows[e.RowIndex].Cells[11].Value.ToString();
                Adnote_v     = ordertable.Rows[e.RowIndex].Cells[12].Value.ToString();



            }
           
        }




        private void deleteaorder_Click(object sender, EventArgs e)
        {
            //visibale
            deleteorder.Visible = true;
            deleteordercancle.Visible = true;
            ordertable.Visible = true;

            placeaordervisible(false);                   
            orderedit.Visible = false;
            ordereditcancle.Visible = false;
            ordereditsavebtn.Visible = false;
            
        }

        private void deleteorder_Click(object sender, EventArgs e)
        {
            if (Oid_v == "")
            {
                MessageBox.Show("Select a row you want to delete.");
            }
            else
            {
                string dq = "delete from Orderinfo where Oid ='" + Oid_v + "'";
                dbconn(dq);
                ordertable1();
                Oid_v = "";
                row = 0;
                MessageBox.Show("Selected Order is Deleted successfully. ");
                clearedit();
            }
        }

        private void deleteordercancle_Click(object sender, EventArgs e)
        {
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            OrderSearchbox.Visible = true;
            OrderSearchcom.Visible = true;
            panel3.Visible = true;
            Ordersearchicon.Visible = true;
        }

        private void editaorder_Click(object sender, EventArgs e)
        {
            orderedit.Visible = true;
            ordereditcancle.Visible = true;
            deleteorder.Visible = false;
            deleteordercancle.Visible = false;
            
            
        }
        private void ordereditcancle_Click(object sender, EventArgs e)
        {
            placeaordervisible(false);
            orderedit.Visible = false;
            ordereditcancle.Visible = false;
            ordereditsavebtn.Visible = false;
            ordertable.Visible = true;
            OrderSearchbox.Visible = true;
            OrderSearchcom.Visible = true;
            panel3.Visible = true;
            Ordersearchicon.Visible = true;
            ordertable1();




        }
        private void orderedit_Click(object sender, EventArgs e)
        {

            placeaordervisible(true);
            ordersavebtn.Visible = false;
            addordercanclebtn.Visible = false;
            ordertable.Visible = false;
            dateTimePickerOrder.Visible = false;
            label14.Visible = false;
            orderedit.Visible = false;
            ordereditsavebtn.Visible = true;
            OrderSearchbox.Visible = false;
            OrderSearchcom.Visible = false;
            panel3.Visible = false;
            Ordersearchicon.Visible = false;



            orderidtxt.Text = Oid_v;
            cnametxt.Text = Cname_v;
            cmnumbertxt.Text = CMnumber_v;
            caddresstxt.Text = Caddress_v;
            pidtxt.Text = Pid_v;
            qtytxt.Text = qty_v;
            billtxt.Text = bill_v;
            paidamounttxt.Text = Paidamount_v;
            duetxt.Text = due_v;
            notetxt.Text = Adnote_v;
            paycombox.Text = paymathod_v;
            statcomboxx.Text = status_v;


        }

       
    }
}
