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
using System.Collections.Generic;

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
        /// 
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
            if (IsProductsInStockEmpty() == true)
                throw new StockException("Product is not in stock at the moment!");
            else
            {
                if (ProductsInStock.ContainsKey(product))
                    return true;
            }
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
                throw new StockException("Product is already in stock!");
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
            if (IsProductsInStockEmpty() == true)
                throw new StockException("There aren't any products in stock at the moment!");

            if (IsProductInStock(product) == false)
                throw new StockException("Product is already out of stock!");
            else
            {
                ProductsInStock.Remove(product);
                return true;
            }
        }

        //public static bool AddStockAll(int quantity)
        //{
        //    if (IsProductsInStockEmpty() == true)
        //        throw new StockException("Product is not in stock at the moment!");

        //    foreach (var product in ProductsInStock)
        //    {
        //        ProductsInStock[product] += quantity;
        //    }
        //    return true;
        //}

        public static bool AddStockToProduct(Product product, int quantity)
        {
            if (IsProductInStock(product) == true)
                throw new StockException("Product is not in stock at the moment!");

            ProductsInStock[product] += quantity;
            return true;
        }

        //public static bool RemoveStockAll(int quantity)
        //{
        //    if (IsProductsInStockEmpty() == true)
        //        throw new StockException("Product is not in stock at the moment!");

        //    foreach (var product in ProductsInStock)
        //    {
        //        ProductsInStock[product] -= quantity;
        //    }
        //    return true;
        //}

        public static bool RemoveStockFromProduct(Product product, int quantity)
        {
            if (IsProductInStock(product) == true)
                throw new StockException("Product is not in stock at the moment!");

            ProductsInStock[product] -= quantity;
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="StockException"></exception>
        public static Dictionary<Product, int> ReturnProductsInStock()
        {
            if (IsProductsInStockEmpty() == true)
                throw new StockException("Unable to return the products in stock ... Stock is empty!");

            Dictionary<Product, int> dictionaryAux = new Dictionary<Product, int>();

            foreach (var item in ProductsInStock)
            {
                dictionaryAux.Add(item.Key, item.Value);
            }
            return dictionaryAux;
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Stock()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
