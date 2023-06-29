using UnityEngine;

namespace Hangman.Config
{
    [CreateAssetMenu(fileName = "ConfigRoot", menuName = "Config/Root")]
    public class ConfigRoot : ScriptableObject
    {
        public char[] letters;
        public string[] words;
        public int mistakesLimit;
        public UIConfig uiConfig;
    }
}