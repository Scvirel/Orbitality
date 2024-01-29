namespace Orbitality.Client.Runtime
{
    public sealed class LevelDataState : ILevelDataState
    {
        private LevelStateModel _value = default;
        public LevelStateModel Value 
        { 
            get => _value; 
            set => _value = value; 
        }
    }
}