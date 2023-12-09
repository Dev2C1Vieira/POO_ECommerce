/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 7:07:33 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using ProductCatalog;
using ProductCatalogs;
using ECRules;
using System.Collections.Generic;

namespace IOData
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 7:07:33 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class IO
    {
        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor
        /// </summary>
        public IO() { }

        #endregion

        #region OtherMethods

        #region ProductCatalogMethods

        #region ProductsMethods

        public static bool InsertProduct(Product product)
        {
            Console.WriteLine("\nEnter Product Name: ");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("\nEnter Product Price:");
            product.Price = float.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Product Launch Date:");
            Console.WriteLine("\nEnter Day (dd):");
            int launchday = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\nEnter Month (mm):");
            int launchmonth = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\nEnter Year (yyyy):");
            int launchyear = Convert.ToInt16(Console.ReadLine());

            product.LauchDate = new DateTime(launchyear, launchmonth, launchday);

            product.VisibilityStatus = true;

            Rules.InsertProduct(product);

            return true;
        }

        public static bool ListProductsInformation(List<Product> productsList)
        {
            foreach (Product po in productsList)
            {
                if (po.VisibilityStatus == true)
                    Console.WriteLine($"\n|     {po.ProductID} {po.ProductName} {po.Price} {po.LauchDate.ToShortDateString()}   |");
                continue;
            }
            return true;
        }

        #endregion

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}