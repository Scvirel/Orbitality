using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetTriggerEnter : Instruction<Collider2D>
    {
        [Inject] private readonly ILevelService _levelService = default;

        [SerializeField] private Transform _hpBar = default;

        public override void Execute(Collider2D input)
        {
            if (input.gameObject.TryGetComponent(out RocketDataState state))
            {
                float hp = _hpBar.localScale.x - (state.Value.Damage / 100f);

                if (hp <= 0)
                {
                    _levelService.RemovePlanet(this.gameObject);
                    Destroy(gameObject);
                }
                else
                {
                    _hpBar.localScale = new Vector3(_hpBar.localScale.x - (state.Value.Damage / 100f), _hpBar.localScale.y, _hpBar.localScale.z);
                }
            }
        }
    }
}