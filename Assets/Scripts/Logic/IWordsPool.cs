using System;

namespace Hangman.Logic
{
    public interface IWordsPool
    {
        event Action<string> wordPlayed;
        event Action resetted;
    }
}
