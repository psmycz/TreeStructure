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
            if (_ParentId > 0) {                        // dodawanie do istniejacej kategorii
                Category parentCategory = unitOfWork.Categories.Get(_ParentId);

                newCategory.Name = _Name;
                newCategory.ParentCategoryId = parentCategory.Id;
                newCategory.ParentCategory = parentCategory;
            }
            else                                        // dodawanie do pustej
            {
                newCategory.Name = _Name;
            }
            unitOfWork.Categories.Add(newCategory);
            unitOfWork.Complete();
        }

        public void RemoveCategory(int CategoryId, UnitOfWork unitOfWork)
        {
            Category category = unitOfWork.Categories.Get(CategoryId);
            List<Category> categories = new List<Category>();

            void deleteAll(Category cat) {              // lista podkategorii
                if (cat.Subcategories.Count != 0)
                {
                    foreach (var c in cat.Subcategories)
                    {
                        categories.Add(c);
                        deleteAll(c);
                    }
                }
            }
            deleteAll(category);

            foreach (Category c in categories) unitOfWork.Categories.Remove(c);     // kategorii z podkategoriami
            unitOfWork.Categories.Remove(category);
            unitOfWork.Complete();
        }

        public void EditCategory(string _Name, int _CategoryId, UnitOfWork unitOfWork)
        {
            Category category = unitOfWork.Categories.Get(_CategoryId);
            category.Name = _Name;
            unitOfWork.Complete();
        }

        public void MoveCategory(int categoryId, int destinationId, UnitOfWork unitOfWork)
        {
            Category current = unitOfWork.Categories.Get(categoryId);
            if (destinationId != 0)                                 // przesuwanie do istniejacej kategorii
            {
                Category destination = unitOfWork.Categories.Get(destinationId);

                if (current.ParentCategory != null)
                    current.ParentCategory.Subcategories.Remove(current);
                current.ParentCategory = destination;
                current.ParentCategoryId = destinationId;
                destination.Subcategories.Add(current);
            }
            else                                                    // przesuwanie do pustej
            {
                if (current.ParentCategory != null)
                    current.ParentCategory.Subcategories.Remove(current);
                current.ParentCategory = null;
                current.ParentCategoryId = null;
            }
            unitOfWork.Complete();
        }

        public string PrintStructure(IEnumerable<Category> categories)      // tworzenie stringa ze struktura
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

