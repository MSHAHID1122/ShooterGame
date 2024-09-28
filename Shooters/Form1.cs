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
    public partial class Form1 : Form
    {

       
        bool up, down, right, left;
        PictureBox player = new PictureBox();
     
        int bullet_count=5;
        ProgressBar playerhealth = new ProgressBar();
        PictureBox enemy1 = new PictureBox();
        PictureBox enemy2 = new PictureBox();
        PictureBox enemy3= new PictureBox();
        Label lblKills = new Label();
        PictureBox ammo = new PictureBox();
        PictureBox health = new PictureBox();
        PictureBox bomb = new PictureBox();
        Label lblbombs = new Label();


        bool ammo_drop = false;
        int health_pack=2;

        int kills = 0;
        int enemy_number = 3;
        int current_enemy = 0;
        int bomb_count = 10;
    

       string  direction;
        Player p = new Player();
        public Form1(Player plr)
        {
            InitializeComponent();
            p.Name = plr.Name;
            p.Password = plr.Password;
        }

        private void BulletSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"bulletsound.wav");
            player.Play();
        }
        private void emptySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"emptysound.wav");
            player.Play();
        }
        private void needAmmmoSound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"needammo.wav");
            player.Play();

        }
      
        private void add_player()
        {

            player.Name = "hero";
            player.Size = new Size(90, 90);
            player.Location = new Point(50, 50);
            player.BackgroundImageLayout = ImageLayout.Zoom;
            player.BackColor = Color.Transparent;
            Controls.Add(player);

        }



        private void drop_bomp()
        {
            Random rn = new Random();
            bomb.Name = "bomb";
            bomb.Left = rn.Next(20, ClientSize.Width - 30);
            bomb.Top = rn.Next(100, ClientSize.Height - 30);
            bomb.Size = new Size(20, 20);
            bomb.BackColor = Color.Red;
            bomb.BackgroundImageLayout = ImageLayout.Zoom;
            Controls.Add(bomb);
        }

        private void drop_ammo()
        {


            Random rand = new Random();
            ammo.Name = "ammo";

            ammo.Left = rand.Next(20, ClientSize.Width-30);
            ammo.Top = rand.Next(100, ClientSize.Height-30);
         
            ammo.BackgroundImageLayout = ImageLayout.Zoom;
            ammo.BackColor = Color.Transparent;
            Controls.Add(ammo);
            ammo_drop = true;
         if (health_pack == 0)
            {
                Random rand1 = new Random();

                health.Name = "health";
                health.Left = rand1.Next(30, ClientSize.Width - 30);
                health.Top = rand1.Next(200, ClientSize.Height - 30);
                health.BackgroundImageLayout = ImageLayout.Zoom;
                health.BackColor = Color.Transparent;
                Controls.Add(health);
                health_pack = 3;

            }
            else
            {
                health_pack--;
            }

       }
        private void fire_up()
        {
            PictureBox fire = new PictureBox();
            fire.Name = "fire1";
            fire.Size = new Size(15, 15);
            fire.Location = new Point((player.Width / 2) + (player.Left - 20), player.Top - 3);
            fire.BackgroundImageLayout = ImageLayout.Zoom;
            fire.BackColor = Color.Transparent;
            Controls.Add(fire);
        }
        private void fire_down()
        {
            PictureBox fire = new PictureBox();
            fire.Name = "fire2";
            fire.Size = new Size(15, 19);
            fire.Location = new Point((player.Width / 2) + (player.Left - 22), player.Top + 25);
            fire.BackgroundImageLayout = ImageLayout.Stretch;
            fire.BackColor = Color.Transparent;
            Controls.Add(fire);
        }
        private void fire_left()
        {
            PictureBox fire = new PictureBox();
            fire.Name = "fire3";
            fire.Size = new Size(15, 15);
            fire.Location = new Point((player.Width / 2) + (player.Left - 15), player.Top + 22);
            fire.BackgroundImageLayout = ImageLayout.Zoom;
            fire.BackColor = Color.Transparent;
            Controls.Add(fire);
        }


        private void fire_right()
        {
            PictureBox fire = new PictureBox();
            fire.Name = "fire4";
            fire.Size = new Size(19, 15);
            fire.Location = new Point(player.Right + 10, player.Bottom - (player.Height / 2)-20);
            fire.BackgroundImageLayout = ImageLayout.Stretch;
            fire.BackColor = Color.Transparent;
            Controls.Add(fire);
        }
        private void add_enemy()
        {
            for (int i = current_enemy; i < enemy_number; i++)
            {
                if (i == 0)
                {
                    enemy1.Name = "enemy1";
                    enemy1.Size = new Size(90, 90);
                    System.Random rand = new Random();
                    enemy1.Location = new Point(rand.Next(ClientSize.Width - 50), rand.Next(ClientSize.Height - 50));
                    enemy1.BackgroundImageLayout = ImageLayout.Zoom;
                    enemy1.BackColor = Color.Transparent;
                    Controls.Add(enemy1);
                }
                else if (i == 1)
                {
                    enemy2.Name = "enemy2";
                    enemy2.Size = new Size(90, 90);
                    System.Random rand = new Random();
                    enemy2.Location = new Point(rand.Next(ClientSize.Width - 50), rand.Next(ClientSize.Height - 50));
                    enemy2.BackgroundImageLayout = ImageLayout.Zoom;
                    enemy2.BackColor = Color.Transparent;
                    Controls.Add(enemy2);
                }
                if (i == 2)
                {
                    enemy3.Name = "enemy3";
                    enemy3.Size = new Size(90, 90);
                    System.Random rand = new Random();
                    enemy3.Location = new Point(rand.Next(ClientSize.Width - 50), rand.Next(ClientSize.Height - 50));
                    enemy3.BackgroundImageLayout = ImageLayout.Zoom;
                    enemy3.BackColor = Color.Transparent;
                    Controls.Add(enemy3);
                }

            }

        }


       
        private void player_Click(object sender, EventArgs e)
        {

        }

      /*  private void fire_move()
        {
            foreach (Control c in Controls)
            {
                if (c.Name == "fire1")
                {
                    

                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                   else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                else    if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }
                   if (c.Top == this.Top)
                    {
                        Controls.Remove(c);
                    }

                    c.Top -= 30;


                }
                else if (c.Name == "fire2")
                {


                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                    else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                    else   if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }



                     if (c.Top >= this.Bottom)
                    {
                        Controls.Remove(c);
                    }
                    c.Top += 30;


                }

                else if (c.Name == "fire3")
                {

                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                   else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                  else  if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }


                   if (c.Left == this.Left)
                    {
                        Controls.Remove(c);
                    }

                    c.Left -= 30;



                }


                else if (c.Name == "fire4")
                {

                   if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                 else   if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                  else  if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }
                    if (c.Left == this.Right)
                    {
                        Controls.Remove(c);
                    }
                    c.Left += 30;

                }

            }
        }*/
        private void Form1_Load(object sender, EventArgs e)
        {
            playerhealth.Value = 100;
            playerhealth.BackColor = Color.Green;
            playerhealth.Name = "health";
            Controls.Add(lblKills);
            Controls.Add(playerhealth);
            health_and_kills();

            add_player();
            add_enemy();

        }

     
