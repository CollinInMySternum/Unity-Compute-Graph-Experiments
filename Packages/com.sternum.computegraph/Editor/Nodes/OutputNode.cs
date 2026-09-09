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
            context.AddInputPort<int>("Index").Build();
            context.AddInputPort<float>("Value").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            compiler.Declarations.AppendLine($"RWStructuredBuffer<float4> {TargetBufferName};");
            
            string value = EvaluateInput(compiler, "Value");
            string index = EvaluateInput(compiler, "Index");

            compiler.Body.AppendLine($"    {TargetBufferName}[{index}] = {value};");
        }
    }
}