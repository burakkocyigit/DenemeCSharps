namespace S7.Net_Example
{
    partial class FormMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtSlot = new System.Windows.Forms.TextBox();
            this.txtRack = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboxCPUType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.btnMRead = new System.Windows.Forms.Button();
            this.btnMWrite = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDisconnect);
            this.groupBox1.Controls.Add(this.btnConnect);
            this.groupBox1.Controls.Add(this.txtSlot);
            this.groupBox1.Controls.Add(this.txtRack);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboxCPUType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 189);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(182, 131);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(73, 25);
            this.btnDisconnect.TabIndex = 1;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(80, 131);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(73, 25);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtSlot
            // 
            this.txtSlot.Location = new System.Drawing.Point(80, 105);
            this.txtSlot.Name = "txtSlot";
            this.txtSlot.Size = new System.Drawing.Size(175, 20);
            this.txtSlot.TabIndex = 4;
            this.txtSlot.Text = "1";
            // 
            // txtRack
            // 
            this.txtRack.Location = new System.Drawing.Point(80, 79);
            this.txtRack.Name = "txtRack";
            this.txtRack.Size = new System.Drawing.Size(175, 20);
            this.txtRack.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Slot:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(80, 53);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(175, 20);
            this.txtIPAddress.TabIndex = 2;
            this.txtIPAddress.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Rack:";
            // 
            // cboxCPUType
            // 
            this.cboxCPUType.FormattingEnabled = true;
            this.cboxCPUType.Location = new System.Drawing.Point(80, 26);
            this.cboxCPUType.Name = "cboxCPUType";
            this.cboxCPUType.Size = new System.Drawing.Size(175, 21);
            this.cboxCPUType.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "CPU type:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnMWrite);
            this.groupBox2.Controls.Add(this.btnMRead);
            this.groupBox2.Controls.Add(this.txtPV);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtSP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtMAddress);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 142);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Read/Write M Memory";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Address:";
            // 
            // txtMAddress
            // 
            this.txtMAddress.Location = new System.Drawing.Point(80, 22);
            this.txtMAddress.Name = "txtMAddress";
            this.txtMAddress.Size = new System.Drawing.Size(175, 20);
            this.txtMAddress.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "SP:";
            // 
            // txtSP
            // 
            this.txtSP.Location = new System.Drawing.Point(80, 48);
            this.txtSP.Name = "txtSP";
            this.txtSP.Size = new System.Drawing.Size(175, 20);
            this.txtSP.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "PV:";
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(80, 74);
            this.txtPV.Name = "txtPV";
            this.txtPV.Size = new System.Drawing.Size(175, 20);
            this.txtPV.TabIndex = 3;
            // 
            // btnMRead
            // 
            this.btnMRead.Location = new System.Drawing.Point(80, 101);
            this.btnMRead.Name = "btnMRead";
            this.btnMRead.Size = new System.Drawing.Size(75, 23);
            this.btnMRead.TabIndex = 4;
            this.btnMRead.Text = "Read";
            this.btnMRead.UseVisualStyleBackColor = true;
            this.btnMRead.Click += new System.EventHandler(this.btnMRead_Click);
            // 
            // btnMWrite
            // 
            this.btnMWrite.Location = new System.Drawing.Point(180, 101);
            this.btnMWrite.Name = "btnMWrite";
            this.btnMWrite.Size = new System.Drawing.Size(75, 23);
            this.btnMWrite.TabIndex = 4;
            this.btnMWrite.Text = "Write";
            this.btnMWrite.UseVisualStyleBackColor = true;
            this.btnMWrite.Click += new System.EventHandler(this.btnMWrite_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 357);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormMain";
            this.Text = "How to use S7.Net Connected to Siemens S7 PLC using Visual C#";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtSlot;
        private System.Windows.Forms.TextBox txtRack;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboxCPUType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnMWrite;
        private System.Windows.Forms.Button btnMRead;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMAddress;
        private System.Windows.Forms.Label label5;
    }
}

