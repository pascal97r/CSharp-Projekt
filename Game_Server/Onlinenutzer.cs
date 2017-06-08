using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Server
{
    public partial class Onlinenutzer : Form
    {
        Form1 server;
        List<Spieler> spieler;

        delegate void SetListBoxCallback(String text);

        public Onlinenutzer(Form1 server, List<Spieler> spieler)
        {
            InitializeComponent();

            this.spieler = new List<Spieler>();
            this.spieler = spieler;

            this.server = server;

            updateNutzer(this.spieler);
        }

        public void updateNutzer(List<Spieler> spieler)
        {
            if(spieler != null)
            {
                foreach (Spieler s in spieler)
                {
                    listBox1.Items.Add(s.Name);
                }

                labelOnline.Text = spieler.Count.ToString();
            }
        }
       
        private void Pfeil1_MouseEnter(object sender, EventArgs e)
        {
            pfeil2.Visible = true;
        }

        private void pfeil2_Click(object sender, EventArgs e)
        {
            server.schließeNutzer();
        }

        private void pfeil2_MouseLeave(object sender, EventArgs e)
        {
            pfeil2.Visible = false;
        }

        public void addUser(Spieler spieler)
        {
            this.spieler.Add(spieler);
        }

        public void setListBoxText(String text)
        {

            if (listBox1.InvokeRequired)
            {
                SetListBoxCallback del = new SetListBoxCallback(setListBoxText);
                this.Invoke(del, new object[] { text });
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }
    }
}
