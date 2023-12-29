/*
 * <copyright file = "ManagerMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 6:13:31 PM </date>
 * <description></description>
 * 
 * */

using System;

// External
using ECMenus;
using RevenueEnginesM;
using ProductCatalogsM;
using StaffClientSystemR;
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
    public class ManagerMenu
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
        public static void LoginMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            char op;
            string workEmail, password;

            while (true)
            {
                Clear();
                Console.WriteLine("Enter the needed information!\n\n");

                Console.Write("Enter your Work Email: ");
                workEmail = Console.ReadLine();

                Console.Write("Enter your Password: ");
                password = Console.ReadLine();

                if (!ManagersRules.LoginManager(workEmail, password, out string name))
                {
                    Console.WriteLine("\nYour information is incorrect!");
                    Console.WriteLine("\n\nPlease try again...");

                    // Keep trying loop or exit login loop
                    do
                    {
                        Console.WriteLine("\n\n  Try Again (y/n): ");
                        op = char.Parse(Console.ReadLine());
                        if ((!(op == 'y')) && (!(op == 'n')))
                        {
                            Clear();
                            Console.WriteLine("\nInvalid Option! [y/n]\n");
                        }
                        else
                        {
                            if (op == 'y')
                            {   // Compare first character of op with 'y'
                                LoginMenu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            }
                            else
                            {
                                MainMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            }
                        }
                    } while ((!(op == 'y')) && (!(op == 'n')));
                }
                else
                {
                    Clear();
                    Console.WriteLine($"\nWelcome {name}!\n");
                    Pause();
                    Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Manager Menu ---------\n");
                        if (op < 1 || op > 4)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-4]\n");
                        }
                        Console.WriteLine("\nHere you need to choose one of the options!");
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. Manage Product Catalog.               |");
                        Console.WriteLine("  |  2. Manage Staff Client Systems.          |");
                        Console.WriteLine("  |  3. Manage Revenue Engines.               |");
                        Console.WriteLine("  |  4. Return to Main Menu.                  |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 4);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            PCMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 2:
                            SCSMMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 3:
                            REMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 4:
                            MainMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
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
