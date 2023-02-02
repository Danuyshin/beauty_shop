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

namespace beauty_shop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            SqlDataReader read= new SqlCommand("SELECT[type],id\r\n  FROM [beauty_shop].[dbo].[user] where login='"+textBox1.Text+"' and password='"+textBox2.Text+"'", data.sql).ExecuteReader();
            if(!read.Read())
            {
                MessageBox.Show("Логин или пароль введены неверно");
                data.sql.Close();
                return;
            }
            int status = read.GetInt32(0);
            data.user = read.GetInt32(1);
            data.sql.Close(); 
            switch(status)
            {
                case 1:
                    data.admin.Show();
                break;
                case 2:
                    data.client.Show();
                break;
            }
            this.Hide();
        }
    }
}
