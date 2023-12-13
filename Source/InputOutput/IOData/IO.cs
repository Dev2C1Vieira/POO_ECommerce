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
using System.Collections.Generic;
using System.Globalization;

// External
using ProductCatalog;

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

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static Product GetNewProductInformation(Product product)
        {
            Console.WriteLine("\nEnter Product Name:");
            product.ProductName = Console.ReadLine();

            Console.WriteLine("\nEnter Product Description:");
            product.ProductDescription = Console.ReadLine();

            Console.WriteLine("\nEnter Product Price:");
            product.Price = float.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Product Launch Date (dd-MM-yyyy):");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            product.LauchDate = launchDate;

            Console.WriteLine("\nEnter Product Warranty Duration:");
            product.WarrantyDuration = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Product Amount in Stock:");
            product.AmountInStock = int.Parse(Console.ReadLine());

            product.VisibilityStatus = true;

            return product;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
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