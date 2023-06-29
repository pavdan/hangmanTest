using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman.Logic
{
    [Serializable]
    public class WordsPool : IWordsPool
    {
        public event Action<string> wordPlayed;
        public event Action resetted;

        private readonly string[] _allWords;
        private readonly Random _random;
        private readonly List<string> _unplayedWords;

        public WordsPool(string[] allWords, string[] playedWords)
        {
            _allWords = allWords;
            _unplayedWords = new List<string>();

            foreach (string word in _allWords)
            {
                if (!playedWords.Contains(word))
                {
                    _unplayedWords.Add(word);
                }
            }

            _random = new Random();
        }

        public string PopRandomUnusedWord()
        {
            if (_unplayedWords.Count == 0)
            {
                Reset();
            }

            int index = _random.Next(_unplayedWords.Count);
            string word = _unplayedWords[index];
            
            _unplayedWords.RemoveAt(index);
            wordPlayed?.Invoke(word);
            
            return word;
        }

        private void Reset()
        {
            _unplayedWords.AddRange(_allWords);
            resetted?.Invoke();
        }
    }
}