/*
 * <copyright file = "SalesRules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/29/2023 4:46:09 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

// External
using ProductCatalog;
using RevenueEngineE;
using RevenueEngines;

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
    public class SalesRules
    {
        #region Methods

        /// <summary>
        /// This method verifies if the visibility status of the given sale is visible or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsSaleAvailable(Sale sale)
        {
            try
            {
                return Sales.IsSaleAvailable(sale);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated sale is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks if there is a sale that has the id indicated by the user.
        /// </summary>
        /// <returns></returns>
        public static bool IsProductIDAvailable(int saleID)
        {
            try
            {
                return Sales.IsSaleIDAvailable(saleID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated sale ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the sales list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Sales.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of sales present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the sales historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Sales.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of sales present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Verifies if the sale exists.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool ExistSale(int saleID)
        {
            try
            {
                return Sales.ExistSale(ReturnSaleFromID(saleID));
            }
            catch (SaleException SE)
            {
                throw new SaleException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to return sale from ID!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an object of type Sale, using its ID.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static Sale ReturnSaleFromID(int saleID)
        {
            try
            {
                return Sales.ReturnSaleFromID(saleID);
            }
            catch (SaleException SE)
            {
                throw new SaleException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to return sale from ID!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks whether there is a sufficient quantity of a given product in stock to make a purchase.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool EnoughQuantityToBuy(Product product, int quantity)
        {
            try
            {
                return Sales.EnoughQuantityToBuy(product, quantity);
            }
            catch (SaleException SE)
            {
                throw new SaleException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify the amount of products in stock!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that calculates the total cost of the purchase.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static double CalculateTotalPurchaseValue(Sale sale)
        {
            try
            {
                return Sales.CalculateTotalPurchaseValue(sale);
            }
            catch (SaleException SE)
            {
                throw new SaleException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to calculate the total cost of the purchase!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the sale, whether it respects business rules.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertSale(Sale sale)
        {
            try
            {
                sale.SaleID = Sales.ReturnIDNewSale();
                Sales.InsertSale(sale);
                return true;
            }
            catch (SaleException SE)
            {
                throw new SaleException("\nFailure of Business Rules!" + "-" + SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new sale!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the sales list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static List<Sale> ReturnSalesList()
        {
            try
            {
                return Sales.ReturnSalesList();
            }
            catch (SaleException SE)
            {
                throw new SaleException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the sales present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the products list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Sale> ReturnHistoric()
        {
            try
            {
                return Sales.ReturnHistoric();
            }
            catch (SaleException SE)
            {
                throw new SaleException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the sales historic!" + "-" + E.Message);
            }
        }



        /// <summary>
        /// This function removes a sale by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveSale(int saleID)
        {
            try
            {
                return Sales.RemoveSale(saleID);
            }
            catch (SaleException SE)
            {
                throw new SaleException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated sale!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a sale by passing its ID as a parameter, putting it back as an available product.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RecoverSale(int saleID)
        {
            try
            {
                return Sales.RecoverSale(saleID);
            }
            catch (SaleException SE)
            {
                throw new SaleException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated sale!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a sale by passing its ID as a parameter.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteSale(int saleID)
        {
            try
            {
                return Sales.DeleteSale(saleID);
            }
            catch (SaleException SE)
            {
                throw new SaleException(SE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated sale!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the sales data from a file into the sales list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadSalesDataBin(string fileName)
        {
            try
            {
                return Sales.LoadSalesDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing sale data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save sale data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load sales data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the sales data from the sales list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveSalesDataBin(string fileName)
        {
            try
            {
                return Sales.SaveSalesDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing sale data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save sale data!" + IOE.Message);
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
