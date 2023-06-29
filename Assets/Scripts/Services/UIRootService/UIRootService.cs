using Hangman.UI;

namespace Hangman.Services.UIRoot
{
    public class UIRootService : IUIRootService
    {
        public UIRootService(Root root)
        {
            this.root = root;
        }

        public Root root { get; }
    }
}