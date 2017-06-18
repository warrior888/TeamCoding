﻿using System;
using System.Diagnostics;
using Toci.Piastcode.SpeechRecognition.Entities;

namespace Toci.Piastcode.SpeechRecognition.Tools
{
    public class SpeechRecognitionManager
    {
        protected SpeechRecognition spR;

        public void ManageVoiceInstructions(Action<string> callback)
        {
            spR = new SpeechRecognition();

            spR.GrammarSource = new GrammarSource { FilePath = @"..\..\..\Toci\Toci.Piastcode.SpeechRecognition\Tools\grammar.xml" };
            //TODO : uncomment on release ver
          //  spR.Listen(); 
            spR.RecognizeSpeech += callback;
        }
    }
}