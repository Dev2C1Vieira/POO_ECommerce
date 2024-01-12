/*
 * <copyright file = "Stock.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 10:08:44 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

// External
using ProductCatalog;
using RevenueEngineE;

namespace RevenueEngines
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/19/2023 10:08:44 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Stock
    {
        #region Attributes

        /// <summary>
        /// Atributes creation
        /// </summary>
        private static Dictionary<Product, int> productsInStock;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        static Stock()
        {
            productsInStock = new Dictionary<Product, int>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'productsInStock' attribute
        /// </summary>
        public static Dictionary<Product, int> ProductsInStock
        {
            get { return productsInStock; }
            set { productsInStock = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingStockMethods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsProductsInStockEmpty()
        {
            if (ProductsInStock.Count == 0)
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool IsProductInStock(Product product)
        {
            if (ProductsInStock.ContainsKey(product))
                return true;
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool AddProductToStock(Product product, int quantity)
        {
            if (IsProductInStock(product) == true)
            { throw new StockException("\nProduct is already in stock!"); }
            else
            {
                ProductsInStock.Add(product, quantity);
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool RemoveProductFromStock(Product product)
        {
            if (IsProductInStock(product) == false)
            { throw new StockException("\nProduct is already out of stock!"); }
            else
            {
                ProductsInStock.Remove(product);
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool AddStockToProduct(Product product, int quantity)
        {
            if (IsProductInStock(product) == false)
            { throw new StockException("\nProduct is not in stock at the moment!"); }
            else
            {
                ProductsInStock[product] += quantity;
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool RemoveStockFromProduct(Product product, int quantity)
        {
            if (IsProductInStock(product) == false)
                throw new StockException("\nProduct is not in stock at the moment!");

            int aux = ProductsInStock[product] - quantity;

            if (aux <= 0)
                RemoveProductFromStock(product);
            else
            {
                ProductsInStock[product] = aux;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static Dictionary<Product, int> ReturnProductsInStock()
        {
            if (IsProductsInStockEmpty() == true)
                throw new StockException("Stock is empty!");

            Dictionary<Product, int> dictionaryAux = new Dictionary<Product, int>();

            foreach (var item in ProductsInStock)
            {
                dictionaryAux.Add(item.Key, item.Value);
            }
            return dictionaryAux;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountProductsInStock()
        {
            int count = 0;

            if (IsProductsInStockEmpty() == true)
                return count;
            else
            {
                foreach (var item in ProductsInStock)
                    count++;
            }
            return count;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the stock data from a file into the stock.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadStockDataBin(string fileName)
        {
            Dictionary<Product, int> auxStock = new Dictionary<Product, int>();
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    Dictionary<Product, int> loadedStock = (Dictionary<Product, int>)formatter.Deserialize(fileStream);

                    foreach (var item in loadedStock)
                    {
                        auxStock.Add(item.Key, item.Value);
                    }
                    ProductsInStock = auxStock;
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the stock data from stock into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static bool SaveStockDataBin(string fileName)
        {
            // Creates a FileStream to write stock data to the file.
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, ProductsInStock);
            }
            return true;
        }

        #endregion

        #endregion

        #endregion
    }
}
