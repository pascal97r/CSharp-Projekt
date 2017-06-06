using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Game_Server
{
    public class Spiel
    {
        String TRENN = ";";

        #region Attribute
        List<Spieler> spieler;
        List<PictureBox> meteoriten;
        
        Panel panel;

        int geschwindkeit = 1;
        int wartezeit;

        Random rand;

        int spielBrettAnfang;
        int SpielBrettEnde;

        Thread thread;
        ThreadStart ts;

        Boolean synS1 = false;
        Boolean synS2 = false;

        Boolean start = false;

        PlayerPosManager pMan1;
        PlayerPosManager pMan2;

        Form1 server;

        public List<Spieler> Spieler
        {
            get
            {
                return spieler;
            }

            set
            {
                spieler = value;
            }
        }
        #endregion


        #region Mehrspieler
        public Spiel(Spieler spieler1, Spieler spieler2, Form1 server)
        {
            Spieler = new List<Spieler>();

            spieler1.Spiel = this;
            spieler2.Spiel = this;

            Spieler.Add(spieler1);
            Spieler.Add(spieler2);

            this.server = server;

            meteoriten = new List<PictureBox>();
            rand = new Random();

            ts = new ThreadStart(game);
            thread = new Thread(ts);
            thread.Start();

            int x1 = 300;
            int x2 = 400;
            int y = 400;
            
            foreach(Spieler s in Spieler)
            {
                s.sendeNachricht("STA" + TRENN + x1 + TRENN + y + TRENN + x2 + TRENN + y + TRENN);
                x1 += 100;
                x2 -= 100;
            }
        }

        public void synchronisation()
        {
            if (synS1 == false)
            {
                synS1 = true;
            }
            else if (synS2 == false)
            {
                synS2 = true;
            }
        }

        //Spielablauf
        private void game()
        {
            int posPlayer1_x;
            int posPlayer1_y;

            int posPlayer2_x;
            int posPlayer2_y;

            if (synS1 == true && synS2 == true)
            {
                start = true;

                for (int countdown = 5; countdown == 0; countdown--)
                {
                    foreach (Spieler s in Spieler)
                    {
                        s.sendeNachricht("CND" + TRENN + countdown + TRENN);
                        countdown--;
                        Thread.Sleep(1000);
                    }
                }
            }

            pMan1 = new PlayerPosManager(Spieler[0]);
            pMan2 = new PlayerPosManager(Spieler[1]);

            while (start)
            {


                foreach(Spieler s in Spieler)
                {
                    if(s.Equals(Spieler[0]))
                    {
                        pMan1.sendPos();
                    }
                }
            }
        }
        #endregion

        #region Meteor
        private void erzeugeMeteor(object sendser, EventArgs e)
        {
            int x = neuerSpawnPunkt();

            String nachricht = "MET" + TRENN + x + TRENN + rand.Next(1, 5);

            foreach(Spieler s in Spieler)
            {
                s.sendeNachricht(nachricht);
            }
        }

        private int neuerSpawnPunkt()
        {
            Boolean überlappen = true;
            int x = 0;
            do
            {
                x =
               rand.Next(spielBrettAnfang, SpielBrettEnde);

                foreach (PictureBox pair in meteoriten)
                {
                    //entweder Image-Location oder Location
                  
                    if (pair.Location.X > x && x < pair.Location.X + 100)
                    {
                        überlappen = true;
                    }
                    else
                    {
                        pair.Location = new Point(pair.Location.X - geschwindkeit);
                    }
                }
            } while (überlappen == true);
            return x;
        }
        #endregion
    }
}
