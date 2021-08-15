using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SUNNAH_STATION_PROJECT
{
    public partial class welcome : Form
    {
        public welcome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new dashboard().Show();
            this.Hide();

            new loginpage().Hide();
            dashboard d = new dashboard();
            
            d.dashboardclick();
        }
    }
}
