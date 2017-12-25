namespace DaoVangServer
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
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.StartServer_btn = new System.Windows.Forms.Button();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(10, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "PLAY";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(10, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(170, 101);
            this.button4.TabIndex = 3;
            this.button4.Text = "GRAB !";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.StartServer_btn);
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
            // StartServer_btn
            // 
            this.StartServer_btn.Location = new System.Drawing.Point(10, 109);
            this.StartServer_btn.Name = "StartServer_btn";
            this.StartServer_btn.Size = new System.Drawing.Size(170, 23);
            this.StartServer_btn.TabIndex = 6;
            this.StartServer_btn.Text = "START";
            this.StartServer_btn.UseVisualStyleBackColor = true;
            this.StartServer_btn.Click += new System.EventHandler(this.StartServer_btn_Click);
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
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(792, 435);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 129);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Clients";
            // 
            // Client2_tb
            // 
            this.Client2_tb.Enabled = false;
            this.Client2_tb.Location = new System.Drawing.Point(63, 59);
            this.Client2_tb.Name = "Client2_tb";
            this.Client2_tb.Size = new System.Drawing.Size(117, 20);
            this.Client2_tb.TabIndex = 9;
            // 
            // Client1_tb
            // 
            this.Client1_tb.Enabled = false;
            this.Client1_tb.Location = new System.Drawing.Point(63, 33);
            this.Client1_tb.Name = "Client1_tb";
            this.Client1_tb.Size = new System.Drawing.Size(117, 20);
            this.Client1_tb.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(7, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Client 2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(7, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Client 1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(792, 570);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(186, 180);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Play offline";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 762);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button StartServer_btn;
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
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

