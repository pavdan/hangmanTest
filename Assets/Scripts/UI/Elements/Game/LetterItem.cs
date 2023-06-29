using UnityEngine;
using UnityEngine.UI;

namespace Hangman.UI.Elements
{
    public class LetterItem : MonoBehaviour
    {
        [SerializeField] private Text _letter;

        public void UnlockLetter(char letter)
        {
            _letter.text = letter.ToString();
        }
    }
}