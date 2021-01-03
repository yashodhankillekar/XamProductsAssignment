using System;
using System.Collections.Generic;

#nullable disable

namespace XamProductsAssignment.Models
{
    public partial class Product
    {
        public int ProductRowId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int? ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int? ProductCategory { get; set; }
        public int? ProductManufacturer { get; set; }
        public int? ProductAddedByUser { get; set; }

        public virtual User ProductAddedByUserNavigation { get; set; }
        public virtual Category ProductCategoryNavigation { get; set; }
        public virtual Manufacturer ProductManufacturerNavigation { get; set; }
    }
}
