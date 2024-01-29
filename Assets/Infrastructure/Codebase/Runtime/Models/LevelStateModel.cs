using System;

namespace Orbitality.Client.Runtime
{
    [Serializable]
    public sealed class LevelStateModel
    {
        public string SaveId = default;
        public PlayerDataModel[] Players = default;
        public RocketDataModel[] Rockets = default;

        public LevelStateModel(
            string saveId,
            PlayerDataModel[] players,
            RocketDataModel[] rockets = default)
        {
            SaveId = saveId;
            Players = players;
            Rockets = rockets;
        }
    }
}