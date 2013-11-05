using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserGroup.Entities
{
    [Table("Products")]
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        // public Category Category  { get ;  set;}
        public ICollection<OrderDetail> Order_Detail { get; set; }
        // public Supplier Suppliers { get ;  set;}
    }
}