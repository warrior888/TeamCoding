using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piastcode.Instructions.Entities
{
    public class DevHandledInstruction : IDevHandledInstruction
    {
        public string FileContent { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}