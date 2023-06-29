using System;
using Hangman.Services.Config;
using UnityEngine;

namespace Hangman.UI.Elements
{
    public class GameGuessState : MonoBehaviour
    {
        public event Action<char> keyboardClicked;

        [SerializeField] private Keyboard _keyboard;

        public void Construct(IUIConfigService uiConfigService, char[] letters)
        {
            _keyboard.Construct(uiConfigService.prefabsConfig.keyboardItemPrefab, letters);

            _keyboard.clicked += OnKeyboardClicked;
        }

        public void Cleanup()
        {
            _keyboard.clicked -= OnKeyboardClicked;
            
            _keyboard.Cleanup();
        }

        public void OnKeyboardClicked(char letter)
        {
            keyboardClicked?.Invoke(letter);
        }
    }
}