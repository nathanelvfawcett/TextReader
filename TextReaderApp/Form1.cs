using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextReaderApp
{
    public partial class Form1 : Form
    {
        string fileName;
        string line;
        SpeechSynthesizer synth = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize a new instance of the SpeechSynthesizer.  

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("An error occured.");
            }
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))

                    while ((line = sr.ReadLine()) != null)
                    {
                        synth.Speak(line);
                    }
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured. Please try again.");
            }
        }
    }
}
