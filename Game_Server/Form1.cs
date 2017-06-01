using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Net.Sockets;

namespace Game_Server
{
    public partial class Form1 : Form
    {

        #region Attribute
        //TCP
        TcpListener listener = null;
        TcpClient client = null;

        //Spieler
        Spieler player;
        List<Spieler> spieler;
        int spieleranzahl = 0;
        int maxPlayer;
        String[] namen;

        //Thread
        Thread thread = null;
        ThreadStart threadStart = null;

        //Boolean
        Boolean serverAn = false;

        //Timer
        int zeit = 0;

        int meldungZeit = 0;
        int meldungDelay = 500;

        
        //Server
        int port;
        Game_Einstellungen einstellungen;

        //Datenbank
        DataSet dsProfil;
        DataTable dtProfil;
        DataTableReader reader;
        OleDbCommandBuilder cmd;
        OleDbCommand cmd2;

        //Console
        Console console;
        List<String> consoleDaten;

        //Spiel
        List<Spiel> games;

        #endregion

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

        public int MaxPlayer
        {
            get
            {
                return maxPlayer;
            }

            set
            {
                maxPlayer = value;
            }
        }
        #endregion

        #region Datenbank
        private void starteDatenbank()
        {
            try
            {
                connection = new OleDbConnection(Properties.Settings.Default.DBCon);
                dsProfil = new DataSet();
                adapter = new OleDbDataAdapter("Select Profil.* from Profil", connection);
                
                adapter.Fill(dsProfil, "Profil");
                dtProfil = dsProfil.Tables["Profil"];

                dataGridView1.DataSource = dsProfil;
                dataGridView1.DataMember = "Profil";

                labelDatenbankStatus.BackColor = Color.LightGreen;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                labelDatenbankStatus.BackColor = Color.Red;
            }
        }
        
        private void stoppeDatenbank()
        {
            labelDatenbankStatus.BackColor = Color.Red;
            connection.Close();
            connection = null;
        }
        #endregion

        #region Server
        private void starteServer()
        {
            try
            {

                spieler = new List<Spieler>();

                listener = new TcpListener(Port);

                listener.Start();

                timer1.Start();

                labelPort.Text = einstellungen.Port.ToString();
                labelMaxAnzahl.Text = einstellungen.MaxAnzahl.ToString();

                thread = new Thread(threadStart);
                thread.Start();
            }
            catch(Exception e)
            {
                stoppeServer();
            }
        }

        private void stoppeServer()
        {

            labelPort.Text = "0";
            labelMaxAnzahl.Text = "0";

            spieler = null;
            listener = null;

            thread.Interrupt();
            timer1.Stop();
        }
        
        #endregion

        #region EmpfangeDaten
        private void empfangeDaten()
        {
            while (serverAn == true)
            {
                client = listener.AcceptTcpClient();

                if (spieleranzahl <= MaxPlayer)
                {
                    erstelleClient();
                }
            }
        }
        #endregion

        #region Konstruktor
        public Form1()
        {
            InitializeComponent();

            //Statusbackgroundfarbe
            labelServerStatus.BackColor = Color.Red;
            labelDatenbankStatus.BackColor = Color.Red;

            //Einstellungen
            einstellungen = new Game_Einstellungen(this);
            this.Port = einstellungen.Port;

            //Datenbank

            //Console
            console = new Console(this);
            consoleDaten = new List<string>();
            consoleDaten.Add("Test");

            //Timer
            timer1.Interval = 1;

            //Thread
            threadStart = new ThreadStart(empfangeDaten);

            //Spiel
            games = new List<Spiel>();
        }
        #endregion

