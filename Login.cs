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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ptb_Shophome_Click(object sender, EventArgs e)
        {
            Form home_from = new Home();
            home_from.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((txt_username.Text == "admin")&&(txt_password.Text=="1234"))
            {
                Form admin_from = new Admin();
                admin_from.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Username และ Password ของคุณไม่ถูกต้อง", "Message", MessageBoxButtons.OK);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
