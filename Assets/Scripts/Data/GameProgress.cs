using System;
using System.Collections.Generic;
using Hangman.Logic;

namespace Hangman.Data
{
    [Serializable]
    public class GameProgress
    {
        public WinData winData;
        public List<string> playedWords;
        public IGameLoop gameLoopData;

        public GameProgress()
        {
            winData = new WinData();
            playedWords = new List<string>();
        }
    }
}