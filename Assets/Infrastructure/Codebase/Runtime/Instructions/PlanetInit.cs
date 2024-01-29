using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetInit : Instruction<PlanetDto>
    {
        [SerializeField] private SpriteRenderer _renderer = default;
        [SerializeField] private Transform _transform = default;

        [SerializeField] private GameObject _hud = default;
        [SerializeField] private GameObject _launcherDirectionArrow = default;

        [SerializeField] private PlanetDataState _state = default;

        [SerializeField] private GameObject _userManualLauncher = default;
        [SerializeField] private GameObject _aiLauncher = default;

        public override void Execute(PlanetDto dto)
        {
            if (dto.PlayerType == PlayerType.RealPlayer)
            {
                _hud.SetActive(true);
                _launcherDirectionArrow.SetActive(true);
                _userManualLauncher.SetActive(true);
            }
            else
            {
                _hud.SetActive(false);
                _launcherDirectionArrow.SetActive(false);
                _aiLauncher.SetActive(true);
            }

            _renderer.sprite = dto.Sprite;
            _transform.position = dto.Position;

            _state.Value = dto;
        }
    }
}