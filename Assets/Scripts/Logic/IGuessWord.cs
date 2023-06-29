using System;

namespace Hangman.Logic
{
    public interface IGuessWord
    {
        int length { get; }
        event Action<char, int[]> letterUnlocked;
        event Action wordUnlocked;
    }
}