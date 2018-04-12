using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace HTPSSystem.JMont.Data.Entities

{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }      

        private string _ContactNumber { get; set; }

        public string ContactNumber
        {
            get
            {
                return _ContactNumber;
            }
                set
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        _ContactNumber = value;
                    }
                    else
                    {
                        _ContactNumber = null; //
                    }
                }

        }        

        [NotMapped]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
