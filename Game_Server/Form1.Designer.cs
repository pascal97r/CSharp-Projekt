namespace Game_Server
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxPlayer = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.startenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelDatenbankStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMaxAnzahl = new System.Windows.Forms.Label();
            this.listBoxChat = new System.Windows.Forms.ListBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.buttonKick = new System.Windows.Forms.Button();
            this.buttonBan = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxPlayer
            // 
            this.listBoxPlayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxPlayer.FormattingEnabled = true;
            this.listBoxPlayer.ItemHeight = 20;
            this.listBoxPlayer.Location = new System.Drawing.Point(12, 42);
            this.listBoxPlayer.Name = "listBoxPlayer";
            this.listBoxPlayer.Size = new System.Drawing.Size(122, 104);
            this.listBoxPlayer.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startenToolStripMenuItem,
            this.datenbankToolStripMenuItem,
            this.einstellungenToolStripMenuItem,
            this.consoleToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(375, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // startenToolStripMenuItem
            // 
            this.startenToolStripMenuItem.Name = "startenToolStripMenuItem";
            this.startenToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.startenToolStripMenuItem.Text = "Server Starten";
            this.startenToolStripMenuItem.Click += new System.EventHandler(this.startenToolStripMenuItem_Click);
            // 
            // datenbankToolStripMenuItem
            // 
            this.datenbankToolStripMenuItem.Name = "datenbankToolStripMenuItem";
            this.datenbankToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.datenbankToolStripMenuItem.Text = "Daten laden";
            this.datenbankToolStripMenuItem.Click += new System.EventHandler(this.datenbankToolStripMenuItem_Click);
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.einstellungenToolStripMenuItem.Text = "Einstellungen";
            this.einstellungenToolStripMenuItem.Click += new System.EventHandler(this.einstellungenToolStripMenuItem_Click);
            // 
            // consoleToolStripMenuItem
            // 
            this.consoleToolStripMenuItem.Name = "consoleToolStripMenuItem";
            this.consoleToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.consoleToolStripMenuItem.Text = "Console";
            this.consoleToolStripMenuItem.Click += new System.EventHandler(this.consoleToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Serverstatus:";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Location = new System.Drawing.Point(87, 164);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(25, 13);
            this.labelServerStatus.TabIndex = 4;
            this.labelServerStatus.Text = "      ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datenbankstatus:";
            // 
            // labelDatenbankStatus
            // 
            this.labelDatenbankStatus.AutoSize = true;
            this.labelDatenbankStatus.Location = new System.Drawing.Point(109, 197);
            this.labelDatenbankStatus.Name = "labelDatenbankStatus";
            this.labelDatenbankStatus.Size = new System.Drawing.Size(25, 13);
            this.labelDatenbankStatus.TabIndex = 6;
            this.labelDatenbankStatus.Text = "      ";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 318);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(375, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(284, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port:";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(328, 31);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(13, 13);
            this.labelPort.TabIndex = 9;
            this.labelPort.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Max. Anzahl:";
            // 
            // labelMaxAnzahl
            // 
            this.labelMaxAnzahl.AutoSize = true;
            this.labelMaxAnzahl.Location = new System.Drawing.Point(328, 51);
            this.labelMaxAnzahl.Name = "labelMaxAnzahl";
            this.labelMaxAnzahl.Size = new System.Drawing.Size(13, 13);
            this.labelMaxAnzahl.TabIndex = 11;
            this.labelMaxAnzahl.Text = "0";
            // 
            // listBoxChat
            // 
            this.listBoxChat.FormattingEnabled = true;
            this.listBoxChat.Location = new System.Drawing.Point(158, 156);
            this.listBoxChat.Name = "listBoxChat";
            this.listBoxChat.Size = new System.Drawing.Size(210, 134);
            this.listBoxChat.TabIndex = 12;
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(158, 288);
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(210, 20);
            this.textBoxChat.TabIndex = 13;
            this.textBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyDown);
            // 
            // buttonKick
            // 
            this.buttonKick.Location = new System.Drawing.Point(140, 122);
            this.buttonKick.Name = "buttonKick";
            this.buttonKick.Size = new System.Drawing.Size(88, 24);
            this.buttonKick.TabIndex = 14;
            this.buttonKick.Text = "Kicken";
            this.buttonKick.UseVisualStyleBackColor = true;
            // 
            // buttonBan
            // 
            this.buttonBan.Location = new System.Drawing.Point(140, 92);
            this.buttonBan.Name = "buttonBan";
            this.buttonBan.Size = new System.Drawing.Size(88, 24);
            this.buttonBan.TabIndex = 15;
            this.buttonBan.Text = "Bannen";
            this.buttonBan.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 340);
            this.Controls.Add(this.buttonBan);
            this.Controls.Add(this.buttonKick);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.listBoxChat);
            this.Controls.Add(this.labelMaxAnzahl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.labelDatenbankStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelServerStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxPlayer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxPlayer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem startenToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelDatenbankStatus;
        private System.Windows.Forms.ToolStripMenuItem datenbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMaxAnzahl;
        private System.Windows.Forms.ToolStripMenuItem consoleToolStripMenuItem;
        private System.Data.OleDb.OleDbConnection connection;
        private System.Data.OleDb.OleDbDataAdapter adapter;
        private System.Windows.Forms.ListBox listBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Button buttonKick;
        private System.Windows.Forms.Button buttonBan;
    }
}

