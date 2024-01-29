using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using Random = System.Random;

namespace Orbitality.Client.Runtime
{
    public sealed class StartGame : Instruction
    {
        [Inject] private readonly IIsFileExist _isFileExist = default;
        [InjectOptional] private readonly ILoadFromFile _loadFromFile = default;
        [Inject] private readonly ILoadSceneWithBind _loadSceneWithBind = default;
        [Inject] private readonly IUnloadSceneWithState _unloadSceneWithState = default;

        [SerializeField] private string _saveId = default;
        [SerializeField] private int _fakes = default;

        public override void Execute()
        {
            string filePath = Application.persistentDataPath + $"/{_saveId}.json";
            LevelDataState levelData = new LevelDataState();

            if (_isFileExist.Execute(filePath))
            {
                string fileContent = _loadFromFile.Execute(filePath);
                levelData.Value = JsonUtility.FromJson<LevelStateModel>(fileContent);
            }
            else
            {
                levelData.Value = new LevelStateModel(_saveId, GeneratePlayers());
            }

            _loadSceneWithBind.Execute(
                GameScenes.Battleground,
                LoadSceneMode.Additive,
                    container =>
                    {
                        container
                            .Bind<ILevelDataState>()
                            .To<LevelDataState>()
                            .FromInstance(levelData)
                            .AsSingle();
                    }
                );

            _unloadSceneWithState.Execute(gameObject.scene);

            _isCompleted = true;
        }

        private PlayerDataModel[] GeneratePlayers()
        {
            PlayerDataModel[] result = new PlayerDataModel[_fakes];
            Random random = new Random();

            int userPos = random.Next(0, _fakes);
            int orbiteX = 0;

            for (int i = 0; i < _fakes; i++)
            {
                orbiteX += 20;

                result[i] = new PlayerDataModel(
                                Guid.NewGuid().ToString(),
                                userPos == i ? PlayerType.RealPlayer : PlayerType.Bot,
                                new PlanetDataModel(
                                    (PlanetType)random.Next(1, 6),
                                    new Vector3(i % 2 == 0 ? orbiteX : orbiteX * -1, 0, 0),
                                    Quaternion.identity
                                    )
                                );
            }

            return result;
        }
    }
}