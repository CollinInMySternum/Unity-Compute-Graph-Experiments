using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using Unity.Properties;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Editor
{
    [Serializable]
    public abstract class ComputeNodeBase : Node
    {
        [NonSerialized] private string _cachedVarName;

        public void ResetCompilationState()
        {
            _cachedVarName = null;
        }

        public string GetOrEmitHLSL(HLSLCompiler compiler, string outputPortName)
        {
            if (string.IsNullOrEmpty(_cachedVarName))
            {
                _cachedVarName = compiler.GetUniqueVarName(GetType().Name.Replace("Node", ""));
                EmitHLSL(compiler, _cachedVarName);
            }

            return FormatOutputVariable(_cachedVarName, outputPortName);
        }

        protected abstract void EmitHLSL(HLSLCompiler compiler, string outputVar);

        protected virtual string FormatOutputVariable(string baseVarName, string outputPortName)
        {
            return baseVarName;
        }

        protected string EvaluateInput(HLSLCompiler compiler, string portName, string fallbackValue = "0.0")
        {
            var port = GetInputPortByName(portName);
            if (port == null) return fallbackValue;
            
            var connectedPorts = new List<IPort>();
            port.GetConnectedPorts(connectedPorts);
            var connectedPort = connectedPorts.FirstOrDefault();

            // Handle inline UI Values
            if (connectedPort == null)
            {
                Type type = port.DataType;
                
                if (type == typeof(float) && port.TryGetValue<float>(out var v1)) return FormatValueHLSL(v1, type);
                if (type == typeof(int) && port.TryGetValue<int>(out var v2)) return FormatValueHLSL(v2, type);
                if (type == typeof(Vector2) && port.TryGetValue<Vector2>(out var v3)) return FormatValueHLSL(v3, type);
                if (type == typeof(Vector3) && port.TryGetValue<Vector3>(out var v4)) return FormatValueHLSL(v4, type);
                if (type == typeof(Vector4) && port.TryGetValue<Vector4>(out var v5)) return FormatValueHLSL(v5, type);
            }
            
            // Standard compute nodes
            if (connectedPort.GetNode() is ComputeNodeBase connectedNode)
            {
                return connectedNode.GetOrEmitHLSL(compiler, connectedPort.Name);
            }

            // GTF Variables/Uniforms
            if (connectedPort.GetNode() is IVariableNode variableNode)
            {
                IVariable variable = variableNode.Variable;
                string varName = variable.Name;

                if (!compiler.RegisteredUniforms.Contains(varName))
                {
                    string hlslType = TypeToHLSL(variable.DataType);

                    compiler.Declarations.AppendLine($"{hlslType} {varName};");
                }
            }
            
            // GTF Constants/Literals
            if (connectedPort.GetNode() is IConstantNode constantNode)
            {
                Type type = connectedPort.DataType;
                
                if (type == typeof(float) && constantNode.TryGetValue<float>(out var v1)) return FormatValueHLSL(v1, type);
                if (type == typeof(int) && constantNode.TryGetValue<int>(out var v2)) return FormatValueHLSL(v2, type);
                if (type == typeof(Vector2) && constantNode.TryGetValue<Vector2>(out var v3)) return FormatValueHLSL(v3, type);
                if (type == typeof(Vector3) && constantNode.TryGetValue<Vector3>(out var v4)) return FormatValueHLSL(v4, type);
                if (type == typeof(Vector4) && constantNode.TryGetValue<Vector4>(out var v5)) return FormatValueHLSL(v5, type);
            }

            return fallbackValue;
        }

        private string FormatValueHLSL(object value, Type type)
        {
            if (type == typeof(float)) return ((float)value).ToString("G", CultureInfo.InvariantCulture);
            if (type == typeof(int)) return ((int)value).ToString("G", CultureInfo.InvariantCulture);
            if (type == typeof(Vector2))
            {
                var v = (Vector2)value;
                string x = v.x.ToString("F4");
                string y = v.y.ToString("F4");
                return $"float2({x},{y})";
            }
            if (type == typeof(Vector3))
            {
                var v = (Vector3)value;
                
                string x = v.x.ToString("F4");
                string y = v.y.ToString("F4");
                string z = v.z.ToString("F4");
                
                return $"float3({x},{y},{z})";
            }
            if (type == typeof(Vector4))
            {
                var v = (Vector4)value;
                
                string x = v.x.ToString("F4");
                string y = v.y.ToString("F4");
                string z = v.z.ToString("F4");
                string w = v.z.ToString("F4");
                
                return $"float4({x},{y},{z},{w})";
            }

            return "0";
        }

        protected string TypeToHLSL(Type t)
        {
            if (t == typeof(float)) return "float";
            if (t == typeof(Vector2)) return "float2";
            if (t == typeof(Vector3)) return "float3";
            if (t == typeof(Vector4)) return "float4";

            if (t == typeof(int)) return "int";
            if (t == typeof(int2)) return "int2";
            if (t == typeof(int3)) return "int3";
            if (t == typeof(int4)) return "int4";
            if (t == typeof(Texture2D)) return "Texture2D";

            return "float";
        }
    }
}