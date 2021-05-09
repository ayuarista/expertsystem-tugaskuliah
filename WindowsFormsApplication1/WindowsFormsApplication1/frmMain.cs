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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btn_LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 fl = new Form1();
            fl.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Rule_Click(object sender, EventArgs e)
        {
            
            adm_gejala fl = new adm_gejala();
            fl.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            adm_rule fl = new adm_rule();
            fl.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            adm_hasil fl = new adm_hasil();
            fl.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            adm_admin fl = new adm_admin();
            fl.Show();
        }
    }
}
