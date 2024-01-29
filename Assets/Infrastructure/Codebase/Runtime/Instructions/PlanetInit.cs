using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetInit : Instruction<PlanetDto>
    {
        [SerializeField] private SpriteRenderer _renderer = default;
        [SerializeField] private Transform _transform = default;

        [SerializeField] private GameObject _nickName = default;
        [SerializeField] private GameObject _launcherDirectionArrow = default;

        [SerializeField] private PlanetDataState _state = default;

        public override void Execute(PlanetDto dto)
        {
            if (dto.PlayerType == PlayerType.RealPlayer)
            {
                _nickName.SetActive(true);
                _launcherDirectionArrow.SetActive(true);
            }
            else
            {
                _nickName.SetActive(false);
                _launcherDirectionArrow.SetActive(false);
            }

            _renderer.sprite = dto.Sprite;
            _transform.position = dto.Position;

            _state.Value = dto;
        }
    }
}