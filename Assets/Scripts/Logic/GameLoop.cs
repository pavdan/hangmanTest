using System;
using Hangman.Logic.States;
using Hangman.Services;

namespace Hangman.Logic
{
    [Serializable]
    public class GameLoop : IGameLoop
    {
        public event Action<bool> ended;
        
        public GameLoopStateMachine stateMachine;
        public IMistakes mistakes => _mistakesCounter;
        public IWordsPool wordsPool => _wordsPool;
        public IGuessWord guessWord => _guessWord;

        private readonly WordsPool _wordsPool;
        private readonly MistakesCounter _mistakesCounter;
        
        private GuessWord _guessWord;

        public GameLoop(WordsPool wordsPool, MistakesCounter mistakesCounter)
        {
            stateMachine = new GameLoopStateMachine(AllServices.Container, this);
            _wordsPool = wordsPool;
            _mistakesCounter = mistakesCounter;
        }

        public void StartNewLoop()
        {
            _mistakesCounter.Cleanup();
            
            _guessWord = new GuessWord(_wordsPool.PopRandomUnusedWord());
            _guessWord.guessFailed += OnGuessFailed;
        }

        private void OnGuessFailed()
        {
            _mistakesCounter.Add();
        }

        public void Guess(char letter)
        {
            _guessWord.GuessLetter(letter);
        }

        public void End(bool won)
        {
            ended?.Invoke(won);

            _guessWord.guessFailed -= OnGuessFailed;
        }
    }
}