using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Trigonometry
{
    [Serializable]
    [Node("Trigonometry", "", "Sine (Degrees)", StylePath)]
    public class SineDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = sin({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Sine (Radians)", StylePath)]
    public class SineRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = sin({valX} * 180.0f / PI);");
        }
    }
    
    [Serializable]
    [Node("Trigonometry", "", "Arcsine (Degrees)", StylePath)]
    public class ArcSineDegrees : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = asin({valX} * PI / 180.0f);");
        }
    }

    [Serializable]
    [Node("Trigonometry", "", "Arcsine (Radians)", StylePath)]
    public class ArcSineRadians : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("In").WithDataType<float>();
            context.AddOutputPort("Out").WithDataType<float>();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valX = EvaluateInput(compiler, "In");

            compiler.Body.AppendLine($"    float {outputVar} = asin({valX} * 180.0f / PI);");
        }
    }
}