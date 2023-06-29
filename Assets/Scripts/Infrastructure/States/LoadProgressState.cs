using Hangman.Data;
using Hangman.Services.PersistentProgress;

namespace Hangman.Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IProgressService _progressService;

        public LoadProgressState(GameStateMachine gameStateMachine, IProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
        }

        public void Enter()
        {
            InitProgress();

            _gameStateMachine.Enter<StartWindowState>();
        }

        public void Exit()
        {
        }

        private void InitProgress()
        {
            _progressService.progress = NewProgress();
        }

        private GameProgress NewProgress()
        {
            return new GameProgress();
        }
    }
}