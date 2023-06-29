using UnityEngine;

namespace Hangman.Config
{
    [CreateAssetMenu(fileName = "TextsConfig", menuName = "Config/Texts")]
    public class TextsConfig : ScriptableObject
    {
        public string title;
        public string winCounterTemplate;
        public string winText;
        public string loseText;
        public string playAgainButtonText;
        public string playButtonText;
        [TextArea(1, 10)] public string rules;
    }
}