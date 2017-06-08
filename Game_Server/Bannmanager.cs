using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Game_Server
{
    public partial class Bannmanager : Form
    {
        private List<String> bannedip;
        private Game_Einstellungen einstellungen;

        public Bannmanager(Game_Einstellungen einstellungen, int x, int y)
        {
            InitializeComponent();
            this.einstellungen = einstellungen;
            bannedip = new List<string>();

            öffneDatei();
        }

        private void öffneDatei()
        {
            FileStream stream = new FileStream("IPs.xml", FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(List<String>));
            bannedip = (List<String>)serializer.Deserialize(stream);

            foreach(String ip in bannedip)
            {
                listBox1.Items.Add(ip);
            }
        }

        private void speichereDatei()
        {
            FileStream stream = new FileStream("IPs.xml",FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<String>));
            serializer.Serialize(stream, bannedip);
        }

        private void addIp(String ip)
        {
            listBox1.Items.Add(ip);
            bannedip.Add(ip);
        }

        public Boolean checkIp(String ip)
        {
            foreach(String ips in bannedip)
            {
                if(ips.Equals(ip))
                {
                    return false;
                }
            }

            return true;
        }

        private void buttonSafe_Click(object sender, EventArgs e)
        {
            speichereDatei();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            einstellungen.closeBann();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            addIp(textBox1.Text);
        }
    }
}
