using StrukturaDrzewiasta.Core.Repositories;
using System;


namespace StrukturaDrzewiasta.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
