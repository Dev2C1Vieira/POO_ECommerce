using System;

namespace ProductCatalog.Interfaces
{
    public interface IProduct
    {
        /// <summary>
        /// Creation of properties
        /// </summary>
        int ProductID { get; set; }

        string ProductName { get; set; }

        string ProductDescription { get; set; }

        double Price { get; set; }

        DateTime LauchDate { get; set; }

        int WarrantyDuration { get; set; }

        //int CategoryID { get; set; }

        //int BrandID { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the cost of the product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        int CompareTo(Product product);
    }
}
