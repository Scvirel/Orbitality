using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class AxisRotator : MonoBehaviour
    {
        [SerializeField] private Transform _ourTransform = default;

        [SerializeField] private float _speed = 100f;

        private void FixedUpdate()
        {
            _ourTransform.Rotate(new Vector3(0, 0, _speed) * Time.fixedDeltaTime);
        }
    }
}