﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TentaProjekt.Data;
using TentaProjekt.Models;

namespace TentaProjekt.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<Product> _logger;

        public ProductController(ApplicationDbContext context, ILogger<Product> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
           _logger.LogWarning("With great powers comes great responsibilities");
           return View(await _context.Products.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = "TV"},
                new SelectListItem {Value = "2", Text = "DVD"},
                new SelectListItem {Value = "3", Text = "VHS"}
            };
            ViewBag.categoryList = categoryList;

            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,Name,Price")] Product product)
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = "TV"},
                new SelectListItem {Value = "2", Text = "DVD"},
                new SelectListItem {Value = "3", Text = "VHS"}
            };
            ViewBag.categoryList = categoryList;

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = "TV"},
                new SelectListItem {Value = "2", Text = "DVD"},
                new SelectListItem {Value = "3", Text = "VHS"}
            };
            ViewBag.categoryList = categoryList;

            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,Name,Price")] Product product)
        {
            var categoryList = new List<SelectListItem>()
            {
                new SelectListItem {Value = "1", Text = "TV"},
                new SelectListItem {Value = "2", Text = "DVD"},
                new SelectListItem {Value = "3", Text = "VHS"}
            };
            ViewBag.categoryList = categoryList;


            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .SingleOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.SingleOrDefaultAsync(m => m.ProductId == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
