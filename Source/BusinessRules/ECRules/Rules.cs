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
            if (produto.Price > 1000)
                throw new ProductException("\nFailure of Business Rules ... Product price cannot exceed 1000!");

            if (produto.WarrantyDuration < 2)
                throw new ProductException("\nFailure of Business Rules ... Product warranty duration cannot be less than 2 years!");

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
                throw new Exception("\nFailed to return the amount of products present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the product list.
        /// </summary>
        /// <returns></returns>
        public static bool IsProductIDAvailable(int productID)
        {
            try
            {
                return Products.IsProductIDAvailable(productID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated product ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool UpdateProduct(int fieldToUpdate, string atribute, int productID)
        {
            if (fieldToUpdate == 3)
            {
                float price = float.Parse(atribute);

                if (price > 1000)
                    throw new ProductException("\nFailure of Business Rules ... Product price cannot exceed 1000!");
            }
            if (fieldToUpdate == 3)
            {
                int warrantyDuration = int.Parse(atribute);

                if (warrantyDuration < 2)
                    throw new ProductException("\nFailure of Business Rules ... Product warranty duration cannot be less than 2 years!");
            }

            try
            {
                return Products.UpdateProduct(fieldToUpdate, atribute, productID);
            }
            catch (ProductException PE)
            {
                throw new ProductException("\nFailure of Business Rules!" + "-" + PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool DeleteProduct(int productID)
        {
            try
            {
                return Products.DeleteProduct(productID);
            }
            catch (ProductException PE)
            {
                throw new Exception(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated product!" + "-" + E.Message);
            }
        }

        #endregion
    }
}
