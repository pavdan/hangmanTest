using Hangman.UI;

namespace Hangman.Services.UIRoot
{
    public interface IUIRootService : IService
    {
        Root root { get; }
    }
}