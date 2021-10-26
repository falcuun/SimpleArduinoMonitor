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
            this.OutputScreenTextView = new System.Windows.Forms.TextBox();
            this.WRITE_BUTTON = new System.Windows.Forms.Button();
            this.SERIAL_WRITE = new System.Windows.Forms.TextBox();
            this.DISCONNECT_BUTTON = new System.Windows.Forms.Button();
            this.CLEAR_OUTPUT_BUTTON = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BaudRateInputBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // COM_NAMES
            // 
            this.COM_NAMES.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.COM_NAMES.FormattingEnabled = true;
            this.COM_NAMES.Location = new System.Drawing.Point(58, 306);
            this.COM_NAMES.Name = "COM_NAMES";
            this.COM_NAMES.Size = new System.Drawing.Size(121, 21);
            this.COM_NAMES.TabIndex = 0;
            this.COM_NAMES.Click += new System.EventHandler(this.comboBox1_Click);
            // 
            // SERIAL_READ
            // 
            this.OutputScreenTextView.Location = new System.Drawing.Point(12, 12);
            this.OutputScreenTextView.Multiline = true;
            this.OutputScreenTextView.Name = "SERIAL_READ";
            this.OutputScreenTextView.ReadOnly = true;
            this.OutputScreenTextView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutputScreenTextView.Size = new System.Drawing.Size(776, 288);
            this.OutputScreenTextView.TabIndex = 5;
            // 
            // WRITE_BUTTON
            // 
            this.WRITE_BUTTON.Location = new System.Drawing.Point(713, 375);
            this.WRITE_BUTTON.Name = "WRITE_BUTTON";
            this.WRITE_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.WRITE_BUTTON.TabIndex = 7;
            this.WRITE_BUTTON.Text = "SEND";
            this.WRITE_BUTTON.UseVisualStyleBackColor = true;
            this.WRITE_BUTTON.Click += new System.EventHandler(this.WRITE_BUTTON_Click);
            // 
            // SERIAL_WRITE
            // 
            this.SERIAL_WRITE.Location = new System.Drawing.Point(15, 375);
            this.SERIAL_WRITE.Name = "SERIAL_WRITE";
            this.SERIAL_WRITE.Size = new System.Drawing.Size(672, 20);
            this.SERIAL_WRITE.TabIndex = 9;
            // 
            // DISCONNECT_BUTTON
            // 
            this.DISCONNECT_BUTTON.Location = new System.Drawing.Point(713, 306);
            this.DISCONNECT_BUTTON.Name = "DISCONNECT_BUTTON";
            this.DISCONNECT_BUTTON.Size = new System.Drawing.Size(75, 59);
            this.DISCONNECT_BUTTON.TabIndex = 12;
            this.DISCONNECT_BUTTON.Text = "OPEN";
            this.DISCONNECT_BUTTON.UseVisualStyleBackColor = true;
            this.DISCONNECT_BUTTON.Click += new System.EventHandler(this.DISCONNECT_BUTTON_Click);
            // 
            // CLEAR_OUTPUT_BUTTON
            // 
            this.CLEAR_OUTPUT_BUTTON.Location = new System.Drawing.Point(387, 304);
            this.CLEAR_OUTPUT_BUTTON.Name = "CLEAR_OUTPUT_BUTTON";
            this.CLEAR_OUTPUT_BUTTON.Size = new System.Drawing.Size(137, 23);
            this.CLEAR_OUTPUT_BUTTON.TabIndex = 18;
            this.CLEAR_OUTPUT_BUTTON.Text = "CLEAR OUTPUT";
            this.CLEAR_OUTPUT_BUTTON.UseVisualStyleBackColor = true;
            this.CLEAR_OUTPUT_BUTTON.Click += new System.EventHandler(this.CLEAR_OUTPUT_BUTTON_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 309);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "PORT:";
            // 
            // BaudRateInputBox
            // 
            this.BaudRateInputBox.Location = new System.Drawing.Point(253, 307);
            this.BaudRateInputBox.Name = "BaudRateInputBox";
            this.BaudRateInputBox.Size = new System.Drawing.Size(128, 20);
            this.BaudRateInputBox.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BaudRateInputBox);
            this.Controls.Add(this.CLEAR_OUTPUT_BUTTON);
            this.Controls.Add(this.DISCONNECT_BUTTON);
            this.Controls.Add(this.SERIAL_WRITE);
            this.Controls.Add(this.WRITE_BUTTON);
            this.Controls.Add(this.OutputScreenTextView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.COM_NAMES);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COM_NAMES;
        private System.Windows.Forms.TextBox OutputScreenTextView;
        private System.Windows.Forms.Button WRITE_BUTTON;
        private System.Windows.Forms.TextBox SERIAL_WRITE;
        private System.Windows.Forms.Button DISCONNECT_BUTTON;
        private System.Windows.Forms.Button CLEAR_OUTPUT_BUTTON;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BaudRateInputBox;
    }
}

