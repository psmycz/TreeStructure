using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrukturaDrzewiasta.Persistance.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(DatabaseContext context)
            :base(context)
        { 
        }

        // Repository metods implementation

        public DatabaseContext DatabaseContext => Context as DatabaseContext;
    }
}