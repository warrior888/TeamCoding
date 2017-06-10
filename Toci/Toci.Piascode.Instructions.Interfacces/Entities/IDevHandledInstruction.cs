namespace Toci.Piascode.Instructions.Interfacces.Entities
{
    public interface IDevHandledInstruction : IHandledInstruction
    {
        string FileContent { get; set; }
        string FileName { get; set; }
    }
}