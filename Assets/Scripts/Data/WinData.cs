using System;

namespace Hangman.Data
{
    [Serializable]
    public class WinData
    {
        public int wins { get; private set; }
        public int loses { get; private set; }

        public event Action changed;

        public void Won()
        {
            wins++;

            changed?.Invoke();
        }

        public void Lost()
        {
            loses++;

            changed?.Invoke();
        }
    }
}