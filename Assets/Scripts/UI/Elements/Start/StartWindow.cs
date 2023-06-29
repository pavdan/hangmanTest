using System;
using Hangman.Services.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI
{
    public class StartWindow : WindowBase
    {
        [SerializeField] private Button _playButton;
        [SerializeField] private Text _playButtonText;
        [SerializeField] private Text _rulesText;
        public event Action playButtonClicked;

        public void Construct(IUIConfigService uiConfigService)
        {
            _playButtonText.text = uiConfigService.textsConfig.playButtonText;
            _rulesText.text = uiConfigService.textsConfig.rules;

            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        public void Cleanup()
        {
            _playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            playButtonClicked?.Invoke();
        }
    }
}