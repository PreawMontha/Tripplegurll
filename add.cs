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

namespace Tripplegurll
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog opfd = new OpenFileDialog(); //สร้างออบเจค OpenFileDialog 
            DialogResult user_choose = opfd.ShowDialog(); //แสดงออกมาให้ user เห็น
            //ถ้าเลือก OK
            if (user_choose == DialogResult.OK)
            {
                //opfd.FileName ตำแหน่งไฟล์ของไฟล์ที่เลือก แสดงที่ textBox
                textBox1.Text = opfd.FileName;
                //สร้าง ออบเจค image จาก ตำแหน่งไฟล์
                Image img = Image.FromFile(textBox1.Text);
                //กำหนด รูปภาพใหม่ที่ user เลือกไปที่ picturebox
                pbb_bill.Image = img;
            }
        }
        //-----------------------------------บันทึกข้อมูลลง Customers-------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "Message", MessageBoxButtons.OKCancel);

            MySqlConnection conn;
            string server = "localhost";
            string database = "Tripplegurll";
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
                string sqlCmd = "INSERT INTO customers VALUES (@customerid, @customername, @phone, @address, @total)";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@customerid", txt_ID.Text);
                cmd.Parameters.AddWithValue("@customername", txt_name.Text);
                cmd.Parameters.AddWithValue("@phone", txt_phone.Text);
                cmd.Parameters.AddWithValue("@address", txt_address.Text);
                cmd.Parameters.AddWithValue("@total", txt_total.Text);

                cmd.ExecuteNonQuery(); //ส่ง SQL ไป
                conn.Close();//ปิด connection เพื่อกัน memory leak
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form report_from = new report();
            report_from.Show();
            this.Hide();
        }
        //---------------------------เก็บค่า total ไว้ใน DataGridView-------------------------------
        private void add_Load(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "tripplegurll";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            conn = new MySqlConnection(connectionString);
            conn.Open();

            //----------------------------------
            try
            {
                string sqlCmd = "SELECT Price FROM success ORDER BY OrderID DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);

                MySqlDataReader datareader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(datareader);
                dataGridView1.DataSource = dt;

                txt_total.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void add_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            Form shopping_from = new shopping();
            shopping_from.Show();
            this.Hide();
        }
    }
}
