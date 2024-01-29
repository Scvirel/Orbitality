using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class OrbitalityMove : MonoBehaviour
    {
        [SerializeField] private Transform _ourTransform = default;
        [SerializeField] private PlanetDataState _state = default;

        private void FixedUpdate()
        {
            Vector3 direction = _ourTransform.position;

            float angle = Mathf.Atan2(direction.y, direction.x);

            angle += _state.Value.OrbitRotationSpeed * Time.fixedDeltaTime;

            float x = Mathf.Cos(angle) * direction.magnitude;
            float y = Mathf.Sin(angle) * direction.magnitude;

            _ourTransform.position = new Vector3(x, y, transform.position.z);
        }
    }
}