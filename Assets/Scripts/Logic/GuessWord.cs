using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.Logic
{
    [Serializable]
    public class GuessWord : IGuessWord
    {
        private readonly string _word;
        private readonly int _uniqueLetterQty;
        private List<char> _unlockedLetters;

        public event Action<char, int[]> letterUnlocked;
        public event Action guessFailed;
        public event Action wordUnlocked;

        public GuessWord(string word)
        {
            _word = word;
            _uniqueLetterQty = _word.Distinct().Count();
            _unlockedLetters = new List<char>();
        }

        public int length => _word.Length;

        public void GuessLetter(char letter)
        {
            if (_unlockedLetters.Contains(letter))
            {
                return;
            }

            List<int> foundIndexes = SearchLetterIndexes(letter);

            if (foundIndexes.Count == 0)
            {
                guessFailed?.Invoke();
                return;
            }

            _unlockedLetters.Add(letter);
            letterUnlocked?.Invoke(letter, foundIndexes.ToArray());

            if (_unlockedLetters.Count == _uniqueLetterQty)
            {
                wordUnlocked?.Invoke();
            }
        }

        private List<int> SearchLetterIndexes(char letter)
        {
            var result = new List<int>();

            for (int i = _word.IndexOf(letter); i > -1; i = _word.IndexOf(letter, i + 1)) result.Add(i);

            return result;
        }
    }
}