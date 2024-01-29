using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class PlanetEntryExecutor : BaseTargetExecutor<PlanetDto>
    {
        public sealed class Factory : PlaceholderFactory<PlanetEntryExecutor> { }

        public override void Execute(PlanetDto model)
        {
            base.Execute(model);
        }
    }
}