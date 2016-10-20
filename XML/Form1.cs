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
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSpeichern_Click(object sender, EventArgs e)
        {
            String path = Path.GetTempFileName();
            using (XmlWriter xmlAusgabe = XmlWriter.Create(path, new XmlWriterSettings() { Indent = true }))
            {
                try
                {
                    xmlAusgabe.WriteStartDocument();
                    xmlAusgabe.WriteStartElement("TEST");
                    xmlAusgabe.WriteElementString("Name", textBox1.Text);
                    xmlAusgabe.WriteElementString("Adresse", richTextBox1.Text);
                    xmlAusgabe.WriteEndElement();
                    xmlAusgabe.WriteEndDocument();
                }
                finally
                {
                    xmlAusgabe.Flush();
                }
            }

            using (StreamReader reader = File.OpenText(path))
            {
                richTextBoxAusgabe.Text = reader.ReadToEnd();
            }
        }
    }
}
