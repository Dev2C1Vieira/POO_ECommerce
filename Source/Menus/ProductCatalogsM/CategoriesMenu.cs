/*
 * <copyright file = "CategoriesMenu.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 9:28:56 PM </date>
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
    /// Created On: 12/17/2023 9:28:56 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class CategoriesMenu
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
        public static void DisplayHistocicMenu()
        {
            List<Category> listingCategories = new List<Category>();
            Console.WriteLine("\nTable containing the information of the existing categories.\n");
            // Table Construction
            Console.WriteLine("\n+---------------------------------------------------+");
            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  CREATION DATE  |");
            Console.WriteLine("+---------------------------------------------------+");
            listingCategories = CategoriesRules.ReturnHistoric();
            CategoriesIO.ListHistoric(listingCategories);
            Console.WriteLine("+---------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {CategoriesRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Products Menu.        |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN)
        {
            int categoryID, op;
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
                        Menu(productsFN, categoriesFN, brandsFN, clientsFN);
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
                            Console.WriteLine("\nLets Delete a Category!");

                            categoryID = CategoriesIO.GetCategoryID();

                            result = CategoriesRules.DeleteCategory(categoryID);
                            if (result == true)
                                Console.WriteLine("\nCategory was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the category!");

                            CategoriesRules.SaveCategoriesDataBin(categoriesFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Category!");

                            categoryID = CategoriesIO.GetCategoryID();

                            result = CategoriesRules.RecoverCategory(categoryID);
                            if (result == true)
                                Console.WriteLine("\nCategory was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the category!");

                            CategoriesRules.SaveCategoriesDataBin(categoriesFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN)
        {
            int op = 1, field, categoryID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Categories Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing categories.         |");
                        Console.WriteLine("  |  2. Insert a new category.                |");
                        Console.WriteLine("  |  3. Update category information.          |");
                        Console.WriteLine("  |  4. Remove a category.                    |");
                        Console.WriteLine("  |  5. Show categories historic.             |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Category> listingCategories = new List<Category>();
                            Console.WriteLine("\nTable containing the information of the existing categories.\n");
                            // Table Construction
                            Console.WriteLine("\n+---------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  CREATION DATE  |");
                            Console.WriteLine("+---------------------------------------------------+");
                            listingCategories = CategoriesRules.ReturnCategoriesList();
                            CategoriesIO.ListCategoriesInformation(listingCategories);
                            Console.WriteLine("+---------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {CategoriesRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Category!");

                            Category category = new Category();
                            category = CategoriesIO.GetNewCategoryInformation(category);

                            result = CategoriesRules.InsertCategory(category);

                            if (result == true)
                                Console.WriteLine("\nNew category inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new category!");
                            }

                            CategoriesRules.SaveCategoriesDataBin(categoriesFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Category!");

                            categoryID = CategoriesIO.GetCategoryID();

                            if (CategoriesRules.IsCategoryIDAvailable(categoryID) == false)
                            {
                                Console.WriteLine("\nCategory does not exist! ... Please enter an ID of an existing category.");
                                Pause();
                                Menu(productsFN, categoriesFN, brandsFN, clientsFN);
                            }

                            Clear();

                            //
                            Console.WriteLine("\nChoose which field you want to change:");

                            Console.WriteLine("\n  +-------------------------------------------+");
                            Console.WriteLine("  |  1. Update category Name.                 |");
                            Console.WriteLine("  |  2. Update category Description.          |");
                            Console.WriteLine("  |  3. Update category Creation Date.        |");
                            Console.WriteLine("  |  4. Back!                                 |");
                            Console.WriteLine("  +-------------------------------------------+");
                            Console.Write("\nOption: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 7) { Menu(productsFN, categoriesFN, brandsFN, clientsFN); }

                            Clear();

                            string attribute = ProductsIO.GetAttributeToUpdate(field);

                            result = CategoriesRules.UpdateCategory(field, attribute, categoryID);
                            if (result == true)
                                Console.WriteLine("\nCategory was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the category!");

                            CategoriesRules.SaveCategoriesDataBin(categoriesFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Category!");

                            categoryID = CategoriesIO.GetCategoryID();

                            result = CategoriesRules.RemoveCategory(categoryID);
                            if (result == true)
                                Console.WriteLine("\nCategory was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the category!");

                            CategoriesRules.SaveCategoriesDataBin(categoriesFN);

                            Pause();
                            break;
                        case 5:
                            LoopDisplayHistocicMenu(productsFN, categoriesFN, brandsFN, clientsFN);
                            break;
                        case 6:
                            PCMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN);
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
