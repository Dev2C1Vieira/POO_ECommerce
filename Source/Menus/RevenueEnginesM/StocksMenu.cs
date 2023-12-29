/*
 * <copyright file = "StocksMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/23/2023 8:31:13 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections.Generic;

// External
using ProductCatalog;
using RevenueEngineR;
using RevenueEngineIO;
using ProductCatalogR;

namespace RevenueEnginesM
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class StocksMenu
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public static void Clear() { Console.Clear(); }

        /// <summary>
        /// 
        /// </summary>
        public static void Flushtdin() { while (Console.In.Peek() != -1 && Console.In.ReadLine() != null) { } }

        /// <summary>
        /// 
        /// </summary>
        public static void Pause()
        {
            Flushtdin();
            Console.WriteLine("\n\nPress ");
            Console.WriteLine("any key ");
            Console.WriteLine("to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsFN"></param>
        /// <param name="categoriesFN"></param>
        /// <param name="brandsFN"></param>
        /// <param name="clientsFN"></param>
        /// <param name="employeesFN"></param>
        /// <param name="managersFN"></param>
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN, 
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1, productID, quantity;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Clients Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. Show the Stock.                       |");
                        Console.WriteLine("  |  2. Add product to stock.                 |");
                        Console.WriteLine("  |  3. Remove product from stock.            |");
                        Console.WriteLine("  |  4. Add stock to product.                 |");
                        Console.WriteLine("  |  5. Remove stock from product.            |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("\nTable containing the information of the existing clients.\n");
                            // Table Construction
                            Console.WriteLine("\n+----------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  PRODUCT CODE  |  PRODUCT NAME  |  PRODUCT DESCRIPTION  |  UNIT PRICE  |  QUANTITY IN STOCK  |");
                            Console.WriteLine("+----------------------------------------------------------------------------------------------+");
                            StockIO.ListProductsInStockInformation(StockRules.ReturnProductsInStock());
                            Console.WriteLine("+----------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {StockRules.ReturnAmountProductsInStock()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets add new product to Stock!");

                            Product product1 = new Product();

                            productID = StockIO.GetNewStockInformation(out quantity);

                            product1 = ProductsRules.ReturnProductFromID(productID);

                            if (ProductsRules.ExistProduct(productID) == true)
                            {
                                if (ProductsRules.IsProductAvailable(product1) == true)
                                {
                                    result = StockRules.AddProductToStock(product1, quantity);

                                    StockRules.SaveStockDataBin(stockFN);

                                    if (result == true)
                                        Console.WriteLine("\nNew product added to stock successfully!");
                                    else
                                    {
                                        Console.WriteLine("\nUnable to add new product to stock!");
                                    }
                                }
                                else
                                    Console.WriteLine("\nProduct does not exist ... Choose an available product!");
                            }
                            else
                                Console.WriteLine("\nProduct does not exist ... Choose an available product!");

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Remove product from Stock!");

                            Product product2 = new Product();

                            productID = StockIO.GetProductID();

                            product2 = ProductsRules.ReturnProductFromID(productID);

                            if (ProductsRules.ExistProduct(productID) == true)
                            {
                                result = StockRules.RemoveProductFromStock(product2);

                                StockRules.SaveStockDataBin(stockFN);

                                if (result == true)
                                    Console.WriteLine("\nProduct was successfully removed from Stock!");
                                else
                                    Console.WriteLine("\nUnable to remove the product from Stock!");
                            }

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets add stock to product!");

                            Product product3 = new Product();

                            productID = StockIO.GetNewStockInformation(out quantity);

                            product3 = ProductsRules.ReturnProductFromID(productID);

                            if (ProductsRules.ExistProduct(productID) == true)
                            {
                                result = StockRules.AddStockToProduct(product3, quantity);

                                StockRules.SaveStockDataBin(stockFN);

                                if (result == true)
                                    Console.WriteLine("\nStock added successfully to product!");
                                else
                                {
                                    Console.WriteLine("\nUnable to add stock to product!");
                                }
                            }

                            Pause();
                            break;
                        case 5:
                            Console.WriteLine("\nLets stock from product!");

                            Product product4 = new Product();

                            productID = StockIO.GetNewStockInformation(out quantity);

                            product4 = ProductsRules.ReturnProductFromID(productID);

                            if (ProductsRules.ExistProduct(productID) == true)
                            {
                                result = StockRules.RemoveStockFromProduct(product4, quantity);

                                StockRules.SaveStockDataBin(stockFN);

                                if (result == true)
                                    Console.WriteLine("\nStock was successfully removed from the product!");
                                else
                                    Console.WriteLine("\nUnable to remove stock from product!");
                            }

                            Pause();
                            break;
                        case 6:
                            REMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                    }
                }
            }
            catch (FormatException E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            finally
            {
                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
            }
        }

        #endregion
    }
}
