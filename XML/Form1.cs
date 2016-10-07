using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;


namespace XML
{
    public partial class Form1 : Form
    {
        TimeSpan Dauer = new TimeSpan(0, 0, 10);
        DateTime Start;
        public Form1()
        {
            InitializeComponent();
            Start = DateTime.Now;
            timer1.Start();
        }


        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            
            StringWriter ausgabe = new StringWriter();

            using (XmlWriter xmlAusgabe = XmlWriter.Create(Path.GetTempFileName(), new XmlWriterSettings() { Indent = true }))
            {
                try
                {
                    //xmlAusgabe.WriteStartDocument();
                    //xmlAusgabe.WriteStartElement("TEST");
                    //xmlAusgabe.WriteStartElement("TEST", textBox1.Text);
                    //xmlAusgabe.WriteStartElement("TEST", richTextBox1.Text);
                    //xmlAusgabe.WriteEndElement();
                }
                finally
                {
                    xmlAusgabe.Flush();
                }
            }
            //richTextBoxAusgabe.Text = ausgabe.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now.Subtract(Start);
            labelTimer.Text = diff.TotalSeconds.ToString();
            if (Dauer < diff)
            {
                panel1.Enabled = false;

                // 
                // Thread Daten laden
                // Benutzer deaktiviern
                // Daten anzeigen
                // Benutzer aktivieren
            }


        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Start = DateTime.Now;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            Start = DateTime.Now;

        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Start = DateTime.Now;

        }

        private void labelTimer_Click(object sender, EventArgs e)
        {

        }
    }
}
