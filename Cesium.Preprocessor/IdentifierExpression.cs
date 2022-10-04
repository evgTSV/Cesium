﻿using System.Text.RegularExpressions;
using Yoakke.SynKit.Lexer;

namespace Cesium.Preprocessor;

internal class IdentifierExpression : IPreprocessorExpression
{
    public IdentifierExpression(string identifer)
    {
        this.Identifer = identifer;
    }

    public string Identifer { get; }

    public string? EvaluateExpression(IMacroContext context)
    {
        if (context.TryResolveMacro(this.Identifer, out var result))
        {
            return result;
        }

        if (Regex.IsMatch(this.Identifer, Regexes.IntLiteral))
        {
            return this.Identifer;
        }

        return result;
    }
}