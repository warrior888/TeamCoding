using System;
using System.Speech.Recognition;
using Toci.Piastcode.SpeechRecognition.Entities;
using Toci.Piastcode.SpeechRecognition.Interfaces.Entities;
using Toci.Piastcode.SpeechRecognition.Interfaces.Tools;

namespace Toci.Piastcode.SpeechRecognition.Tools
{
    public class SpeechRecognition : ISpeechRecognition
    {
        public Action<string> RecognizeSpeech { get; set; }
        public IGrammarSource GrammarSource { get; set; }

        protected IGrammarManager GrammarManager = new GrammarManager(); 
        protected SpeechRecognitionEngine SREngine = new SpeechRecognitionEngine();

        public virtual void Listen()
        {
            SREngine.SetInputToDefaultAudioDevice();
            SREngine.LoadGrammar(GrammarManager.GetGrammar(GrammarSource));
            SREngine.RecognizeAsync(RecognizeMode.Multiple);
            SREngine.SpeechRecognized += SREngine_SpeechRecognized;
            SREngine.SpeechDetected += SREngine_SpeechDetected;
        }

        private void SREngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
           
        }

        protected virtual void SREngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            RecognizeSpeech(e.Result.Text);
        }
    }
}