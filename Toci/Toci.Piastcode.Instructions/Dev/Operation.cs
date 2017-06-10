using Toci.Piascode.Instructions.Interfacces.Dev;

namespace Toci.Piastcode.Instructions.Dev
{
    public class Operation : IOperation
    {
        public string Add { get; set; }
        public string Remove { get; set; }
        public string Rename { get; set; }
    }
}