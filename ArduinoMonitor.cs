using System;
using System.IO.Ports;

namespace SimpleArduinoSerialMonitor
{
    class ArduinoMonitor
    {
        public event EventHandler<ArduinoSerialReadEventArgs> ardEvent;
        SerialPort serial_port = null;
        string Message { get; set; }

        public ArduinoMonitor(string com_name, int baud_rate)
        {
            serial_port = new SerialPort(com_name, baud_rate, Parity.None, 8, StopBits.One);
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public bool OpenPort()
        {
            serial_port.Open();
            return serial_port.IsOpen;
        }

        public bool ClosePort()
        {
            serial_port.Close();
            if(serial_port.IsOpen)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void WriteToArduino(string message)
        {
            serial_port.Write(message);
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                ArduinoSerialReadEventArgs asre = new ArduinoSerialReadEventArgs();
                asre.message = serial_port.ReadLine();
                ardEvent?.Invoke(this, asre);
            }
            catch (System.IO.IOException) { return; }
        }
    }

}
