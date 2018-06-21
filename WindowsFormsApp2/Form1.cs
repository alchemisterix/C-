using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; // добавил
using System.Collections;
using System.Threading;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        SerialPort _serialPort;
        public Form1()
        {
            InitializeComponent();

            button_disconnect.Enabled = false; //disable disconnect button


            ArrayList ports = new ArrayList(); //collecting portnames



            foreach (string s in SerialPort.GetPortNames()) //get all aviliable ports
            {
                comboBox1.Items.Add(s);                     //put port name into combox
                comboBox1.SelectedIndex = 0;                //set default port to first port founded
                ports.Add(s);                               //put port name into collections
            }

        }




        private void button1_Click(object sender, EventArgs e)      //Connect button presed
        {

            _serialPort = new SerialPort(comboBox1.Text, 9600);     //lets try to open port
            _serialPort.Open();                                     //port opening
            if (_serialPort.IsOpen)                                 //if port open succes
            {
                label1.Text = "OPENING PORT";                       //Show message
                button_connect.Enabled = false;                     //disable connect button
                button_disconnect.Enabled = true;                   //and enable disconnect button
            }





        }

        private void button_disconnect_Click(object sender, EventArgs e)
        {
            
            if (_serialPort.IsOpen)                                 //if Serial Port opened
            {
                label1.Text = "CLOSING PORT";                       //show message in form
                button_connect.Enabled = true;                      //enable connect button
                button_disconnect.Enabled = false;                  //disable disconnect button
                _serialPort.Close();                                //closing port
                label1.Text = "PORT CLOSED";                        //show message
            }
        }

    } 
}
