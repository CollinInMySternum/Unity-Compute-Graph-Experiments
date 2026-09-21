using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using Unity.Properties;
using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;
using Editor;

namespace Editor.Nodes
{
    [Serializable]
    [Node("", "", "", StylePath)]
    public abstract class ComputeNodeBase : Node
    {
        public const string StylePath = "Packages/com.sternum.computegraph/Editor/Styles/ComputeNodeStylesMaster.uss";
        
        [NonSerialized] private string _cachedVarName;

        public void ResetCompilationState()
        {
            _cachedVarName = null;
        }

        public string GetOrEmitHLSL(ComputeGraphCompiler compiler, string outputPortName)
        {
            if (string.IsNullOrEmpty(_cachedVarName))
            {
                _cachedVarName = compiler.GetUniqueVarName(GetType().Name.Replace("Node", ""));
                EmitHLSL(compiler, _cachedVarName);
            }

            return FormatOutputVariable(_cachedVarName, outputPortName);
        }

        protected abstract void EmitHLSL(ComputeGraphCompiler compiler, string outputVar);

        protected virtual string FormatOutputVariable(string baseVarName, string outputPortName)
        {
            return baseVarName;
        }

        protected string EvaluateInput(ComputeGraphCompiler compiler, string portName, string fallbackValue = "0.0")
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
                
                if (type == typeof(float) && port.TryGetValue<float>(out var v1)) return ComputeGraphTypes.FormatValueHLSL(v1, type);
                if (type == typeof(int) && port.TryGetValue<int>(out var v2)) return ComputeGraphTypes.FormatValueHLSL(v2, type);
                if (type == typeof(Vector2) && port.TryGetValue<Vector2>(out var v3)) return ComputeGraphTypes.FormatValueHLSL(v3, type);
                if (type == typeof(Vector3) && port.TryGetValue<Vector3>(out var v4)) return ComputeGraphTypes.FormatValueHLSL(v4, type);
                if (type == typeof(Vector4) && port.TryGetValue<Vector4>(out var v5)) return ComputeGraphTypes.FormatValueHLSL(v5, type);
                if (type == typeof(bool) && port.TryGetValue<bool>(out var v6)) return ComputeGraphTypes.FormatValueHLSL(v6, type);
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
                    compiler.RegisteredUniforms.Add(varName);
                    
                    string hlslType = ComputeGraphTypes.GetStringFromCSType(variable.DataType);

                    compiler.Declarations.AppendLine($"{hlslType} {varName};");
                }
                
                return varName;
            }
            
            // GTF Constants/Literals
            if (connectedPort.GetNode() is IConstantNode constantNode)
            {
                Type type = connectedPort.DataType;
                
                if (type == typeof(float) && constantNode.TryGetValue<float>(out var v1)) return ComputeGraphTypes.FormatValueHLSL(v1, type);
                if (type == typeof(int) && constantNode.TryGetValue<int>(out var v2)) return ComputeGraphTypes.FormatValueHLSL(v2, type);
                if (type == typeof(Vector2) && constantNode.TryGetValue<Vector2>(out var v3)) return ComputeGraphTypes.FormatValueHLSL(v3, type);
                if (type == typeof(Vector3) && constantNode.TryGetValue<Vector3>(out var v4)) return ComputeGraphTypes.FormatValueHLSL(v4, type);
                if (type == typeof(Vector4) && constantNode.TryGetValue<Vector4>(out var v5)) return ComputeGraphTypes.FormatValueHLSL(v5, type);
                if (type == typeof(bool) && constantNode.TryGetValue<bool>(out var v6)) return ComputeGraphTypes.FormatValueHLSL(v6, type);
            }

            return fallbackValue;
        }
    }
}