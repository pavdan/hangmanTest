using Hangman.Infrastructure.States;
using Hangman.Logic;
using Hangman.Services.Config;
using Hangman.Services.PersistentProgress;
using Hangman.Services.UIRoot;

namespace Hangman.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IConfigService _config;
        private readonly IProgressService _progressService;
        private readonly IGameStateMachine _stateMachine;
        private readonly IUIRootService _uiRootService;

        public GameFactory(
            IConfigService config,
            IProgressService progressService,
            IGameStateMachine stateMachine,
            IUIRootService uiRootService)
        {
            _config = config;
            _progressService = progressService;
            _stateMachine = stateMachine;
            _uiRootService = uiRootService;
        }
        public GameLoop CreateGameLoop()
        {
            return new GameLoop(
                CreateWordsPool(),
                CreateMistakesCounter()
            );
        }

        private WordsPool CreateWordsPool()
        {
            return new WordsPool(_config.words, _progressService.progress.playedWords.ToArray());
        }

        private MistakesCounter CreateMistakesCounter()
        {
            return new MistakesCounter(_config.mistakesLimit);
        }
    }
}