using Hangman.Logic;
using Hangman.Logic.States;
using Hangman.Services.PersistentProgress;
using Hangman.UI.Services.Layout;

namespace Hangman.Infrastructure.States
{
    public class GameLoopState : IPayloadedState<GameLoop>
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;
        private readonly IUILayout _uiLayout;

        public GameLoopState(GameStateMachine gameStateMachine, IProgressService progressService, IUILayout uiLayout)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _uiLayout = uiLayout;
        }

        public void Enter(GameLoop gameLoop)
        {
            _progressService.progress.gameLoopData.wordsPool.resetted += OnWordPoolResetted;
            _progressService.progress.gameLoopData.wordsPool.wordPlayed += OnWordPlayed;
            _progressService.progress.gameLoopData.ended += OnGameLoopEnded;

            _uiLayout.ShowGameWindow();

            gameLoop.stateMachine.Enter<GuessState>();
        }

        public void Exit()
        {
            _progressService.progress.gameLoopData.ended -= OnGameLoopEnded;
            _progressService.progress.gameLoopData.wordsPool.wordPlayed -= OnWordPlayed;
            _progressService.progress.gameLoopData.wordsPool.resetted -= OnWordPoolResetted;
        }

        void OnWordPoolResetted()
        {
            _progressService.progress.playedWords.Clear();
        }

        void OnWordPlayed(string word)
        {
            _progressService.progress.playedWords.Add(word);
        }

        void OnGameLoopEnded(bool won)
        {
            if (won)
            {
                _progressService.progress.winData.Won();
            }
            else
            {
                _progressService.progress.winData.Lost();
            }
        }
    }
}