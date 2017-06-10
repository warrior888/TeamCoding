using System;
using System.Collections.Generic;
using Toci.Piascode.Instructions.Interfacces.Dev;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piascode.Instructions.Interfacces.Tools
{
    public interface IDevInstructionHandler<TDevInstruction> where TDevInstruction : IDevInstructions<IDevHandledInstruction>
    {
        // slownik
        Dictionary<string, Action<TDevInstruction>> DevInstructions { get; set; }
    }
}