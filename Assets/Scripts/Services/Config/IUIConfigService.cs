using Hangman.Config;

namespace Hangman.Services.Config
{
    public interface IUIConfigService : IService
    {
        PrefabsConfig prefabsConfig { get; }
        TextsConfig textsConfig { get; }
    }
}