/*
 * <copyright file = "PCMenu.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 11:38:47 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;

// External
using StaffMenu;

namespace ProductCatalogsM
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/17/2023 11:38:47 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class PCMenu
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

        public static void Menu()
        {
            int op = 1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Product Catalog Menu ---------\n");
                        if (op < 1 || op > 4)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-4]\n");
                        }
                        Console.WriteLine("\nHere you need to choose one of the options!");
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. Manage Procucts.                      |");
                        Console.WriteLine("  |  2. Manage Categories.                    |");
                        Console.WriteLine("  |  3. Manage Brands.                        |");
                        Console.WriteLine("  |  4. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 4);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            ProductsMenu.Menu();
                            break;
                        case 2:
                            CategoriesMenu.Menu();
                            break;
                        case 3:
                            BrandsMenu.Menu();
                            break;
                        case 4:
                            EmployeeMenu.Menu();
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
                Menu();
            }
        }

        #endregion
    }
}
