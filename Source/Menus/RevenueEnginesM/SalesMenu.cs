/*
 * <copyright file = "SalesMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/29/2023 5:47:07 PM </date>
 * <description></description>
 * 
 * */

using System;

// External
using RevenueEngine;
using RevenueEngineR;
using RevenueEngineIO;

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
    public class SalesMenu
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
        /// Menu that list the sales present in the sales historic
        /// </summary>
        public static void DisplayHistoricMenu()
        {
            Console.WriteLine("\nTable containing the information of the sales historic.\n");
            // Table Construction
            Console.WriteLine("\n+--------------------------------------------------------------------------+");
            Console.WriteLine("|  CODE  |  DATE SALE  |  PRODUCT  |  CLIENT  |  QUANTITY  |  TOTAL PRICE  |");
            Console.WriteLine("+--------------------------------------------------------------------------+");
            SalesIO.ListHistoric(SalesRules.ReturnHistoric());
            Console.WriteLine("+--------------------------------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {SalesRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Products Menu.        |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// Menu that allows for a sale to be deleted or recovered.
        /// </summary>
        /// <param name="productsFN"></param>
        /// <param name="categoriesFN"></param>
        /// <param name="brandsFN"></param>
        /// <param name="clientsFN"></param>
        /// <param name="employeesFN"></param>
        /// <param name="managersFN"></param>
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int saleID, op;
            bool result;

            while (true)
            {
                Clear();
                DisplayHistoricMenu();
                do
                {
                    Console.Write("\nChoose an Option: ");
                    op = int.Parse(Console.ReadLine());
                    if (op == 3)
                    {
                        Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                    }

                    if (op < 1 || op > 3)
                    {
                        Clear();
                        DisplayHistoricMenu();
                        Console.WriteLine("\n\n\tInvalid Option! [1/3]\n");
                    }
                    else
                    {
                        if (op == 1)
                        {
                            Console.WriteLine("\nLets Delete a Sale!");

                            saleID = SalesIO.GetSaleID();

                            result = SalesRules.DeleteSale(saleID);
                            if (result == true)
                                Console.WriteLine("\nSale was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the sale!");

                            SalesRules.SaveSalesDataBin(salesFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Sale!");

                            saleID = SalesIO.GetSaleID();

                            result = SalesRules.RecoverSale(saleID);
                            if (result == true)
                                Console.WriteLine("\nSale was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the sale!");

                            SalesRules.SaveSalesDataBin(salesFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
        }

        /// <summary>
        /// Menu that allows for the sale to be managed.
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
            int op = 1, saleID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Products Managment Menu ---------\n");
                        if (op < 1 || op > 5)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-5]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing sales.              |");
                        Console.WriteLine("  |  2. Insert a new sale.                    |");
                        Console.WriteLine("  |  3. Remove a sale.                        |");
                        Console.WriteLine("  |  4. Show sales historic.                  |");
                        Console.WriteLine("  |  5. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 5);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            Console.WriteLine("\nTable containing the information of the existing sales.\n");
                            // Table Construction
                            Console.WriteLine("\n+--------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  DATE SALE  |  PRODUCT  |  CLIENT  |  QUANTITY  |  TOTAL PRICE  |");
                            Console.WriteLine("+--------------------------------------------------------------------------+");
                            SalesIO.ListSalesInformation(SalesRules.ReturnSalesList());
                            Console.WriteLine("+--------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {SalesRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Sale!");

                            Sale sale = new Sale();
                            sale = SalesIO.GetNewSaleInformation(sale);

                            result = SalesRules.InsertSale(sale, stockFN);

                            if (result == true)
                                Console.WriteLine("\nNew sale inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new sale!");
                            }

                            SalesRules.SaveSalesDataBin(salesFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Remove a Sale!");

                            saleID = SalesIO.GetSaleID();

                            result = SalesRules.RemoveSale(saleID);
                            if (result == true)
                                Console.WriteLine("\nSale was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the sale!");

                            SalesRules.SaveSalesDataBin(salesFN);

                            Pause();
                            break;
                        case 4:
                            LoopDisplayHistocicMenu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 5:
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
