/*
 * <copyright file = "StockRules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/23/2023 8:53:08 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Diagnostics;

// External
using ProductCatalog;
using RevenueEngines;
using RevenueEngineE;
using System.Collections.Generic;

namespace RevenueEngineR
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class StockRules
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsProductsInStockEmpty()
        {
            try
            {
                return Stock.IsProductsInStockEmpty();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the there are any products in stock!" + "-" + E.Message);
            }
        }


        public static bool IsProductInStock(Product product)
        {
            try
            {
                return Stock.IsProductInStock(product);
            }
            catch (StockException SE)
            {
                throw new StockException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to add a product to stock!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool AddProductToStock(Product product, int quantity)
        {
            try
            {
                return Stock.AddProductToStock(product, quantity);
            }
            catch (StockException SE)
            {
                throw new StockException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to add a product to stock!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveProductFromStock(Product product)
        {
            try
            {
                return Stock.RemoveProductFromStock(product);
            }
            catch (StockException SE)
            {
                throw new StockException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove a product from stock!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool AddStockToProduct(Product product, int quantity)
        {
            try
            {
                return Stock.AddStockToProduct(product, quantity);
            }
            catch (StockException SE)
            {
                throw new StockException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to add stock to product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveStockFromProduct(Product product, int quantity)
        {
            try
            {
                return Stock.RemoveStockFromProduct(product, quantity);
            }
            catch (StockException SE)
            {
                throw new StockException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove stock from product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        /// <exception cref="Exception"></exception>
        public static Dictionary<Product, int> ReturnProductsInStock()
        {
            try
            {
                return Stock.ReturnProductsInStock();
            }
            catch (StockException SE)
            {
                throw new StockException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return products in stock!" + "-" + E.Message);
            }
        }

        #endregion
    }
}
