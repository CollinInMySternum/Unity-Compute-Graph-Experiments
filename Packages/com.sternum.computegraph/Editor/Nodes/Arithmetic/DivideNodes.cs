using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes
{
    [Serializable]
    public abstract class DivideNode : ComputeNodeBase
    {
        protected abstract Type workingType { get; }
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort("A").WithDataType(workingType).Build();
            context.AddInputPort("B").WithDataType(workingType).Build();
            
            context.AddOutputPort("Out").WithDataType(workingType).Build();
        }

        protected override void EmitHLSL(ComputeGraphCompiler compiler, string outputVar)
        {
            string valA = EvaluateInput(compiler, "A");
            string valB = EvaluateInput(compiler, "B");

            string hlslType = ComputeGraphTypes.GetStringFromCSType(workingType);

            compiler.Body.AppendLine($"    {hlslType} {outputVar} = {valA} / {valB};");
        }
    }
    
    // -- Floats -- 

    [Serializable]
    [Node("Math/Float", "", "Divide Float", StylePath)]
    public class DivideFloat : DivideNode
    { 
        protected override Type workingType => typeof(float);
    }
    
    [Serializable]
    [Node("Math/Float2", "", "Divide Float2", StylePath)]
    public class DivideFloat2 : DivideNode
    { 
        protected override Type workingType => typeof(Vector2);
    }
    
    [Serializable]
    [Node("Math/Float3", "", "Divide Float3", StylePath)]
    public class DivideFloat3 : DivideNode
    { 
        protected override Type workingType => typeof(Vector3);
    }
    
    [Serializable]
    [Node("Math/Float4", "", "Divide Float4", StylePath)]
    public class DivideFloat4 : DivideNode
    { 
        protected override Type workingType => typeof(Vector4);
    }
    
    // -- Integers --
    
    [Serializable]
    [Node("Math/Int", "", "Divide Int", StylePath)]
    public class DivideInt : DivideNode
    { 
        protected override Type workingType => typeof(int);
    }
    
    [Serializable]
    [Node("Math/Int2", "", "Divide Int2", StylePath)]
    public class DivideInt2 : DivideNode
    { 
        protected override Type workingType => typeof(int2);
    }
    
    [Serializable]
    [Node("Math/Int3", "", "Divide Int3", StylePath)]
    public class DivideInt3 : DivideNode
    { 
        protected override Type workingType => typeof(int3);
    }
    
    [Serializable]
    [Node("Math/Int4", "", "Divide Int4", StylePath)]
    public class DivideInt4 : DivideNode
    { 
        protected override Type workingType => typeof(int4);
    }
}