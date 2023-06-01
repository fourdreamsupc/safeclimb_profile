using System.Threading.Tasks;

namespace Go2Climb.API.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}