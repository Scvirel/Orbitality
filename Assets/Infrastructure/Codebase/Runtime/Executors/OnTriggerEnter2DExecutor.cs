using UnityEngine;

namespace Orbitality.Client.Runtime
{
    public sealed class OnTriggerEnter2DExecutor : BaseTargetExecutor<Collider2D>
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            base.Execute(collision);
        }
    }
}