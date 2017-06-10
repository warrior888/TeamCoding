using System;
using Toci.Piastcode.SpeechRecognition.Interfaces.Entities;

namespace Toci.Piastcode.SpeechRecognition.Interfaces.Tools
{
    public interface ISpeechRecognition
    {
        Action<string> RecognizeSpeech { get; set; }

        IGrammarSource GrammarSource { get; set; }
    }
}