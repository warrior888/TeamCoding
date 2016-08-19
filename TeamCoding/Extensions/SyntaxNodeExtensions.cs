﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.TeamFoundation.CodeSense.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamCoding.Extensions
{
    public static class SyntaxNodeExtensions
    {
        public static int GetTreePositionHashCode(this SyntaxNode node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node));
            }

            CodeElementIdentity Identity;

            if (node is CSharpSyntaxNode)
            {
                Identity = CSharpSyntaxNodeExtensions.GetCodeElementIdentity((CSharpSyntaxNode)node);
            }
            else if (node is VisualBasicSyntaxNode)
            {
                Identity = VisualBasicSyntaxNodeExtensions.GetCodeElementIdentity((VisualBasicSyntaxNode)node);
            }
            else
            {
                TeamCodingPackage.Current.Logger.WriteError($"Called {nameof(GetTreePositionHashCode)} with unexpected SyntaxNode type {node.GetType().Name}. Reverting to using anscestor HashCodes.");
                // Can't just use the node's parents and self's hashcode since that includes trivia (whitespace), so we combine the hash code of all token's text
                return node.AncestorsAndSelf().SelectMany(n => n.DescendantTokens()).Aggregate(17, (acc, next) => unchecked(acc * 31 + next.ToString().GetHashCode()));
            }

            return Identity.GetHashCode();
        }
    }
}
