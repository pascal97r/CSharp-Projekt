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
    public partial class Game_Einstellungen : Form
    {
        String ip = "127.0.0.1";
        int port = 7007;
        int maxAnzahl = 10;

        Form1 server = null;

        public Game_Einstellungen()
        {
            InitializeComponent();
            textBoxServerport.Text = Port.ToString();
        }

        public Game_Einstellungen(Form1 server)
        {
            InitializeComponent();
            textBoxServerport.Text = Port.ToString();
            this.server = server;
        }

        #region Getter / Setter
        public int Port
        {
            get
            {
                return port;
            }

            set
            {
                port = value;
            }
        }

        public int MaxAnzahl
        {
            get
            {
                return maxAnzahl;
            }
            set
            {
                maxAnzahl = value;
            }
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Port = Convert.ToInt32(textBoxServerport.Text);
            MaxAnzahl = Convert.ToInt32(textBoxSpieleranzahl.Text);
            server.Port = Port;
            server.MaxPlayer = MaxAnzahl;
            this.Hide();
        }

        public void öffneGui()
        {
            textBoxServerport.Text = Port.ToString();
            textBoxSpieleranzahl.Text = MaxAnzahl.ToString();
            this.Show();
        }

        private void Game_Einstellungen_Load(object sender, EventArgs e)
        {

        }
    }
}
