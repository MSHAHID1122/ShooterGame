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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SignInFORMcs form = new SignInFORMcs();
            form.Show();
        }



        private void Sound_Play()
        {
            System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(@"battlesong1.wav");
            sound1.Play();
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            //timer1.Stop();
            Player pl = new Player(playerName.Text, playerPassword.Text);

            bool chec = Player.is_user_exists(pl);

            if (chec)
            {
                timer1.Enabled = false;
                Form1 form = new Form1(pl);
                form.Show();

            }
            else
            {
                MessageBox.Show("MAKE AN ACCOUNT FIRST");
                playerName.Text = "";
                playerPassword.Text = "";

            }

        }

        private void playerPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void playerName_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;
            FrontPage form = new FrontPage();

            this.Hide();
            form.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
         //   timer1.Start();
            this.guna2Button1.BackColor = System.Drawing.Color.Gray;
            this.guna2Button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.guna2Button1.BorderThickness = 5;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Teal;
            this.guna2Button1.Font = new System.Drawing.Font("hooge 05_55", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(ClientSize.Width-150, ClientSize.Height-(ClientSize.Height-30));
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(150, 40);
            this.guna2Button1.TabIndex = 10;
            this.guna2Button1.Text = "HOME";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Sound_Play();
        }
    }
}
