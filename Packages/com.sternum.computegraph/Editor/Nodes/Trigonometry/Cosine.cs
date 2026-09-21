using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Trigonometry
{
    [Serializable]
    [Node("Trigonometry", "", "Cosine (Degrees)", StylePath)]
    public class CosineDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = cos({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Cosine (Radians)", StylePath)]
    public class CosineRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = cos({valX} * 180.0f / PI);");
        }
    }
    
    [Serializable]
    [Node("Trigonometry", "", "Arccosine (Degrees)", StylePath)]
    public class ArcCosineDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = acos({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Arccosine (Radians)", StylePath)]
    public class ArcCosineRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = acos({valX} * 180.0f / PI);");
        }
    }
}