/*
        private void move_player()
        {
            
            if (left == true && player.Left > 0)
            {
                player.Left -= 20;
            }

            if (right == true && player.Right < this.ClientSize.Width)
            {
                player.Left += 20;
            }

            if (up == true && player.Top - player.Height > 0)
            {
                player.Top -= 20;

            }

            if (down == true && player.Bottom  <= this.ClientSize.Height)
            {
                player.Top += 20;
            }
        }

      *//*  private double calculate_distance(int x, int y)
        {
            double a = Math.Sqrt(((Math.Pow(enemy.Width - x, 2)) + (Math.Pow(enemy.Height - y, 2))));
            return a;
        }*//*
        private void move_enemy()
        {

            foreach (Control c in Controls)
            {

                if (c.Name == "enemy1")
                {
                    if (c.Top < player.Top)
                    {
                        c.Top +=3;
                        enemy1.Image = Properties.Resources.zdown;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;
                        enemy1.Image = Properties.Resources.zright;

                    }
                    if (c.Top >player.Top)
                    {
                        c.Top -= 3;
                        enemy1.Image = Properties.Resources.zup;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;
                        enemy1.Image = Properties.Resources.zleft;

                    }

                }
                if (c.Name == "enemy2")
                {

                    if (c.Top < player.Top)
                    {
                        c.Top += 3;
                        enemy2.Image = Properties.Resources.zdown;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;
                        enemy2.Image = Properties.Resources.zright;

                    }
                    if (c.Top > player.Top)
                    {
                        c.Top -= 3;
                        enemy2.Image = Properties.Resources.zup;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;
                        enemy2.Image = Properties.Resources.zleft;

                    }
                }
                if (c.Name == "enemy3")
                {

                    if (c.Top < player.Top)
                    {
                        c.Top += 3;
                        enemy3.Image = Properties.Resources.zdown;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;
                        enemy3.Image = Properties.Resources.zright;

                    }
                    if (c.Top > player.Top)
                    {
                        c.Top -= 3;
                        enemy3.Image = Properties.Resources.zup;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;
                        enemy3.Image = Properties.Resources.zleft;

                    }
                }

                if (c.Name == "bomb")
                {
                    if (player.Bounds.IntersectsWith(bomb.Bounds))
                    {
                        playerhealth.Value = 10;
                        Controls.Remove(c);
                        bomb_count--;
                    }
                    if (player.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                      
                        kills += 1;
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                       

                    }
                    if (player.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                      
                        kills += 1;
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();


                    }
                    if (player.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        kills += 1;
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();


                    }
                }

               if (c.Name == "ammo")
                    {
                        if (player.Bounds.IntersectsWith(ammo.Bounds))
                        {
                            Controls.Remove(c);
                            ammo_drop = false;
                            bullet_count = 5;
                        }

                    }

                
                if (c.Name == "health")
                {
                    if (player.Bounds.IntersectsWith(c.Bounds))
                    {
                        Controls.Remove(c);
                        if (playerhealth.Value == 10)
                        {
                            playerhealth.Value =20;
                        }
                       else if (playerhealth.Value == 20)
                        {
                            playerhealth.Value =30;
                        }
                       else if (playerhealth.Value == 30)
                        {
                            playerhealth.Value =40;
                        }
                       else if (playerhealth.Value == 40)
                        {
                            playerhealth.Value= 50;
                        }
                       else if (playerhealth.Value == 50)
                        {
                            playerhealth.Value =60;
                        }
                       else if (playerhealth.Value == 60)
                        {
                            playerhealth.Value =70;
                        }
                        else if (playerhealth.Value == 70)
                        {
                            playerhealth.Value = 80;
                        }
                        else if (playerhealth.Value == 80)
                        {
                            playerhealth.Value = 90;
                        }
                        else if (playerhealth.Value == 90)
                        {
                            playerhealth.Value = 100;
                        }

                    }

                }
            
            }

            *//*
                        int x = player.Width;
                        int y = player.Height;

                        List<double> distance = new List<double>();
                        double up = calculate_distance(x, y - 10);
                        double down = calculate_distance(x, y + 10);
                        double right = calculate_distance(x + 10, y);
                        double left = calculate_distance(x - 1, y);

                        distance.Add(up);
                        distance.Add(down);
                        distance.Add(right);
                        distance.Add(right);

                        distance.Sort();
                        distance.Clear()*//*;

            *//*if (distance[3]==left && enemy.Left > 0)
            {
                enemy.Left -= 10;
            }

            if (distance[3]==right && enemy.Right + enemy.Width < this.ClientSize.Width)
            {
                enemy.Left += 10;
            }

            if (distance[3]==up && enemy.Top - enemy.Height > 0)
            {
                enemy.Top -= 10;

            }H

            if (distance[3]==down && enemy.Bottom + enemy.Height < this.ClientSize.Height)
            {
                enemy.Top += 10;
            }
            distance.Clear();
*//*

        }

*/        private void health_and_kills()
        {
            playerhealth.Top = ClientSize.Height - (ClientSize.Height - 50);
            playerhealth.Left = ClientSize.Width - 200;



            lblbombs.Top = ClientSize.Height - (ClientSize.Height - 55);
            lblbombs.Left = ClientSize.Width - 55;
            lblbombs.Font = new System.Drawing.Font("hooge 05_55", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbombs.ForeColor = System.Drawing.Color.Red;

            lblbombs.BackColor = Color.Transparent;
            Controls.Add(lblbombs);

            lblKills.Top = ClientSize.Height - (ClientSize.Height - 55);
            lblKills.Left = ClientSize.Width - 400;
            lblKills.Font = new System.Drawing.Font("hooge 05_55", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKills.ForeColor = System.Drawing.Color.Red;

            lblKills.BackColor = Color.Transparent;
      

        }

        
        
        private void MainTimerEvent(object sender, EventArgs e)
         {

            lblKills.Text = "KILLS :"+kills;
            lblbombs.Text = "BOMBS :" + bomb_count;

            if (playerhealth.Value > 0)
            {


                Move();
                GC.Collect();
            }
            else

            {
                timer1.Stop();
                
                player.Width = 120;
                player.BackgroundImageLayout = ImageLayout.Zoom;
                p.Kills = kills;

                DateTime date = DateTime.Now;
                p.Time = date.ToString();
                if (Player.list2.Count > 0)
                {
                    if (kills > Player.list2[0].Kills)
                    {
                        Controls.Remove(player);
                        Controls.Remove(enemy1);
                        Controls.Remove(enemy2);
                        Controls.Remove(enemy3);
               
                        PictureBox p = new PictureBox();
                        p.Name = "trophy";
                        p.Location = new Point((ClientSize.Width / 2)-400, (ClientSize.Height / 2)-200);
                        p.Size = new Size(260, 260);
                        p.BackgroundImageLayout = ImageLayout.Zoom;
                        p.BackColor = Color.Transparent;
    
                        Controls.Add(p);
                        PictureBox pg = new PictureBox();
                        pg.Name = "gif";
                        pg.Location = new Point(50,50);
                        pg.Height = 1000;
                        pg.Width = 1000;
                        pg.BackgroundImageLayout = ImageLayout.Stretch;
                        pg.BackColor = Color.Transparent;
                        Controls.Add(pg);
                       
                        MessageBox.Show("Congratulations for : " + kills + "  KILLS");


                    }
                    else
                    {
                        MessageBox.Show("KILLS : " + kills);

                    }
                }
                else
                {
                    Controls.Remove(player);
                    Controls.Remove(enemy1);
                    Controls.Remove(enemy2);
                    Controls.Remove(enemy3);
                    PictureBox p = new PictureBox();
                    p.Name = "trophy";
                    p.Location = new Point((ClientSize.Width / 2) - 400, (ClientSize.Height / 2) - 200);
                    p.Size = new Size(260, 260);
                    p.BackgroundImageLayout = ImageLayout.Center;
                    p.BackColor = Color.Transparent;



                    Controls.Add(p);
                    PictureBox pg = new PictureBox();
                    pg.Name = "gif";
                    pg.Location = new Point(0, 0);
                    pg.Width = 1000;
                    pg.Height = 1000;
                    pg.BackgroundImageLayout = ImageLayout.Center;
                    pg.BackColor = Color.Transparent;

                    Controls.Add(pg);
                    MessageBox.Show("Congratulations for : " + kills + "  KILLS");

                }
                Player.add_score1(p);

                this.Close();
                Player.store_score(p);
            }
          
          

        }

/*
        private void check_collision()
        {

            foreach (Control c in Controls)
            {
                if (c.Name == "enemy1")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        if(playerhealth.Value>0)
                        playerhealth.Value-=10;
                    }
                }
                if (c.Name == "enemy2")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        playerhealth.Value -= 10;
                    }
                }
                if (c.Name == "enemy3")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        playerhealth.Value -= 10;
                    }
                }
            }

        }
 */       private void key_is_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left&& playerhealth.Value>0)
            {
                left = true;
                player.Image = null;
                direction = "left";
            }
           if (e.KeyCode == Keys.Right&& playerhealth.Value>0)
            {
                right = true;
                player.Image = null;
                direction = "right";
            }
            if (e.KeyCode == Keys.Up&& playerhealth.Value>0)
            {
                up = true;
                player.Image = null;
                direction = "up";

            }
            if (e.KeyCode == Keys.Down&& playerhealth.Value>0)
            {
                down = true;
                player.Image = null;


                direction = "down";
            }
            if(e.KeyCode==Keys.D && bomb_count > 0)
            {
                drop_bomp();
            }
          
          
            if (e.KeyCode == Keys.Space  && playerhealth.Value>0)
            {
                if (bullet_count <= 0)
                  {
                  
                    needAmmmoSound();
                }
                else
                {
                    BulletSound();
                    bullet_count--;

                    if (direction == "up")
                    {
                        fire_up();
                    }
                    else if (direction == "down")
                    {
                        fire_down();
                    }
                    else if (direction == "left")
                    {
                        fire_left();
                    }
                    else if (direction == "right")
                    {
                        fire_right();
                    }
                }

                  

            }

            if (bullet_count <= 0 && ammo_drop==false)
            {
                drop_ammo();
            }

            
        }





        private void keyisUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
           if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                up = false;

            }
            if (e.KeyCode == Keys.Down)
            {
                down = false;
            }


        }


        private void Move()
        {



            if (left == true && player.Left > 0)
            {
                player.Left -= 20;
            }

            if (right == true && player.Right < this.ClientSize.Width)
            {
                player.Left += 20;
            }

            if (up == true && player.Top - player.Height > 0)
            {
                player.Top -= 20;

            }

            if (down == true && player.Bottom <= this.ClientSize.Height)
            {
                player.Top += 20;
            }







            foreach (Control c in Controls)
            {

                if (c.Name == "enemy1")
                {
                    if (c.Top < player.Top)
                    {
                        c.Top += 3;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;

                    }
                    if (c.Top > player.Top)
                    {
                        c.Top -= 3;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;

                    }

                }
                if (c.Name == "enemy2")
                {

                    if (c.Top < player.Top)
                    {
                        c.Top += 3;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;

                    }
                    if (c.Top > player.Top)
                    {
                        c.Top -= 3;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;

                    }
                }
                if (c.Name == "enemy3")
                {

                    if (c.Top < player.Top)
                    {
                        c.Top += 3;

                    }
                    if (c.Left < player.Left)
                    {
                        c.Left += 3;

                    }
                    if (c.Top > player.Top)
                    {
                        c.Top -= 3;

                    }
                    if (c.Left > player.Left)
                    {
                        c.Left -= 3;

                    }
                }

                if (c.Name == "bomb")
                {
                    if (player.Bounds.IntersectsWith(bomb.Bounds))
                    {
                        playerhealth.Value = 10;
                        Controls.Remove(c);
                        bomb_count--;
                    }
                    if (bomb.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);

                        kills += 1;
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        bomb_count--;


                    }
                    if(bomb.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);

                        kills += 1;
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        bomb_count--;

                    }
                    if (bomb.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        kills += 1;
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        bomb_count--;

                    }
                }

                if (c.Name == "ammo")
                {
                    if (player.Bounds.IntersectsWith(ammo.Bounds))
                    {
                        Controls.Remove(c);
                        ammo_drop = false;
                        bullet_count = 5;
                    }

                }


                if (c.Name == "health")
                {
                    if (player.Bounds.IntersectsWith(c.Bounds))
                    {
                        Controls.Remove(c);
                        if (playerhealth.Value == 10)
                        {
                            playerhealth.Value = 20;
                        }
                        else if (playerhealth.Value == 20)
                        {
                            playerhealth.Value = 30;
                        }
                        else if (playerhealth.Value == 30)
                        {
                            playerhealth.Value = 40;
                        }
                        else if (playerhealth.Value == 40)
                        {
                            playerhealth.Value = 50;
                        }
                        else if (playerhealth.Value == 50)
                        {
                            playerhealth.Value = 60;
                        }
                        else if (playerhealth.Value == 60)
                        {
                            playerhealth.Value = 70;
                        }
                        else if (playerhealth.Value == 70)
                        {
                            playerhealth.Value = 80;
                        }
                        else if (playerhealth.Value == 80)
                        {
                            playerhealth.Value = 90;
                        }
                        else if (playerhealth.Value == 90)
                        {
                            playerhealth.Value = 100;
                        }

                    }

                }

            




























                if (c.Name == "fire1")
                {


                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                    else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                    else if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }
                    if (c.Top == this.Top)
                    {
                        Controls.Remove(c);
                    }

                    c.Top -= 30;


                }
                else if (c.Name == "fire2")
                {


                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                    else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                    else if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }



                    if (c.Top >= this.Bottom)
                    {
                        Controls.Remove(c);
                    }
                    c.Top += 30;


                }

                else if (c.Name == "fire3")
                {

                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                    else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                    else if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }


                    if (c.Left == this.Left)
                    {
                        Controls.Remove(c);
                    }

                    c.Left -= 30;



                }


                else if (c.Name == "fire4")
                {

                    if (c.Bounds.IntersectsWith(enemy1.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy1);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        kills += 1;
                    }
                    else if (c.Bounds.IntersectsWith(enemy2.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        kills += 1;


                    }
                    else if (c.Bounds.IntersectsWith(enemy3.Bounds))
                    {
                        Controls.Remove(c);
                        Controls.Remove(enemy2);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        kills += 1;

                    }
                    if (c.Left == this.Right)
                    {
                        Controls.Remove(c);
                    }
                    c.Left += 30;

                }

            








            
                if (c.Name == "enemy1")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 1;
                        current_enemy = 0;
                        add_enemy();
                        if (playerhealth.Value > 0)
                            playerhealth.Value -= 10;
                    }
                }
                if (c.Name == "enemy2")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 2;
                        current_enemy = 1;
                        add_enemy();
                        if(playerhealth.Value>0)
                        playerhealth.Value -= 10;
                    }
                }
                if (c.Name == "enemy3")
                {
                    if (c.Bounds.IntersectsWith(player.Bounds))
                    {
                        Controls.Remove(c);
                        enemy_number = 3;
                        current_enemy = 2;
                        add_enemy();
                        if(playerhealth.Value>0)
                        playerhealth.Value -= 10;
                    }
                }
            }













        }

        // END OF MOVE

    }
}
