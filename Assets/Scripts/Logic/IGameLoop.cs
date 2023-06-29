using System;

namespace Hangman.Logic
{
    public interface IGameLoop
    {
        event Action<bool> ended;

        IGuessWord guessWord { get; }
        IMistakes mistakes { get; }
        IWordsPool wordsPool { get; }
    }
}