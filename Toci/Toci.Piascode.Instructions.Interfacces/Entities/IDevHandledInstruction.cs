namespace Toci.Piascode.Instructions.Interfacces.Entities
{
    public interface IDevHandledInstruction : IHandledInstruction
    {
        string FileType{ get; set; }
        string FileContent { get; set; }
        string FileName { get; set; }
    }
}