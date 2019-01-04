using System;

namespace SimpleArduinoSerialMonitor
{
    class ArduinoSerialReadEventArgs : EventArgs
    {
        public string message { get; set; }
    }
}
