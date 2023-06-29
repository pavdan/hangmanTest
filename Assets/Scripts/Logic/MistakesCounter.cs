using System;

namespace Hangman.Logic
{
    [Serializable]
    public class MistakesCounter : IMistakes
    {
        public event Action<int> mistakeDone;
        public event Action limitReached;

        private readonly int _mistakesLimit;
        private int _mistakesQuantity;

        public MistakesCounter(int mistakesLimit)
        {
            _mistakesLimit = mistakesLimit;
        }

        public void Add()
        {
            _mistakesQuantity++;
            mistakeDone?.Invoke(_mistakesQuantity);

            if (_mistakesQuantity > _mistakesLimit)
            {
                limitReached?.Invoke();
            }
        }

        public void Cleanup()
        {
            _mistakesQuantity = 0;
        }
    }
}