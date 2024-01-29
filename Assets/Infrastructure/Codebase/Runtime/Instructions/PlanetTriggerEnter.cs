using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetTriggerEnter : Instruction<Collider2D>
    {
        public override void Execute(Collider2D input)
        {
            Debug.Log($"Planet triggered {input.gameObject.name}");
        }
    }
}