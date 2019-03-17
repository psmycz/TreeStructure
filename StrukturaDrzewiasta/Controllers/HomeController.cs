
using Microsoft.AspNet.Identity;
using StrukturaDrzewiasta.Core.Domain;
using StrukturaDrzewiasta.Persistance;
using StrukturaDrzewiasta.Services;
using StrukturaDrzewiasta.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Security.Claims;
using Microsoft.AspNet.Identity.Owin;

namespace StrukturaDrzewiasta.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DatabaseContext());
        private CategoryService categoryService = new CategoryService();
        private IEnumerable<Category> categories;
        // GET: Home

        [HttpGet]
        public ActionResult Index()
        {

            ViewBag.Title = "Tree Structure Home";

            // tworzy strukture, wczytuje liste obiektow bez rodzicow i zmienia w funkcji na html string
            categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
            var treeStructureHtml = categoryService.PrintStructure(categories);
            ViewBag.HtmlString = new HtmlString(treeStructureHtml);

            return View();
        }

#region ADD

        [HttpGet]
        public ActionResult Add()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }
            var allCategories = new CategoryVM();                                       
            allCategories.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

            categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
            var treeStructureHtml = categoryService.PrintStructure(categories);
            ViewBag.HtmlString = new HtmlString(treeStructureHtml);
            
            return View(allCategories);                                                  
        }

        [HttpPost]
        public ActionResult Add(CategoryVM categoryVM)
        {
            if (!ModelState.IsValidField("Name")) {
                categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");
                
                categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                var treeStructureHtml = categoryService.PrintStructure(categories);
                ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                return View(categoryVM);
            }
            else  // sprawdza czy wystapila juz taka nazwa bez uwzgledniania wielkosci liter
            {
                IEnumerable<Category> all = unitOfWork.Categories.GetAll();
                foreach (var cat in all)
                {
                    if (categoryVM.Name.ToLower() == cat.Name.ToLower())
                    { 
                        categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                        categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                        var treeStructureHtml = categoryService.PrintStructure(categories);
                        ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                        ModelState.AddModelError("", "Catalog with exact name already exist.");

                        return View(categoryVM);
                    }
                }
            }

            categoryService.AddCategory(categoryVM.Name, categoryVM.ParentId, unitOfWork);
            TempData["Success"] = "You successfully added new category";

            return RedirectToAction("Index");
            
        }

        #endregion

#region REMOVE
        [HttpGet]
        public ActionResult Remove()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }
            var allCategories = new CategoryVM();
            allCategories.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

            categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
            var treeStructureHtml = categoryService.PrintStructure(categories);
            ViewBag.HtmlString = new HtmlString(treeStructureHtml);


            return View(allCategories);
        }

        [HttpPost]
        public ActionResult Remove(CategoryVM categoryVM)
        {
            if (categoryVM.ParentId == 0)
            {
                if (!ModelState.IsValid)
                {
                    categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                    categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                    var treeStructureHtml = categoryService.PrintStructure(categories);
                    ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                    ModelState.AddModelError("", "Choose category to remove.");

                    return View(categoryVM);
                }
            }
            categoryService.RemoveCategory(categoryVM.ParentId, unitOfWork);
            TempData["Success"] = "You successfully removed category";

            return RedirectToAction("Index");

        }
        #endregion

#region EDIT
        [HttpGet]
        public ActionResult Edit()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }
            var allCategories = new CategoryVM();
            allCategories.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

            categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
            var treeStructureHtml = categoryService.PrintStructure(categories);
            ViewBag.HtmlString = new HtmlString(treeStructureHtml);

            return View(allCategories);
        }

        [HttpPost]
        public ActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                var treeStructureHtml = categoryService.PrintStructure(categories);
                ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                return View(categoryVM);
            }
            else  // sprawdza czy wystapila juz taka nazwa bez uwzgledniania wielkosci liter
            {
                IEnumerable<Category> all = unitOfWork.Categories.GetAll();
                foreach (var cat in all)
                {
                    if (categoryVM.Name.ToLower() == cat.Name.ToLower())
                    {
                        categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                        categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                        var treeStructureHtml = categoryService.PrintStructure(categories);
                        ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                        ModelState.AddModelError("", "Catalog with exact name already exist.");

                        return View(categoryVM);
                    }
                }
            }
            categoryService.EditCategory(categoryVM.Name, categoryVM.ParentId, unitOfWork);
            TempData["Success"] = "You successfully edited category";

            return RedirectToAction("Index");

        }
        #endregion

