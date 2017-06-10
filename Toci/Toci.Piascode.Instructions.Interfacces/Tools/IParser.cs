using System.Collections.Generic;
using Toci.Piascode.Instructions.Interfacces.Entities;

namespace Toci.Piascode.Instructions.Interfacces.Tools
{
    public interface IParser<TTarget, TSource, out TRresult> 
        where TTarget : ITarget 
        where TSource : ISource
        where TRresult : IResult
    {
        TTarget Target { get; set; }
        TSource Source { get; set; }
        TRresult Parse(TTarget target, TSource source);
        
    }
}