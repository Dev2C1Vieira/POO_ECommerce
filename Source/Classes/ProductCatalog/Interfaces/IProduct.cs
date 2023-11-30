using System;
using System.Collections;
using System.Collections.Generic;

namespace ProductCatalog.Interfaces
{
    public interface IProduct
    {
        List<Product> ProductsList { get; set; }
        
        bool ExistProduct(Product product);

        bool InsertProduct(Product product);

        bool UpdateProduct(Product product);
        
        bool DeleteProduct(Product product);


        //Still in progress...
    }
}
    