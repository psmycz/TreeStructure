using System;
using System.Collections.Generic;
using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.Persistance;

namespace StrukturaDrzewiasta.Services
{
    public class CategoryService : ICategoryService
    {
        private string result = "";

        public void AddCategory(string _Name, int _ParentId, UnitOfWork unitOfWork)
        {
            Category newCategory = new Category();
            if (_ParentId > 0) { 
                Category parentCategory = unitOfWork.Categories.Get(_ParentId);

                newCategory.Name = _Name;
                newCategory.ParentCategoryId = parentCategory.Id;
                newCategory.ParentCategory = parentCategory;
            }
            else
            {
                newCategory.Name = _Name;
            }
            unitOfWork.Categories.Add(newCategory);
            unitOfWork.Complete();
        }

        public void RemoveCategory(int CategoryId, UnitOfWork unitOfWork)
        {
            Category category = unitOfWork.Categories.Get(CategoryId);
            if(category.Subcategories.Count != 0)
            {
                unitOfWork.Categories.RemoveRange(category.Subcategories);
            }
            unitOfWork.Categories.Remove(category);
            unitOfWork.Complete();
        }

        public void EditCategory(string _Name, int _CategoryId, UnitOfWork unitOfWork)
        {
            Category category = unitOfWork.Categories.Get(_CategoryId);
            category.Name = _Name;
            unitOfWork.Complete();
        }

        //todo: przesuniecie do pustego miejsca
        public void MoveCategory(int categoryId, int destinationId, UnitOfWork unitOfWork)
        {
            Category current = unitOfWork.Categories.Get(categoryId);
            if (destinationId != 0)
            {
                Category destination = unitOfWork.Categories.Get(destinationId);

                if (current.ParentCategory != null)
                    current.ParentCategory.Subcategories.Remove(current);
                current.ParentCategory = destination;
                current.ParentCategoryId = destinationId;
                destination.Subcategories.Add(current);
            }
            else
            {
                if (current.ParentCategory != null)
                    current.ParentCategory.Subcategories.Remove(current);
                current.ParentCategory = null;
                current.ParentCategoryId = null;
            }
            unitOfWork.Complete();
        }

        public string PrintStructure(IEnumerable<Category> categories)
        {
            if (result == "")
                result += "<ul id='myUL'>";
            else
                result += "<ul class='nested'>";
            foreach (var cat in categories)
            {
                if (cat.Subcategories.Count == 0)
                    result += "<li>" + cat.Name + "</li>";
                else if (cat.Subcategories.Count != 0)
                {
                    result += "<li><span class='box'>" + cat.Name + "</span>";
                    PrintStructure(cat.Subcategories);
                }
            }
            result += "</ul>";
            return result;
        }


    }
}

