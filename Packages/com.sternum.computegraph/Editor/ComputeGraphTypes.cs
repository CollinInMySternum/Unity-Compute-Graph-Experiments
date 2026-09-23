using System;
using System.Globalization;
using Unity.Mathematics;
using UnityEngine;

namespace Editor
{
    public static class ComputeGraphTypes
    {
        public enum HLSLDataType
        {
            Float,
            Float2,
            Float3,
            Float4,
            
            Int,
            Int2,
            Int3,
            Int4,
            
            Bool
        }
        
        public static Type GetCSharpType(HLSLDataType dataType)
        {
            switch (dataType)
            {
                case HLSLDataType.Float: return typeof(float);
                case HLSLDataType.Float2: return typeof(Vector2);
                case HLSLDataType.Float3: return typeof(Vector3);
                case HLSLDataType.Float4: return typeof(Vector4);
                case HLSLDataType.Int: return typeof(int);
                case HLSLDataType.Int2: return typeof(int2);
                case HLSLDataType.Int3: return typeof(int3);
                case HLSLDataType.Int4: return typeof(int4);
                case HLSLDataType.Bool: return typeof(bool);
                default: return typeof(float);
            }
        }
        
        public static string FormatValueHLSL(object value, Type type)
        {
            // Single component
            if (type == typeof(float)) return ((float)value).ToString("G", CultureInfo.InvariantCulture);
            if (type == typeof(int)) return ((int)value).ToString("G", CultureInfo.InvariantCulture);
            if (type == typeof(bool)) return ((bool)value).ToString().ToLower();
            
            // Multi-component
            
            // Floats
            if (type == typeof(Vector2))
            {
                var v = (Vector2)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                
                return $"float2({x},{y})";
            }
            if (type == typeof(Vector3))
            {
                var v = (Vector3)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                string z = v.z.ToString("G");
                
                return $"float3({x},{y},{z})";
            }
            if (type == typeof(Vector4))
            {
                var v = (Vector4)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                string z = v.z.ToString("G");
                string w = v.z.ToString("G");
                
                return $"float4({x},{y},{z},{w})";
            }
            
            // Integers
            if (type == typeof(int2))
            {
                var v = (Vector2)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                
                return $"int2({x},{y})";
            }
            if (type == typeof(int3))
            {
                var v = (Vector3)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                string z = v.z.ToString("G");
                
                return $"int3({x},{y},{z})";
            }
            if (type == typeof(int4))
            {
                var v = (int4)value;
                
                string x = v.x.ToString("G");
                string y = v.y.ToString("G");
                string z = v.z.ToString("G");
                string w = v.z.ToString("G");
                
                return $"int4({x},{y},{z},{w})";
            }

            return "0";
        }

        public static HLSLDataType GetHLSLTypeFromString(string str)
        {
            switch (str)
            {
                case "float": return HLSLDataType.Float;
                case "float2": return HLSLDataType.Float2;
                case "float3": return HLSLDataType.Float3;
                case "float4": return HLSLDataType.Float4;
                case "int": return HLSLDataType.Int;
                case "int2": return HLSLDataType.Int2;
                case "int3": return HLSLDataType.Int3;
                case "int4": return HLSLDataType.Int4;
                case "bool": return HLSLDataType.Bool;
                
                default: return HLSLDataType.Float;
            }
        }

        public static string GetStringFromHLSLType(HLSLDataType t)
        {
            switch (t)
            {
                case HLSLDataType.Float: return "float";
                case HLSLDataType.Float2: return "float2";
                case HLSLDataType.Float3: return "float3";
                case HLSLDataType.Float4: return "float4";
                
                case HLSLDataType.Int: return "int";
                case HLSLDataType.Int2: return "int2";
                case HLSLDataType.Int3: return "int3";
                case HLSLDataType.Int4: return "int4";
                
                case HLSLDataType.Bool: return "bool";
                
                default: return "float";
            }
        }

        public static string GetStringFromCSType(Type t)
        {
            if (t == typeof(float)) return "float";
            if (t == typeof(Vector2)) return "float2";
            if (t == typeof(Vector3)) return "float3";
            if (t == typeof(Vector4)) return "float4";

            if (t == typeof(int)) return "int";
            if (t == typeof(int2)) return "int2";
            if (t == typeof(int3)) return "int3";
            if (t == typeof(int4)) return "int4";

            if (t == typeof(bool)) return "bool";
            if (t == typeof(Texture2D)) return "Texture2D";

            return "float";
        }
    }
}