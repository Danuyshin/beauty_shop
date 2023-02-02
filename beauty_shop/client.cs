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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace beauty_shop
{
    public partial class client : Form
    {
        public int id;
        public client()
        {
            InitializeComponent();
        }

        private void client_Load(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[category]", data.sql).Fill(ds);
            data.sql.Close();
            dataGridView1.DataSource= ds.Tables[0];
            dataGridView1.Columns[0].Visible= false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            imageList1.Images.Clear();
            listView1.Items.Clear();
            int row = (int)dataGridView1.CurrentRow.Index;
            int category = (int)dataGridView1.Rows[row].Cells[0].Value;
            int id = 0;
            data.sql.Open();
            SqlDataReader read=new SqlCommand("SELECT  [id]\r\n      ,[name]\r\n      \r\n      ,[img]      \r\n  FROM [beauty_shop].[dbo].[product] where category="+category+"", data.sql).ExecuteReader();
            while (read.Read())
            {
                imageList1.Images.Add(Image.FromFile(read.GetString(2)));
                ListViewItem lvi1 = new ListViewItem();
                lvi1.ImageIndex = id;
                lvi1.Text = read.GetString(1);
                lvi1.IndentCount = read.GetInt32(0);
                listView1.Items.Add(lvi1);
                id++;

            }

            read.Close();
            data.sql.Close();
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible==true)
            {
                dataGridView1.Visible= false;
            }
            else
            {
                dataGridView1.Visible = true;
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                id = listView1.SelectedItems[0].IndentCount;
            }
            data.sql.Open();
            SqlDataReader read = new SqlCommand("SELECT  product.[name]\r\n      ,[category].name\r\n      ,[brand].name\r\n      ,[weight]\r\n      ,[price]\r\n      ,[img]\r\n      ,[country].name\r\n      ,[result].name\r\n      ,[type].name\r\n      ,[description]\r\n      ,[gender].name\r\n  FROM ((((([beauty_shop].[dbo].[product] left join category on category.id=product.category) left join brand on brand.id=product.brand) left join country on country.id=product.country) left join result on result.id=product.result)left join type on type.id=product.type) left join gender on gender.id=product.gender where product.id="+id+"", data.sql).ExecuteReader();
            read.Read();
            label1.Text = read.GetString(0);
            label2.Text = read.GetInt32(4).ToString();
            pictureBox1.Image = Image.FromFile(read.GetString(5));
            label4.Text = read.GetString(9);
            label5.Text = read.GetString(7);
            label6.Text = read.GetString(3);
            label7.Text = read.GetString(1);
            label8.Text = read.GetString(6);
            label9.Text=read.GetString(10);
            label10.Text = read.GetString(8);
            read.Close();
            data.sql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds= new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[cart]\r\n           ([product]\r\n           ,[user]\r\n           ,[amount])\r\n     VALUES\r\n           ("+id+","+data.user+","+int.Parse(textBox1.Text)+")", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "0")
            {
                textBox1.Text=(int.Parse(textBox1.Text)-1).ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();

        }
    }
}
