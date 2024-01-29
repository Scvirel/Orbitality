﻿using UnityEngine;
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

        [SerializeField] private Transform _reloadBar = default;
        private float _reloadTimer = default;
        private RocketModel _laucnhRocketData = default;

        private void Awake()
        {
            _laucnhRocketData = _rocketConfig.GetDataByType(_rocketType);
            _reloadTimer = _laucnhRocketData.CooldownSec;
        }

        public override void Execute()
        {
            if (_planetDataState.Value.PlayerType != PlayerType.Bot)
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

                    _levelService.InsertRocket(executor.gameObject);

                    StartReload();
                }

            }
        }

        private void FixedUpdate()
        {
            _reloadTimer += Time.fixedDeltaTime;
            _reloadBar.localScale = new Vector3(Mathf.Lerp(0f, 1.0f, _reloadTimer / _laucnhRocketData.CooldownSec), _reloadBar.localScale.y, _reloadBar.localScale.z);
        }

        private void StartReload()
        {
            _reloadBar.localScale = new Vector3(0, _reloadBar.localScale.y, _reloadBar.localScale.z);
            _reloadTimer = 0.1f;
        }
    }
}