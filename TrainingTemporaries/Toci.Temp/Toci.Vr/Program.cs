using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Toci.Vr
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechRecognitionEngine sre = new SpeechRecognitionEngine();

            sre.SetInputToDefaultAudioDevice();

            Choices ch = new Choices();
            
            ch.Add("IDevHandledInstruction");

            GrammarBuilder grB = new GrammarBuilder();
            grB.Append(ch);

            //sre.LoadGrammar(new DictationGrammar());

            //sre.LoadGrammar(new Grammar(@"C:\Users\Warrior\Documents\TeamCodingGhostRider\TrainingTemporaries\Toci.Temp\Toci.Vr\data\grammar.xml"));

            //Grammar gr123 = new Grammar(@"C:\Users\Warrior\Documents\TeamCodingGhostRider\TrainingTemporaries\Toci.Temp\Toci.Vr\data\grammar.xml");
            

            sre.LoadGrammar(new Grammar(grB));



            sre.SpeechRecognized += Sre_SpeechRecognized;
            sre.SpeechDetected += Sre_SpeechDetected;
            sre.RecognizeAsync(RecognizeMode.Multiple);

            Console.ReadLine();
        }

        private static void Sre_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            
        }

        private static void Sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            Console.WriteLine(e.Result.Text);
        }
    }
}
