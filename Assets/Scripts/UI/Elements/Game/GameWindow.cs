using System;
using Hangman.Services.Config;
using Hangman.Services.PersistentProgress;
using Hangman.UI.Elements;
using UnityEngine;

namespace Hangman.UI
{
    public class GameWindow : WindowBase
    {
        public GameGuessState gameGuessState => _gameGuessState;
        public GameEndState gameEndState => _gameEndState;

        [SerializeField] private GameGuessState _gameGuessState;
        [SerializeField] private GameEndState _gameEndState;

        [SerializeField] private Letters _letters;
        [SerializeField] private HangmanParts _hangmanParts;
        [SerializeField] private WinCounter _winCounter;

        private IProgressService _progressService;
        private IUIConfigService _uiConfigService;

        public void Construct(IProgressService progressService, IUIConfigService uiConfigService)
        {
            _progressService = progressService;
            _uiConfigService = uiConfigService;
        }

        public void ConstructGame()
        {
            _hangmanParts.Construct(_progressService.progress.gameLoopData.mistakes);

            _letters.Construct(
                _uiConfigService.prefabsConfig.letterItemPrefab,
                _progressService.progress.gameLoopData.guessWord
            );

            _winCounter.Construct(_uiConfigService.textsConfig, _progressService.progress.winData);
        }

        public void SwitchToGuessState()
        {
            _gameGuessState.gameObject.SetActive(true);
            _gameEndState.gameObject.SetActive(false);
        }

        public void SwitchToGameEndState()
        {
            _gameGuessState.gameObject.SetActive(false);
            _gameEndState.gameObject.SetActive(true);
        }

        public void Cleanup()
        {
            _gameEndState.Cleanup();
            _gameGuessState.Cleanup();

            _hangmanParts.Cleanup();
            _letters.Cleanup();
            _winCounter.Cleanup();

            _gameGuessState.gameObject.SetActive(false);
            _gameEndState.gameObject.SetActive(false);
        }
    }
}
