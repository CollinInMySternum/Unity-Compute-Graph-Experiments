using System;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEngine;

namespace Editor.Nodes.Vector
{
    [Serializable]
    [Node("Math/Float2")]
    public class BreakFloat2 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<Vector2>("In").Build();
            
            context.AddOutputPort<float>("X").Build();
            context.AddOutputPort<float>("Y").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "float2(0.0, 0.0)");
                
            compiler.Body.AppendLine($"    float2 {outputVar} = {valIn};");
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                default: return baseVarName;
            }
        }
    }
    
    [Serializable]
    [Node("Math/Float3")]
    public class BreakFloat3 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<Vector3>("In").Build();
            
            context.AddOutputPort<float>("X").Build();
            context.AddOutputPort<float>("Y").Build();
            context.AddOutputPort<float>("Z").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "float3(0.0, 0.0, 0.0)");
                
            compiler.Body.AppendLine($"    float3 {outputVar} = {valIn};");
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                case "Z": return $"{baseVarName}.z";
                default: return baseVarName;
            }
        }
    }
    
    [Serializable]
    [Node("Math/Float4")]
    public class BreakFloat4 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<Vector4>("In").Build();
            
            context.AddOutputPort<float>("X").Build();
            context.AddOutputPort<float>("Y").Build();
            context.AddOutputPort<float>("Z").Build();
            context.AddOutputPort<float>("W").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "float4(0.0, 0.0, 0.0, 0.0)");
                
            compiler.Body.AppendLine($"    float4 {outputVar} = {valIn};");
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                case "Z": return $"{baseVarName}.z";
                case "W": return $"{baseVarName}.w";
                default: return baseVarName;
            }
        }
    }
    
    [Serializable]
    [Node("Math/Int2")]
    public class BreakInt2 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int2>("In").Build();
            
            context.AddOutputPort<int>("X").Build();
            context.AddOutputPort<int>("Y").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "int2(0, 0)");
                
            compiler.Body.AppendLine($"    int2 {outputVar} = {valIn};");
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                default: return baseVarName;
            }
        }
    }
    
    [Serializable]
    [Node("Math/Int3")]
    public class BreakInt3 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int3>("In").Build();
            
            context.AddOutputPort<int>("X").Build();
            context.AddOutputPort<int>("Y").Build();
            context.AddOutputPort<int>("Z").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "int3(0, 0, 0)");
                
            compiler.Body.AppendLine($"    int3 {outputVar} = {valIn};");
        }
        
        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                case "Z": return $"{baseVarName}.z";
                default: return baseVarName;
            }
        }
    }
    
    [Serializable]
    [Node("Math/Int4")]
    public class BreakInt4 : ComputeNodeBase
    {
        protected override void OnDefinePorts(IPortDefinitionContext context)
        {
            context.AddInputPort<int4>("In").Build();
            
            context.AddOutputPort<int>("X").Build();
            context.AddOutputPort<int>("Y").Build();
            context.AddOutputPort<int>("Z").Build();
            context.AddOutputPort<int>("W").Build();
        }

        protected override void EmitHLSL(HLSLCompiler compiler, string outputVar)
        {
            string valIn = EvaluateInput(compiler, "In", "int4(0, 0, 0, 0)");
                
            compiler.Body.AppendLine($"    int4 {outputVar} = {valIn};");
        }

        protected override string FormatOutputVariable(string baseVarName, string outPortName)
        {
            switch (outPortName)
            {
                case "X": return $"{baseVarName}.x";
                case "Y": return $"{baseVarName}.y";
                case "Z": return $"{baseVarName}.z";
                case "W": return $"{baseVarName}.w";
                default: return baseVarName;
            }
        }
    }
}