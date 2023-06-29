using Hangman.Infrastructure.Factory;
using Hangman.Logic;
using Hangman.Services.Config;
using Hangman.Services.PersistentProgress;
using Hangman.UI.Services.Layout;

namespace Hangman.Infrastructure.States
{
    public class LoadGameLoopState : IState
    {
        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly IProgressService _progressService;

        public LoadGameLoopState(GameStateMachine gameStateMachine, IGameFactory gameFactory,
            IProgressService progressService)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter()
        {
            GameLoop gameLoop = _gameFactory.CreateGameLoop();
            _progressService.progress.gameLoopData = gameLoop;

            _gameStateMachine.Enter<GameLoopState, GameLoop>(gameLoop);
        }

        public void Exit()
        {
        }
    }
}
