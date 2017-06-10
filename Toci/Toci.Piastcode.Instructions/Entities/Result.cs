using System.Collections.Generic;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piastcode.Instructions.Entities
{
    public class Result : IResult
    {
        public List<string> ParseResult { get; set; }
    }
}