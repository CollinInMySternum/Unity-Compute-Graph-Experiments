using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Search;

namespace Editor.Nodes
{
    [Serializable]
    public abstract class SubtractNode : ComputeNodeBase
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

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} - {valB};");
        }
    }
    
    // -- Floats -- 

    [Serializable]
    [Node("Math/Float")]
    public class SubtractFloat : SubtractNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2")]
    public class SubtractFloat2 : SubtractNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3")]
    public class SubtractFloat3 : SubtractNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4")]
    public class SubtractFloat4 : SubtractNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
    
    // -- Integers --
    
    [Serializable]
    [Node("Math/Int")]
    public class SubtractInt : SubtractNode
    { 
        protected override Type workingType => typeof(int);
    }
    
    [Serializable]
    [Node("Math/Int2")]
    public class SubtractInt2 : SubtractNode
    { 
        protected override Type workingType => typeof(int2);
    }
    
    [Serializable]
    [Node("Math/Int3")]
    public class SubtractInt3 : SubtractNode
    { 
        protected override Type workingType => typeof(int3);
    }
    
    [Serializable]
    [Node("Math/Int4")]
    public class SubtractInt4 : SubtractNode
    { 
        protected override Type workingType => typeof(int4);
    }
}