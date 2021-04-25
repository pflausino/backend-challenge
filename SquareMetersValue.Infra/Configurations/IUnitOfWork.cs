using System;
using System.Threading.Tasks;

namespace SquareMetersValue.Infra.Configurations
{

    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
