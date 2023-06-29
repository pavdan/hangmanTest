using Hangman.Logic;
using UnityEngine;

namespace Hangman.UI.Elements
{
    public class HangmanParts : MonoBehaviour
    {
        [SerializeField] private GameObject[] _hangmanParts;
        
        private IMistakes _mistakes;

        public void Construct(IMistakes mistakes)
        {
            _mistakes = mistakes;
            
            foreach (GameObject hangmanPart in _hangmanParts)
            {
                hangmanPart.SetActive(false);
            }

            _mistakes.mistakeDone += OnMistakeDone;
        }

        public void Cleanup()
        {
            _mistakes.mistakeDone -= OnMistakeDone;
        }

        void OnMistakeDone(int mistakeNumber)
        {
            ShowPart(mistakeNumber);
        }

        void ShowPart(int partNumber)
        {
            _hangmanParts[partNumber - 1].SetActive(true);
        }
    }
}