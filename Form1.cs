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
            am.OpenPort();

        }

        private void SetText(string text)
        {

        }
    }
}
