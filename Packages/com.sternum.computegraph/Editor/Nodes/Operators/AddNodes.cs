using System;
using System.Collections.Generic;
using System.Linq;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Search;

using Editor;

namespace Editor.Nodes
{
    [Serializable]
    [Node("", "", "Add", StylePath)]
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

            string hlslType = ComputeGraphTypes.GetStringFromCSType(workingType);

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} + {valB};");
        }
    }
    
    // -- Floats -- 

    [Serializable]
    [Node("Math/Float", "", "Add Float", StylePath)]
    public class AddFloat : AddNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2", "", "Add Float2", StylePath)]
    public class AddFloat2 : AddNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3", "", "Add Float3", StylePath)]
    public class AddFloat3 : AddNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4", "", "Add Float4", StylePath)]
    public class AddFloat4 : AddNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
    
    // -- Integers --
    
    [Serializable]
    [Node("Math/Int", "", "Add Int", StylePath)]
    public class AddInt : AddNode
    { 
        protected override Type workingType => typeof(int);
    }
    
    [Serializable]
    [Node("Math/Int2", "", "Add Int2", StylePath)]
    public class AddInt2 : AddNode
    { 
        protected override Type workingType => typeof(int2);
    }
    
    [Serializable]
    [Node("Math/Int3", "", "Add Int3", StylePath)]
    public class AddInt3 : AddNode
    { 
        protected override Type workingType => typeof(int3);
    }
    
    [Serializable]
    [Node("Math/Int4", "", "Add Int4", StylePath)]
    public class AddInt4 : AddNode
    { 
        protected override Type workingType => typeof(int4);
    }
}