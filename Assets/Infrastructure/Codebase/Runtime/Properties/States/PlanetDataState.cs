namespace Orbitality.Client.Runtime
{
    public sealed class PlanetDataState : MonoStateProperty<PlanetDto>
    {
        private PlanetDto _value = default;
        public override PlanetDto Value 
        { 
            get => _value; 
            set => _value = value;
        }
    }
}