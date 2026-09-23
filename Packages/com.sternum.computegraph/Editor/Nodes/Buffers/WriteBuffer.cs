using System;
using Unity.GraphToolkit.Editor;
using UnityEngine;

namespace Editor.Nodes
{
    [Serializable]
    [Node("Buffers", "", "Write Buffer", StylePath)]
    public class WriteBuffer : ComputeNodeBase
    {
        private const string k_BufferName = "BufferName";
        private const string k_ValueType = "ValueType";

        protected override void OnDefineOptions(IOptionDefinitionContext context)
        {
            context.AddOption<string>(k_BufferName)
                .WithDisplayName("Buffer Name")
                .WithDefaultValue("Buffer");
            
            context.AddOption<ComputeGraphTypes.HLSLDataType>(k_ValueType)
                .WithDisplayName("Value Type")
                .WithDefaultValue(ComputeGraphTypes.HLSLDataType.Float);        }

        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            GetNodeOptionByName(k_ValueType).TryGetValue<ComputeGraphTypes.HLSLDataType>(out var valueHLSLType);
            var valueCSType = ComputeGraphTypes.GetCSharpType(valueHLSLType);

            context.AddInputPort<int>("Index").Build();
            context.AddInputPort("Value").WithDataType(valueCSType).Build();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            GetNodeOptionByName(k_BufferName).TryGetValue<string>(out var bufferName);
            GetNodeOptionByName(k_ValueType).TryGetValue<ComputeGraphTypes.HLSLDataType>(out var valueHLSLType);
            
            if (!compiler.RegisteredUniforms.Contains(bufferName))
            {
                compiler.RegisteredUniforms.Add(bufferName);
                
                compiler.Declarations.AppendLine($"RWStructuredBuffer<{ComputeGraphTypes.GetStringFromHLSLType(valueHLSLType)}> {bufferName};");
            }
            
            string value = EvaluateInput(compiler, "Value");
            string index = EvaluateInput(compiler, "Index");

            compiler.Body.AppendLine($"    {bufferName}[{index}] = {value};");
        }
    }
}