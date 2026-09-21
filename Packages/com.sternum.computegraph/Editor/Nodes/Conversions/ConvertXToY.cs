using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Conversions
{
    // Master implementation
    
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

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "X");
            string hlslTypeY = ComputeGraphTypes.GetStringFromCSType(workingTypeY);

            compiler.Body.AppendLine($"    {hlslTypeY} {outputVar} = {hlslTypeY}({valX});");
        }
    }
    
    // Scalars

    [Serializable]
    [Node("Conversions", "", "Convert Int to Float", StylePath)]
    public class ConvertIntToFloat : ConvertXToY
    {
        protected override Type workingTypeX => typeof(int);
        protected override Type workingTypeY => typeof(float);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Float to Int", StylePath)]
    public class ConvertFloatToInt : ConvertXToY
    {
        protected override Type workingTypeX => typeof(float);
        protected override Type workingTypeY => typeof(int);
    }
    
    // Vectors
    
    [Serializable]
    [Node("Conversions", "", "Convert Int2 to Float2", StylePath)]
    public class ConvertInt2ToFloat2 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(int2);
        protected override Type workingTypeY => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Int3 to Float3", StylePath)]
    public class ConvertInt3ToFloat3 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(int3);
        protected override Type workingTypeY => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Int4 to Float4", StylePath)]
    public class ConvertInt4ToFloat4 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(int4);
        protected override Type workingTypeY => typeof(Vector4);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Float2 to Int2", StylePath)]
    public class ConvertFloat2ToInt2 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(Vector2);
        protected override Type workingTypeY => typeof(int2);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Float3 to Int3", StylePath)]
    public class ConvertFloat3ToInt3 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(Vector3);
        protected override Type workingTypeY => typeof(int3);
    }
    
    [Serializable]
    [Node("Conversions", "", "Convert Float4 to Int4", StylePath)]
    public class ConvertFloat4ToInt4 : ConvertXToY
    {
        protected override Type workingTypeX => typeof(Vector4);
        protected override Type workingTypeY => typeof(int4);
    }
}