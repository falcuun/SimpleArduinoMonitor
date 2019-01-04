using System;
using System.Windows.Forms;
using System.IO.Ports;

namespace SimpleArduinoSerialMonitor
{
    public partial class Form1 : Form
    {
        private ArduinoMonitor am;
        private string com_name;
        private int baud_rate;

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
            baud_rate = Int32.Parse(BAUD_RATES.GetItemText(BAUD_RATES.SelectedItem));
        }

        private void CONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            am = new ArduinoMonitor(com_name, baud_rate);
            if(am.OpenPort()){
                READ_BUTTON.Enabled = true;
            }
        }

        private void ArduinoSerialReadEventHandler(object sender, ArduinoSerialReadEventArgs e)
        {
            SetText(e.message);
        }

        private void SetText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(SetText), text);
                return;
            }
            SERIAL_READ.AppendText(text);
            SERIAL_READ.AppendText(Environment.NewLine);
        }

        private void READ_BUTTON_Click(object sender, EventArgs e)
        {
            am.ardEvent += ArduinoSerialReadEventHandler;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            READ_BUTTON.Enabled = false;
        }
    }
}
