using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hangman.UI.Elements
{
    public class Keyboard : MonoBehaviour
    {
        [SerializeField] private Transform _itemsRoot;

        private Dictionary<char, KeyboardItem> _keyboardItems;
        public event Action<char> clicked;

        public void Construct(KeyboardItem keyboardItemTemplate, char[] letters)
        {
            if (_keyboardItems != null)
            {
                return;
            }

            _keyboardItems = new Dictionary<char, KeyboardItem>();

            foreach (char letter in letters)
            {
                KeyboardItem keyboardItem = Instantiate(keyboardItemTemplate, _itemsRoot);
                keyboardItem.Construct(letter);
                _keyboardItems.Add(letter, keyboardItem);
                keyboardItem.clicked += () => OnClicked(letter);
            }
        }

        private void OnClicked(char letter)
        {
            clicked?.Invoke(letter);
            _keyboardItems[letter].Disable();
        }

        public void Cleanup()
        {
            foreach (KeyboardItem keyboardItem in _keyboardItems.Values) keyboardItem.Cleanup();
        }
    }
}