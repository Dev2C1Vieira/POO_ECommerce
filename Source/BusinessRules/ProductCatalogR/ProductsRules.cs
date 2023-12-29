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
using System.IO;
using System.Collections.Generic;
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
        #region Methods

        /// <summary>
        /// This method verifies if the visibility status of the given product is visible or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsProductAvailable(Product product)
        {
            try
            {
                return Products.IsProductAvailable(product);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated product ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks if there is a product that has the id indicated by the user.
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
        /// Method that returns the number of elements present in the product list.
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
        /// Method that returns the number of elements present in the products historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Products.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of products present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Verifies if the product exists.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool ExistProduct(int productID)
        {
            try
            {
                return Products.ExistProduct(ReturnProductFromID(productID));
            }
            catch (ProductException PE)
            {
                throw new ProductException("\nFailure of Business Rules!" + "-" + PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to return product from ID!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        /// <exception cref="Exception"></exception>
        public static Product ReturnProductFromID(int productID)
        {
            try
            {
                return Products.ReturnProductFromID(productID);
            }
            catch (ProductException PE)
            {
                throw new ProductException("\nFailure of Business Rules!" + "-" + PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to return product from ID!" + "-" + E.Message);
            }
        }

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
        /// Method that returns an auxiliary list that contains the elements present in the product list.
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
                throw new ProductException(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the products present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the products list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        public static List<Product> ReturnHistoric()
        {
            try
            {
                return Products.ReturnHistoric();
            }
            catch (ProductException PE)
            {
                throw new Exception(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the products historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
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
        /// This function removes a product by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool RemoveProduct(int productID)
        {
            try
            {
                return Products.RemoveProduct(productID);
            }
            catch (ProductException PE)
            {
                throw new ProductException(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a product by passing its ID as a parameter, putting it back as an available product.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool RecoverProduct(int productID)
        {
            try
            {
                return Products.RecoverProduct(productID);
            }
            catch (ProductException PE)
            {
                throw new ProductException(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a product by passing its ID as a parameter.
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
                throw new ProductException(PE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated product!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the products data from a file into the products list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
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
                throw new IOException("\nIO error when trying to save product data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load products data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the products data from the products list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
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
                throw new IOException("\nIO error when trying to save product data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to save the data in the file!" + E.Message);
            }
        }

        #endregion

        #endregion
    }
}
