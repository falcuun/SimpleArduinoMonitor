using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SimpleArduinoSerialMonitor
{
    class ArduinoMonitor
    {
        SerialPort serial_port = null;
        static string Message { get; set; }

        public ArduinoMonitor(string com_name, int baud_rate)
        {
            serial_port = new SerialPort(com_name, baud_rate, Parity.None, 8, StopBits.One);
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }

        public void OpenPort()
        {
            serial_port.Open();
        }

        public string ReadFromArduino()
        {
            return Message;
        }

        private static void DataReceivedHandler(object sender,SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Message = sp.ReadLine();
            System.Diagnostics.Debug.WriteLine(sp.ReadLine());
        }
    }

}
