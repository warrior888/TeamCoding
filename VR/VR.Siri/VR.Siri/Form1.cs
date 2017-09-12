using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Plugin.BingSpeech;

namespace VR.Siri
{
    public partial class Form1 : Form
    {
        protected SpeechRecognitionEngine SRE = new SpeechRecognitionEngine();
        protected int y = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // BingSpeech bs = new BingSpeech();
           // bs.MicrophoneService = SRE;

            SRE.EndSilenceTimeout = TimeSpan.Zero;

            DictationGrammar dg = new DictationGrammar();
            dg.Weight = 0.02f;
            //dg.SetDictationContext();
            //dg.Priority = 2;


            Choices c = new Choices("woman", "speaks", "fluent", "english", "and ", "he", "is", "understanding");
            

            Grammar g = new Grammar(new GrammarBuilder(c));
            g.Weight = 0.98f;
            g.Priority = 1;


            SRE.LoadGrammar(g);
            SRE.LoadGrammar(dg);
            
            SRE.SetInputToDefaultAudioDevice();

            SRE.SpeechRecognized += SRE_SpeechRecognized;

            SRE.RecognizeAsync(RecognizeMode.Multiple);

            
        }

        private void SRE_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Label l = new Label();
            string wtf = "";
            foreach (var word in e.Result.Words)
            {
                wtf += word.Text;
            }

            l.Text = e.Result.Text;
            l.Location = new Point(20, y += 20);
            Controls.Add(l);
        }
    }
}
