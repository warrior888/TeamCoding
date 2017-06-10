using Toci.Piascode.Instructions.Interfacces.Dev;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piascode.Instructions.Interfacces.Tools
{
    public interface IDeveloperCommandDriver
    {
        IDevInstructions<IDevHandledInstruction> DevInstruction { get; set; }
        IDevHandledInstruction DevHandledInstruction { get; set; }
        IDevInstructions<IDevHandledInstruction> CommandDriver(IResult result);
        IDevHandledInstruction CreateDevHandledInstruction(IDevInstructions<IDevHandledInstruction> devInstruction);
    }
}