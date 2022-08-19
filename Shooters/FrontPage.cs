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
    public partial class FrontPage : Form
    {
        public FrontPage()
        {
            InitializeComponent();
            sound2();
        }

        Button enter = new Button();
        int song_No=0;
        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(@"battlesong.wav");
        System.Media.SoundPlayer sound1 = new System.Media.SoundPlayer(@"battlesong1.wav");

        private void button()
        {
            this.enter.BackColor = System.Drawing.Color.Transparent;
            this.enter.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.enter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.enter.Location = new System.Drawing.Point(ClientSize.Width - (ClientSize.Width - 150), ClientSize.Height - (ClientSize.Height - 150));
            this.enter.Name = "enter";
            this.enter.Size = new System.Drawing.Size(274, 80);
            this.enter.TabIndex = 0;
            this.enter.Text = "Enter Game";

        }
        private void sound2()
        {
            sound.Play();
           
        }
        private void sound3()
        {
            sound1.Play();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (song_No == 0)
            sound2();
            else if(song_No==1)
            sound3();
            button();
           
        }

        private void FrontPage_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (song_No == 0)
            {
                song_No = 1;
            }
            else
                song_No = 0;

            timer.Stop();
            timer.Start();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            sound1.Stop();
            sound.Stop();
            Player.add_score_into_list();
            Player.add_user_data_into_list();
            Form3 form = new Form3();
            timer.Stop();

            this.Hide();
            form.Show();
                 
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            Player.add_score_into_list();
            Form2 form = new Form2();
            timer.Stop();
            this.Hide();
            form.Show();
            
        }
    }
}
