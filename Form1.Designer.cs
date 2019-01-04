namespace SimpleArduinoSerialMonitor
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
            this.COM_NAMES = new System.Windows.Forms.ComboBox();
            this.BAUD_RATES = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CONNECT_BUTTON = new System.Windows.Forms.Button();
            this.SERIAL_READ = new System.Windows.Forms.TextBox();
            this.READ_BUTTON = new System.Windows.Forms.Button();
            this.WRITE_BUTTON = new System.Windows.Forms.Button();
            this.SERIAL_WRITE = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // COM_NAMES
            // 
            this.COM_NAMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_NAMES.FormattingEnabled = true;
            this.COM_NAMES.Location = new System.Drawing.Point(12, 26);
            this.COM_NAMES.Name = "COM_NAMES";
            this.COM_NAMES.Size = new System.Drawing.Size(121, 21);
            this.COM_NAMES.TabIndex = 0;
            this.COM_NAMES.SelectedIndexChanged += new System.EventHandler(this.COM_NAMES_SelectedIndexChanged);
            this.COM_NAMES.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // BAUD_RATES
            // 
            this.BAUD_RATES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BAUD_RATES.FormattingEnabled = true;
            this.BAUD_RATES.Items.AddRange(new object[] {
            "110",
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.BAUD_RATES.Location = new System.Drawing.Point(139, 26);
            this.BAUD_RATES.Name = "BAUD_RATES";
            this.BAUD_RATES.Size = new System.Drawing.Size(121, 21);
            this.BAUD_RATES.TabIndex = 1;
            this.BAUD_RATES.SelectedIndexChanged += new System.EventHandler(this.BAUD_RATES_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "COM NAMES";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "BAUD RATES";
            // 
            // CONNECT_BUTTON
            // 
            this.CONNECT_BUTTON.Location = new System.Drawing.Point(267, 24);
            this.CONNECT_BUTTON.Name = "CONNECT_BUTTON";
            this.CONNECT_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.CONNECT_BUTTON.TabIndex = 4;
            this.CONNECT_BUTTON.Text = "Connect";
            this.CONNECT_BUTTON.UseVisualStyleBackColor = true;
            this.CONNECT_BUTTON.Click += new System.EventHandler(this.CONNECT_BUTTON_Click);
            // 
            // SERIAL_READ
            // 
            this.SERIAL_READ.Location = new System.Drawing.Point(8, 295);
            this.SERIAL_READ.Multiline = true;
            this.SERIAL_READ.Name = "SERIAL_READ";
            this.SERIAL_READ.ReadOnly = true;
            this.SERIAL_READ.Size = new System.Drawing.Size(334, 143);
            this.SERIAL_READ.TabIndex = 5;
            // 
            // READ_BUTTON
            // 
            this.READ_BUTTON.Location = new System.Drawing.Point(8, 266);
            this.READ_BUTTON.Name = "READ_BUTTON";
            this.READ_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.READ_BUTTON.TabIndex = 6;
            this.READ_BUTTON.Text = "READ";
            this.READ_BUTTON.UseVisualStyleBackColor = true;
            this.READ_BUTTON.Click += new System.EventHandler(this.READ_BUTTON_Click);
            // 
            // WRITE_BUTTON
            // 
            this.WRITE_BUTTON.Location = new System.Drawing.Point(713, 415);
            this.WRITE_BUTTON.Name = "WRITE_BUTTON";
            this.WRITE_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.WRITE_BUTTON.TabIndex = 7;
            this.WRITE_BUTTON.Text = "WRITE";
            this.WRITE_BUTTON.UseVisualStyleBackColor = true;
            this.WRITE_BUTTON.Click += new System.EventHandler(this.WRITE_BUTTON_Click);
            // 
            // SERIAL_WRITE
            // 
            this.SERIAL_WRITE.Location = new System.Drawing.Point(432, 417);
            this.SERIAL_WRITE.Name = "SERIAL_WRITE";
            this.SERIAL_WRITE.Size = new System.Drawing.Size(275, 20);
            this.SERIAL_WRITE.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "INPUT MESSAGE";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SERIAL_WRITE);
            this.Controls.Add(this.WRITE_BUTTON);
            this.Controls.Add(this.READ_BUTTON);
            this.Controls.Add(this.SERIAL_READ);
            this.Controls.Add(this.CONNECT_BUTTON);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BAUD_RATES);
            this.Controls.Add(this.COM_NAMES);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COM_NAMES;
        private System.Windows.Forms.ComboBox BAUD_RATES;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CONNECT_BUTTON;
        private System.Windows.Forms.TextBox SERIAL_READ;
        private System.Windows.Forms.Button READ_BUTTON;
        private System.Windows.Forms.Button WRITE_BUTTON;
        private System.Windows.Forms.TextBox SERIAL_WRITE;
        private System.Windows.Forms.Label label4;
    }
}

