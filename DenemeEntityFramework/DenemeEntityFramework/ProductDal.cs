using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DenemeEntityFramework
{
    public class ProductDal
    {
        public List<Product> getAll()
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.ToList();
            }
        }
        public List<Product> getByName(string key)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.Name.Contains(key)).ToList();
            }
        }
        public List<Product> getByUnitPrice(decimal price)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= price).ToList();
            }
        }
        public List<Product> getByUnitPrice(decimal min, decimal max)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min && p.UnitPrice <= max).ToList();
            }
        }
        public Product getById(int id)
        {
            using (ETradeContext context = new ETradeContext())
            {
                return context.Products.FirstOrDefault(p => p.Id == id);
            }
        }
        public void add(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void update(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void delete(Product product)
        {
            using (ETradeContext context = new ETradeContext())
            {
                var entity = context.Entry(product);
                entity.State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
