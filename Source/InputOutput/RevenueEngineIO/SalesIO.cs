/*
 * <copyright file = "SalesIO.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/29/2023 5:52:25 PM </date>
 * <description></description>
 * 
 * */

using ProductCatalog;
using RevenueEngines;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
    public class SalesIO
    {
        #region Methods

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public static Sale GetNewSaleInformation(Sale sale)
        {
            Console.Write("\nEnter sale Date (dd-MM-yyyy): ");
            string saleDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime saleDate = DateTime.ParseExact(saleDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            sale.DateSale = saleDate;

            Console.Write("\nEnter sale Product Code: ");
            sale.ProductID = int.Parse(Console.ReadLine());

            Console.Write("\nEnter sale Client Code: ");
            sale.ClientID = int.Parse(Console.ReadLine());

            Console.Write("\nEnter sale Product Quantity: ");
            sale.Quantity = int.Parse(Console.ReadLine());

            sale.VisibilityStatus = true;

            return sale;
        }

        /// <summary>
        /// Method that lists the sales records on the console.
        /// </summary>
        /// <param name="salesList"></param>
        /// <returns></returns>
        public static bool ListSalesInformation(List<Sale> salesList)
        {
            if (salesList.Count == 0)
            {
                Console.WriteLine("|     The sales list is empty!     |");
                return false;
            }
            foreach (Sale sal in salesList)
            {
                Console.WriteLine($"|  {sal.SaleID}  |  {sal.DateSale.ToShortDateString()}  " +
                    $"|  {sal.ProductID}  |  {sal.ClientID}  |  {sal.Quantity}  |  {sal.TotalPrice.ToString("F2")}  |");
            }
            return true;
        }

        /// <summary>
        /// Method that lists the sales historic records on the console.
        /// </summary>
        /// <param name="salesList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Sale> salesList)
        {
            if (salesList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Sale sal in salesList)
            {
                Console.WriteLine($"|  {sal.SaleID}  |  {sal.DateSale.ToShortDateString()}  " +
                    $"|  {sal.ProductID}  |  {sal.ClientID}  |  {sal.Quantity}  |  {sal.TotalPrice.ToString("F2")}  |");
            }
            return true;
        }

        /// <summary>
        /// Method that read from the console the Sale ID.
        /// </summary>
        /// <returns></returns>
        public static int GetSaleID()
        {
            Console.Write("\nEnter Sale ID: ");
            int saleID = int.Parse(Console.ReadLine());

            return saleID;
        }

        #endregion
    }
}