#region MOVE
        [HttpGet]
        public ActionResult Move()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }
            var allCategories = new CategoryVM();
            allCategories.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

            categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
            var treeStructureHtml = categoryService.PrintStructure(categories);
            ViewBag.HtmlString = new HtmlString(treeStructureHtml);

            return View(allCategories);
        }

        [HttpPost]
        public ActionResult Move(CategoryVM categoryVM)
        {
            if (!ModelState.IsValidField("CurrentCategoryId"))
            {
                categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                var treeStructureHtml = categoryService.PrintStructure(categories);
                ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                return View(categoryVM);
            }
            else
            {
                Category destinationCat = unitOfWork.Categories.Get(categoryVM.ParentId);
                Category currentCat = unitOfWork.Categories.Get(categoryVM.CurrentCategoryId);
                bool flag = false;

                void find(Category parentCategory) {                                // funkcja przeszukuje podkatalogi
                    foreach (Category cat in parentCategory.Subcategories)
                    {
                        if (cat == destinationCat || destinationCat == currentCat)
                        { 
                            flag = true;
                            break;
                        }
                        if (cat.Subcategories.Count != 0)
                            find(cat);
                    }
                }
                find(currentCat);
                if (flag)
                {
                    categoryVM.ParentArtibutes = new SelectList(unitOfWork.Categories.GetAll(), "Id", "Name");

                    categories = unitOfWork.Categories.Find(c => c.ParentCategoryId == null);
                    var treeStructureHtml = categoryService.PrintStructure(categories);
                    ViewBag.HtmlString = new HtmlString(treeStructureHtml);

                    ModelState.AddModelError("", "Cannot move this category to one of it's subcategories.");

                    return View(categoryVM);
                }

            }
            categoryService.MoveCategory(categoryVM.CurrentCategoryId, categoryVM.ParentId, unitOfWork);

            TempData["Success"] = "You successfully moved category";

            return RedirectToAction("Index");

        }
        #endregion

#region REGISTER

        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(UserVM userVM)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = userVM.UserName,
                    Email = userVM.Email,
                    FirstName = userVM.FirstName,
                    LastName = userVM.LastName
                };

                IdentityResult result = await HttpContext.GetOwinContext().GetUserManager<AccountManager>().CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    TempData["Success"] = "You successfully registered a new user";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(userVM);
        }

        #endregion

#region LOGIN

        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("ErrorPage");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                User user = await HttpContext.GetOwinContext()
                                            .GetUserManager<AccountManager>()
                                            .FindAsync(loginVM.UserName, loginVM.Password);

                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid name or password.");
                }
                else
                {
                    ClaimsIdentity identity = await HttpContext.GetOwinContext()
                                                                .GetUserManager<AccountManager>()
                                                                .CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    HttpContext.GetOwinContext()
                                .Authentication
                                .SignOut();
                    HttpContext.GetOwinContext()
                                .Authentication
                                .SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                    TempData["Success"] = "You successfully logged in";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginVM);
        }

        #endregion

#region LOGOUT

        [Authorize]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext()
                                .Authentication
                                .SignOut();

            TempData["Success"] = "You successfully logged out";
            return RedirectToAction("Index", "Home");
        }

        #endregion

        // GET: Home
        public ActionResult About()
        {
            ViewBag.Title = "About";

            return View();
        }

    } 
}