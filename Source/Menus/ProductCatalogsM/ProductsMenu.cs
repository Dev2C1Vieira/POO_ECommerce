/*
 * <copyright file = "ProductsMenu.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/16/2023 8:42:47 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;

//  External
using ProductCatalog;
using ProductCatalogR;
using IOData;

namespace ProductCatalogsM
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/16/2023 8:42:47 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class ProductsMenu
    {
        public static void Clear() { Console.Clear(); }

        public static void Flushtdin() { while (Console.In.Peek() != -1 && Console.In.ReadLine() != null) { } }

        public static void Pause()
        {
            Flushtdin();
            Console.WriteLine("\n\nPress ");
            //Red();
            Console.WriteLine("any key ");
            //Reset();
            Console.WriteLine("to continue...");
            Console.ReadKey(true);
        }

        public static void Menu(string fileName)
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
                        Console.WriteLine("  --------- Welcome to ECommerce Application ---------\n");
                        if (op < 1 || op > 7)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-7]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing products.           |");
                        Console.WriteLine("  |  2. Insert a new product.                 |");
                        Console.WriteLine("  |  3. Update product information.           |");
                        Console.WriteLine("  |  4. Remove a product.                     |");
                        Console.WriteLine("  |  5. Exit Application!                     |");
                        Console.WriteLine("  +-------------------------------------------+\n");
                        Console.WriteLine("\n\n Option: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 7);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Product> listingProdutcs = new List<Product>();
                            Console.WriteLine("\nTable containing the information of the existing products.\n");
                            // Table Construction
                            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  PRICE  |  LAUNCH DATE  |  WARRANTY DURARION  |  AMOUNT IN STOCK  |");
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            listingProdutcs = ProductsRules.ReturnProductsList();
                            IO.ListProductsInformation(listingProdutcs);
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {ProductsRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Product!");

                            Product product = new Product();
                            product = IO.GetNewProductInformation(product);

                            result = ProductsRules.InsertProduct(product);

                            if (result == true)
                                Console.WriteLine("\nNew product inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new product!");
                            }

                            ProductsRules.SaveProductsDataBin(fileName);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Product!");

                            productID = IO.GetProductID();

                            if (ProductsRules.IsProductIDAvailable(productID) == false)
                            {
                                Console.WriteLine("\nProduct does not exist! ... Please enter an ID of an existing product.");
                                Pause();
                                Menu(fileName);
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
                            Console.WriteLine("\n\n Option: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 7) { Menu(fileName); }

                            Clear();

                            string attribut = IO.GetAttributeToUpdate(field);

                            result = ProductsRules.UpdateProduct(field, attribut, productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the product!");

                            ProductsRules.SaveProductsDataBin(fileName);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Product!");

                            productID = IO.GetProductID();

                            result = ProductsRules.DeleteProduct(productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the product!");

                            ProductsRules.SaveProductsDataBin(fileName);

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
                Menu(fileName);
            }
        }
    }
}
