using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class RocketEntryExecutor : BaseTargetExecutor<RocketDto>
    {
        public sealed class Factory : PlaceholderFactory<RocketEntryExecutor> { }

        public override void Execute(RocketDto model)
        {
            base.Execute(model);
        }
    }
}