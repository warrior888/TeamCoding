using System.Speech.Recognition;
using Toci.Piastcode.SpeechRecognition.Interfaces.Entities;
using Toci.Piastcode.SpeechRecognition.Interfaces.Tools;

namespace Toci.Piastcode.SpeechRecognition.Tools
{
    public class GrammarManager : IGrammarManager
    {
        public virtual Grammar GetGrammar(IGrammarSource grammarSource)
        {
            return new Grammar(grammarSource.FilePath);
        }
    }
}