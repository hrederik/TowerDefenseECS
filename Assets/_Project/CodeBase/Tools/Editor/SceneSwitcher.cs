using UnityEditor;
using UnityEditor.SceneManagement;

namespace Tools.Editor
{
    public class SceneSwitcher : UnityEditor.Editor
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
    }
}