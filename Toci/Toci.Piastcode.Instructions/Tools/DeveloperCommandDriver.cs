using Toci.Piascode.Instructions.Interfacces.Dev;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;
using Toci.Piastcode.Instructions.Dev;
using Toci.Piastcode.Instructions.Entities;

namespace Toci.Piastcode.Instructions.Tools
{
    public class DeveloperCommandDriver : IDeveloperCommandDriver
    {
        public IDevInstructions<IDevHandledInstruction> DevInstruction { get; set; }
        public IDevHandledInstruction DevHandledInstruction { get; set; }
        public IDevInstructions<IDevHandledInstruction> CommandDriver(IResult result)
        {
            DevInstruction = new DevInstructions<IDevHandledInstruction>
            {
                AccessModifier = result.ParseResult[1],
                EntityType = result.ParseResult[2],
                Name = result.ParseResult[3]
            };

            return DevInstruction;
        }

        public IDevHandledInstruction CreateDevHandledInstruction(IDevInstructions<IDevHandledInstruction> devInstruction)
        {
            DevHandledInstruction = new DevHandledInstruction();

            DevHandledInstruction.FileContent += (devInstruction.AccessModifier + " " + devInstruction.EntityType + " " + devInstruction.Name + "{}");
            DevHandledInstruction.FileName = devInstruction.Name;

            return DevHandledInstruction;
        }

        public void InvokeDevInstruction(IDevInstructions<IDevHandledInstruction> instruction)
        {
        }
    }
}