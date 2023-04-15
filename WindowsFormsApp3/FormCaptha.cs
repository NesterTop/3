using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class FormCaptha : Form
    {
        string str = GetCaptha();
        public FormCaptha()
        {
            InitializeComponent();
        }

        public static string GetCaptha()
        {
            string result = "";
            char[] chars = "QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm".ToArray();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                result += chars[random.Next(0, chars.Length - 1)];
            }

            return result;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Font font = new Font("Times New Roman", 14);

            e.Graphics.Clear(Color.Black);
            e.Graphics.DrawString(str, font, Brushes.White, 10, 10);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == str)
            {
                this.Close();
            }
        }
    }
}
