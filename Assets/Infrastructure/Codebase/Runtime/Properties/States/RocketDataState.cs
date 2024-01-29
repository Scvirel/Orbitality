namespace Orbitality.Client.Runtime
{
    public sealed class RocketDataState : MonoStateProperty<RocketDto>
    {
        private RocketDto _value = default;
        public override RocketDto Value
        {
            get => _value;
            set => _value = value;
        }
    }
}