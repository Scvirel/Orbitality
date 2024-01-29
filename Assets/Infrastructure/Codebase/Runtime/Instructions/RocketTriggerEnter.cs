using UnityEngine;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketTriggerEnter : Instruction<Collider2D>
    {
        [Inject] private readonly ILevelService _levelService = default;

        public override void Execute(Collider2D input)
        {
            _levelService.RemoveRocket(this.gameObject);
            Destroy(gameObject);
        }
    }
}