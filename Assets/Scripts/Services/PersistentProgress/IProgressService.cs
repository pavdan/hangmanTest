using Hangman.Data;

namespace Hangman.Services.PersistentProgress
{
    public interface IProgressService : IService
    {
        GameProgress progress { get; set; }
    }
}