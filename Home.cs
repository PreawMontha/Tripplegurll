using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tripplegurll
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Shophome_Click(object sender, EventArgs e)
        {
            Form shopping_from = new shopping();
            shopping_from.Show();
            this.Hide();
        }

        private void lbb_Shop_Click(object sender, EventArgs e)
        {
            Form shopping_from = new shopping();
            shopping_from.Show();
            this.Hide();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Form contact_from = new contact();
            contact_from.Show();
            this.Hide();
        }

        private void lbb_Contack_Click(object sender, EventArgs e)
        {
            Form login_from = new Login();
            login_from.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
