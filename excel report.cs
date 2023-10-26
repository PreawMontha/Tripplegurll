using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace Tripplegurll
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        // --------------------------------------แสดงข้อมูลการสั่งซื้อ-------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "tripplegurll";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

            }
            try
            {
                string sqlCmd = "SELECT * FROM success WHERE CustomerID = @cid ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@cid", textBox1.Text); 
                MySqlDataReader reader = cmd.ExecuteReader();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void report_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        // --------------------------------------แสดงข้อมูลลูกค้า----------------------------------------
        private void button2_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "tripplegurll";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception)
            {

            }
            //---------------------------------------------
            try
            {
                string sqlCmd = "SELECT * FROM customers WHERE CustomersName = @ctn ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@ctn", textBox1.Text);
                MySqlDataReader reader = cmd.ExecuteReader();

                System.Data.DataTable dt = new System.Data.DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter Your ID or CustomerName";
                textBox1.ForeColor = Color.DarkGray;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form add_from = new add();
            add_from.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form home_from = new Home();
            home_from.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form home_from = new Home();
            home_from.Show();
            this.Hide();
        }
    }
}
