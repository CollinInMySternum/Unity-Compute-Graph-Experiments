using System;
using Unity.GraphToolkit.Editor;
using UnityEngine;

namespace Editor.Nodes
{
    [Serializable]
    public class OutputNode : ComputeNodeBase
    {
        public string TargetBufferName = "ResultBuffer";

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("Result").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            compiler.Declarations.AppendLine($"RWStructuredBuffer<float4> {TargetBufferName};");
            
            string finalResult = EvaluateInput(compiler, "Result");

            compiler.Body.AppendLine($"    {TargetBufferName}[id.x] = {finalResult};");
        }
    }
}