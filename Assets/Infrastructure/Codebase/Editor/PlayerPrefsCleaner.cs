using UnityEditor;
using UnityEngine;

namespace Orbitality.Client.CustomEditor
{
    public sealed class PlayerPrefsCleaner : Editor
    {
        [MenuItem("CustomEditor/Clear Prefs")]
        private static void ClearPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}