        #region GUI
        private void datenbankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            starteDatenbank();
        }
        private void einstellungenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            einstellungen.öffneGui();
        }

        private void startenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startenToolStripMenuItem.Text == "Server Starten")
            {
                startenToolStripMenuItem.Text = "Server Stoppen";
                serverAn = true;
                labelServerStatus.BackColor = Color.LightGreen;
                starteServer();
            }
            else
            {
                startenToolStripMenuItem.Text = "Server Starten";
                serverAn = false;
                labelServerStatus.BackColor = Color.Red;
                stoppeServer();
            }
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            console.ConsoleDaten = consoleDaten;
            console.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (console != null)
            {
                console.Close();
                console = null;
            }

            serverAn = false;

            if(listener != null)
                listener = null;

            if (client != null)
            {
                client.Close();
                client = null;
            }

            if(spieler != null)
                spieler = null;

            if(namen != null)
                namen = null;

            if (thread != null)
            {
                thread.Interrupt();
                thread = null;
            }

            if(dsProfil != null)
                dsProfil = null;

            if(dtProfil != null)
               dtProfil = null;

            if (reader != null)
            {
                reader.Close();
                reader = null;
            }

            if(cmd != null)
               cmd = null;

            if(cmd2 != null)
               cmd2 = null;

            if (einstellungen != null)
            {
                einstellungen.Close();
                einstellungen = null;
            }

        }
        #endregion

        #region Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            zeit++;
            console.Zeit = zeit;
                        
            if (meldungZeit < zeit)
            {
                statusStrip.Items.Clear();
            }
            

        }
        #endregion
        
        #region Server - Spieler
        private void erstelleClient()
        {
            player = new Spieler(client, this);
        }

        public void addPlayer(String name)
        {
            spieleranzahl++;
            player.Spielernummer = spieleranzahl;

            spieler.Add(player);

            player = null;
        }
        
        public void removePlayer()
        {

        }
        #endregion

        #region Datenbank - Spieler
        public Boolean abfrageLoginUser(String name, String passwort)
        {
            name = name.ToLower();
            try
            {
                foreach (DataRow dr in dtProfil.Rows)
                {
                    if (dr["Name"].ToString().ToLower().Equals(name))
                    {
                        if(dr["Passwort"].ToString().Equals(passwort))
                        {
                            return true;
                        }
                    }
                }
            }
            catch
            {

            }

            return false;
        }
        
        public Boolean abfrageRegisterName(String name)
        {
            name = name.ToLower();
            try
            {
                foreach (DataRow dr in dtProfil.Rows)
                {
                    if (dr["Name"].ToString().ToLower() == name)
                    {
                        return true;
                    }
                }
                
                return false;
            }
            catch
            {

            }

            return true;

        }

        public void registriereUser(String name, String passwort)
        {
            DataTable table = dsProfil.Tables["Profil"];
            DataRow newRow = table.NewRow();
            OleDbCommandBuilder cmdBld = new OleDbCommandBuilder(adapter);

            newRow["Name"] = name;
            newRow["Wins"] = 0;
            newRow["Loses"] = 0;
            newRow["Spiele"] = 0;
            newRow["Spielzeit"] = 0;
            newRow["Passwort"] = passwort;
            table.Rows.Add(newRow);

            adapter.InsertCommand = cmdBld.GetInsertCommand();
            adapter.Update(dsProfil.Tables["Profil"]);

            table = null;
            newRow = null;
            cmdBld = null;
        }
        #endregion

        #region Chat
        public void sendePrivatNachricht(String name, String text)
        {
            foreach(Spieler s in spieler)
            {
                if(s.Name == name)
                {
                    s.sendeNachricht(text);
                }
            }
        }
        #endregion

        #region Status / Console
        private void updateStatusStrip(int nummer)
        {
            statusStrip.Items.Clear();

            switch (nummer)
            {
                case 1:
                    statusStrip.Items.Add("Fehler beim laden der Daten ...");
                    meldungZeit = zeit + meldungDelay;
                    break;
            }
        }

        #endregion

        #region Spiel
        public void starteSpiel(Spieler s1, Spieler s2)
        {
            Spiel spiel = new Spiel(s1, s2, this);
        }

        public void beendeSpiel(Spiel spiel)
        {
            games.Remove(spiel);
        }
        #endregion


    }
}
