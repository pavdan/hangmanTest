using Hangman.Config;
using Hangman.Data;
using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI.Elements
{
    public class WinCounter : MonoBehaviour
    {
        [SerializeField] private Text _winCounterText;

        private WinData _winData;
        private TextsConfig _textsConfig;

        public void Construct(TextsConfig textsConfig, WinData winData)
        {
            _textsConfig = textsConfig;
            _winData = winData;
            _winData.changed += UpdateCounter;

            UpdateCounter();
        }

        public void Cleanup()
        {
            _winData.changed -= UpdateCounter;
        }

        private void UpdateCounter()
        {
            _winCounterText.text = string.Format(
                _textsConfig.winCounterTemplate,
                _winData.wins.ToString(),
                _winData.loses.ToString()
            );
        }
    }
}
