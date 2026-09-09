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

            string hlslType = ComputeGraphTypes.GetCSharpTypeString(workingType);

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} * {valB};");
        }
    }
    
    // -- Floats -- 
    
    [Serializable]
    [Node("Math/Float", "", "Multiply Float", StylePath)]
    public class MultiplyFloat : MultiplyNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2", "", "Multiply Float2", StylePath)]
    public class MultiplyFloat2 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3", "", "Multiply Float3", StylePath)]
    public class MultiplyFloat3 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4", "", "Multiply Float4", StylePath)]
    public class MultiplyFloat4 : MultiplyNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
    
    // -- Integers --
    
    [Serializable]
    [Node("Math/Int", "", "Multiply Int", StylePath)]
    public class MultiplyInt : MultiplyNode
    { 
        protected override Type workingType => typeof(int);
    }
    
    [Serializable]
    [Node("Math/Int2", "", "Multiply Int2", StylePath)]
    public class MultiplyInt2 : MultiplyNode
    { 
        protected override Type workingType => typeof(int2);
    }
    
    [Serializable]
    [Node("Math/Int3", "", "Multiply Int3", StylePath)]
    public class MultiplyInt3 : MultiplyNode
    { 
        protected override Type workingType => typeof(int3);
    }
    
    [Serializable]
    [Node("Math/Int4", "", "Multiply Int4", StylePath)]
    public class MultiplyInt4 : MultiplyNode
    { 
        protected override Type workingType => typeof(int4);
    }
}