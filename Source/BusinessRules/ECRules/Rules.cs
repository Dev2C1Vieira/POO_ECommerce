/*
 * <copyright file = "Rules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/3/2023 7:23:12 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;

// External
// Product Catalog
using ProductCatalog;
using ProductCatalogs;
using ProductCatalogE;

// Revenue Engine


// Staff Client System


namespace ECRules
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/3/2023 7:23:12 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Rules
    {
        #region ProductsMethods

        /// <summary>
        /// Method that checks, before inserting the product, whether it respects business rules.
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool InsertProduct(Product produto)
        {
            if ((produto.Price > 1000) || (produto.WarrantyDuration < 2))
                return false;

            try
            {
                Products.InsertProduct(produto);
                return true;
            }
            catch (ProductException PE)
            {
                throw new ProductException("\nFailure of Business Rules!" + "-" + PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new product!" + "-" + E.Message);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Product> ReturnProductsList()
        {
            try
            {
                return Products.ReturnProductsList();
            }
            catch (ProductException PE)
            {
                throw new Exception(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the products present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Products.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception(E.Message);
            }
        }

        #endregion
    }
}
