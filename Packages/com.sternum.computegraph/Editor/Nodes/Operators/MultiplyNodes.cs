using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.Search;

namespace Editor.Nodes
{
    [Serializable]
    public abstract class MultiplyNode : ComputeNodeBase
    {
        protected abstract Type workingType { get; }
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("A").WithDataType(workingType).Build();
            context.AddInputPort("B").WithDataType(workingType).Build();
            
            context.AddOutputPort("Out").WithDataType(workingType).Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valA = EvaluateInput(compiler, "A");
            string valB = EvaluateInput(compiler, "B");

            string hlslType = TypeToHLSL(workingType);

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} * {valB};");
        }
    }

    [Serializable]
    [Node("Math/Float")]
    public class MultiplyFloat : MultiplyNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2")]
    public class MultiplyFloat2 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3")]
    public class MultiplyFloat3 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4")]
    public class MultiplyFloat4 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
}