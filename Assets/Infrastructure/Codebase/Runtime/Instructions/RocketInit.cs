using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketInit : Instruction<RocketDto>
    {
        [SerializeField] private SpriteRenderer _renderer = default;
        [SerializeField] private Transform _transform = default;

        [SerializeField] private RocketDataState _rocketDataState = default;

        private const float DestroyTimeout = 15f;

        public override void Execute(RocketDto dto)
        {
            _renderer.sprite = dto.Sprite;
            _transform.position = dto.Position;
            _transform.rotation = dto.Rotation;

            _rocketDataState.Value = dto;

            Destroy(_transform.gameObject, DestroyTimeout);
        }
    }
}