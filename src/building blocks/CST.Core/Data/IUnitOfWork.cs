using System.Threading.Tasks;

namespace CST.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}