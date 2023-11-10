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
using ClientsDLL;
using ProductCatalog;
using InputConsoleOutput;

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
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to ECommerce Application!");

            #region Inicial_Trial

            #region Clients

            Console.WriteLine("\n------------------ Clients Section ------------------\n");

            Clients client1 = new Clients();
            Clients client2 = new Clients();

            client1.Name = "Pedro Vieira";
            client1.Gender = true;
            client1.BirthDate = new DateTime(2004, 09, 15, 02, 34, 54);
            client1.Address = "Rua das Flores, 123";
            client1.PhoneNumber = 916735615;
            client1.EmailAddress = "a25626@alunos.ipca.pt";

            client2.Name = "Albina Soares";
            client2.Gender = false;
            client2.BirthDate = new DateTime(1993, 03, 07, 14, 13, 39);
            client2.Address = "Rua das Crostacios, 231";
            client2.PhoneNumber = 914826352;
            client2.EmailAddress = "a28514@alunos.ipca.pt";

            IO.ShowClientInformation(client1);
            IO.ShowClientInformation(client2);

            if (IO.CompareClients(client1, client2) == true)//not working properly
                Console.WriteLine("\nThe clientes are equal!\n");
            else
                Console.WriteLine("\nThe clientes are not equal!\n");

            #endregion

            #region ProductCatalog

            #region Products

            Console.WriteLine("\n------------------ Products Section ------------------\n");

            Products product1 = new Products();
            Products product2 = new Products();
            Products product3 = new Products();

            product1.ProductName = "Rato Logitech Pro X Superlight";
            product1.Price = 120.39;
            product1.LauchDate = new DateTime(2022, 12, 03);
            product1.VisibilityStatus = true;

            product2.ProductName = "Auscultadores Logitech Pro X Wireless";
            product2.Price = 189.99;
            product2.LauchDate = new DateTime(2022, 09, 17);
            product2.VisibilityStatus = false;

            product3.ProductName = "Teclado Logitech X Pro Wireless";
            product3.Price = 221.79;
            product3.LauchDate = new DateTime(2022, 11, 21);
            product3.VisibilityStatus = true;

            IO.ShowProductInformation(product1);
            IO.ShowProductInformation(product2);
            IO.ShowProductInformation(product3);

            if ((IO.IsProductAvailable(product1) == true) && (IO.IsProductAvailable(product3) == true))
            {
                if (IO.CompareProducts(product1, product3))
                    Console.WriteLine("\nThe {0} and {1} products whose IDs are respectively {2} and {3} are equal.\n",
                        product1.ProductName, product3.ProductName, product1.ProductID, product3.ProductID);
                else
                    Console.WriteLine("\nThe {0} and {1} products whose IDs are respectively {2} and {3} are not equal.\n",
                        product1.ProductName, product3.ProductName, product1.ProductID, product3.ProductID);
            }
            else Console.WriteLine("\nUnable to compare Products!\n");

            #endregion

            #region Categories

            Console.WriteLine("\n------------------ Categories Section ------------------\n");

            DateTime c1_creationDate = new DateTime(2018, 07, 25);
            Categories category1 = new Categories("Gaming Mouse", true, c1_creationDate, 1);
            DateTime c2_creationDate = new DateTime(2019, 03, 17);
            Categories category2 = new Categories("Gaming Keyboard", false, c2_creationDate, 2);

            IO.ShowCategoryInformation(category1);
            IO.ShowCategoryInformation(category2);

            if ((IO.IsCategoryAvailable(category1) == true) && (IO.IsCategoryAvailable(category2) == true))
            {
                if (IO.CompareCategories(category1, category2))
                    Console.WriteLine("\nThe {0} and {1} categories whose IDs are respectively {2} and {3} are equal.\n",
                        category1.CategoryName, category2.CategoryName, category1.CategoryID, category2.CategoryID);
                else
                    Console.WriteLine("\nThe {0} and {1} categories whose IDs are respectively {2} and {3} are not equal.\n",
                        category1.CategoryName, category2.CategoryName, category1.CategoryID, category2.CategoryID);
            }
            else Console.WriteLine("\nUnable to compare Categories!\n");

            #endregion

            #region Brands

            Console.WriteLine("\n------------------ Brands Section ------------------\n");

            DateTime b1_fundationDate = new DateTime(2017, 03, 21);
            DateTime b1_creationDate = new DateTime(2023, 11, 10);
            Brands brand1 = new Brands("Logitech", "Lausanne, Suíça", b1_fundationDate, true, b1_creationDate);
            DateTime b2_fundationDate = new DateTime(2013, 07, 03);
            DateTime b2_creationDate = new DateTime(2023, 11, 10);
            Brands brand2 = new Brands("Sony", "Tóquio, Japão", b2_fundationDate, true, b2_creationDate);

            IO.ShowBrandInformation(brand1);
            IO.ShowBrandInformation(brand2);

            if ((IO.IsBrandAvailable(brand1) == true) && (IO.IsBrandAvailable(brand2) == true))
            {
                if (IO.CompareBrands(brand1, brand2))
                    Console.WriteLine("\nThe {0} and {1} brands whose IDs are respectively {2} and {3} are equal.\n", 
                        brand1.BrandName, brand2.BrandName, brand1.BrandID, brand2.BrandID);
                else
                    Console.WriteLine("\nThe {0} and {1} brands whose IDs are respectively {2} and {3} are not equal.\n", 
                        brand1.BrandName, brand2.BrandName, brand1.BrandID, brand2.BrandID);
            }
            else Console.WriteLine("\nUnable to compare Brands!\n");

            #endregion

            #endregion

            #endregion
        }
    }
}
