/*
 * <copyright file = "StockIO.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/24/2023 2:36:57 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Globalization;
using System.Collections.Generic;

// External
using ProductCatalog;

namespace RevenueEngineIO
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class StockIO
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public static int GetNewStockInformation(out int quantity)
        {
            Dictionary<Product, int> newStockInfo = new Dictionary<Product, int>();

            int productID = GetProductID();

            Console.Write("\nEnter Quantiry in stock: ");
            quantity = int.Parse(Console.ReadLine());

            return productID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListProductsInStockInformation(Dictionary<Product, int> productsInStock)
        {
            if (productsInStock.Count == 0)
            {
                Console.WriteLine("|     The products list is empty!     |");
                return false;
            }
            foreach (var item in productsInStock)
            {
                Console.WriteLine($"|  {item.Key.ProductID}  |  {item.Key.ProductName}  |  {item.Key.ProductDescription}  |" +
                    $"  {item.Key.Price.ToString("F2")}  |  {item.Value}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetProductID()
        {
            Console.Write("\nEnter Product ID: ");
            int productID = int.Parse(Console.ReadLine());

            return productID;
        }

        #endregion
    }
}
