using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SimpleArduinoSerialMonitor
{
    public partial class Form1 : Form
    {
        private ArduinoMonitor am;
        private string com_name;
        private int baud_rate;
        private bool TextWasChanged = false;
        private OpenFileDialog opf = new OpenFileDialog();

        #region VS Generated Methods
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            COM_NAMES.Items.Clear();
            string[] port_names = SerialPort.GetPortNames();
            COM_NAMES.Items.AddRange(port_names);
        }

        private void COM_NAMES_SelectedIndexChanged(object sender, EventArgs e)
        {
            com_name = COM_NAMES.GetItemText(COM_NAMES.SelectedItem);
        }

        private void BAUD_RATES_SelectedIndexChanged(object sender, EventArgs e)
        {
            baud_rate = int.Parse(BAUD_RATES.GetItemText(BAUD_RATES.SelectedItem));
        }

        private void CONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            am = new ArduinoMonitor(com_name, baud_rate);
            if (am.OpenPort())
            {
                DISCONNECT_BUTTON.Enabled = true;
                READ_BUTTON.Enabled = true;
                WRITE_BUTTON.Enabled = true;
                CONNECT_BUTTON.Enabled = false;
            }
        }

        private void READ_BUTTON_Click(object sender, EventArgs e)
        {
            am.ardEvent += ArduinoSerialReadEventHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DISCONNECT_BUTTON.Enabled = false;
            READ_BUTTON.Enabled = false;
            WRITE_BUTTON.Enabled = false;
        }

        private void WRITE_BUTTON_Click(object sender, EventArgs e)
        {
            am.WriteToArduino(SERIAL_WRITE.Text);
        }
        #endregion

        private void ArduinoSerialReadEventHandler(object sender, ArduinoSerialReadEventArgs e)
        {
            SetText(e.message);
            SetTextFile(e.message);
        }

        private void WriteToFileEventHandler(object sender, ArduinoSerialReadEventArgs e)
        {
            WriteToFile(e.message);
        }

        /*TODO 1:
         Add a way to stop writing to file before disconnecting.
             */
        private void SetText(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(SetText), text);
                    return;
                }
                SERIAL_READ.AppendText(text);
                SERIAL_READ.AppendText(Environment.NewLine);
            }
            catch (System.ObjectDisposedException)
            { return; }
        }

        private void SetTextFile(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(SetTextFile), text);
                    return;
                }
                ONE_LINE_READ.Text = text;
            }
            catch (System.ObjectDisposedException)
            { return; }
        }

        private void WriteToFile(string text)
        {
            if (File.Exists(FILE_PATH_BOX.Text))
            {
                ONE_LINE_READ.TextChanged += ONE_LINE_READ_TEXTCHANGED;
                using (StreamWriter tw = new StreamWriter(FILE_PATH_BOX.Text, true))
                {
                    if (TextWasChanged)
                    {
                        tw.Write(text);
                    }
                }
            }
        }

        private void ONE_LINE_READ_TEXTCHANGED(object sender, EventArgs e)
        {
            TextWasChanged = true;
        }

        private void DISCONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            if (am.ClosePort())
            {
                CONNECT_BUTTON.Enabled = true;
                DISCONNECT_BUTTON.Enabled = false;
            }
        }

        /*TODO 2: 
         Add a way to enter file path and create a new file if it doesn't exist 
             
             */
        private void WRITE_TO_FILE_BUTTON_Click(object sender, EventArgs e)
        {
            opf.ShowDialog();
            FILE_PATH_BOX.Text = opf.FileName;
            am.ardEvent += WriteToFileEventHandler;
        }
    }
}
