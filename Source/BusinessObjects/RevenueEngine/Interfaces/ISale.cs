using System;

namespace RevenueEngine.Interfaces
{
    public interface ISale
    {
        int SaleID { get; set; }

        DateTime DateSale { get; set; }

        int ProductID { get; set; }

        int ClientID { get; set; }

        bool VisibilityStatus { get; set; }

        int CompareTo(Sale sale);
    }
}
