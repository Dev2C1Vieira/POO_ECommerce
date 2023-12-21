using System;

namespace ProductCatalog.Interfaces
{
    public interface IBrand
    {
        /// <summary>
        /// Creation of the properties
        /// </summary>
        int BrandID { get; set; }

        string BrandName { get; set; }

        string BrandDescription { get; set; }

        string OriginCountry { get; set; }

        DateTime FundationDate { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the fundation date of the brand.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        int CompareTo(Brand brand);
    }
}
