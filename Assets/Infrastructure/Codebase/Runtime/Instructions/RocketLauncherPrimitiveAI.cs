using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketLauncherPrimitiveAI : Instruction
    {
        [Inject] private readonly ILevelService _levelService = default;
        [Inject] private readonly RocketEntryExecutor.Factory _rocketFactory = default;
        [Inject] private readonly RocketConfig _rocketConfig = default;

        [SerializeField] private RocketType _rocketType = default;
        [SerializeField] private Transform _position = default;
        [SerializeField] private Transform _rotation = default;

        [SerializeField] private PlanetDataState _planetDataState = default;

        private float _reloadTimer = default;
        private RocketModel _laucnhRocketData = default;

        private void Awake()
        {
            _laucnhRocketData = _rocketConfig.GetDataByType(_rocketType);
            _reloadTimer = _laucnhRocketData.CooldownSec;
        }

        public override void Execute()
        {
            if (_planetDataState.Value.PlayerType != PlayerType.RealPlayer)
            {
                if (_reloadTimer >= _laucnhRocketData.CooldownSec)
                {
                    RocketEntryExecutor executor = _rocketFactory.Create();

                    executor.transform.SetPositionAndRotation(_position.position, _position.rotation);
                    executor.gameObject.transform.localScale = Vector3.one;

                    executor.Execute(
                        new RocketDto(
                            _rocketType,
                            _laucnhRocketData.Sprite,
                            _laucnhRocketData.Speed,
                            _laucnhRocketData.CooldownSec,
                            _laucnhRocketData.Damage,
                            _position.position,
                            _rotation.rotation
                            )
                        );

                    Debug.Log($"[AI] shoot with : {_rocketType} !");

                    _levelService.InsertRocket(executor.gameObject);

                    _reloadTimer = 0f;
                }

            }
        }

        private void FixedUpdate()
        {
            _reloadTimer += Time.fixedDeltaTime;
        }
    }
}