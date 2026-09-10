using System;
using Unity.GraphToolkit.Editor;
using UnityEngine;

using Editor;

namespace Editor.Nodes
{
    [Serializable]
    [Node("Buffers", "", "Read Buffer", StylePath)]
    public class ReadBuffer : ComputeNodeBase
    {
        [SerializeField] public string BufferName = "ResultBuffer";
        [SerializeField] public ComputeGraphTypes.HLSLDataType IndexType = ComputeGraphTypes.HLSLDataType.Int;
        [SerializeField] public ComputeGraphTypes.HLSLDataType ValueType = ComputeGraphTypes.HLSLDataType.Float;

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            var indexCSType = ComputeGraphTypes.GetCSharpType(IndexType);
            var valueCSType = ComputeGraphTypes.GetCSharpType(ValueType);
            
            context.AddInputPort("Index").WithDataType(indexCSType).Build();
            context.AddOutputPort("Value").WithDataType(valueCSType).Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            if (!compiler.RegisteredUniforms.Contains(BufferName))
            {
                compiler.RegisteredUniforms.Add(BufferName);
                
                compiler.Declarations.AppendLine($"RWStructuredBuffer<{ComputeGraphTypes.GetStringFromHLSLType(ValueType)}> {BufferName};");
            }
            
            string index = EvaluateInput(compiler, "Index");
            var valueType = ComputeGraphTypes.GetStringFromHLSLType(IndexType);

            compiler.Body.AppendLine($"    {valueType} {outputVar} = {BufferName}[{index}];");
        }
    }
}