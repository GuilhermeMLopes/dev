using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProductCatalog.Data;
using ProductCatalog.Models;

namespace ProductCatalog.Repositories
{
    public class CategoryRepository
    {
        private readonly StoreDataContext _context;
        public CategoryRepository(StoreDataContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> Get() 
        {
            return _context.Categories.AsNoTracking().ToList();
        }
        public Category Get(int id) 
        {
            return _context.Categories.AsNoTracking().Where(X => X.Id == id).FirstOrDefault();
        }
        public IEnumerable<Product> GetProducts(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }
        public void Save(Category category) 
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }
        public void Update(Category category) 
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Excluir(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
    }
}