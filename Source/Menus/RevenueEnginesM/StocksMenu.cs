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
        /// <param name="fileName"></param>
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
                            Dictionary<Product, int> listingStock = new Dictionary<Product, int>();
                            Console.WriteLine("\nTable containing the information of the existing clients.\n");
                            // Table Construction
                            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  GENDER  |  DATE OF BIRTH  |  POSTAL CODE  |  ADDRESS  |  PHONE NUMBER  |  EMAIL  |");
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            listingStock = StockRules.ReturnProductsInStock();
                            StockIO.ListProductsInStockInformation(listingStock);
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {StockRules.ReturnAmountProductsInStock()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets add new product to Stock!");

                            productID = StockIO.GetNewStockInformation(out quantity);

                            result = StockRules.AddProductToStock(ProductsRules.ReturnProductFromID(productID), quantity);

                            if (result == true)
                                Console.WriteLine("\nNew product added to stock successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new product to stock!");
                            }

                            StockRules.SaveStockDataBin(stockFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Remove product from Stock!");

                            productID = StockIO.GetProductID();

                            result = StockRules.RemoveProductFromStock(ProductsRules.ReturnProductFromID(productID));
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully removed from Stock!");
                            else
                                Console.WriteLine("\nUnable to remove the product from Stock!");

                            StockRules.SaveStockDataBin(stockFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets add stock to product!");

                            productID = StockIO.GetNewStockInformation(out quantity);

                            result = StockRules.AddStockToProduct(ProductsRules.ReturnProductFromID(productID), quantity);

                            if (result == true)
                                Console.WriteLine("\nStock added successfully to product!");
                            else
                            {
                                Console.WriteLine("\nUnable to add stock to product!");
                            }

                            StockRules.SaveStockDataBin(stockFN);

                            Pause();
                            break;
                        case 5:
                            Console.WriteLine("\nLets stock from product!");

                             productID = StockIO.GetNewStockInformation(out quantity);

                            result = StockRules.RemoveStockFromProduct(ProductsRules.ReturnProductFromID(productID), quantity);

                            if (result == true)
                                Console.WriteLine("\nStock was successfully removed from the product!");
                            else
                                Console.WriteLine("\nUnable to remove stock from product!");

                            StockRules.SaveStockDataBin(stockFN);

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
