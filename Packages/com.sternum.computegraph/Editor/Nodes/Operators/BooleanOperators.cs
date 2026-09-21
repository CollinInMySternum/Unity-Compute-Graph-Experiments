using System;
using Unity.GraphToolkit.Editor;

namespace Editor.Nodes
{
    [Serializable]
    [Node("Operators", "", "OR", StylePath)]
    public class BooleanOr : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("A").WithDataType<bool>();
            context.AddInputPort("B").WithDataType<bool>();

            context.AddOutputPort("Out").WithDataType<bool>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valA = EvaluateInput(compiler, "A");
            string valB = EvaluateInput(compiler, "B");

            compiler.Body.AppendLine($"    bool {outputVar} = {valA} || {valB};");
        }
    }
    
    [Serializable]
    [Node("Operators", "", "AND", StylePath)]
    public class BooleanAnd : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("A").WithDataType<bool>();
            context.AddInputPort("B").WithDataType<bool>();
            
            context.AddOutputPort("Out").WithDataType<bool>();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valA = EvaluateInput(compiler, "A");
            string valB = EvaluateInput(compiler, "B");

            compiler.Body.AppendLine($"    bool {outputVar} = {valA} && {valB};");
        }
    }
}