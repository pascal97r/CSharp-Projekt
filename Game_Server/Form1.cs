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

                updateConsole("[Server] >> Datenbank gestartet");
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
            updateConsole("[Server] >> Datenbank gestoppt");
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

                updateConsole("[Server] >> Server gestartet");

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

            updateConsole("[Server] >> Server gestoppt");

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

                erstelleClient();

                //if (spieleranzahl <= MaxPlayer)
                //{
                //    erstelleClient();
                //}
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
            if(console == null)
            {
                console = new Console(this);
                console.ConsoleDaten = consoleDaten;
                console.Show();
            }
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

            updateConsole("[Server] >> Spieler hinzugefügt : " + name + " : " + player.Spielernummer);

            player = null;
        }
        
        public void sendPlayerData(Spieler p)
        {
            int win = 0;
            int lose = 0;
            int spiele = 0;
            int spielzeit = 0;

            foreach (DataRow dr in dtProfil.Rows)
            {
                if (dr["Name"].ToString().ToLower().Equals(p.Name))
                {
                    win = Convert.ToInt32(dr["Wins"]);
                    lose = Convert.ToInt32(dr["Loses"]);
                    spiele = Convert.ToInt32(dr["Spiele"]);
                    spielzeit = Convert.ToInt32(dr["Spielzeit"]);

                    break;
                }
            }

            updateConsole("[Server] >> Befehl: " + "DPD" + ";" + win + ";" + lose + ";" + spiele + ";" + spielzeit + ";");

            spieler[p.Spielernummer].sendeNachricht("DPD" + ";" + win + ";" + lose + ";" + spiele + ";" + spielzeit + ";");
        }

        public void sendUserlist(Spieler p)
        {
            String namen = "";

            foreach(Spieler s in spieler)
            {
                namen += s.Name;
                namen += ";";
            }

            updateConsole("[Server] >> Befehl: " + "URL" + namen);

            spieler[p.Spielernummer].sendeNachricht("URL" + namen);
        }

        public void sendHighscore(Spieler p)
        {
            int highscore = 0;

            foreach (DataRow dr in dtProfil.Rows)
            {
                if (dr["Name"].ToString().ToLower().Equals(p.Name))
                {
                    highscore = Convert.ToInt32(dr["Highscore"]);

                    break;
                }
            }

            updateConsole("[Server] >> Befehl: " + "HSC" + highscore + ";");

            spieler[p.Spielernummer].sendeNachricht("HSC" + highscore + ";");
        }

        public void removePlayer(Spieler p)
        {
            spieler.Remove(p);
            p = null;
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
                            updateConsole("[Server] >> Loginabfrage: " + name + " : " + passwort + " : True");
                            return true;
                        }
                    }
                }
            }
            catch
            {

            }

            updateConsole("[Server] >> Loginabfrage: " + name + " : " + passwort + " : False");

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
                        updateConsole("[Server] >> Registernameabfrage: " + name + " : Name vorhanden");
                        return true;
                    }
                }

                updateConsole("[Server] >> Registernameabfrage: " + name + " : Name frei");

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

            updateConsole("[Server] >> Registrierung: " + name + " : " + passwort);

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


        private void textBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                broadcast();
            }
        }

        private void broadcast()
        {
            String nachricht = textBoxChat.Text;

            //foreach(Spieler s in spieler)
            //{
            //    s.sendeNachricht("MSG" + ";" + "|Broadcast|" + ";" + nachricht + ";");
            //}

            updateConsole("[Server] >> Broadcast: " + nachricht);
            textBoxChat.Text = "";
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

        private void updateConsole(String nachricht)
        {
            if(console != null)
            {
                console.setListBoxText(nachricht);
            }
            consoleDaten.Add(nachricht);
        }

        public void closeConsole()
        {
            console = null;
        }

        #endregion

        #region Spiel
        public void starteSpiel(Spieler s1, Spieler s2)
        {
            updateConsole("[Server] >> Spielmanager: Spiel gestartet von " + s1.Name + " : Mitspieler : " + s2.Name);
            Spiel spiel = new Spiel(s1, s2, this);
        }

        public void beendeSpiel(Spiel spiel)
        {
            updateConsole("[Server] >> Spielmanager : Spiel beendet von " + spiel.Spieler[0]);
            games.Remove(spiel);
        }

        #endregion


    }
}
