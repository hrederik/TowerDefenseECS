using Helpers.Tools.Codegen;
using UnityEditor;
using UnityEditor.SceneManagement;

namespace Helpers.Tools.Editor
{
    public class Tools : UnityEditor.Editor
    {
        [MenuItem("Tools/SceneSwitcher/Load Boot Scene")]
        public static void LoadBootScene()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/Boot.unity");
        }
        
        [MenuItem("Tools/SceneSwitcher/Load Game Scene")]
        public static void LoadGameScene()
        {
            EditorSceneManager.SaveOpenScenes();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/Game.unity");
        }
        
        [MenuItem("Tools/Codegen/Generate Providers")]
        public static void GenerateProviders()
        {
            ProviderGenerator.Generate();
        }
    }
}