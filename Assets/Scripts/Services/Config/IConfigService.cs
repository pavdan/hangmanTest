namespace Hangman.Services.Config
{
    public interface IConfigService : IService
    {
        char[] letters { get; }
        string[] words { get; }
        int mistakesLimit { get; }
    }
}