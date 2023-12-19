/*
 * <copyright file = "EmployeeMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 5:20:13 PM </date>
 * <description></description>
 * 
 * */

using System;

// External
using ECMenus;
using ProductCatalogsM;
using StaffClientSystemsM;

namespace StaffMenu
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class EmployeeMenu
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
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN)
        {
            int op = 1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Employee Menu ---------\n");
                        if (op < 1 || op > 4)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-4]\n");
                        }
                        Console.WriteLine("\nHere you need to choose one of the options!");
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. Manage Product Catalog.               |");
                        Console.WriteLine("  |  2. Manage Staff Client Systems.          |");
                        Console.WriteLine("  |  3. Manage Revenue Engines.               |");
                        Console.WriteLine("  |  4. Return Main Menu.                     |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 4);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            PCMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN);
                            break;
                        case 2:
                            SCSMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN);
                            break;
                        case 3:
                            // Menu
                            break;
                        case 4:
                            MainMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN);
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
                Menu(productsFN, categoriesFN, brandsFN, clientsFN);
            }
        }

        #endregion
    }
}
