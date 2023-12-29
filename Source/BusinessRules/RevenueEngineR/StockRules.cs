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
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Runtime.Serialization;

// External
using ProductCatalog;
using RevenueEngines;
using RevenueEngineE;

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

        #region ManagingStockMethods

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
                throw new StockException(SE.Message);
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
                throw new StockException(SE.Message);
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
                throw new StockException(SE.Message);
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
                throw new StockException(SE.Message);
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

        public static int ReturnAmountProductsInStock()
        {
            try
            {
                return Stock.ReturnAmountProductsInStock();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return products in stock!" + "-" + E.Message);
            }
        }

        #endregion

        #region File Management

        /// <summary>
        /// Method that loads the stock data from a file into the stock.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadStockDataBin(string fileName)
        {
            try
            {
                return Stock.LoadStockDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing stock data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save stock data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load stock data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the stock data from stock into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveStockDataBin(string fileName)
        {
            try
            {
                return Stock.SaveStockDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing stock data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save stock data!" + IOE.Message);
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
