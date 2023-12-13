/*
 * <copyright file = "Program.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:26:37 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections.Generic;

//External
using ProductCatalog;
using ECRules;
using IOData;

namespace ECommerce
{
    /// <summary>
    /// Purpose: [Write the purpose of the class
    /// Project Name: Projeto_POO_25626
    /// Created By: Pedro Vieira
    /// Created On: 26/10/2023 - 20:26:37 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    internal class Program
    {
        public static void Red() { Console.ForegroundColor = ConsoleColor.Red; }

        public static void Green() { Console.ForegroundColor = ConsoleColor.Green; }

        public static void Yellow() { Console.ForegroundColor = ConsoleColor.Yellow; }

        public static void Blue() { Console.ForegroundColor = ConsoleColor.Blue; }

        public static void Reset() { Console.ResetColor(); }

        public static void Clear() { Console.Clear(); }

        public static void Flushtdin() { while (Console.In.Peek() != -1 && Console.In.ReadLine() != null) { } }

        public static void Pause()
        {
            Flushtdin();
            Console.WriteLine("\n\nPress ");
            Red();
            Console.WriteLine("any key ");
            Reset();
            Console.WriteLine("to continue...");
            Console.ReadKey(true);
        }

        public static void Menu()
        {
            int op = -1;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Reset();
                        Red();
                        Console.WriteLine("  --------- Welcome to ECommerce Application ---------\n");
                        Reset();
                        if (op < 1 || op > 3)
                        {
                            Red();
                            Console.WriteLine("\n  Invalid Option! [1-3]\n");
                        }
                        Yellow();
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing products!           |");
                        Console.WriteLine("  |  2. Insert a new product!                 |");
                        Console.WriteLine("  |  3. Exit Application!                     |");
                        Console.WriteLine("  +-------------------------------------------+\n");
                        Red();
                        Console.WriteLine("\n\n Option: ");
                        op = Convert.ToInt16(Console.ReadLine());
                        Reset();
                    } while (op < 1 || op > 3);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Product> listingProdutcs = new List<Product>();
                            Red();
                            Console.WriteLine("\nTable containing the information of the existing products.\n");
                            // Table Construction
                            Yellow();
                            Console.WriteLine("\n+---------------------------------------------------------------+");
                            Console.WriteLine("|    CODE      NAME                 PRICE      LAUNCH DATE       |");
                            Console.WriteLine("+---------------------------------------------------------------+\n");
                            Reset();
                            listingProdutcs = Rules.ReturnProductsList();
                            IO.ListProductsInformation(listingProdutcs);
                            Console.WriteLine("\n+---------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {Rules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Product product = new Product();
                            product = IO.GetNewProductInformation(product);

                            Console.WriteLine("\nLets Insert new Product!");

                            bool result = Rules.InsertProduct(product);
                            if (result == true)
                                Console.WriteLine("\nNew product inserted successfully!");
                            else
                                Console.WriteLine("\nUnable to add new product!");
                            break;
                        case 3:
                            Environment.Exit(0);
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

        static void Main()
        {
            Menu();
        }
    }
}