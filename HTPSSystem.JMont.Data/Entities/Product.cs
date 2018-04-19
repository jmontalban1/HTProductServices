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
    [Table("Product")]
   public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        [StringLength(40, ErrorMessage = "Product Name is limited to 40 characters")]
        public string Name { get; set; }
        public string ModelNumber{ get; set; }

        public bool Discontinued { get; set; }


        private DateTime? _DiscontinuedDate; // just do auto implement

        
        public DateTime? DiscontinuedDate
        {
            get
            {
                return _DiscontinuedDate;
            }
            set
            {
                if (value.HasValue && value.Value.Equals(DateTime.MinValue))
                    _DiscontinuedDate = null;
                else
                    _DiscontinuedDate = value;
            }   
        }
    }
}
