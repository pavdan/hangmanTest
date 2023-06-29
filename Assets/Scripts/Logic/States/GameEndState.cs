using Hangman.UI.Services.Layout;

namespace Hangman.Logic.States
{
    public class GameEndState : IPayloadedState<bool>
    {
        private readonly GameLoopStateMachine _gameLoopStateMachine;
        private readonly IUILayout _uiLayout;

        public GameEndState(GameLoopStateMachine gameLoopStateMachine,
            IUILayout uiLayout)
        {
            _gameLoopStateMachine = gameLoopStateMachine;
            _uiLayout = uiLayout;
        }

        public void Enter(bool won)
        {
            _uiLayout.ShowGameEndState(won);
            _uiLayout.gameEndState.playAgainButtonClicked += OnPlayAgainButtonClicked;
        }

        public void Exit()
        {
            _uiLayout.gameEndState.playAgainButtonClicked -= OnPlayAgainButtonClicked;
            
            _uiLayout.gameWindow.Cleanup();
        }

        void OnPlayAgainButtonClicked()
        {
            _gameLoopStateMachine.Enter<GuessState>();
        }
    }
}