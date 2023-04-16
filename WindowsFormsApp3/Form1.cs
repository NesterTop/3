using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        DataTable dt;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-AVGELME\STP;Initial Catalog=root;Integrated Security=True");

        int countClick = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 20000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = new DataTable();

            countClick++;
            if (countClick == 3)
            {
                this.Enabled = false;
                countClick = 0;
                timer1.Start();
                new FormCaptha().Show();
            }

            connection.Open();

            string login = textBox1.Text;
            string password = textBox2.Text;

            SqlCommand cmd = new SqlCommand($"select * from users where login = '{login}' and password = '{password}'", connection);
            dt.Load(cmd.ExecuteReader());

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Вы успешно авторизовались");
            }

            else
            {
                MessageBox.Show("Такого пользователя не существует, попробуйте еще раз");
            }

            connection.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Enabled = true;
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataBase dataBase = new DataBase();

            dataBase.OpenConnection();
            DataTable dm = dataBase.UpdateData("select * from users");
            dataBase.CloseConnection();
        }
    }
}
