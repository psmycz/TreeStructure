using StrukturaDrzewiasta.Core;
using StrukturaDrzewiasta.Core.Repositories;
using StrukturaDrzewiasta.Persistance.Repositories;

namespace StrukturaDrzewiasta.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public UnitOfWork(DatabaseContext context)
        {
            this._context = context;

            Categories = new CategoryRepository(this._context);

        }
        public ICategoryRepository Categories { get; }

        public int Complete()
        {
            return this._context.SaveChanges();
        }

        public void Dispose()
        {
            this._context.Dispose();
        }
    }
}