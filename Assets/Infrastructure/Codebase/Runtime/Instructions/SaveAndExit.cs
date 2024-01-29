using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class SaveAndExit : Instruction
    {
        [Inject] ISaveToFile _saveToFile = default;
        [Inject] ILevelService _levelService = default;
        [Inject] ILevelDataState _levelDataState = default;

        [Inject] private readonly ILoadScene _loadScene = default;
        [Inject] private readonly IUnloadSceneWithName _uloadSceneWithName = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.Menu, LoadSceneMode.Additive);

            _saveToFile.Execute(
                Application.persistentDataPath + $"/{_levelDataState.Value.SaveId}.json",
                JsonUtility.ToJson(
                    new LevelStateModel(
                        _levelDataState.Value.SaveId,
                        SelectPlayers(),
                        SelectRockets()
                    ))
                );

            Time.timeScale = 1f;

            _uloadSceneWithName.Execute(GameScenes.Battleground);
            _uloadSceneWithName.Execute(GameScenes.PausePopup);
        }

        private PlayerDataModel[] SelectPlayers()
        {
            int count = _levelService.Planets.Count();
            PlayerDataModel[] result = new PlayerDataModel[count];

            int planetIterator = default;
            for (int i = 0; i < count; i++)
            {
                GameObject obj = _levelService.Planets.ElementAt(i);

                PlanetDataState planetState = obj.GetComponent<PlanetDataState>();
                if (planetState == null)
                {
                    continue; //Sun no planet btw               (:
                }

                PlanetDto planetDto = planetState.Value;

                result[planetIterator] =
                    new PlayerDataModel(
                        planetDto.OwnerId,
                        planetDto.PlayerType,
                        new PlanetDataModel(
                            planetDto.Type,
                            obj.transform.position,
                            obj.transform.rotation
                            )
                        );
                planetIterator++;
            }

            return result;
        }
        private RocketDataModel[] SelectRockets()
        {
            int count = _levelService.Rockets.Count();
            RocketDataModel[] result = new RocketDataModel[count];

            for ( int i = 0; i < count; i++ ) 
            {
                GameObject obj = _levelService.Rockets.ElementAt(i);

                result[i] = 
                    new RocketDataModel(
                        obj.GetComponent<RocketDataState>().Value.Type,
                        obj.transform.position,
                        obj.transform.rotation
                        );
            }

            return result;
        }
    }
}