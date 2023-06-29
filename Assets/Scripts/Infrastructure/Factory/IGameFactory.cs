using System.Threading.Tasks;
using Hangman.Logic;
using Hangman.Services;

namespace Hangman.Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameLoop CreateGameLoop();
    }
}