﻿using UnityEngine.SceneManagement;
using Zenject;

namespace Orbitality.Client.Runtime
{
    public sealed class ShowMenu : Instruction
    {
        [Inject] private readonly ILoadScene _loadScene = default;

        public override void Execute()
        {
            _loadScene.Execute(GameScenes.Menu, LoadSceneMode.Additive);
        }
    }
}