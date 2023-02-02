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
    public partial class admin : Form
    {
        public int id;
        public string file;
        public admin()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Image Files(*.jpeg)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";

        }

        private void admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            data.table = "brand";
            load();
        }
        public void load()
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter=new SqlDataAdapter();
            switch (data.table)
            {
                case "brand":
                   new SqlDataAdapter("SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[brand]", data.sql).Fill(ds);
                    break;
                case "category":
                    new SqlDataAdapter("SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[category]", data.sql).Fill(ds);
                    break;
                case "country":
                    new SqlDataAdapter("SELECT [id]\r\n      ,[name]\r\n  FROM [dbo].[country]", data.sql).Fill(ds);
                    break;
                case "type":
                    new SqlDataAdapter("SELECT [id]\r\n      ,[name]\r\n  FROM [dbo].[type]", data.sql).Fill(ds);
                    break;
                case "result":
                    new SqlDataAdapter("SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[result]", data.sql).Fill(ds);
                    break;
                case "product":
                    new SqlDataAdapter("SELECT [id]\r\n      ,[name]\r\n      ,[category]\r\n      ,[brand]\r\n      ,[weight]\r\n      ,[price]\r\n      ,[img]\r\n      ,[country]\r\n      ,[result]\r\n      ,[type]\r\n, description  FROM [dbo].[product]" +
                        "SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[category]" +
                        "SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[brand]" +
                        "SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[country]" +
                        "SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[result]" +
                        "SELECT  [id]\r\n      ,[name]\r\n  FROM [beauty_shop].[dbo].[type]", data.sql).Fill(ds);
                    comboBox1.ValueMember ="id";
                    comboBox1.DisplayMember = "name";
                    comboBox1.DataSource = ds.Tables[1];
                    comboBox2.ValueMember = "id";
                    comboBox2.DisplayMember = "name";
                    comboBox2.DataSource = ds.Tables[2];
                    comboBox3.ValueMember = "id";
                    comboBox3.DisplayMember = "name";
                    comboBox3.DataSource = ds.Tables[3];
                    comboBox4.ValueMember = "id";
                    comboBox4.DisplayMember = "name";
                    comboBox4.DataSource = ds.Tables[4];
                    comboBox5.ValueMember = "id";
                    comboBox5.DisplayMember = "name";
                    comboBox5.DataSource = ds.Tables[5];

                    break;
            }
            dataGridView1.DataSource = ds.Tables[0];
            data.sql.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = (int)dataGridView1.CurrentRow.Index;
            id = (int)dataGridView1.Rows[row].Cells[0].Value;
            switch (data.table)
            {
                case "brand":
                    textBox1.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    break;
                case "category":
                    textBox2.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    break;
                case "country":
                    textBox3.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    break;
                    case "type":
                    textBox4.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    break;
                    case "result":
                    textBox5.Text= dataGridView1.Rows[row].Cells[1].Value.ToString();
                    break;
                case "product":
                    textBox6.Text = dataGridView1.Rows[row].Cells[1].Value.ToString();
                    comboBox1.SelectedIndex= (int)dataGridView1.Rows[row].Cells[2].Value-1;
                    comboBox2.SelectedIndex = (int)dataGridView1.Rows[row].Cells[3].Value-1;
                    textBox7.Text= dataGridView1.Rows[row].Cells[4].Value.ToString();
                    numericUpDown1.Value= (int)dataGridView1.Rows[row].Cells[5].Value;
                    pictureBox1.Image = Image.FromFile(dataGridView1.Rows[row].Cells[6].Value.ToString());
                    comboBox3.SelectedIndex= (int)dataGridView1.Rows[row].Cells[7].Value-1;
                    comboBox4.SelectedIndex= (int)dataGridView1.Rows[row].Cells[8].Value-1;
                    comboBox5.SelectedIndex= (int)dataGridView1.Rows[row].Cells[9].Value-1;
                    break;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[brand]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[brand]\r\n           ([name])\r\n     VALUES\r\n           ('"+textBox1.Text+"')", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[brand]\r\n   SET [name] = '"+textBox1.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            data.table = "category";
            load();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[category]\r\n           ([name])\r\n     VALUES\r\n           ('"+textBox2.Text+"')", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds= new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[category]\r\n   SET [name] = '"+textBox2.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[category]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[country]\r\n           ([name])\r\n     VALUES\r\n           ('"+textBox3.Text+"')", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[country]\r\n   SET [name] = '"+textBox3.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[country]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data.table = "country";
            load();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            data.table = "type";
            load();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[type]\r\n           ([name])\r\n     VALUES\r\n           ('"+textBox4.Text+"')", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[type]\r\n   SET [name] = '"+textBox4.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds= new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[type]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[result]\r\n           ([name])\r\n     VALUES\r\n           ('"+textBox5.Text+"')", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[result]\r\n   SET [name] = '"+textBox5.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[result]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            data.table = "result";
            load();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            data.table = "product";
            load();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("DELETE FROM [dbo].[product]\r\n      WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds= new DataSet();
            new SqlDataAdapter("UPDATE [dbo].[product]\r\n   SET [name] = '"+textBox6.Text+"',[category] = "+comboBox1.SelectedValue+",[brand] = "+comboBox2.SelectedValue+",[weight] = '"+textBox7.Text+"',[price] = "+numericUpDown1.Value+",[img] = '"+file+"',[country] = "+comboBox3.SelectedValue+",[result] = "+comboBox4.SelectedValue+",[type] = "+comboBox5.SelectedValue+", description='"+textBox8.Text+"'\r\n WHERE id="+id+"", data.sql).Fill(ds);
            data.sql.Close();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            data.sql.Open();
            DataSet ds = new DataSet();
            new SqlDataAdapter("INSERT INTO [dbo].[product]\r\n ([name],[category],[brand],[weight],[price],[img],[country],[result],[type], description)    VALUES('"+textBox6.Text+"',"+comboBox1.SelectedValue+","+comboBox2.SelectedValue+",'"+textBox7.Text+"',"+numericUpDown1.Value+",'"+file+"',"+comboBox3.SelectedValue+","+comboBox4.SelectedValue+","+comboBox5.SelectedValue+", '"+textBox8.Text+"')", data.sql).Fill(ds);
            data.sql.Close();

        }

        private void button23_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            file = openFileDialog1.FileName;
            pictureBox1.Image = Image.FromFile(file);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            switch (data.table)
            {
                case "brand":
                    brand.Visible = true;
                    break;
                case "category":
                    category.Visible = true;
                    break;
                case "country":
                    country.Visible = true;
                    break;
                case "type":
                    type.Visible = true;
                    break;
                case "result":
                    result.Visible = true;
                    break;
                case "product":
                    product.Visible = true;
                    break;
            }
        }
    }
}
