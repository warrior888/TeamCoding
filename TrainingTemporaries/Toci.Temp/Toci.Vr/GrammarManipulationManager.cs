using System.Xml.Linq;

namespace Toci.Vr
{
    public class GrammarManipulationManager
    {
        private string grammarPath;
        public GrammarManipulationManager(string path)
        {
            grammarPath = path;
        }
        public void AddChoiceToGrammar(string ruleId, string item)
        {
            XDocument document = XDocument.Load(grammarPath);


            //document.Nodes()
            
        }
    }
}