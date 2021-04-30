using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PortSerial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public delegate void MyDelegate();
        public void UpdateTextBox()
        {
            richTextBox1.AppendText(serialPort1.ReadExisting());
            richTextBox1.ScrollToCaret();
        }
        private void DateReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            richTextBox1.BeginInvoke(new MyDelegate(UpdateTextBox));
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] Prot = System.IO.Ports.SerialPort.GetPortNames();
            for (int i = 1; i < Prot.Length; i++)
            {
                comboBox2.Items.Add(Prot[i]);
            }
            DisConnetion.Enabled = false;
        }
        private void Connetion_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen==true)
            {
                serialPort1.Close();
            }
            try
            {
                serialPort1.PortName = comboBox2.Text;
                serialPort1.BaudRate = 9600;
                serialPort1.Parity = System.IO.Ports.Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = System.IO.Ports.StopBits.One;
                // Open The SerialPort1
                serialPort1.Open();
                // Update the 
                richTextBox1.Text = comboBox2.Text + " Connetion ";
                Connetion.Enabled = false;
                DisConnetion.Enabled = true;
            }
            catch 
            {
                MessageBox.Show(" Error Serial Port Not Connetion  "," Error Port ",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }
        private void DisConnetion_Click(object sender, EventArgs e)
        {
            try
            {
                // Close Serial Port
                serialPort1.Close();
                // Update Text richTextBox 
                richTextBox1.Text = serialPort1.PortName + " DisConneted. ";
                Connetion.Enabled = true;
                DisConnetion.Enabled = false;
            }
            catch
            {
                MessageBox.Show(" The Serial Port Not DisConneted ", " Error Dis Cooneted ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Send_Click(object sender, EventArgs e)
        {
            try
            {
                ///...(Rig &) Open key F7_(+"Shift"+"Tab"+;_;+"Ctrl") {~[!(+ Hack.IO & ^ % 7(MyComputer.PingID))]}=>;
                ///...Wirte Date String Serial Port1; ;
                serialPort1.Write(textBox1.Text + Environment.NewLine);
                // Apped richTextbox 
                richTextBox1.AppendText(" > " + textBox1.Text + Environment.NewLine);
                richTextBox1.ScrollToCaret();
                textBox1.Text = string.Empty; 
            }
            catch 
            {
                MessageBox.Show(" The Not Write Date String Serial Port ", " Error Send String ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
