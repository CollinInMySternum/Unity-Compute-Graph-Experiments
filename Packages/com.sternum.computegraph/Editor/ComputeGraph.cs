using System;
using System.Collections.Generic;
using System.Linq;
using Editor.Nodes;
using Unity.GraphToolkit.Editor;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [Graph(AssetExtension)]
    [Serializable]
    public class ComputeGraph : Graph
    {
        public const string AssetExtension = "cg";

        [MenuItem("Assets/Create/Compute Graph", false)]
        static void CreateAssetFile()
        {
            GraphDatabase.PromptInProjectBrowserToCreateNewAsset<ComputeGraph>();
        }
        
        public static ComputeGraph ActiveGraph { get; private set; }
        
        public override void OnEnable()
        {
            base.OnEnable();
            ActiveGraph = this;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (ActiveGraph == this) ActiveGraph = null; 
        }

        public void CompileToHLSL()
        {
            var compiler = new HLSLCompiler();

            var outputNode = this.GetNodes().OfType<OutputNode>().FirstOrDefault();

            if (outputNode == null)
            {
                Debug.LogError("Compilation Failed: No OutputNode found on graph.");
                return;
            }

            foreach (var node in this.GetNodes().OfType<ComputeNodeBase>())
            {
                node.ResetCompilationState();
            }

            outputNode.GetOrEmitHLSL(compiler, "Result");

            string finalCode = compiler.GetCompiledShader();
            
            Debug.Log($"Compilation Successful\n\n {finalCode}");
        }

        public override bool IsConnectionAllowed(IPort output, IPort input)
        {
            return base.IsConnectionAllowed(output, input);
        }
    }
}