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
            Console.Write("\nEnter product Name: ");
            product.ProductName = Console.ReadLine();

            Console.Write("\nEnter product Description: ");
            product.ProductDescription = Console.ReadLine();

            Console.Write("\nEnter product Price: ");
            product.Price = float.Parse(Console.ReadLine());

            Console.Write("\nEnter product Launch Date (dd-MM-yyyy): ");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            product.LauchDate = launchDate;

            Console.Write("\nEnter product Warranty Duration:");
            product.WarrantyDuration = int.Parse(Console.ReadLine());

            Console.Write("\nEnter product Amount in Stock:");
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
            if (productsList.Count == 0)
            {
                Console.WriteLine("\n|     The product list is empty!   |");
                return false;
            }
            foreach (Product po in productsList)
            {
                if (po.VisibilityStatus == true)
                    Console.WriteLine($"|  {po.ProductID}  |  {po.ProductName}  |  {po.ProductDescription}  |  {po.Price.ToString("F2")}  |  {po.LauchDate.ToShortDateString()}  |  {po.WarrantyDuration}  |  {po.AmountInStock}  |");
                else continue;
            }
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetProductID()
        {
            Console.WriteLine("\nEnter Product ID:");
            int productID = int.Parse(Console.ReadLine());

            return productID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <returns></returns>
        public static string GetAttributeToUpdate(int fieldToUpdate)
        {
            string newAttribute = string.Empty;
            if (fieldToUpdate == 1)
            {
                Console.WriteLine("\nEnter product new Name:");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.WriteLine("\nEnter product new Description:");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.WriteLine("\nEnter product new Price:");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 4)
            {
                Console.WriteLine("\nEnter product new Launch Date (dd-MM-yyyy):");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 5)
            {
                Console.WriteLine("\nEnter product new Warranty Duration:");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 6)
            {
                Console.WriteLine("\nEnter product new Amount in Stock:");
                newAttribute = Console.ReadLine();
            }

            return newAttribute;
        }

        #endregion

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}