using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using HTPSSystem.JMont.Data.Entities;
using HTPSSystem.JMont.DAL;
using System.ComponentModel;
#endregion

namespace HTPSSystem.JMont.BLL
{
    [DataObject]
  public class CustomerController
    {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<Customer> Customers_List()
        {
            using (var context = new HTPSContext())
            {
                return context.Customer.ToList();
            }
        }

        public Customer Customer_Find (int Customerid)
        {
            using (var context = new HTPSContext())
            {
                return context.Customer.Find(Customerid);
            }
        }
    }

}
