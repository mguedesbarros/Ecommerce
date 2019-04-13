using System;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Data.Context.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
        void BeginTransaction();
    }
}
