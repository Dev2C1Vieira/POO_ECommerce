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

// External
using ProductCatalog;
using ProductCatalogR;
using ProductCatalogIO;

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
        /// Menu that list the products present in the products historic
        /// </summary>
        public static void DisplayHistocicMenu()
        {
            Console.WriteLine("\nTable containing the information of the products historic.\n");
            // Table Construction
            Console.WriteLine("\n+---------------------------------------------------------------------------------+");
            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  PRICE  |  LAUNCH DATE  |  WARRANTY DURARION  |");
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            ProductsIO.ListHistoric(ProductsRules.ReturnHistoric());
            Console.WriteLine("+---------------------------------------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {ProductsRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Products Menu.        |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
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
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int productID, op;
            bool result;

            while (true)
            {
                Clear();
                DisplayHistocicMenu();
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
                        DisplayHistocicMenu();
                        Console.WriteLine("\n\n\tInvalid Option! [1/3]\n");
                    }
                    else
                    {
                        if (op == 1)
                        {
                            Console.WriteLine("\nLets Delete a Product!");

                            productID = ProductsIO.GetProductID();

                            result = ProductsRules.DeleteProduct(productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the product!");

                            ProductsRules.SaveProductsDataBin(productsFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Product!");

                            productID = ProductsIO.GetProductID();

                            result = ProductsRules.RecoverProduct(productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the product!");

                            ProductsRules.SaveProductsDataBin(productsFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
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
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1, field, productID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Products Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing products.           |");
                        Console.WriteLine("  |  2. Insert a new product.                 |");
                        Console.WriteLine("  |  3. Update product information.           |");
                        Console.WriteLine("  |  4. Remove a product.                     |");
                        Console.WriteLine("  |  5. Show products historic.               |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Product> listingProdutcs = new List<Product>();
                            Console.WriteLine("\nTable containing the information of the existing products.\n");
                            // Table Construction
                            Console.WriteLine("\n+---------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  PRICE  |  LAUNCH DATE  |  WARRANTY DURARION  |");
                            Console.WriteLine("+---------------------------------------------------------------------------------+");
                            listingProdutcs = ProductsRules.ReturnProductsList();
                            ProductsIO.ListProductsInformation(listingProdutcs);
                            Console.WriteLine("+---------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {ProductsRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Product!");

                            Product product = new Product();
                            product = ProductsIO.GetNewProductInformation(product);

                            result = ProductsRules.InsertProduct(product);

                            if (result == true)
                                Console.WriteLine("\nNew product inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new product!");
                            }

                            ProductsRules.SaveProductsDataBin(productsFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Product!");

                            productID = ProductsIO.GetProductID();

                            if (ProductsRules.IsProductIDAvailable(productID) == false)
                            {
                                Console.WriteLine("\nProduct does not exist! ... Please enter an ID of an existing product.");
                                Pause();
                                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
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
                            Console.WriteLine("  |  7. Back!                                 |");
                            Console.WriteLine("  +-------------------------------------------+");
                            Console.Write("\nOption: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 7) { Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN); }

                            Clear();

                            string attribute = ProductsIO.GetAttributeToUpdate(field);

                            result = ProductsRules.UpdateProduct(field, attribute, productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the product!");

                            ProductsRules.SaveProductsDataBin(productsFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Product!");

                            productID = ProductsIO.GetProductID();

                            result = ProductsRules.RemoveProduct(productID);
                            if (result == true)
                                Console.WriteLine("\nProduct was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the product!");

                            ProductsRules.SaveProductsDataBin(productsFN);

                            Pause();
                            break;
                        case 5:
                            LoopDisplayHistocicMenu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 6:
                            PCMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
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
