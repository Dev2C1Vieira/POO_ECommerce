/*
 * <copyright file = "Sales.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:34:10 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

// External
using RevenueEngineE;
using ProductCatalogs;
using ProductCatalog;

namespace RevenueEngines
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:10 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Sales
    {
        #region Attributes

        /// <summary>
        /// Creation of the Sales class atributes
        /// </summary>
        private static List<Sale> salesList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        static Sales()
        {
            salesList = new List<Sale>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'salesList' attribute
        /// </summary>
        public static List<Sale> SalesList
        {
            get { return salesList; }
            set { salesList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given sale already exists in the List.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public static bool ExistSale(Sale sale)
        {
            if (SalesList.Contains(sale))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given sale is visible or not.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public static bool IsSaleAvailable(Sale sale)
        {
            if (sale.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two sales, indicated by parameter.
        /// </summary>
        /// <param name="sale1"></param>
        /// <param name="sale2"></param>
        /// <returns></returns>
        public static bool CompareSales(Sale sale1, Sale sale2)
        {
            if (sale1.Equals(sale2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the sales list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsSalesListEmpty()
        {
            if (SalesList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewSale()
        {
            if (IsSalesListEmpty() == true)
                return 1;

            Sale aux = SalesList.Last();
            return aux.ProductID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the sales list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Sale sale in SalesList)
            {
                if (sale.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the sales historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Sale sale in SalesList)
            {
                if (sale.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a sale that has the id indicated by the user.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        public static bool IsSaleIDAvailable(int saleID)
        {
            foreach (Sale sale in SalesList)
            {
                if (sale.SaleID == saleID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Sale, using its ID.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        public static Sale ReturnSaleFromID(int saleID)
        {
            Sale auxSale = new Sale();
            foreach (Sale sale in SalesList)
            {
                if (sale.SaleID == saleID)
                    auxSale = sale;
                else continue;
            }
            return auxSale;
        }

        /// <summary>
        /// Method that checks whether there is a sufficient quantity of a given product in stock to make a purchase.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool EnoughQuantityToBuy(Product product, int quantity)
        {
            if (Stock.IsProductsInStockEmpty() == true)
                throw new SaleException("There aren't any products in stock at the moment!");

            if (Stock.IsProductInStock(product) == false)
                throw new SaleException("Product is not in stock at the moment!");

            foreach (var item in Stock.ProductsInStock)
            {
                if (item.Key.Equals(product))
                {
                    if (item.Value >= quantity)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method that calculates the total cost of the purchase.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public static double CalculateTotalPurchaseValue(Sale sale)
        {
            Product product = Products.ReturnProductFromID(sale.ProductID);

            return (product.Price * sale.Quantity);
        }

        /// <summary>
        /// This function inserts a sale passed as a List parameter.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool InsertSale(Sale sale)
        {
            if (ExistSale(sale) == true)
                throw new SaleException("\nUnable to insert new sale ... Sale is already inserted!");

            if (Products.ExistProduct(Products.ReturnProductFromID(sale.ProductID)) == true)
            {
                if (EnoughQuantityToBuy(Products.ReturnProductFromID(sale.ProductID), sale.Quantity) == true)
                {
                    Stock.RemoveStockFromProduct(Products.ReturnProductFromID(sale.ProductID), sale.Quantity);
                    sale.TotalPrice = CalculateTotalPurchaseValue(sale);
                    SalesList.Add(sale);
                    return true;
                }
                else
                    throw new SaleException("\nUnable to insert new sale ... " +
                        "Product does not have sufficient quantity in stock to make the purchase\r\n!");
            }
            else
                throw new SaleException("\nUnable to insert new sale ... Product does not exist!");
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the sales list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static List<Sale> ReturnSalesList()
        {
            List<Sale> listaAux = new List<Sale>();

            if (IsSalesListEmpty() == true)
                throw new SaleException("\nThe sales list is empty!");

            foreach (Sale sale in SalesList)
            {
                if (sale.VisibilityStatus == true)
                    listaAux.Add(sale);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the sales list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static List<Sale> ReturnHistoric()
        {
            List<Sale> listaAux = new List<Sale>();

            if (IsSalesListEmpty() == true)
                throw new SaleException("\nThe sales list is empty!");

            foreach (Sale sale in SalesList)
            {
                if (sale.VisibilityStatus == false)
                    listaAux.Add(sale);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// This function removes a sale by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool RemoveSale(int saleID)
        {
            if (ExistSale(ReturnSaleFromID(saleID)) == false)
                throw new SaleException("\nUnable to remove sale ... Sale does not exist!");

            foreach (Sale sale in SalesList)
            {
                if (sale.Equals(ReturnSaleFromID(saleID)))
                {
                    if (sale.VisibilityStatus == true)
                    {
                        sale.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new SaleException("\nUnable to remove sale ... Sale has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a sale by passing its ID as a parameter, putting it back as an available product.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool RecoverSale(int saleID)
        {
            if (ExistSale(ReturnSaleFromID(saleID)) == false)
                throw new SaleException("\nUnable to recover sale ... Sale does not exist!");

            foreach (Sale sale in SalesList)
            {
                if (sale.Equals(ReturnSaleFromID(saleID)))
                {
                    if (sale.VisibilityStatus == false)
                    {
                        sale.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new SaleException("\nUnable to recover sale ... Sale hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a sale by passing its ID as a parameter.
        /// </summary>
        /// <param name="saleID"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool DeleteSale(int saleID)
        {
            if (ExistSale(ReturnSaleFromID(saleID)) == false)
                throw new SaleException("\nUnable to delete sale ... Sale does not exist!");

            foreach (Sale sale in SalesList)
            {
                if (sale.Equals(ReturnSaleFromID(saleID)))
                {
                    if (sale.VisibilityStatus == false)
                    {
                        SalesList.Remove(sale);
                        return true;
                    }
                    else
                        throw new SaleException("\nUnable to delete sale ... Sale hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the sales data from a file into the sales list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadSalesDataBin(string fileName)
        {

            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Sale> loadedSales = (List<Sale>)formatter.Deserialize(fileStream);

                    foreach (Sale sale in loadedSales)
                    {
                        SalesList.Add(sale);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the sales data from the sales list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="SaleException"></exception>
        public static bool SaveSalesDataBin(string fileName)
        {
            if (IsSalesListEmpty() == true)
                throw new SaleException("\nThe sales list is empty!");

            // Cria um FileStream para gravar os dados dos produtos no arquivo
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, SalesList);
            }
            return true;
        }

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
