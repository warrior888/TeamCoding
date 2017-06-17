using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;
using Toci.Piastcode.Instructions.Entities;
using Toci.Piastcode.Instructions.Form;
using Toci.Piastcode.Instructions.Tools;
using Toci.Piastcode.SpeechRecognition.Tools;

namespace TeamCoding.Toci.Implementations
{
    public class VrCommandsManager
    {
        private SpeechRecognitionManager speechRecognitionManager;

        public void Register()
        {
            speechRecognitionManager = new SpeechRecognitionManager();

            speechRecognitionManager.ManageVoiceInstructions(Parse);
        }

        protected virtual void Parse(string input)
        {
            //GetName.GetStringFromForm() 

            Parser<ITarget, ISource, IResult> parser = new Parser<ITarget, ISource, IResult>();
            IResult result = parser.Parse(null, new Source { StringSource = input });

            IDeveloperCommandDriver dcDriver = new DeveloperCommandDriver();
            IDevHandledInstruction instruction = dcDriver.CreateDevHandledInstruction(dcDriver.CommandDriver(result));

            var form = new VrAddNewItemForm(instruction);
            form.Show();


            /*

            ProjectManager.Dte.ItemOperations.AddNewItem("Code\\class", instruction.FileName + ".cs");*/
        }
    }
}