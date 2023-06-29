using System.Collections.Generic;
using Hangman.Logic;
using UnityEngine;

namespace Hangman.UI.Elements
{
    public class Letters : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;

        private IGuessWord _guessWord;
        private LetterItem[] _letterItems;

        public void Construct(LetterItem letterItemTemplate, IGuessWord guessWord)
        {
            _guessWord = guessWord;

            var letterItems = new List<LetterItem>();

            for (int i = 0; i < _guessWord.length; i++)
            {
                letterItems.Add(Instantiate(letterItemTemplate, _itemsRoot));
            }

            _letterItems = letterItems.ToArray();

            _guessWord.letterUnlocked += OnLetterUnlocked;
        }

        private void OnLetterUnlocked(char letter, int[] positions)
        {
            foreach (int position in positions)
            {
                _letterItems[position].UnlockLetter(letter);
            }
        }

        public void Cleanup()
        {
            _guessWord.letterUnlocked -= OnLetterUnlocked;
            _guessWord = null;

            foreach (Transform child in _itemsRoot)
            {
                Destroy(child.gameObject);
            }
        }
    }
}