using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class adm_gjl : Form
    {
        public adm_gjl()
        {
            InitializeComponent();


        }

        databaseconnection objConnect;
        string conString;

        DataSet ds;
        DataRow dRow;

        DataRow dRows;

        int MaxRows;
        int inc = 0;
        int nilai = 0;
        int score = 0;

        private void adm_gjl_Load(object sender, EventArgs e)
        {
            try
            {
                objConnect = new databaseconnection();
                conString = Properties.Settings.Default.Database1ConnectionString1;

                objConnect.connection_string = conString;
                objConnect.Sql = Properties.Settings.Default.Setting;

                ds = objConnect.GetConnection;
                MaxRows = ds.Tables[0].Rows.Count;
                NavigateRecords();

            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc];
            textBox1.Text = dRow.ItemArray.GetValue(1).ToString();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fl = new Form1();
            fl.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (inc != 0)
            {
                inc--;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("no more rows");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (inc != MaxRows - 1)
            {
                inc++;
                NavigateRecords();
            }
            else
            {
                MessageBox.Show("no more rows");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NavigateRecords();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            row[1] = textBox1.Text;



            ds.Tables[0].Rows.Add(row);
            try
            {

                objConnect.UpdateDatabase(ds);

                MaxRows = MaxRows + 1;
                inc = MaxRows - 1;

                MessageBox.Show("Database updated");

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }
            button3.Enabled = false;
            button2.Enabled = true;
            button1.Enabled = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {

            DataRow row = ds.Tables[0].NewRow();
            row[1] = textBox1.Text;
            
            try
            {
                objConnect.UpdateDatabase(ds);
                MessageBox.Show("Record updated");

            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message);

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ds.Tables[0].Rows[inc].Delete();
                objConnect.UpdateDatabase(ds);
                MaxRows = ds.Tables[0].Rows.Count;
                inc--;

                NavigateRecords();
                MessageBox.Show("Record Updated");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fl = new frmMain();
            fl.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            adm_gjl2 fl = new adm_gjl2();
            fl.Show();
        }
    }
}
