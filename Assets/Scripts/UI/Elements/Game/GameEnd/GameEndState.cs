using System;
using Hangman.Services.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI.Elements
{
    public class GameEndState : MonoBehaviour
    {
        public event Action playAgainButtonClicked;

        [SerializeField] private Button _playAgainButton;
        [SerializeField] private Text _playAgainButtonText;
        [SerializeField] private Text _resultText;

        public void Construct(IUIConfigService uiConfigService, bool won)
        {
            _playAgainButtonText.text = uiConfigService.textsConfig.playAgainButtonText;
            _resultText.text = won
                ? uiConfigService.textsConfig.winText
                : uiConfigService.textsConfig.loseText;

            _playAgainButton.onClick.AddListener(OnPlayAgainButtonClicked);
        }

        public void Cleanup()
        {
            _playAgainButton.onClick.RemoveListener(OnPlayAgainButtonClicked);
        }

        private void OnPlayAgainButtonClicked()
        {
            playAgainButtonClicked?.Invoke();
        }
    }
}