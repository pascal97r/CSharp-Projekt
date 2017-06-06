﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Game_Server
{
    public partial class Console : Form
    {
        #region Attribute
        List<String> consoleDaten = new List<String>();
        int zeit = 0;

        Thread thread;
        ThreadStart threadStart;

        delegate void SetListBoxCallback(String text);

        Form1 server;
        #endregion

        #region Getter / Setter
        public List<string> ConsoleDaten
        {
            get
            {
                return consoleDaten;
            }

            set
            {
                consoleDaten = value;
            }
        }

        public int Zeit
        {
            get
            {
                return zeit;
            }

            set
            {
                zeit = value;
            }
        }
        #endregion

        #region Konstruktor
        public Console(Form1 server)
        {
            InitializeComponent();

            this.server = server;
            
        }
        #endregion

        #region Methode
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Console_Load(object sender, EventArgs e)
        {
            foreach(String text in ConsoleDaten)
            {
                listBox1.Items.Add(text);
            }
        }


        public void setListBoxText(String text)
        {
            if(listBox1.InvokeRequired)
            {
                SetListBoxCallback del = new SetListBoxCallback(setListBoxText);
                this.Invoke(del, new object[] { text });
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }
        #endregion

        private void Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            server.closeConsole();
        }
    }
}
