using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.Persistance;
using System;
using System.Collections.Generic;

namespace StrukturaDrzewiasta.Services
{
    public interface ICategoryService
    {
        String PrintStructure(IEnumerable<Category> categories);
        void AddCategory(string name, int parentId, UnitOfWork unitOfWork);
        void RemoveCategory(int categoryId, UnitOfWork unitOfWork);
        void EditCategory(string name, int categoryId, UnitOfWork unitOfWork);
        void MoveCategory(int categoryId, int destinationId, UnitOfWork unitOfWork);
    }
}
