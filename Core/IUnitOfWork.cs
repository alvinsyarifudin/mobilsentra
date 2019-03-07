using System.Threading.Tasks;

namespace mobilsentra.Core
{
    public interface IUnitOfWork
    {
        Task Complete();
    }
}