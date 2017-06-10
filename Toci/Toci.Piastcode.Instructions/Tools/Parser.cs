using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Toci.Piascode.Instructions.Interfacces.Entities;
using Toci.Piascode.Instructions.Interfacces.Tools;
using Toci.Piastcode.Instructions.Entities;

namespace Toci.Piastcode.Instructions.Tools
{
    public class Parser<TTarget, TSource, TResult> : IParser<TTarget, TSource, TResult> 
        where TTarget : ITarget 
        where TSource : ISource 
        where TResult : IResult
    {
        public TTarget Target { get; set; }
        public TSource Source { get; set; }
        public TResult Parse(TTarget target, TSource source)
        {
            var splitSource = source.StringSource.Split(new[] {" "}, StringSplitOptions.None);
            IResult result = new Result();

            result.ParseResult = splitSource.ToList();
            return (TResult)result;
        }
    }
}