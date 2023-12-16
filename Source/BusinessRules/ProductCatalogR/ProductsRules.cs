/*
 * <copyright file = "ProductsRules.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/16/2023 9:01:30 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

// External
using ProductCatalog;
using ProductCatalogs;
using ProductCatalogE;

namespace ProductCatalogR
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/16/2023 9:01:30 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class ProductsRules
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
                produto.ProductID = Products.ReturnIDNewProduct();
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

        #region File Management

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        public static bool LoadProductsDataBin(string fileName)
        {
            try
            {
                return Products.LoadProductsDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing product data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new SerializationException("\nIO error when trying to save product data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new SerializationException("\nUnable to load products data from file!" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool SaveProductsDataBin(string fileName)
        {
            try
            {
                return Products.SaveProductsDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing product data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new SerializationException("\nIO error when trying to save product data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new SerializationException("\nUnable to save the data in the file!" + E.Message);
            }
        }

        #endregion

        #endregion
    }
}
