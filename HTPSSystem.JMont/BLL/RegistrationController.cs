using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using HTPSSystem.JMont.Data.Entities;
using HTPSSystem.JMont.DAL;
using System.Data.SqlClient;
#endregion

namespace HTPSSystem.JMont.BLL
{
   public class RegistrationController
    {
        public List<Registration> Registration_List(int productid)
        {
            using (var context = new HTPSContext())
            {
                var results = context.Database.SqlQuery<Registration>(
                    "Registration_GetByProduct @ProductID",                    
                    new SqlParameter("ProductID", @productid));
                return context.Registration.ToList();
            }
        }

        


        public Registration Registration_Find(int Registrationid)
        {
            using (var context = new HTPSContext())
            {
                return context.Registration.Find(Registrationid);
            }
        }



    }
}
