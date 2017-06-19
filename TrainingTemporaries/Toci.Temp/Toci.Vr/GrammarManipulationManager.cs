using System.Xml.Linq;
using System.Reflection;
using System;
using System.Linq;

namespace Toci.Vr
{
    public class GrammarManipulationManager
    {
        //private string grammarPath;
        //public GrammarManipulationManager(string path)
        //{
        //    grammarPath = path;
        //}
        //public void AddChoiceToGrammar(string ruleId, string item)
        //{
        //    XDocument document = XDocument.Load(grammarPath);


        //    //document.Nodes()

        //}


            //   chyba o to chodziło ?

        




        public void AddAssemblyFiles()
        {
            //C: \Users\piotr\Documents\TeamCoding\TrainingTemporaries\Toci.Temp\Toci.Vr\data   -> lokalnie do zmiany

            Type[] allTypesInAssembly = Assembly.GetExecutingAssembly().GetTypes();

            var dane = XDocument.Load(@"C:\Users\piotr\Documents\TeamCoding\TrainingTemporaries\Toci.Temp\Toci.Vr\data\grammar.xml");
             foreach (var item in allTypesInAssembly)
             {
                 var slowoX = item.ToString();


                 var tede = new XElement("item", new XText(slowoX), new XElement("tag", new XText("out = \"" + slowoX + "\";")));

                 var customer = dane.Root.Elements("rule").Single(x => (string)x.Attribute("id") == "Accessor");

                 customer.Element("one-of").Add(tede);


             }

             dane.Save("grammar.xml");
        }
    }
}