using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using UnityEngine;
using UnityEngine.Search;

namespace Editor.Nodes
{
    [Serializable]
    public abstract class AddNode : ComputeNodeBase
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

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} + {valB};");
        }
    }

    [Serializable]
    [Node("Math/Float")]
    public class AddFloat : AddNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2")]
    public class AddFloat2 : AddNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3")]
    public class AddFloat3 : AddNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4")]
    public class AddFloat4 : AddNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
}