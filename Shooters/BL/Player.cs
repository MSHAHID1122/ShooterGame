using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Shooters.BL
{
    public class Player
    {
        private string name;

        private int kills;
   
        private string password;
        public static List<Player> list1 = new List<Player>();
        public static List<Player> list2 = new List<Player>();

        private string time;


        public static void add_user(Player p)
        {
            StreamWriter st = new StreamWriter("usercred.txt",true);
            st.WriteLine(p.Name + "," + p.Password);
            st.Flush();

            st.Close();
        }
        public static void add_user1(Player p)
        {
            list1.Add(p);
        }

        public static void add_score1(Player p)
        {
            list2.Add(p);
        }

        public static void store_score(Player p)
        {
            StreamWriter st = new StreamWriter("highscore.txt",true);
            st.WriteLine(p.Name + "," + p.Kills+","+p.Time);
            st.Flush();
            st.Close();
        }

        public static void add_score_into_list()
        {

            list2.Clear();
            List<Player> pl = new List<Player>();
            StreamReader st = new StreamReader("highscore.txt");
            string record;
            while ((record = st.ReadLine()) != null)
            {
                string[] new_record = record.Split(',');
                Player player = new Player(new_record[0], int.Parse(new_record[1]), new_record[2]);
                pl.Add(player);
            }

            st.Close();
            list2 = pl.OrderByDescending(o=>o.kills).ToList();
        }
       


        public static void add_user_data_into_list()
        {
            list1.Clear();
            StreamReader st = new StreamReader("usercred.txt");
            string record;
            while ((record = st.ReadLine()) != null)
            {
                string[] new_record = record.Split(',');
                Player player = new Player(new_record[0], new_record[1]);
                list1.Add(player);
            }
            st.Close();
        }
      

        public static bool  is_user_exists(Player p)
        {
            foreach(Player ply in list1)
            {
                if (ply.Name == p.Name && ply.Password==p.Password)
                {
                    return true;
                }
            }
            return false;
        }
  
        public Player()
        {

        }
        public Player(string name, int kills)

        {
            DateTime t = DateTime.Now;
            this.Time = t.ToString();
            this.Name = name;
            this.kills = kills;
           
        }
        public Player(string name,int kills,string time)
        {
            this.Name = name;
            this.kills = kills;
            this.time = time;
        }
        public Player(string name, string pasword)
        {
            this.Name = name;
            this.password = pasword;
        }


        public string Name { get => name; set => name = value; }

        public int Kills
        {
            get { return kills; }
            set
            {
                if (kills < 10000)
                {
                    kills = value;
                }
            }
        }

        public string Password { get => password; set => password = value; }
        public string Time { get => time; set => time = value; }
    }
}
