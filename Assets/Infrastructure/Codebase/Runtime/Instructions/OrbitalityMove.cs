using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class OrbitalityMove : MonoBehaviour
    {
        [SerializeField] private Transform _targetTransform;

        [SerializeField] private Transform _ourTransform = default;
        [SerializeField] private float _speed = 2f;

        private void FixedUpdate()
        {
            Vector3 direction = _ourTransform.position - _targetTransform.position;

            float angle = Mathf.Atan2(direction.y, direction.x);

            angle += _speed * Time.fixedDeltaTime;

            float x = _targetTransform.position.x + Mathf.Cos(angle) * direction.magnitude;
            float y = _targetTransform.position.y + Mathf.Sin(angle) * direction.magnitude;

            _ourTransform.position = new Vector3(x, y, transform.position.z);
        }
    }
}