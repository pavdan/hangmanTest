using System;

namespace Hangman.Logic
{
    public interface IMistakes
    {
        event Action<int> mistakeDone;
        event Action limitReached;
    }
}
