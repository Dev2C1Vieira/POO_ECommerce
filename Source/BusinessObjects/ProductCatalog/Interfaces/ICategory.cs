using System;

namespace ProductCatalog.Interfaces
{
    public interface ICategory
    {
        /// <summary>
        /// Creation of the properties
        /// </summary>
        int CategoryID { get; set; }

        string CategoryName { get; set; }

        string CategoryDescription { get; set; }

        DateTime CreationDate { get; set; }

        int BrandID { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the description of the category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        int CompareTo(Category category);
    }
}
