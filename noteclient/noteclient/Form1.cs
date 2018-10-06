using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using connectmsql;
using MySql.Data.MySqlClient;

namespace noteclient
{
    public partial class Form1 : Form
    {
        //public MySqlConnection connection = new MySqlConnection("Server=95.84.154.71;Database=test;port=3308;User Id=Test;password=JyA2aM3qydPVCfe;SslMode=none;");
        MySqlConnection connection = DBUtils.GetDBConnection();

        public Form1()
        {
            InitializeComponent();    
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Getting Connection ...");
            //MySqlConnection conn = DBUtils.GetDBConnection();
            
            try
            {
                //MessageBox.Show("Openning Connection ...");

                connection.Open();

                MessageBox.Show("Connection successful!");
                
                string[] strings = new string[5];
                Check(connection, ref strings);
                listBox1.Items.AddRange(strings);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }






        private static void Check(MySqlConnection conn, ref string[] strings)
        {
            string sql = "Select id, login, password, email from users";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand();

            // Сочетать Command с Connection.
            cmd.Connection = conn;
            cmd.CommandText = sql;


            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Индекс (index) столбца Emp_ID в команде SQL.
                        int UserIndex = reader.GetOrdinal("id"); // 0
                        

                        long UserId = Convert.ToInt64(reader.GetValue(0));

                        // Столбец Emp_No имеет index = 1.
                        //string empNo = reader.GetString(1);
                        //int empNameIndex = reader.GetOrdinal("Emp_Name");// 2
                        //string empName = reader.GetString(empNameIndex);


                        string UserLogin = reader.GetString(1);
                        string UserPass = reader.GetString(2);
                        string UserEmail = reader.GetString(3);

                        // Индекс (index) столбца Mng_Id в команде SQL.
                        //int mngIdIndex = reader.GetOrdinal("Mng_Id");

                        //long? mngId = null;

                        // Проверить значение данного столбца может являться null или нет.
                        //if (!reader.IsDBNull(mngIdIndex))
                        //{
                        //    mngId = Convert.ToInt64(reader.GetValue(mngIdIndex));
                        //}
                        //Console.WriteLine("--------------------");
                        
                        //MessageBox.Show("empIdIndex:" + UserIndex);
                        //MessageBox.Show("Id:" + UserId);
                        //MessageBox.Show("Login:" + UserLogin);
                        //MessageBox.Show("Pass:" + UserPass);
                        //MessageBox.Show("Email:" + UserEmail);
                        strings[0] = "empIdIndex:" + UserIndex;
                        strings[1] = "Id:" + UserId;
                        strings[2] = "Login:" + UserLogin;
                        strings[3] = "Pass:" + UserPass;
                        strings[4] = "Email:" + UserEmail;



                    }
                }
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
