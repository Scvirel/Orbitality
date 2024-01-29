using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketLauncher : Instruction
    {
        [Inject] private readonly ILevelService _levelService = default;
        [Inject] private readonly RocketEntryExecutor.Factory _rocketFactory = default;
        [Inject] private readonly RocketConfig _rocketConfig = default;

        [SerializeField] private RocketType _rocketType = default;
        [SerializeField] private Transform _position = default;
        [SerializeField] private Transform _rotation = default;

        [SerializeField] private PlanetDataState _planetDataState = default; 

        public override void Execute()
        {
            if (_planetDataState.Value.PlayerType != PlayerType.Bot)
            {
                RocketModel rocketData = _rocketConfig.GetDataByType(_rocketType);

                RocketEntryExecutor executor = _rocketFactory.Create();

                executor.transform.SetPositionAndRotation(_position.position, _position.rotation);
                executor.gameObject.transform.localScale = Vector3.one;

                executor.Execute(
                    new RocketDto(
                        _rocketType,
                        rocketData.Sprite,
                        rocketData.Speed,
                        rocketData.CooldownMSec,
                        rocketData.Damage,
                        _position.position,
                        _rotation.rotation
                        )
                    );

                _levelService.InsertRocket(executor.gameObject);
            }
        }
    }
}