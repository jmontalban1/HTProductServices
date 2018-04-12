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
   public class RegistrationController
    {
        public List<Registration> Registration_List()
        {
            using (var context = new HTPSContext())
            {
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
