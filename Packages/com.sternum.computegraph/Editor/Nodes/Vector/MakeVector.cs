using System;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Vector
{
    [Serializable]
    public class MakeFloat2Node : ComputeNodeBase
    {
        protected Type workingType = typeof(Vector2);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("X").Build();
            context.AddInputPort<float>("Y").Build();
            
            context.AddOutputPort<Vector2>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
                
            compiler.Body.AppendLine($"    float2{outputVar} = float2({x}, {y});");
        }
    }
    
    [Serializable]
    public class MakeFloat3Node : ComputeNodeBase
    {
        protected Type workingType = typeof(Vector3);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("X").Build();
            context.AddInputPort<float>("Y").Build();
            context.AddInputPort<float>("Z").Build();
            
            context.AddOutputPort<Vector3>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
            string z = EvaluateInput(compiler, "Z");
                
            compiler.Body.AppendLine($"    float3{outputVar} = float3({x}, {y}, {z});");
        }
    }
    
    [Serializable]
    public class MakeFloat4Node : ComputeNodeBase
    {
        protected Type workingType = typeof(Vector4);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<float>("X").Build();
            context.AddInputPort<float>("Y").Build();
            context.AddInputPort<float>("Z").Build();
            context.AddInputPort<float>("W").Build();
            
            context.AddOutputPort<Vector4>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
            string z = EvaluateInput(compiler, "Z");
            string w = EvaluateInput(compiler, "W");
                
            compiler.Body.AppendLine($"    float4{outputVar} = float4({x}, {y}, {z}, {w});");
        }
    }
    
    [Serializable]
    public class MakeInt2Node : ComputeNodeBase
    {
        protected Type workingType = typeof(int2);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int>("X").Build();
            context.AddInputPort<int>("Y").Build();
            
            context.AddOutputPort<int2>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
                
            compiler.Body.AppendLine($"    int2{outputVar} = int2({x}, {y});");
        }
    }
    
    [Serializable]
    public class MakeInt3Node : ComputeNodeBase
    {
        protected Type workingType = typeof(int3);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int>("X").Build();
            context.AddInputPort<int>("Y").Build();
            context.AddInputPort<int>("Z").Build();
            
            context.AddOutputPort<int3>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
            string z = EvaluateInput(compiler, "Z");
                
            compiler.Body.AppendLine($"    int3{outputVar} = int3({x}, {y}, {z});");
        }
    }
    
    [Serializable]
    public class MakeInt4Node : ComputeNodeBase
    {
        protected Type workingType = typeof(int4);
        
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int>("X").Build();
            context.AddInputPort<int>("Y").Build();
            context.AddInputPort<int>("Z").Build();
            context.AddInputPort<int>("W").Build();
            
            context.AddOutputPort<int4>("Out").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string x = EvaluateInput(compiler, "X");
            string y = EvaluateInput(compiler, "Y");
            string z = EvaluateInput(compiler, "Z");
            string w = EvaluateInput(compiler, "W");
                
            compiler.Body.AppendLine($"    int4{outputVar} = int4({x}, {y}, {z}, {w});");
        }
    }
}