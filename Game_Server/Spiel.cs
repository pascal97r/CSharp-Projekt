using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Server
{
    class Spiel
    {
        #region Attribute
        List<Spieler> spieler;
        Dictionary<PictureBox, int> meteoriten;

        Timer timer;
        Panel panel;

        int geschwindkeit;
        int wartezeit;

        Random rand;

        int spielBrettAnfang;
        int SpielBrettEnde;
        #endregion

        #region Mehrspieler
        public Spiel(Spieler spieler1, Spieler spieler2)
        {
            spieler = new List<Spieler>();

            spieler1.Spiel = this;
            spieler2.Spiel = this;

            spieler.Add(spieler1);
            spieler.Add(spieler2);

            meteoriten = new Dictionary<PictureBox, int>();
            timer = new Timer();
            timer.Interval = 1000;
            rand = new Random();
        }
        #endregion

        #region Meteor
        private void erzeugeMeteor(object sendser, EventArgs e)
        {
            int x = neuerSpawnPunkt();

            String nachricht = "MET;" + x + ";" + rand.Next(1, 5);
            foreach(Spieler s in spieler)
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
                foreach (KeyValuePair<PictureBox, int> pair in meteoriten)
                {
                    //entweder Image-Location oder Location
                    if (pair.Key.Location.X == x)
                    {
                        überlappen = true;
                    }
                    else if (pair.Key.Location.X > x && x < pair.Key.Size.Width + pair.Key.Location.X)
                    {
                        überlappen = true;
                    }
                    pair.Key.Location = new Point(pair.Key.Location.X - pair.Value);
                }
            } while (überlappen == true);
            return x;
        }

        private void bewegeMeteoren()
        {
            foreach (KeyValuePair<PictureBox, int> pair in meteoriten)
            {
                //entweder Image-Location oder Location
                pair.Key.Location = new Point(pair.Key.Location.X - pair.Value);
            }
        }

        #endregion
    }
}
