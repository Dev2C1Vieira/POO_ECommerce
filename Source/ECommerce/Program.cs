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

        public static void Menu(Product product)
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
                            Red();
                            Console.WriteLine("\nTable containing the information of the existing products.\n");
                            // Table Construction
                            Yellow();
                            Console.WriteLine("\n+---------------------------------------------------------------+");
                            Console.WriteLine("|    CODE      NAME                 PRICE      LAUNCH DATE       |");
                            Console.WriteLine("+---------------------------------------------------------------+\n");
                            Reset();
                            IO.ListProductsInformation(Rules.ReturnProductsList());
                            //printf("\n+-----------------------------------------------------------------------------------------------+");
                            //printf("\n\nTotal sum of accessible records:");
                            //red();
                            //// this function return the amount of records in the Linked List Meios
                            //printf(" %d\n", countNonBookingRecords(meios));
                            //reset();
                            Pause();
                            break;
                        case 2:
                            IO.InsertProduct(product);
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
                Menu(product);
            }
        }

        static void Main()
        {
            Product product1 = new Product();

            product1.ProductName = "Logitech Pro X Superlight";
            product1.Price = 135.54;
            product1.LauchDate = new DateTime(2021, 09, 11);
            product1.VisibilityStatus = true;

            //try
            //{
            //    IO.InsertProduct(product1);
            //}
            //catch (Exception E)
            //{
            //    Console.WriteLine(E.Message);
            //}

            Menu(product1);
        }
    }
}