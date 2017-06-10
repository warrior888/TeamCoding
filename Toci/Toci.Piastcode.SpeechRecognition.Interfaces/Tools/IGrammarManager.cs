using System.Speech.Recognition;
using Toci.Piastcode.SpeechRecognition.Interfaces.Entities;

namespace Toci.Piastcode.SpeechRecognition.Interfaces.Tools
{
    public interface IGrammarManager
    {
        Grammar GetGrammar(IGrammarSource grammarSource);
    }
}