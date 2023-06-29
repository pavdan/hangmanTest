using Hangman.Config;
using Hangman.Infrastructure.Factory;
using Hangman.Services;
using Hangman.Services.Config;
using Hangman.Services.PersistentProgress;
using Hangman.Services.UIRoot;
using Hangman.UI.Services.Layout;
using Hangman.UI;

namespace Hangman.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly AllServices _services;
        private readonly GameStateMachine _gameStateMachine;

        public BootstrapState(GameStateMachine gameStateMachine, AllServices services,
            ConfigRoot configRoot, Root root)
        {
            _gameStateMachine = gameStateMachine;
            _services = services;

            RegisterServices(configRoot, root);
        }

        public void Enter()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public void Exit()
        {
        }

        private void RegisterServices(ConfigRoot configRoot, Root root)
        {
            var configService = new ConfigService(configRoot);
            _services.RegisterSingle<IConfigService>(configService);
            _services.RegisterSingle<IUIConfigService>(configService);
            _services.RegisterSingle<IUIRootService>(new UIRootService(root));

            _services.RegisterSingle<IGameStateMachine>(_gameStateMachine);
            _services.RegisterSingle<IProgressService>(new ProgressService());

            _services.RegisterSingle<IUILayout>(new UILayout(
                _services.Single<IProgressService>(),
                _services.Single<IUIRootService>(),
                _services.Single<IUIConfigService>()
            ));

            _services.RegisterSingle<IGameFactory>(new GameFactory(
                _services.Single<IConfigService>(),
                _services.Single<IProgressService>(),
                _services.Single<IGameStateMachine>(),
                _services.Single<IUIRootService>()
            ));
        }
    }
}