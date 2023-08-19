using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace Helpers.Tools.Codegen
{
    public static class ProviderGenerator
    {
        private static readonly string SaveDirectory = $"{Application.dataPath}/_Project/CodeBase/";
        private static readonly string ScriptPostfix = "Provider";
        private static readonly StringBuilder StringBuilder = new();
        
        public static void Generate()
        {
            var components = GetProviderRequiredComponents();
            Save(components);
        }

        private static Type[] GetProviderRequiredComponents() =>
            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.GetCustomAttributes().Count(y => y is ProviderRequiredAttribute) > 0)
                .ToArray();

        private static void Save(Type[] components)
        {
            StringBuilder.Clear();
            
            for (int i = 0; i < components.Length; i++)
            {
                var component = components[i];
                StringBuilder.Append("using Voody.UniLeo; \n");
                StringBuilder.Append($@"public class {component.Name}{ScriptPostfix} : MonoProvider<{component}>");
                StringBuilder.Append("{ }");
                System.IO.File.WriteAllText($"{SaveDirectory}{component.Name}{ScriptPostfix}.cs", StringBuilder.ToString());
                StringBuilder.Clear();
            }
        }
    }
}