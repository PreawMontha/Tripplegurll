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
    public partial class shopping : Form
    {
        public shopping()
        {
            InitializeComponent();
            MessageBox.Show("กรุณาสร้าง ID ที่ด้านบนก่อนการซื้อสินค้า", "Message", MessageBoxButtons.OK);
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
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
                string insertto = "INSERT INTO success (CustomerID, Price) VALUES (@cID, @price)";
                MySqlCommand cmd = new MySqlCommand(insertto, conn);

                int autoAdd;
                if (txt_CreateID.Text == null ||
                    txt_CreateID.Text == "") autoAdd = 0;
                else autoAdd = int.Parse(txt_CreateID.Text);

                cmd.Parameters.AddWithValue("@cID", autoAdd);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();

                Form shopping = new add();
                shopping.Show();
                this.Hide();
            }
            catch (Exception)
            {

            }
        }

        private void txt_delete_MouseEnter(object sender, EventArgs e)
        {
            if (txt_delete.Text == "Enter OrderID")
            {
                txt_delete.Text = "";
                txt_delete.ForeColor = Color.Black;
            }
        }

        private void txt_delete_MouseLeave(object sender, EventArgs e)
        {
            if (txt_delete.Text == "")
            {
                txt_delete.Text = "Enter OrderID";
                txt_delete.ForeColor = Color.Black;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_total.Text = "";
            txt_delete.Text = "";
            nud_amount1.Value = 0;
            nud_amount2.Value = 0;
            nud_amount3.Value = 0;
            nud_amount4.Value = 0;
            nud_amount5.Value = 0;
            nud_amount6.Value = 0;
            nud_amount7.Value = 0;
        }

        private int price = 0, price1 = 230, price2 = 150;

        private void nud_amount2_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void nud_amount3_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void nud_amount4_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void nud_amount5_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void nud_amount6_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void nud_amount7_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }

        private void shopping_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //--------------------------------ลบรายการสินค้า-----------------------------------------
        private void btn_Delete_Click(object sender, EventArgs e)
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
                string sqlCmd = "DELETE FROM success WHERE OrderID = @oid";//แก้ที่นี่
               
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);

                cmd.Parameters.AddWithValue("@oid", txt_delete.Text);//ขึ้นอยู่กับ sqlCmd เติมค่า

                cmd.ExecuteNonQuery(); //ส่ง SQL ไป
                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว");
                conn.Close();//ปิด connection เพื่อกัน memory leak
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
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

            //แสดงสินค้าในDataGridView
            try
            {
                string sqlCmd = "SELECT * FROM success WHERE customerID = @cid";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@cid", txt_CreateID.Text);
                MySqlDataReader reader = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception)
            {
                
            }

            try
            {
                string insertto = "INSERT INTO success (CustomerID, Price) VALUES (@cID, @price)";
                MySqlCommand cmd = new MySqlCommand(insertto, conn);

                int autoAdd;
                if (txt_CreateID.Text == null ||
                    txt_CreateID.Text == "") autoAdd = 0;
                else autoAdd = int.Parse(txt_CreateID.Text);

                cmd.Parameters.AddWithValue("@cID", autoAdd);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.ExecuteNonQuery();

            }
            catch (Exception)
            {
                
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
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

        private void shopping_Load(object sender, EventArgs e)
        {

        }

        private void shopping_Click(object sender, EventArgs e)
        {

        }

        private void nud_amount1_ValueChanged(object sender, EventArgs e)
        {
            sum_nud();
        }
        //----------------------------                                                                                                                                                                                                                                                                                                                                      ---สร้างตัวแปรเก็บข้อมูล Total--------------------------
        private void sum_nud()
        {
            price = 0;

            if (nud_amount1.Value != 0) price += (int)nud_amount1.Value * price1;
            if (nud_amount2.Value != 0) price += (int)nud_amount2.Value * price1;
            if (nud_amount3.Value != 0) price += (int)nud_amount3.Value * price1;
            if (nud_amount4.Value != 0) price += (int)nud_amount4.Value * price2;
            if (nud_amount5.Value != 0) price += (int)nud_amount5.Value * price2;
            if (nud_amount6.Value != 0) price += (int)nud_amount6.Value * price2;
            if (nud_amount7.Value != 0) price += (int)nud_amount7.Value * price2;

            txt_total.Text = "" + price;
        }
    }
}
