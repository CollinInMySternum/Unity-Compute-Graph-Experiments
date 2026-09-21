using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Trigonometry
{
    [Serializable]
    [Node("Trigonometry", "", "Tangent (Degrees)", StylePath)]
    public class TangentDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = tan({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Tangent (Radians)", StylePath)]
    public class TangentRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = tan({valX} * 180.0f / PI);");
        }
    }
    
    [Serializable]
    [Node("Trigonometry", "", "Arctangent (Degrees)", StylePath)]
    public class ArcTangentDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = atan({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Arctangent (Radians)", StylePath)]
    public class ArcTangentRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = atan({valX} * 180.0f / PI);");
        }
    }
}