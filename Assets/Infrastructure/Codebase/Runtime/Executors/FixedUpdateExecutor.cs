using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class FixedUpdateExecutor : BaseExecutor 
    {
        [SerializeField] private int _framesOffset = default;

        private int _currentFrame = default;

        private void FixedUpdate()
        {
            _currentFrame++;

            if (_currentFrame % _framesOffset == 0)
            {
                base.Execute();
            }
        }
    }
}