using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager
    {
        private readonly AgencyContext _context;

        public ProductManager(AgencyContext context)
        {
            _context = context;
        }
        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var selectedProduct = await _context.Products.FindAsync(id);
            if (selectedProduct == null) return;
            selectedProduct.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
        public async Task<List<Product>> GetAll()
        {
            return await _context.Products.
                Where(x=>!x.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductRecords)
                .Include(p => p.ProductPictures).ThenInclude(p =>p.Picture)
                .OrderByDescending(p=>p.ModifiedOn).ToListAsync();
        }

        public async Task<List<Product>> SearchProduct(string? q,int? categoryId,decimal? minPrice,decimal? maxPrice,int? sortBy)
        {
            var products = _context.Products
                .Include(p => p.Category)
                 .Include(p => p.ProductRecords)
                .Include(p => p.ProductPictures).ThenInclude(p=>p.Picture)
                .Where(p=>!p.IsDeleted)
                .AsQueryable();
            if (string.IsNullOrWhiteSpace(q))
            {

                products=products.Where(p => p.ProductRecords.Any(p => p.Name.ToLower().Contains(q.ToLower())));
            }
            if (categoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == categoryId);
            }
            if(minPrice.HasValue && maxPrice.HasValue)
            {
                products=products.Where(p=>p.Price>=minPrice && p.Price<=maxPrice);
            }
            if(sortBy != null)
            {
                products = sortBy switch
                {
                    1 => products.OrderByDescending(p => p.Price),
                    2 => products.OrderBy(p => p.Price),
                    _ => products.OrderByDescending(p => p.PublishDate),
                };
            }


            return await _context.Products.ToListAsync();
        }
        public async Task<Product?>GetById(int id)
        {
            var selectedProduct=await _context.Products.FirstOrDefaultAsync(p=>!p.IsDeleted && p.Id==id);
            if(selectedProduct == null) return null;
            return selectedProduct;
        }
    }
}
