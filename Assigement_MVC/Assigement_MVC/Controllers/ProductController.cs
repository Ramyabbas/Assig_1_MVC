using Microsoft.AspNetCore.Mvc;
using Assigement_MVC.ViewModels;
using Assigement_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Assigement_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
        public IActionResult Index(string p)
        {
            var viewModel = new ProductIndexViewmodell();

            viewModel.products = _dbContext.Products
                .Where(r => p == null || r.Name.Contains(p) || r.CategoryId.Name.Contains(p) || r.Description.Contains(p))
                .Select(product => new ProductViewModell
                {
                    CategoryId=product.CategoryId,
                    Id = product.Id,
                    Name = product.Name,
                    Price=product.Price,
                    Description = product.Description,
                    CategoryName=product.CategoryId.Name
                }).ToList();

            return View(viewModel);
        }


        [Authorize(Roles = "Admin , Product Manager")]
        public IActionResult New()
        {
            var viewModel = new ProductNewViewModel();
            viewModel.AllCategoreis = GetAllCategories();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult New(ProductNewViewModel viewModel)
        {
            var category = GetAllCategories();
            if (ModelState.IsValid)
            {
                var dbProduct = new Product();
                _dbContext.Products.Add(dbProduct);
                dbProduct.CategoryId = _dbContext.ProductCategories.First(r => r.Id == viewModel.CategoryId);
                dbProduct.Name = viewModel.Name;
                dbProduct.Price = viewModel.Price;
                dbProduct.Description = viewModel.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            viewModel.AllCategoreis = GetAllCategories();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin , Product Manager")]
        public IActionResult Edit(int Id)
        {
            var viewmodel = new PorductEditViewModel();

            var dbProduct = _dbContext.Products.First(r => r.Id == Id);
            viewmodel.Id = dbProduct.Id;
            viewmodel.Name = dbProduct.Name;
            viewmodel.Description = dbProduct.Description;
            viewmodel.Price = dbProduct.Price;
            viewmodel.cateories = GetAllCategories();
            return View(viewmodel);
        }


        [HttpPost]
        public IActionResult Edit(int Id, PorductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbProdcut = _dbContext.Products.First(r => r.Id == Id);

                dbProdcut.Name = viewModel.Name;
                dbProdcut.Price = viewModel.Price;
                dbProdcut.Description = viewModel.Description;
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            viewModel.cateories = GetAllCategories();

            return View(viewModel);
        }

        private List<SelectListItem> GetAllCategories()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "Var vänlig och välj en kategori..." });

            list.AddRange(_dbContext.ProductCategories.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Id.ToString()
            }));
            return list;
        }

    }

}
