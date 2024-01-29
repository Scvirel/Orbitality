using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class AxisRotator : MonoBehaviour
    {
        [SerializeField] private Transform _ourTransform = default;
        [SerializeField] private PlanetDataState _state = default;

        private void FixedUpdate()
        {
            _ourTransform.Rotate(new Vector3(0, 0, _state.Value.AxisRotationSpeed) * Time.fixedDeltaTime);
        }
    }
}