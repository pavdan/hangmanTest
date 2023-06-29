using Hangman.Services;
using Hangman.UI.Elements;

namespace Hangman.UI.Services.Layout
{
    public interface IUILayout : IService
    {
        void ShowStartWindow();
        void HideStartWindow();
        void ShowGameWindow();
        void ShowGameGuessState(char[] letters);
        void ShowGameEndState(bool won);
        public StartWindow startWindow { get; }
        public GameWindow gameWindow { get; }
        public GameGuessState gameGuessState { get; }
        public GameEndState gameEndState { get; }
    }
}