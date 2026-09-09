using System;
using Unity.GraphToolkit.Editor;
using UnityEngine;

using Editor;

namespace Editor.Nodes
{
    [Serializable]
    [Node("Buffers", "", "Write Buffer", StylePath)]
    public class WriteBuffer : ComputeNodeBase
    {
        [SerializeField] public string BufferName = "ResultBuffer";
        [SerializeField] public ComputeGraphTypes.HLSLDataType IndexType = ComputeGraphTypes.HLSLDataType.Int;
        [SerializeField] public ComputeGraphTypes.HLSLDataType ValueType = ComputeGraphTypes.HLSLDataType.Float;

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            var indexCSType = ComputeGraphTypes.GetCSharpType(IndexType);
            var valueCSType = ComputeGraphTypes.GetCSharpType(ValueType);
            
            context.AddInputPort("Index").WithDataType(indexCSType).Build();
            context.AddInputPort("Value").WithDataType(valueCSType).Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            compiler.Declarations.AppendLine($"RWStructuredBuffer<{ComputeGraphTypes.GetStringFromHLSLType(ValueType)}> {BufferName};");
            
            string value = EvaluateInput(compiler, "Value");
            string index = EvaluateInput(compiler, "Index");

            compiler.Body.AppendLine($"    {BufferName}[{index}] = {value};");
        }
    }
}