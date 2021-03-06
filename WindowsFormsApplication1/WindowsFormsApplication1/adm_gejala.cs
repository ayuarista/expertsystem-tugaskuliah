using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class adm_gejala : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D: \usb1\kcb fix\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");

        public adm_gejala()
        {
            InitializeComponent();
        }
       
        private void adm_gejala_Load(object sender, EventArgs e)
        {
            disp_data();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into table2(Nama_gejala) values('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("record inserted succesfully");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            adm_gejala frm = new adm_gejala();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from table2 where Nama_gejala='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("record delete sucessfull");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update table2 set Nama_gejala='" + textBox2.Text + "' where Nama_gejala='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("record update sucessfull");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from table2 where Nama_gejala='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmMain fl = new frmMain();
            fl.Show();
            this.Hide();
        }
   
        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fl = new Form1();
            fl.Show();
        }
    }
}
