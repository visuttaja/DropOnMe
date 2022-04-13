namespace DropOnMe
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
            this.textBox_logbox = new System.Windows.Forms.TextBox();
            this.textBox_playlistaddress = new System.Windows.Forms.TextBox();
            this.playlistButton = new System.Windows.Forms.Button();
            this.ExplorerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_logbox
            // 
            this.textBox_logbox.AllowDrop = true;
            this.textBox_logbox.BackColor = System.Drawing.Color.Black;
            this.textBox_logbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_logbox.ForeColor = System.Drawing.Color.Lime;
            this.textBox_logbox.Location = new System.Drawing.Point(12, 109);
            this.textBox_logbox.Multiline = true;
            this.textBox_logbox.Name = "textBox_logbox";
            this.textBox_logbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_logbox.Size = new System.Drawing.Size(768, 185);
            this.textBox_logbox.TabIndex = 1;
            this.textBox_logbox.Text = "Log screen 2";
            this.textBox_logbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDown);
            // 
            // textBox_playlistaddress
            // 
            this.textBox_playlistaddress.AllowDrop = true;
            this.textBox_playlistaddress.BackColor = System.Drawing.Color.Black;
            this.textBox_playlistaddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_playlistaddress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.textBox_playlistaddress.Location = new System.Drawing.Point(22, 300);
            this.textBox_playlistaddress.Multiline = true;
            this.textBox_playlistaddress.Name = "textBox_playlistaddress";
            this.textBox_playlistaddress.Size = new System.Drawing.Size(768, 100);
            this.textBox_playlistaddress.TabIndex = 2;
            this.textBox_playlistaddress.Text = "https://www.youtube.com/watch?v=MchENkV93xc&list=PLkEkWhykb_XRTS1asRRAIPP9L_MwZCT" +
    "u3";
            // 
            // playlistButton
            // 
            this.playlistButton.ForeColor = System.Drawing.Color.Black;
            this.playlistButton.Location = new System.Drawing.Point(36, 414);
            this.playlistButton.Name = "playlistButton";
            this.playlistButton.Size = new System.Drawing.Size(317, 78);
            this.playlistButton.TabIndex = 3;
            this.playlistButton.Text = "Load Playlist";
            this.playlistButton.UseVisualStyleBackColor = true;
            this.playlistButton.Click += new System.EventHandler(this.playlistbutton_Click);
            // 
            // ExplorerButton
            // 
            this.ExplorerButton.ForeColor = System.Drawing.Color.Black;
            this.ExplorerButton.Location = new System.Drawing.Point(491, 12);
            this.ExplorerButton.Name = "ExplorerButton";
            this.ExplorerButton.Size = new System.Drawing.Size(209, 69);
            this.ExplorerButton.TabIndex = 4;
            this.ExplorerButton.Text = "Open root folder";
            this.ExplorerButton.UseVisualStyleBackColor = true;
            this.ExplorerButton.Click += new System.EventHandler(this.ExplorerButton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(802, 518);
            this.Controls.Add(this.ExplorerButton);
            this.Controls.Add(this.playlistButton);
            this.Controls.Add(this.textBox_playlistaddress);
            this.Controls.Add(this.textBox_logbox);
            this.ForeColor = System.Drawing.Color.Aqua;
            this.Name = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.Windows.Forms.TextBox textBox_logbox;
        private System.Windows.Forms.TextBox textBox_playlistaddress;
        private System.Windows.Forms.Button playlistButton;
        private System.Windows.Forms.Button ExplorerButton;
    }
}

