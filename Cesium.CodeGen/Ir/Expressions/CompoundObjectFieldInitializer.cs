using Cesium.Ast;
using Cesium.CodeGen.Contexts;
using Cesium.CodeGen.Extensions;
using Cesium.CodeGen.Ir.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cesium.CodeGen.Ir.Expressions;
internal sealed class CompoundObjectFieldInitializer : IExpression
{
    internal IExpression Inner;
    internal Designation Designation;

    internal CompoundObjectFieldInitializer(AssignmentInitializer initializer, IDeclarationScope scope)
    {
        Inner = initializer.Expression.ToIntermediate(scope);
        Designation = initializer.Designation!;
    }

    internal CompoundObjectFieldInitializer(IExpression inner, Designation designation)
    {
        Inner = inner;
        Designation = designation;
    }

    public void EmitTo(IEmitScope scope) => Inner.EmitTo(scope);

    public IType GetExpressionType(IDeclarationScope scope) => Inner.GetExpressionType(scope);

    public IExpression Lower(IDeclarationScope scope) => new CompoundObjectFieldInitializer(Inner.Lower(scope), Designation);
}
