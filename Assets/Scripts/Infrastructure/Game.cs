using Hangman.Config;
using Hangman.Infrastructure.States;
using Hangman.Services;

namespace Hangman.Infrastructure
{
    public class Game
    {
        public GameStateMachine stateMachine;

        public Game(ICoroutineRunner coroutineRunner,
            ConfigRoot configRoot, UI.Root uiRoot)
        {
            stateMachine = new GameStateMachine(AllServices.Container,
                configRoot, uiRoot);
        }
    }
}