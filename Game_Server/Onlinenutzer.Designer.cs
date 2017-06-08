namespace Game_Server
{
    partial class Onlinenutzer
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelOnline = new System.Windows.Forms.Label();
            this.pfeil2 = new System.Windows.Forms.PictureBox();
            this.Pfeil1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pfeil2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pfeil1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(-1, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(145, 199);
            this.listBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 204);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Online:";
            // 
            // labelOnline
            // 
            this.labelOnline.AutoSize = true;
            this.labelOnline.Location = new System.Drawing.Point(50, 204);
            this.labelOnline.Name = "labelOnline";
            this.labelOnline.Size = new System.Drawing.Size(13, 13);
            this.labelOnline.TabIndex = 2;
            this.labelOnline.Text = "0";
            // 
            // pfeil2
            // 
            this.pfeil2.Image = global::Game_Server.Properties.Resources.PfeilRechts2;
            this.pfeil2.Location = new System.Drawing.Point(121, 204);
            this.pfeil2.Name = "pfeil2";
            this.pfeil2.Size = new System.Drawing.Size(23, 22);
            this.pfeil2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pfeil2.TabIndex = 4;
            this.pfeil2.TabStop = false;
            this.pfeil2.Visible = false;
            this.pfeil2.Click += new System.EventHandler(this.pfeil2_Click);
            this.pfeil2.MouseLeave += new System.EventHandler(this.pfeil2_MouseLeave);
            // 
            // Pfeil1
            // 
            this.Pfeil1.Image = global::Game_Server.Properties.Resources.PfeilRechts1;
            this.Pfeil1.Location = new System.Drawing.Point(121, 204);
            this.Pfeil1.Name = "Pfeil1";
            this.Pfeil1.Size = new System.Drawing.Size(23, 22);
            this.Pfeil1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Pfeil1.TabIndex = 3;
            this.Pfeil1.TabStop = false;
            this.Pfeil1.MouseEnter += new System.EventHandler(this.Pfeil1_MouseEnter);
            // 
            // Onlinenutzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(144, 226);
            this.Controls.Add(this.pfeil2);
            this.Controls.Add(this.Pfeil1);
            this.Controls.Add(this.labelOnline);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Onlinenutzer";
            this.Text = "Onlinenutzer";
            ((System.ComponentModel.ISupportInitialize)(this.pfeil2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pfeil1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelOnline;
        private System.Windows.Forms.PictureBox Pfeil1;
        private System.Windows.Forms.PictureBox pfeil2;
    }
}