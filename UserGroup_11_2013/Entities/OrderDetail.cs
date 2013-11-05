using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGroup.Entities
{
    [Table("Order Details")]
    public class OrderDetail : IValidatableObject
    {
        [Key, Column(Order = 1)]
        public int OrderID { get; set; }
        [Key, Column(Order = 2)]
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }  
        public short Quantity { get; set; }        
        public float Discount { get; set; }
        public Order Orders { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }

        // Validate for the Discount property.
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (Discount < 0 || Discount > 1)
            {
                yield return new ValidationResult
                    ("Discount must be a value between zero and one", new[] { "Discount" });
            }
        }
    }
}