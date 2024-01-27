#if !UNITY_EDITOR 
using UnityEngine;
#endif

namespace Orbitality.Client.Runtime
{
    public sealed class ExitGame : Instruction
    {
        public override void Execute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}