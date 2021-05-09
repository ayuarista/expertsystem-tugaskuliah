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
    public partial class adm_gjl2 : Form
    {
        public adm_gjl2()
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


        private void NavigateRecords()
        {
            dRow = ds.Tables[0].Rows[inc];

            label2.Text = MaxRows.ToString();

            Label box;
            for (int i = 0; i < MaxRows; i++)
            {

                dRows = ds.Tables[0].Rows[nilai];
                label1.Text = dRows.ItemArray.GetValue(1).ToString();
                string a = Convert.ToString(label1.Text);
                string cb = "label";
                box = new Label();
                box.Tag = i.ToString();
                box.Text = a;
                box.Name = cb + (i + 1).ToString();
                box.AutoSize = true;
                box.Location = new Point(10, 50 + (i * 20)); //vertical
                                                             //box.Location = new Point(i * 50, 10); //horizontal
                this.Controls.Add(box);

                if (nilai != MaxRows - 1)
                { nilai++; }
            }

            }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adm_gjl fl = new adm_gjl();
            fl.Show();
        }

        private void adm_gjl2_Load_1(object sender, EventArgs e)
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
    }
}
