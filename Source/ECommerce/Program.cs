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
            int op = 1, field = 0, productID = 0;
            bool result = false;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Reset();
                        //Red();
                        Console.WriteLine("  --------- Welcome to ECommerce Application ---------\n");
                        Reset();
                        if (op < 1 || op > 5)
                        {
                            //Red();
                            Console.WriteLine("\n  Invalid Option! [1-5]\n");
                        }
                        //Yellow();
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing products!           |");
                        Console.WriteLine("  |  2. Insert a new product!                 |");
                        Console.WriteLine("  |  3. Update product information!           |");
                        Console.WriteLine("  |  4. Remove a product!                     |");
                        Console.WriteLine("  |  5. Exit Application!                     |");
                        Console.WriteLine("  +-------------------------------------------+\n");
                        //Red();
                        Console.WriteLine("\n\n Option: ");
                        op = int.Parse(Console.ReadLine());
                        Reset();
                    } while (op < 1 || op > 5);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Product> listingProdutcs = new List<Product>();
                            //Red();
                            Console.WriteLine("\nTable containing the information of the existing products.\n");
                            // Table Construction
                            //Yellow();
                            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  PRICE  |  LAUNCH DATE  |  WARRANTY DURARION  |  AMOUNT IN STOCK  |");
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            Reset();
                            listingProdutcs = Rules.ReturnProductsList();
                            IO.ListProductsInformation(listingProdutcs);
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {Rules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Product!");

                            Product product = new Product();
                            product = IO.GetNewProductInformation(product);

                            result = Rules.InsertProduct(product);
                            if (result == true)
                                Console.WriteLine("\nNew product inserted successfully!");
                            else
                                Console.WriteLine("\nUnable to add new product!");

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Product!");

                            productID = IO.GetProductID();

                            if (Rules.IsProductIDAvailable(productID) == false)
                            {
                                Console.WriteLine("\nProduct does not exist! ... Please enter an ID of an existing product.");
                                Pause();
                                Menu();
                            }

                            Clear();

                            //
                            Console.WriteLine("\nChoose which field you want to change:");

                            Console.WriteLine("\n  +-------------------------------------------+");
                            Console.WriteLine("  |  1. Update product Name.                  |");
                            Console.WriteLine("  |  2. Update product Description.           |");
                            Console.WriteLine("  |  3. Update product Price.                 |");
                            Console.WriteLine("  |  4. Update product Launch Date.           |");
                            Console.WriteLine("  |  5. Update product Warranty Duration.     |");
                            Console.WriteLine("  |  6. Update product Amount In Stock.       |");
                            Console.WriteLine("  |  7. Go back to Menu!                      |");
                            Console.WriteLine("  +-------------------------------------------+\n");
                            //Red();
                            Console.WriteLine("\n\n Option: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 7) { Menu(); }

                            Clear();

                            string attribut = IO.GetAttributeToUpdate(field);

                            result = Rules.UpdateProduct(field, attribut, productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the product!");

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Product!");

                            productID = IO.GetProductID();

                            result = Rules.DeleteProduct(productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the product!");

                            Pause();
                            break;
                        case 5:
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