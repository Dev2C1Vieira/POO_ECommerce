/*
 * <copyright file = "BrandsMenu.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/18/2023 8:18:24 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;

// External
using ProductCatalog;
using ProductCatalogIO;
using ProductCatalogR;

namespace ProductCatalogsM
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/18/2023 8:18:24 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class BrandsMenu
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
            List<Brand> listingBrands = new List<Brand>();
            Console.WriteLine("\nTable containing the information of the existing brands.\n");
            // Table Construction
            Console.WriteLine("\n+---------------------------------------------------------------------+");
            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  ORIGIN COUNTRY  |  FUNDATION DATE  |");
            Console.WriteLine("+-----------------------------------------------------------------------+");
            listingBrands = BrandsRules.ReturnHistoric();
            BrandsIO.ListHistoric(listingBrands);
            Console.WriteLine("+-----------------------------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {BrandsRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Products Menu.        |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// 
        /// </summary>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int brandID, op;
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
                            Console.WriteLine("\nLets Delete a Brand!");

                            brandID = BrandsIO.GetBrandID();

                            result = BrandsRules.DeleteBrand(brandID);
                            if (result == true)
                                Console.WriteLine("\nBrand was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the brand!");

                            BrandsRules.SaveBrandsDataBin(brandsFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Brand!");

                            brandID = BrandsIO.GetBrandID();

                            result = BrandsRules.RecoverBrand(brandID);
                            if (result == true)
                                Console.WriteLine("\nBrand was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the brand!");

                            BrandsRules.SaveBrandsDataBin(brandsFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1, field, brandID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Brands Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing brands.             |");
                        Console.WriteLine("  |  2. Insert a new brand.                   |");
                        Console.WriteLine("  |  3. Update brand information.             |");
                        Console.WriteLine("  |  4. Remove a brand.                       |");
                        Console.WriteLine("  |  5. Show brands historic.                 |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Brand> listingBrands = new List<Brand>();
                            Console.WriteLine("\nTable containing the information of the existing brands.\n");
                            // Table Construction
                            Console.WriteLine("\n+---------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  DESCRIPTION  |  ORIGIN COUNTRY  |  FUNDATION DATE  |");
                            Console.WriteLine("+-----------------------------------------------------------------------+");
                            listingBrands = BrandsRules.ReturnBrandsList();
                            BrandsIO.ListHistoric(listingBrands);
                            Console.WriteLine("+-----------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {BrandsRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Brand!");

                            Brand brand = new Brand();
                            brand = BrandsIO.GetNewBrandInformation(brand);

                            result = BrandsRules.InsertBrand(brand);

                            if (result == true)
                                Console.WriteLine("\nNew brand inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new brand!");
                            }

                            BrandsRules.SaveBrandsDataBin(brandsFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Brand!");

                            brandID = BrandsIO.GetBrandID();

                            if (BrandsRules.IsBrandIDAvailable(brandID) == false)
                            {
                                Console.WriteLine("\nBrand does not exist! ... Please enter an ID of an existing brand.");
                                Pause();
                                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            }

                            Clear();

                            //
                            Console.WriteLine("\nChoose which field you want to change:");

                            Console.WriteLine("\n  +-------------------------------------------+");
                            Console.WriteLine("  |  1. Update product Name.                  |");
                            Console.WriteLine("  |  2. Update product Description.           |");
                            Console.WriteLine("  |  3. Update product Origin Country.        |");
                            Console.WriteLine("  |  4. Update product Launch Date.           |");
                            Console.WriteLine("  |  5. Back!                                 |");
                            Console.WriteLine("  +-------------------------------------------+");
                            Console.Write("\nOption: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 7) { Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN); }

                            Clear();

                            string attribute = BrandsIO.GetAttributeToUpdate(field);

                            result = BrandsRules.UpdateBrand(field, attribute, brandID);
                            if (result == true)
                                Console.WriteLine("\nBrand was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the brand!");

                            BrandsRules.SaveBrandsDataBin(brandsFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Brand!");

                            brandID = BrandsIO.GetBrandID();

                            result = BrandsRules.RemoveBrand(brandID);
                            if (result == true)
                                Console.WriteLine("\nBrand was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the brand!");

                            BrandsRules.SaveBrandsDataBin(brandsFN);

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
