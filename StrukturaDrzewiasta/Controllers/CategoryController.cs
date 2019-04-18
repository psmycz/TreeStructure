using StrukturaDrzewiasta.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.ViewModels;
using StrukturaDrzewiasta.Services;
using System.Web.Http.Cors;

namespace StrukturaDrzewiasta.Controllers
{
    [EnableCorsAttribute("*","*","*")]
    public class CategoryController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DatabaseContext());
        private CategoryService categoryService = new CategoryService();

        public IHttpActionResult Get()
        {
            List<Category> categories = unitOfWork.Categories.GetAll().ToList();

            return Ok(categories);
        }

        public IHttpActionResult Get(int id)
        {
            Category category = unitOfWork.Categories.SingleOrDefault(s => s.Id == id);
            if (category == null)
            {
                //return NotFound();
                return Content(HttpStatusCode.NotFound, "Category not found");
            }

            return Ok(category);
        }

        public IHttpActionResult Post([FromBody] CategoryVM categoryVM)
        {
        
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (categoryVM.ParentId > 0  && !CategoryService.idExist(categoryVM.ParentId, unitOfWork)) { 
                    ModelState.AddModelError("", "Catalog with provided id doesn't exist.");
                    return BadRequest(ModelState);
                }
                if (!CategoryService.isNameDuplicated(categoryVM.Name, unitOfWork))
                {
                    categoryService.AddCategory(categoryVM.Name, categoryVM.ParentId, unitOfWork);

                    Category category = unitOfWork.Categories.SingleOrDefault(c => c.Name == categoryVM.Name);
                    return CreatedAtRoute("DefaultApi", new { id = category.Id }, category);
                }
                else
                {
                    ModelState.AddModelError("", "Catalog with exact name already exist.");
                    return BadRequest(ModelState);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Delete(int id)
        {
            try
            {
                Category category = unitOfWork.Categories.SingleOrDefault(c => c.Id == id);
                if (category == null)
                {
                    return Content(HttpStatusCode.NotFound, "Category not found");
                }

                categoryService.RemoveCategory(id, unitOfWork);

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(int id, [FromBody]CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Category categoryFromDb = unitOfWork.Categories.SingleOrDefault(c => c.Id == id);
                if (categoryFromDb == null)
                    return NotFound();

                if (!CategoryService.isNameDuplicated(categoryVM.Name, unitOfWork))
                {
                    categoryService.EditCategory(categoryVM.Name, id, unitOfWork);

                    return Ok(categoryFromDb);
                }
                else
                {
                    ModelState.AddModelError("", "Catalog with exact name already exist.");
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
