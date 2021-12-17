using System.Threading.Tasks;
using System.Windows.Input;

namespace EvolutionView.Infrastructure.Interfaces
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}
