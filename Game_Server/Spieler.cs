using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using Game_Server;

namespace Game_Server
{
    class Spieler
    {
        #region Attribute
        const char TRENN = ';';
        const String NICK = "NIC";
        const String CIAO = "BYE";

        TcpClient client = null;
        Form1 server = null;

        Thread thread;
        ThreadStart threadStart;

        NetworkStream stream;

        byte[] bytes = new byte[1024];
        int bytesRead = 0;

        String name;
        int spielernummer = 0;

        Boolean loginSuccess = false;

        Boolean aktiv = true;
        #endregion

        #region Getter / Setter
        public int Spielernummer
        {
            get
            {
                return spielernummer;
            }

            set
            {
                spielernummer = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public bool LoginSuccess
        {
            get
            {
                return loginSuccess;
            }

            set
            {
                loginSuccess = value;
            }
        }
        #endregion

        #region Konstruktor
        public Spieler(TcpClient client, Form1 server)
        {
            this.client = client;
            this.server = server;

            stream = client.GetStream();

            threadStart = new ThreadStart(empfangeDaten);
            thread = new Thread(threadStart);
            thread.Start();
        }
        #endregion

        #region EmpfangeDaten
        private void empfangeDaten()
        {
            String name;
            String passwort;

            String text;
            String[] daten;

            try
            {
                while (aktiv)
                {
                    bytesRead = stream.Read(bytes, 0, bytes.Length);

                    text = Encoding.ASCII.GetString(bytes);
                    daten = text.Split(TRENN);
                    
                    switch (daten[0])
                    {
                        //Registration Namensüberprüfung
                        case "DRN":
                            name = daten[1];

                            if(server.abfrageRegisterName(name))
                            {
                                //Name vorhanden
                                bytes = Encoding.ASCII.GetBytes("DRN" + TRENN + "1");
                                stream.Write(bytes, 0, bytes.Length);
                            }
                            else
                            {
                                //Name frei
                                bytes = Encoding.ASCII.GetBytes("DRN" + TRENN + "0");
                                stream.Write(bytes, 0, bytes.Length);
                            }

                            break;
                        //Registration
                        case "DBR":
                            name = daten[1];
                            passwort = daten[2];

                            server.registriereUser(name, passwort);

                            break;
                        //Login
                        case "DBL":
                            name = daten[1];
                            passwort = daten[2];

                            if(server.abfrageLoginUser(name, passwort))
                            {
                                //Name + Passwort stimmen überein
                                bytes = Encoding.ASCII.GetBytes("DBL" + TRENN + "0" + TRENN /* + Daten */);
                                stream.Write(bytes, 0, bytes.Length);
                                loginSuccess = true;
                                server.addPlayer(name);
                            }
                            else
                            {
                                //Name + Passwort stimmen nicht überein
                                bytes = Encoding.ASCII.GetBytes("DBL" + TRENN + "1");
                                stream.Write(bytes, 0, bytes.Length);
                            }
                            break;
                        //Chat
                        case "MSG":
                            String übergabe = "MSG" + TRENN + Name + TRENN + daten[2];
                            server.sendePrivatNachricht(daten[1], übergabe);
                            break;
                    }
                }
            }
            catch(ThreadInterruptedException ex)
            {
                thread.Interrupt();
            }
        }
        #endregion

        #region Chat
        public void sendeNachricht(String text)
        {
            Byte[] bytes = new Byte[1024];

            bytes = Encoding.ASCII.GetBytes(text);

            stream.Write(bytes, 0, bytes.Length);
        }
        #endregion
    }
}
