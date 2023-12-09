using System;
using System.Collections.Generic;
using ProductCatalog;

namespace ProductCatalogs.Interfaces
{
    public interface IProduct
    {
        List<Product> ProductsList { get; set; }

        bool ExistProduct(Product product);

        bool IsProductAvailable(Product product);

        bool InsertProduct(Product product);

        Product ReturnProduct(Product given_product);

        //bool UpdateProduct(Product product);

        //bool DeleteProduct(Product product);

        //Still in progress...
    }
}
