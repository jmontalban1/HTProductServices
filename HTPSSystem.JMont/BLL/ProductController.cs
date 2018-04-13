using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using HTPSSystem.JMont.Data.Entities;
using HTPSSystem.JMont.DAL;
#endregion

namespace HTPSSystem.JMont.BLL

{
   public class ProductController
    {
        public List<Product> Product_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Product.ToList();
            }
        }

        public Product Product_Find(int productid)
        {
            using (var context = new HTPSContext())
            {
                return context.Product.Find(productid);
            }
        }
        public int Product_Delete(int productid)
        {
            using (var context = new HTPSContext())
            {
                var existing = context.Product.Find(productid);
                existing.Discontinued = true;
                context.Entry(existing).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return context.SaveChanges();
            }
        }

        public int Product_Add(Product item)
        {
            using (var context = new HTPSContext())
            {
                context.Product.Add(item);
                context.SaveChanges();
                return item.ProductID;                    
            }

        }
    }
}
