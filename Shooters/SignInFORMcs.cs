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
    public partial class SignInFORMcs : Form
    {
        public SignInFORMcs()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Player pl = new Player(playerName.Text, playerPassword.Text);
            bool check = Player.is_user_exists(pl);
            if (check)
            {
                MessageBox.Show("PLEASE ENTER A STRONG PASSWORD");

            }
            else
            {
                Player.add_user(pl);
                Player.add_user1(pl);
               
                MessageBox.Show("ACCOUNT CREATED ");
                this.Hide();
                Form3 form = new Form3();
                form.Show();
            }


        }

        private void SignInFORMcs_Load(object sender, EventArgs e)
        {

        }

        private void playerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
