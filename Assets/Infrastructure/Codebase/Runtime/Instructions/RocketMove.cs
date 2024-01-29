using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketMove : Instruction
    {
        [Inject] private readonly ILevelService _levelService = default;

        [SerializeField] private Transform _transform = default;
        [SerializeField] private Rigidbody2D _rigidbody = default;

        [SerializeField] private RocketDataState _rocketDataState = null;

        public override void Execute()
        {
            Vector3 nDir = Random.insideUnitCircle.normalized.normalized;

            float angle = Vector2.SignedAngle(nDir, _rigidbody.velocity);

            _transform.rotation = Quaternion.FromToRotation(Vector2.up, nDir);
            _transform.RotateAround(_transform.position, _transform.forward, angle);

            _rigidbody.AddForce(nDir * _rocketDataState.Value.Speed);

            foreach (GameObject planet in _levelService.Planets)
            {
                Vector3 forceDirection = planet.transform.position - transform.position;

                if (forceDirection.magnitude < 1)
                {
                    continue;
                }

                _rigidbody.AddForce(forceDirection.normalized * Constants.G * _rigidbody.mass * forceDirection.magnitude / Constants.G);
            }
        }
    }
}