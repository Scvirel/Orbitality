using System;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class PlayerDataModel
    {
        public string Id = default;
        public PlayerType Type = default;
        public PlanetDataModel ControlledPlanet = default;

        public PlayerDataModel(
            string id, 
            PlayerType type,
            PlanetDataModel controlledPlanet
            )
        {
            Id = id;
            Type = type;
            ControlledPlanet = controlledPlanet;
        }
    }
}