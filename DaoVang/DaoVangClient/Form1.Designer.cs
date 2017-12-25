namespace DaoVangClient
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
            this.play_btn = new System.Windows.Forms.Button();
            this.go_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ConnectServer_btn = new System.Windows.Forms.Button();
            this.Connections_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ServerPort_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIP_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Client2_tb = new System.Windows.Forms.TextBox();
            this.Client1_tb = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // play_btn
            // 
            this.play_btn.Enabled = false;
            this.play_btn.Location = new System.Drawing.Point(10, 29);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(170, 25);
            this.play_btn.TabIndex = 1;
            this.play_btn.Text = "PLAY";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // go_btn
            // 
            this.go_btn.Enabled = false;
            this.go_btn.Location = new System.Drawing.Point(10, 81);
            this.go_btn.Name = "go_btn";
            this.go_btn.Size = new System.Drawing.Size(170, 113);
            this.go_btn.TabIndex = 3;
            this.go_btn.Text = "GRAB !";
            this.go_btn.UseVisualStyleBackColor = true;
            this.go_btn.Click += new System.EventHandler(this.go_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ConnectServer_btn);
            this.groupBox1.Controls.Add(this.Connections_tb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ServerPort_tb);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ServerIP_tb);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(792, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 417);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server";
            // 
            // ConnectServer_btn
            // 
            this.ConnectServer_btn.Location = new System.Drawing.Point(10, 109);
            this.ConnectServer_btn.Name = "ConnectServer_btn";
            this.ConnectServer_btn.Size = new System.Drawing.Size(170, 23);
            this.ConnectServer_btn.TabIndex = 6;
            this.ConnectServer_btn.Text = "CONNECT";
            this.ConnectServer_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ConnectServer_btn.UseVisualStyleBackColor = true;
            this.ConnectServer_btn.Click += new System.EventHandler(this.ConnectServer_btn_Click);
            // 
            // Connections_tb
            // 
            this.Connections_tb.Location = new System.Drawing.Point(10, 179);
            this.Connections_tb.Multiline = true;
            this.Connections_tb.Name = "Connections_tb";
            this.Connections_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Connections_tb.Size = new System.Drawing.Size(170, 232);
            this.Connections_tb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Connections";
            // 
            // ServerPort_tb
            // 
            this.ServerPort_tb.Location = new System.Drawing.Point(63, 68);
            this.ServerPort_tb.Name = "ServerPort_tb";
            this.ServerPort_tb.Size = new System.Drawing.Size(117, 20);
            this.ServerPort_tb.TabIndex = 3;
            this.ServerPort_tb.Text = "13000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // ServerIP_tb
            // 
            this.ServerIP_tb.Location = new System.Drawing.Point(6, 42);
            this.ServerIP_tb.Name = "ServerIP_tb";
            this.ServerIP_tb.Size = new System.Drawing.Size(174, 20);
            this.ServerIP_tb.TabIndex = 1;
            this.ServerIP_tb.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Client2_tb);
            this.groupBox2.Controls.Add(this.Client1_tb);
            this.groupBox2.Controls.Add(this.go_btn);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.play_btn);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(792, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 315);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clients";
            // 
            // Client2_tb
            // 
            this.Client2_tb.Enabled = false;
            this.Client2_tb.Location = new System.Drawing.Point(63, 261);
            this.Client2_tb.Name = "Client2_tb";
            this.Client2_tb.Size = new System.Drawing.Size(117, 20);
            this.Client2_tb.TabIndex = 9;
            // 
            // Client1_tb
            // 
            this.Client1_tb.Enabled = false;
            this.Client1_tb.Location = new System.Drawing.Point(63, 220);
            this.Client1_tb.Name = "Client1_tb";
            this.Client1_tb.Size = new System.Drawing.Size(117, 20);
            this.Client1_tb.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(7, 255);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 26);
            this.label5.TabIndex = 7;
            this.label5.Text = "Opponent\npoints";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(7, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "My points";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 762);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Button go_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button ConnectServer_btn;
        private System.Windows.Forms.TextBox Connections_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerPort_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerIP_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Client2_tb;
        private System.Windows.Forms.TextBox Client1_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

