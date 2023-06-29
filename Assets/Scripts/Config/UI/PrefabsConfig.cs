using Hangman.UI.Elements;
using UnityEngine;

namespace Hangman.Config
{
    [CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Config/Prefabs")]
    public class PrefabsConfig : ScriptableObject
    {
        public LetterItem letterItemPrefab;
        public KeyboardItem keyboardItemPrefab;
    }
}