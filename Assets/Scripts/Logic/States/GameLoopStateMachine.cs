using System;
using System.Collections.Generic;
using Hangman.Services;
using Hangman.Services.Config;
using Hangman.UI.Services.Layout;

namespace Hangman.Logic.States
{
    public class GameLoopStateMachine : IGameLoopStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameLoopStateMachine(AllServices services, GameLoop gameLoop)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(GuessState)] = new GuessState(
                    this,
                    services.Single<IConfigService>(),
                    services.Single<IUILayout>(),
                    gameLoop
                ),

                [typeof(GameEndState)] = new GameEndState(
                    this,
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
