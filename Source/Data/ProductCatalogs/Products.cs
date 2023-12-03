/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:34:51 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using ProductCatalog;
using ProductCatalogs.Interfaces;

namespace ProductCatalogs
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:51 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Products /*: IProduct*/
    {
        #region Attributes

        /// <summary>
        /// 
        /// </summary>
        private static string name; //
        private static List<Product> productsList = new List<Product>(); //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static Products()
        {
            name = string.Empty;
            productsList = new List<Product>(); //
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public static string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Product> ProductsList
        {
            get { return productsList; }
            set { productsList = value; }
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// This function checks whether a given product already exists in the List.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool ExistProduct(Product product)
        {
            if (productsList.Contains(product))
                return true;
            return false;
        }

        /// <summary>
        /// This function inserts a product passed as a List parameter.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool InsertProduct(Product product)
        {
            if (ExistProduct(product) == false)
            {
                productsList.Add(product);
                return (true);
            }
            return (false);

            //Still in progress...
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="given_product"></param>
        /// <returns></returns>
        public static Product ReturnProduct(Product given_product)
        {
            foreach (var product in productsList)
            {
                if (ExistProduct(given_product))
                {
                    return product;
                }
                continue;
            }
            return new Product(); // still checking if it works correctly
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool UpdateProduct(Product product)
        {
            return (false);

            //Still in progress...
        }

        /// <summary>
        /// This function eliminates a product passed as a parameter from the List.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool DeleteProduct(Product product)
        {
            // Checks if the product exists in the list before trying to remove it.
            if (ExistProduct(product) == true)
            {
                productsList.Remove(product); // Remove the product from the list.
                return true; // Indicates that the product was successfully removed.
            }
            return false; // Product not found in the list.
        }

        #endregion

        #region Destructor
        #endregion

        #endregion

        //Still in progress...
    }
}
