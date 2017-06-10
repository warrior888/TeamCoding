using System;
using System.Collections.Generic;
using Toci.Piascode.Instructions.Interfacces.Dev;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;

namespace Toci.Piastcode.Instructions.Tools
{
    public class DevInstructionHandler<TDevInstruction> : IDevInstructionHandler<TDevInstruction> 
        where TDevInstruction : IDevInstructions<IDevHandledInstruction>
    {
        public Dictionary<string, Action<TDevInstruction>> DevInstructions { get; set; }

        //public void Invoke(IDevInstructions<IDevHandledInstruction> dictionary)
        //{
        //    DevInstructions = new Dictionary<string, Action<TDevInstruction>>
        //    {
        //        {"add",  },
        //        {"remove" },
        //        {"rename" }
        //    };
        //}

    }
}