/*
 * <copyright file = "REMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/23/2023 8:31:33 PM </date>
 * <description></description>
 * 
 * */

using System;

// External
using StaffMenu;

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
    public class REMenu
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

        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN, string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Staff Client System Menu ---------\n");
                        if (op < 1 || op > 3)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-3]\n");
                        }
                        Console.WriteLine("\nHere you need to choose one of the options!");
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. Manage Stock.                         |");
                        Console.WriteLine("  |  2. Manage Sales!                         |");
                        Console.WriteLine("  |  3. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 3);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            StocksMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 2:
                            Console.WriteLine("Not working yet!");
                            Pause();
                            break;
                        case 3:
                            EmployeeMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
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
