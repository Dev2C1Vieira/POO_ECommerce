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

            Console.Write("\nEnter product Name: ");
            int productID = int.Parse(Console.ReadLine());

            Console.Write("\nEnter product Description: ");
            quantity = int.Parse(Console.ReadLine());

            return productID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListProductsInformation(List<Product> productsList)
        {
            if (productsList.Count == 0)
            {
                Console.WriteLine("|     The products list is empty!     |");
                return false;
            }
            foreach (Product po in productsList)
            {
                Console.WriteLine($"|  {po.ProductID}  |  {po.ProductName}  |  {po.ProductDescription}  |  {po.Price.ToString("F2")}  |  {po.LauchDate.ToShortDateString()}  |  {po.WarrantyDuration}  |  {po.AmountInStock}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Product> productsList)
        {
            if (productsList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Product po in productsList)
            {
                Console.WriteLine($"|  {po.ProductID}  |  {po.ProductName}  |  {po.ProductDescription}  |  {po.Price.ToString("F2")}  |  {po.LauchDate.ToShortDateString()}  |  {po.WarrantyDuration}  |  {po.AmountInStock}  |");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <returns></returns>
        public static string GetAttributeToUpdate(int fieldToUpdate)
        {
            string newAttribute = string.Empty;
            if (fieldToUpdate == 1)
            {
                Console.Write("\nEnter product new Name: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.Write("\nEnter product new Description: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.Write("\nEnter product new Price: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 4)
            {
                Console.Write("\nEnter product new Launch Date (dd-MM-yyyy): ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 5)
            {
                Console.Write("\nEnter product new Warranty Duration: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 6)
            {
                Console.Write("\nEnter product new Amount in Stock: ");
                newAttribute = Console.ReadLine();
            }

            return newAttribute;
        }

        #endregion
    }
}
