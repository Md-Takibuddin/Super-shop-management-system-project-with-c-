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

        private void button3_Click(object sender, EventArgs e)
        {
            //visible 
            producttable.Visible = true;
            addbt.Visible = true;
            editbt.Visible = true;
            deletebt.Visible = true;
            refrashbt.Visible = true;

            //visible-end 


            //create table 

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
            

            //create table end


        }

        private void producttable_CellClick (object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addbt_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            Nametextbox.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label3.Visible = true;
            textBox3.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            label5.Visible = true;
            textBox5.Visible = true;
            label6.Visible = true;
            comboBox1.Visible = true;

        }
    }
}
