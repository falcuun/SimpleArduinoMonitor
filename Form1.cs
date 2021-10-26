using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

namespace SimpleArduinoSerialMonitor
{
    public partial class Form1 : Form
    {
        private SerialPort _serialPort = null;
        private string _portName;
        private int _baudRate;

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
        private void Form1_Load(object sender, EventArgs e)
        {
            COM_NAMES.Items.Clear();
            string[] port_names = SerialPort.GetPortNames();
            COM_NAMES.Items.AddRange(port_names);
            COM_NAMES.SelectedIndex = 0;
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                DISCONNECT_BUTTON.Text = "OPEN";
            }
            else
            {
                DISCONNECT_BUTTON.Text = "CLOSE";
            }
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string msg = _serialPort.ReadLine();
                OutputScreenAppendText(msg);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void WRITE_BUTTON_Click(object sender, EventArgs e)
        {
            _serialPort.WriteLine(SERIAL_WRITE.Text);
        }

        private bool IsBusy = false;

        private void DISCONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            if (IsBusy) return;
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                IsBusy = true;
                _portName = COM_NAMES.SelectedItem.ToString();
                _baudRate = int.Parse(BaudRateInputBox.Text);
                if (_portName.Equals("")) return;
                if (_baudRate == 0) return;
                _serialPort = new SerialPort(_portName, _baudRate, Parity.None, 8, StopBits.One);
                try
                {
                    _serialPort.Open();
                    _serialPort.DataReceived += _serialPort_DataReceived;
                    if (_serialPort.IsOpen)
                    {
                        DISCONNECT_BUTTON.Text = "CLOSE";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }
            else
            {
                try
                {
                    IsBusy = true;
                    _serialPort.DataReceived -= _serialPort_DataReceived;
                    _serialPort.DiscardInBuffer();
                    _serialPort.Close();
                    DISCONNECT_BUTTON.Text = "OPEN";
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    IsBusy = false;
                }
            }

        }

        private void OutputScreenAppendText(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(OutputScreenAppendText), text);
                    return;
                }
                OutputScreenTextView.AppendText(System.DateTime.Now.ToString());
                OutputScreenTextView.AppendText(" " + text);
                OutputScreenTextView.AppendText("\n");
            }
            catch (ObjectDisposedException)
            { return; }
        }
        private void CLEAR_OUTPUT_BUTTON_Click(object sender, EventArgs e)
        {
            OutputScreenAppendText("");
        }
    }
}
