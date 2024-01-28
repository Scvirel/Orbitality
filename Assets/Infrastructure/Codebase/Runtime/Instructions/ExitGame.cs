#if !UNITY_EDITOR 
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
#endif

namespace Orbitality.Client.Runtime
{
    public sealed class ExitGame : Instruction
    {
        public override void Execute()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            _isCompleted = true;
#else
            Application.Quit();
            _isCompleted = true;
#endif
        }
    }
}