using Hangman.Services.Config;
using Hangman.UI.Services.Layout;

namespace Hangman.Logic.States
{
    public class GuessState : IState
    {
        private readonly IConfigService _config;
        private readonly GameLoopStateMachine _gameLoopStateMachine;
        private readonly IUILayout _uiLayout;
        private readonly GameLoop _gameLoop;

        public GuessState(GameLoopStateMachine gameLoopStateMachine, IConfigService configService, IUILayout uiLayout,
            GameLoop gameLoop)
        {
            _gameLoopStateMachine = gameLoopStateMachine;
            _config = configService;
            _uiLayout = uiLayout;
            _gameLoop = gameLoop;
        }

        public void Enter()
        {
            _gameLoop.StartNewLoop();
            _uiLayout.ShowGameGuessState(_config.letters);
            _uiLayout.gameWindow.ConstructGame();

            _gameLoop.mistakes.limitReached += OnMistakesLimitReached;
            _gameLoop.guessWord.wordUnlocked += OnWordUnlocked;
            _uiLayout.gameGuessState.keyboardClicked += OnkeyboardClicked;
        }

        public void Exit()
        {
            _uiLayout.gameGuessState.keyboardClicked -= OnkeyboardClicked;
            _gameLoop.guessWord.wordUnlocked -= OnWordUnlocked;
            _gameLoop.mistakes.limitReached -= OnMistakesLimitReached;
        }

        void OnkeyboardClicked(char letter)
        {
            _gameLoop.Guess(letter);
        }

        void OnMistakesLimitReached()
        {
            _gameLoop.End(false);
            _gameLoopStateMachine.Enter<GameEndState, bool>(false);
        }

        void OnWordUnlocked()
        {
            _gameLoop.End(true);
            _gameLoopStateMachine.Enter<GameEndState, bool>(true);
        }
    }
}
