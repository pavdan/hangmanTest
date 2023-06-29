using Hangman.UI.Services.Layout;

namespace Hangman.Infrastructure.States
{
    public class StartWindowState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IUILayout _uiLayout;

        public StartWindowState(GameStateMachine gameStateMachine, IUILayout uiLayout)
        {
            _gameStateMachine = gameStateMachine;
            _uiLayout = uiLayout;
        }

        public void Enter()
        {
            _uiLayout.ShowStartWindow();

            _uiLayout.startWindow.playButtonClicked += OnPlayButtonClicked;
        }

        public void Exit()
        {
            _uiLayout.startWindow.playButtonClicked -= OnPlayButtonClicked;
            
            _uiLayout.HideStartWindow();
        }

        void OnPlayButtonClicked()
        {
            _gameStateMachine.Enter<LoadGameLoopState>();
        }
    }
}