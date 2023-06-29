using Hangman.Services.Config;
using Hangman.Services.PersistentProgress;
using Hangman.Services.UIRoot;
using Hangman.UI.Elements;

namespace Hangman.UI.Services.Layout
{
    public class UILayout : IUILayout
    {
        public StartWindow startWindow => _uiRootService.root.startStateWindow;
        public GameWindow gameWindow => _uiRootService.root.gameStateWindow;
        public GameGuessState gameGuessState => gameWindow.gameGuessState;
        public GameEndState gameEndState => gameWindow.gameEndState;

        private readonly IProgressService _progressService;
        private readonly IUIRootService _uiRootService;
        private readonly IUIConfigService _uiConfigService;

        public UILayout(IProgressService progressService, IUIRootService uiRootService,
            IUIConfigService uiConfigService)
        {
            _progressService = progressService;
            _uiRootService = uiRootService;
            _uiConfigService = uiConfigService;

            _uiRootService.root.Construct(uiConfigService);
        }

        public void ShowStartWindow()
        {
            startWindow.Construct(_uiConfigService);
            _uiRootService.root.SwitchToStartState();
        }

        public void HideStartWindow()
        {
            startWindow.Cleanup();
        }

        public void ShowGameWindow()
        {
            gameWindow.Construct(_progressService, _uiConfigService);
            _uiRootService.root.SwitchToGameState();
        }

        public void ShowGameGuessState(char[] letters)
        {
            gameGuessState.Construct(_uiConfigService, letters);
            gameWindow.SwitchToGuessState();
        }

        public void ShowGameEndState(bool won)
        {
            gameEndState.Construct(_uiConfigService, won);
            gameWindow.SwitchToGameEndState();
        }
    }
}
