using Hangman.Services.Config;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI
{
    public class Root : MonoBehaviour
    {
        public StartWindow startStateWindow => _startStateWindow;
        public GameWindow gameStateWindow => _gameStateWindow;

        [SerializeField] private Text _title;
        [SerializeField] private StartWindow _startStateWindow;
        [SerializeField] private GameWindow _gameStateWindow;

        public void Construct(IUIConfigService uiConfig)
        {
            _title.text = uiConfig.textsConfig.title;

            _startStateWindow.gameObject.SetActive(false);
            _gameStateWindow.gameObject.SetActive(false);
        }

        public void SwitchToStartState()
        {
            _startStateWindow.gameObject.SetActive(true);
            _gameStateWindow.gameObject.SetActive(false);
        }

        public void SwitchToGameState()
        {
            _startStateWindow.gameObject.SetActive(false);
            _gameStateWindow.gameObject.SetActive(true);
        }
    }
}