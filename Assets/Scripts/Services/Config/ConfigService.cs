using Hangman.Config;

namespace Hangman.Services.Config
{
    public class ConfigService : IConfigService, IUIConfigService
    {
        private readonly ConfigRoot _configRoot;

        public ConfigService(ConfigRoot configRoot)
        {
            _configRoot = configRoot;
        }

        public char[] letters => _configRoot.letters;
        public string[] words => _configRoot.words;
        public int mistakesLimit => _configRoot.mistakesLimit;
        public PrefabsConfig prefabsConfig => _configRoot.uiConfig.prefabsConfig;
        public TextsConfig textsConfig => _configRoot.uiConfig.textsConfig;
    }
}