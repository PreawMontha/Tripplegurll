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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form Admin = new Home();
            Admin.Show();
            this.Hide();
        }

        private void btn_order_Click(object sender, EventArgs e)
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
                string sqlCmd = "SELECT * FROM success WHERE 1 ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                //cmd.Parameters.AddWithValue("@ctm", txt_Customerid.Text); //CustomerID = @ctm
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

        private void btn_export1_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);//สร้าง workbook เปล่า
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);//ไปที่ sheet1

            //Adding the Columns.
            int col_i = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                xlWorkSheet.Cells[1, col_i] = column.HeaderText;
                col_i++;
            }

            //Adding the Rows.
            int row_i = 2;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                col_i = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        xlWorkSheet.Cells[row_i, col_i] = cell.Value.ToString();
                    }
                    col_i++;
                }
                row_i++;
            }
            SaveFileDialog opfd = new SaveFileDialog(); //สร้างออบเจค OpenFileDialog 
            DialogResult user_choose = opfd.ShowDialog(); //แสดงออกมาให้ user เห็น
                                                          //ถ้าเลือก OK
            if (user_choose == DialogResult.OK)
            {
                string file_name = opfd.FileName;

                xlWorkBook.SaveAs(file_name, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Excel file created");
        }

        private void btn_cudtomers_Click(object sender, EventArgs e)
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
                string sqlCmd = "SELECT * FROM CUSTOMERS WHERE 1 ";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
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

        private void btn_export2_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);//สร้าง workbook เปล่า
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);//ไปที่ sheet1
            
            //Adding the Columns.
            int col_i = 1;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                xlWorkSheet.Cells[1, col_i] = column.HeaderText;
                col_i++;
            }

            //Adding the Rows.
            int row_i = 2;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                col_i = 1;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        xlWorkSheet.Cells[row_i, col_i] = cell.Value.ToString();
                    }
                    col_i++;
                }
                row_i++;
            }
            SaveFileDialog opfd = new SaveFileDialog(); //สร้างออบเจค OpenFileDialog 
            DialogResult user_choose = opfd.ShowDialog(); //แสดงออกมาให้ user เห็น
                                                          //ถ้าเลือก OK
            if (user_choose == DialogResult.OK)
            {
                string file_name = opfd.FileName;

                xlWorkBook.SaveAs(file_name, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
            }

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Excel file created");
        }

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
            catch (Exception )
            {
                
            }
            //---------------------------------------------
            try
            {
                string sqlCmd = "DELETE FROM success WHERE CustomerID = @cidt";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);

                cmd.Parameters.AddWithValue("@cidt", textBox1.Text);//ขึ้นอยู่กับ sqlCmd เติมค่า

                cmd.ExecuteNonQuery(); //ส่ง SQL ไป
                MessageBox.Show("ลบสำเร็จ");
                conn.Close();//ปิด connection เพื่อกัน memory leak
            }
            catch (Exception)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                
            }
            //---------------------------------------------
            try
            {
                string sqlCmd = "DELETE FROM Customers WHERE CustomerID = @cid";
                MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
                cmd.Parameters.AddWithValue("@cid", textBox1.Text);//ขึ้นอยู่กับ sqlCmd เติมค่า

                cmd.ExecuteNonQuery(); //ส่ง SQL ไป
                MessageBox.Show("ลบสำเร็จ");
                conn.Close();//ปิด connection เพื่อกัน memory leak
            }
            catch (Exception)
            {

            }
        }
    }
}
