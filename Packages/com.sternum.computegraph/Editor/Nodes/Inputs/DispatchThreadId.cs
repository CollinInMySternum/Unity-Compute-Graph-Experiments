using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Inputs
{
    [Serializable]
    [Node("Inputs")]
    public class DispatchThreadId : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddOutputPort<int3>("XYZ").Build();
            
            context.AddOutputPort<int>("X").Build();
            context.AddOutputPort<int>("Y").Build();
            context.AddOutputPort<int>("Z").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            // Doesn't emit code, since it just accesses a variable
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "XYZ": return "DispatchThreadId";
                case "X": return "DispatchThreadId.x";
                case "Y": return "DispatchThreadId.y";
                case "Z": return "DispatchThreadId.z";
                
                default: return "0";
            }
        }
    }
}