using System;
using System.Collections.Generic;
using System.IO;
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
        [SerializeField] private string guid = Guid.NewGuid().ToString();
        [SerializeField] private ComputeShader computeShader;
        
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

            var writeNode = GetNodes().OfType<WriteBuffer>().FirstOrDefault();

            if (writeNode == null)
            {
                Debug.LogError("Compilation Failed: No OutputNode found on graph.");
                return;
            }

            foreach (var node in GetNodes().OfType<ComputeNodeBase>())
            {
                node.ResetCompilationState();
            }

            writeNode.GetOrEmitHLSL(compiler, "Result");
            string finalCode = compiler.GetCompiledShader();
            
            CreateComputeAsset(finalCode);
            
            Debug.Log($"Compilation Successful\n\n {finalCode}");
        }

        public void CreateComputeAsset(string source)
        {
            string folderPath = "Assets/ComputeGraph/.generated";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string assetPath = $"{folderPath}/{guid}.compute";
            
            File.WriteAllText(assetPath, source);
            AssetDatabase.ImportAsset(assetPath);

            computeShader = AssetDatabase.LoadAssetAtPath<ComputeShader>(assetPath);
            
            AssetDatabase.SaveAssets();
        }
    }
}