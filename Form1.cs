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
        private string file_path;
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
            if (!BAUD_RATES.Text.Equals(""))
            {
                CONNECT_BUTTON.Enabled = true;
            }
        }

        private void BAUD_RATES_SelectedIndexChanged(object sender, EventArgs e)
        {
            baud_rate = int.Parse(BAUD_RATES.GetItemText(BAUD_RATES.SelectedItem));
            if (!COM_NAMES.Text.Equals(""))
            {
                CONNECT_BUTTON.Enabled = true;
            }
        }

        private void CONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            if (!COM_NAMES.Text.Equals("") && !BAUD_RATES.Text.Equals(""))
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
            else
                SERIAL_READ.Text = "You need to pick COM name and Baud Rate";
        }

        private void READ_BUTTON_Click(object sender, EventArgs e)
        {
            am.ardEvent -= ArduinoSerialReadEventHandler;
            am.ardEvent += ArduinoSerialReadEventHandler;
            READ_BUTTON.Enabled = false;
            CLEAR_OUTPUT_BUTTON.Enabled = false;
            STOP_READING_BUTTON.Enabled = true;
        }


        private void STOP_READING_BUTTON_Click(object sender, EventArgs e)
        {
            am.ardEvent -= ArduinoSerialReadEventHandler;
            am.ardEvent -= WriteToFileEventHandler;
            READ_BUTTON.Enabled = true;
            CLEAR_OUTPUT_BUTTON.Enabled = true;
            STOP_READING_BUTTON.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CONNECT_BUTTON.Enabled = false;
            DISCONNECT_BUTTON.Enabled = false;
            READ_BUTTON.Enabled = false;
            WRITE_BUTTON.Enabled = false;
            STOP_READING_BUTTON.Enabled = false;
            CLEAR_OUTPUT_BUTTON.Enabled = false;
        }

        private void WRITE_BUTTON_Click(object sender, EventArgs e)
        {
            am.WriteToArduino(SERIAL_WRITE.Text);
        }


        private void DISCONNECT_BUTTON_Click(object sender, EventArgs e)
        {
            if (am.ClosePort())
            {
                CONNECT_BUTTON.Enabled = true;
                DISCONNECT_BUTTON.Enabled = false;
            }
        }
        private void WRITE_TO_FILE_BUTTON_Click(object sender, EventArgs e)
        {
            opf.ShowDialog();
            file_path = opf.FileName;
            FILE_PATH_BOX.Text = file_path;
            am.ardEvent -= WriteToFileEventHandler;
            am.ardEvent += WriteToFileEventHandler;
        }

        #endregion

        #region User Defined Methods

        /*
         * Event Handler For Appending text to  SERIAL_READ and ONE_LINE_READ text boxes, enabling the methods to append text continiously as long as Arduino (Serial Port) is sending messages to the Serial Port.
         */
        private void ArduinoSerialReadEventHandler(object sender, ArduinoSerialReadEventArgs e)
        {
            SERIAL_READ_SET_TEXT(e.message);
            ONE_LINE_READ_SET_TEXT(e.message);
        }


        /*
         * Event Handler For Writing to file, enabling the method to write to file continiously as long as Arduino (Serial Port) is sending messages to the Serial Port.
         */
        private void WriteToFileEventHandler(object sender, ArduinoSerialReadEventArgs e)
        {
            WriteToFile(e.message);
        }


        /*
         * Appends the argument Text to SERIAL_READ TextBox and appends a new line after each appended line
         */
        private void SERIAL_READ_SET_TEXT(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(SERIAL_READ_SET_TEXT), text);
                    return;
                }
                SERIAL_READ.AppendText(text);
                SERIAL_READ.AppendText(Environment.NewLine);
            }
            catch (System.ObjectDisposedException)
            { return; }
        }

        /*
         * Sets the Text inside the ONE_LINE_READ TextBox to the passed text in the method's argument. 
         */
        private void ONE_LINE_READ_SET_TEXT(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(ONE_LINE_READ_SET_TEXT), text);
                    return;
                }
                ONE_LINE_READ.Text = text;
            }
            catch (System.ObjectDisposedException)
            { return; }
        }

        /*
         * Writes Text to a file chosen by the user. File Path obtained from FILE_PATH_BOX TextBox from the Form 
         * And passed as the path for file to be written to
         */
        private void WriteToFile(string text)
        {


            if (WRITE_ONE_LINE_FILE.Checked)
            {
                if (!file_path.Equals(""))
                {
                    if (File.Exists(file_path))
                    {
                        ONE_LINE_READ.TextChanged += ONE_LINE_READ_TEXTCHANGED;
                        File.WriteAllText(file_path, text);
                    }
                }
            }
            else 
            {
                if (!file_path.Equals(""))
                {
                    if (File.Exists(file_path))
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
                else
                {
                    File.Create(file_path);
                    WriteToFile(text);
                }
            }
        }

        /*
         * Event For The One Line read Textbox checking if the Text inside it has changed
         */
        private void ONE_LINE_READ_TEXTCHANGED(object sender, EventArgs e)
        {
            TextWasChanged = true;
        }


        /*
         * Event Handler for Key_Down Event on FILE_PATH TextBox
         */
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                file_path = FILE_PATH_BOX.Text;
                am.ardEvent -= WriteToFileEventHandler;
                am.ardEvent += WriteToFileEventHandler;
            }
        }

        #endregion

        private void OUTPUT_CLEAR_TEXT(string text)
        {
            try
            {
                if (InvokeRequired)
                {
                    Invoke(new Action<string>(OUTPUT_CLEAR_TEXT), text);
                    return;
                }
                ONE_LINE_READ.Text = text;
            }
            catch (System.ObjectDisposedException)
            { return; }
        }

        private void CLEAR_OUTPUT_BUTTON_Click(object sender, EventArgs e)
        {
            OUTPUT_CLEAR_TEXT("");
        }
    }
}
