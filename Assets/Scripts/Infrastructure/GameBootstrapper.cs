using Hangman.Config;
using Hangman.Infrastructure.States;
using UnityEngine;

namespace Hangman.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private ConfigRoot _configRoot;
        [SerializeField] private UI.Root _uiRoot;

        private Game _game;

        private void Awake()
        {
            _game = new Game(this, _configRoot, _uiRoot);
            _game.stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}