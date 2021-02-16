using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assigement_MVC.ViewModels;
using Assigement_MVC.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assigement_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index(string p)
        {
            var viewModel = new CategoryIndexViewModel();

            viewModel.Cateories = _dbContext.ProductCategories
                .Where(r => p == null || r.Name.Contains(p) || r.Name.StartsWith(p) )
                .Select(category => new CategoryViewModell
                {
                    Id=category.Id,
                    Name=category.Name,                    
                }).ToList();

            return View(viewModel);
        }

        public IActionResult SelectedCategory(int Id,string p)
        {
            var viewModel = new SelectedCategoryViewModell();

            viewModel.products = _dbContext.Products
                .Where(r => p == null || r.Name.Contains(p) || r.CategoryId.Name.Contains(p) || r.Description.Contains(p))
                .Select(product => new ProductViewModell
                {
                    CategoryId = product.CategoryId,
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    CategoryName = product.CategoryId.Name
                }).Where(r => r.CategoryId.Id == Id).ToList();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin , Product Manager")]
        public IActionResult New()
        {
            var viewModel = new CategoryNewViewModel();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(CategoryNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbCategory = new ProductCategory();
                _dbContext.ProductCategories.Add(dbCategory);
                dbCategory.Name = viewModel.Name;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        [Authorize(Roles = "Admin , Product Manager")]
        public IActionResult Edit(int Id)
        {
            var viewmodel = new CategoryEditViewModel();

            var dbCategory = _dbContext.ProductCategories.Include(x => x.Products).First(r => r.Id == Id);

            viewmodel.Id = dbCategory.Id;
            viewmodel.Name = dbCategory.Name;
            viewmodel.products = GetAllProducts();
            return View(viewmodel);
        }

        private List<SelectListItem> GetAllProducts()
        {
            var list = new List<SelectListItem>();
            list.AddRange(_dbContext.Products.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = r.Name
            }));
            return list;
        }

        [HttpPost]
        public IActionResult Edit(int Id, CategoryEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbcategory = _dbContext.ProductCategories.Include(p => p.Products).First(r => r.Id == Id);

                dbcategory.Name = viewModel.Name;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.products = GetAllProducts();
            return View(viewModel);
        }
    }
}
