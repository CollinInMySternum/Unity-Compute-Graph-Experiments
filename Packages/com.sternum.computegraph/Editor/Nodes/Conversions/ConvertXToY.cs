using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Conversions
{
    // Master implementation, generic C-style conversion
    
    [Serializable]
    public abstract class ConvertXToY : ComputeNodeBase
    {
        protected abstract Type workingTypeX { get; }
        protected abstract Type workingTypeY { get; }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("X").WithDataType(workingTypeX);
            context.AddOutputPort("y").WithDataType(workingTypeY);
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "X");
            string hlslTypeY = ComputeGraphTypes.GetStringFromCSType(workingTypeY);

            compiler.Body.AppendLine($"    {hlslTypeY} {outputVar} = {hlslTypeY}({valX});");
        }
    }
}