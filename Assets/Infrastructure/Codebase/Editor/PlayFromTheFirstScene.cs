using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;
using Orbitality.Client.Runtime;

namespace Orbitality.Client.CustomEditor
{
    public static class PlayFromTheFirstScene
    {
        const string playFromFirstMenuStr = "CustomEditor/Always Start From Scene Bootstrap";

        static bool playFromFirstScene
        {
            get { return EditorPrefs.HasKey(playFromFirstMenuStr) && EditorPrefs.GetBool(playFromFirstMenuStr); }
            set { EditorPrefs.SetBool(playFromFirstMenuStr, value); }
        }

        [MenuItem(playFromFirstMenuStr, false, 0)]
        static void PlayFromFirstSceneCheckMenu()
        {
            playFromFirstScene = !playFromFirstScene;
            Menu.SetChecked(playFromFirstMenuStr, playFromFirstScene);

            ShowNotifyOrLog(playFromFirstScene ? $"Play from scene {GameScenes.Bootstrap}" : "Play from current scene");
        }

        // The menu won't be gray out, we use this validate method for update check state
        [MenuItem(playFromFirstMenuStr, true)]
        static bool PlayFromFirstSceneCheckMenuValidate()
        {
            Menu.SetChecked(playFromFirstMenuStr, playFromFirstScene);
            return true;
        }

        // This method is called before any Awake. It's the perfect callback for this feature
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void LoadFirstSceneAtGameBegins()
        {
            Scene activeScene = SceneManager.GetActiveScene();

            if (!playFromFirstScene || activeScene.name.Equals(GameScenes.Bootstrap))
                return;

            if (EditorBuildSettings.scenes.Length == 0)
            {
                Debug.LogError($"The scene build list is empty. Can't play from {GameScenes.Bootstrap} scene.");
                return;
            }

            SceneManager.LoadScene(GameScenes.Bootstrap);
        }

        static void ShowNotifyOrLog(string msg)
        {
            if (Resources.FindObjectsOfTypeAll<SceneView>().Length > 0)
                EditorWindow.GetWindow<SceneView>().ShowNotification(new GUIContent(msg));
            else
                Debug.Log(msg); // When there's no scene view opened, we just print a log
        }
    }
}