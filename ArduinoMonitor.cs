using System;
using System.IO.Ports;

namespace SimpleArduinoSerialMonitor
{
    class ArduinoMonitor
    {
        public event EventHandler<ArduinoSerialReadEventArgs> ardEvent; // Custom Event Args
        SerialPort serial_port = null; // Declaring Serial Port object
        string Message { get; set; } // Declaring Message from Serial Port



        /*
         * Constructor for the class
         */
        public ArduinoMonitor(string com_name, int baud_rate)
        {
            serial_port = new SerialPort(com_name, baud_rate, Parity.None, 8, StopBits.One); // Initializing a new Serial Port object with passed COM Name and Baud rate
            serial_port.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler); // Adding an Event handler to the port
        }

        /*
         * Opening the Port */
        public bool OpenPort()
        {
            serial_port.Open();
            return serial_port.IsOpen;
        }

        /*
         * Closing the port */
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

        /*
         *Sending a String text to Arduino (Serial Port) */
        public void WriteToArduino(string message)
        {
            serial_port.Write(message);
        }

        /*
         * Event Handler for Receiving the Data from Arduino (Serial Port) and Appending the Message to the Event Args
         */
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
