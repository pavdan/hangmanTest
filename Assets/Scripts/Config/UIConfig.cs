using UnityEngine;

namespace Hangman.Config
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Config/UI")]
    public class UIConfig : ScriptableObject
    {
        public PrefabsConfig prefabsConfig;
        public TextsConfig textsConfig;
    }
}