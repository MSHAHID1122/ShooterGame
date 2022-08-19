using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shooters.BL;

namespace Shooters
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    

       private void databind()
        {
            guna2DataGridView1 = null;
            guna2DataGridView1.DataSource = Player.list2;
            guna2DataGridView1.Refresh();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            guna2DataGridView1.DataSource = Player.list2;
            guna2DataGridView1.Columns["password"].Visible = false;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            FrontPage form = new FrontPage();
            this.Hide();
            form.Show();

        }
    }
}
