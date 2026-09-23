using System;
using System.Collections.Generic;
using Unity.GraphToolkit.Editor;
using UnityEngine;

namespace Editor.Nodes
{
    [Serializable]
    [Node("", "", "", StylePath)]
    public abstract class ComputeNodeWildcardBase : ComputeNodeBase
    {
        [SerializeField] public Type resolvedType = typeof(object);
        public abstract string[] wildcardPorts { get; }

        public void ResolveType()
        {
            Type newType = typeof(object);

            foreach (var portName in wildcardPorts)
            {
                var port = GetInputPortByName(portName);
                if (port == null) continue;
                
                var connectedPorts = new List<IPort>();
                port.GetConnectedPorts(connectedPorts);

                if (connectedPorts.Count > 0)
                {
                    newType = connectedPorts[0].DataType;
                }
            }

            // Ports did not change
            if (newType == resolvedType) return;
            
            // Refresh ports, port type changed
            resolvedType = newType;
            DefineNode();
        }
    }
}