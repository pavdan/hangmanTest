using System;
using System.Collections.Generic;
using Hangman.Config;
using Hangman.Infrastructure.Factory;
using Hangman.Services;
using Hangman.Services.PersistentProgress;
using Hangman.UI.Services.Layout;
using Hangman.UI;

namespace Hangman.Infrastructure.States
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(AllServices services, ConfigRoot configRoot, Root uiRoot)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(
                    this,
                    services,
                    configRoot,
                    uiRoot
                ),
                [typeof(LoadGameLoopState)] = new LoadGameLoopState(
                    this,
                    services.Single<IGameFactory>(),
                    services.Single<IProgressService>()
                ),
                [typeof(StartWindowState)] = new StartWindowState(this, services.Single<IUILayout>()),

                [typeof(LoadProgressState)] = new LoadProgressState(
                    this,
                    services.Single<IProgressService>()
                ),
                [typeof(GameLoopState)] = new GameLoopState(
                    this,
                    services.Single<IProgressService>(),
                    services.Single<IUILayout>()
                )
            };
        }

        public void Enter<TState>()
            where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload)
            where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }

        private TState ChangeState<TState>()
            where TState : class, IExitableState
        {
            _activeState?.Exit();

            var state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>()
            where TState : class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}
