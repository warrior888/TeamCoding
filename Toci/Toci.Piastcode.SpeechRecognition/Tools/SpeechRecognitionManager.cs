using System;
using System.Diagnostics;
using Toci.Piastcode.SpeechRecognition.Entities;

namespace Toci.Piastcode.SpeechRecognition.Tools
{
    public class SpeechRecognitionManager
    {
        public void ManageVoiceInstructions(Action<string> callback)
        {
            SpeechRecognition spR = new SpeechRecognition();

            spR.GrammarSource = new GrammarSource { FilePath = @"C:\Users\Warrior\Documents\TeamCodingGhostRider\Toci\Toci.Piastcode.SpeechRecognition\Tools\grammar.xml" };

            spR.Listen();
            spR.RecognizeSpeech += callback;
        }
    }
}