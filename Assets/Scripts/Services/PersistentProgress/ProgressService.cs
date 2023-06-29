using Hangman.Data;

namespace Hangman.Services.PersistentProgress
{
    public class ProgressService : IProgressService
    {
        public GameProgress progress { get; set; }
    }
}