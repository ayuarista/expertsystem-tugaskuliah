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
    public partial class diagnosa : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D: \usb1\kcb fix\WindowsFormsApplication1\WindowsFormsApplication1\Database1.mdf;Integrated Security=True");
        SqlDataAdapter adapter;
        DataTable table = new DataTable();
        int pos;

        public SqlDataAdapter Adapter { get => adapter; set => adapter = value; }

        public diagnosa()
        {
            InitializeComponent();
        }

        private void diagnosacobacoba_Load(object sender, EventArgs e)
        {
            Adapter = new SqlDataAdapter("select * from table2", con);
            Adapter.Fill(table);
            showData(pos);
        }
        public void showData(int index)
        {
            label1.Text = table.Rows[index][1].ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true || radioButton2.Checked == true)

            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;

                radioButton1.Visible = true;
                radioButton2.Visible = true;

                label4.Text = label4.Text + label3.Text;

                pos++;
                if (pos < table.Rows.Count)
                {
                    showData(pos);
                }
                else
                {
                    solusi  frm = new solusi(label4.Text);
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Pilih Salah satu");
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label3.Text = table.Rows[pos][0].ToString();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label3.Text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
