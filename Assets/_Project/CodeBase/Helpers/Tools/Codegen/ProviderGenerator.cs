using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;
using Voody.UniLeo;

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

        private static Type[] GetProviderRequiredComponents()
        {
            var allTypes = Assembly.GetExecutingAssembly().GetTypes();
            var filteredTypes = allTypes.Where(type => CheckType(type, allTypes)).ToArray();

            return filteredTypes.ToArray();
        }

        private static void Save(Type[] components)
        {
            StringBuilder.Clear();
            
            for (int i = 0; i < components.Length; i++)
            {
                var component = components[i];
                
                StringBuilder.Append("using Voody.UniLeo;\nusing UnityEngine;\n\n");
                StringBuilder.Append($"[AddComponentMenu(\"Providers/{GetSimpleComponentPath(component)}\")]\n");
                StringBuilder.Append($@"public class {component.Name}{ScriptPostfix} : MonoProvider<{component}> {{ }}");
                
                System.IO.File.WriteAllText($"{SaveDirectory}{component.Name}{ScriptPostfix}.cs", StringBuilder.ToString());
                StringBuilder.Clear();
            }
        }

        private static bool CheckType(Type checkable, Type[] allTypes)
        {
            var hasAttribute = checkable.GetCustomAttributes().Count(x => x is ProviderRequiredAttribute) > 0;
            var hasNoProviderYet = allTypes.Count(current => HasProvider(current, checkable)) == 0;
            
            return hasAttribute && hasNoProviderYet;
        }

        private static bool HasProvider(Type current, Type checkable)
        {
            if (current.BaseType == null) return false;
            if (!current.BaseType.IsGenericType) return false;
            if (current.BaseType.GetGenericTypeDefinition() != typeof(MonoProvider<>)) return false;
            if (!current.BaseType.GenericTypeArguments.Contains(checkable)) return false;

            return true;
        }

        private static string GetSimpleComponentPath(Type component)
        {
            var componentPath = component.ToString();
            var componentsFolderName = ".Components";
            
            if (componentPath.Contains(componentsFolderName))
            {
                var startIndex = componentPath.IndexOf(componentsFolderName, StringComparison.Ordinal);
                var count = componentsFolderName.Length;

                componentPath = componentPath.Remove(startIndex, count);
            }

            componentPath = componentPath.Replace('.', '/');


            return componentPath;
        }
    }
}