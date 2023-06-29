using System;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI.Elements
{
    public class KeyboardItem : MonoBehaviour
    {
        public event Action clicked;

        [SerializeField] private Text _letter;
        [SerializeField] private Button _button;

        public void Construct(char letter)
        {
            _letter.text = letter.ToString();

            _button.onClick.AddListener(OnClick);
        }

        private void OnClick()
        {
            clicked?.Invoke();
        }

        public void Disable()
        {
            _button.interactable = false;
        }

        public void Cleanup()
        {
            _button.interactable = true;
        }
    }
}