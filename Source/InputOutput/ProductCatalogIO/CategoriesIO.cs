/*
 * <copyright file = "CategoriesIO.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 10:44:30 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using ProductCatalog;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ProductCatalogIO
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/17/2023 10:44:30 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class CategoriesIO
    {
        #region Methods

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static Category GetNewCategoryInformation(Category category)
        {
            Console.Write("\nEnter category Name: ");
            category.CategoryName = Console.ReadLine();

            Console.Write("\nEnter category Description: ");
            category.CategoryDescription = Console.ReadLine();

            Console.Write("\nEnter category Creation Date (dd-MM-yyyy): ");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            category.CreationDate = launchDate;

            category.VisibilityStatus = true;

            return category;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoriesList"></param>
        /// <returns></returns>
        public static bool ListCategoriesInformation(List<Category> categoriesList)
        {
            if (categoriesList.Count == 0)
            {
                Console.WriteLine("|     The categories list is empty!     |");
                return false;
            }
            foreach (Category ca in categoriesList)
            {
                Console.WriteLine($"|  {ca.CategoryID}  |  {ca.CategoryName}  |  {ca.CategoryDescription}  |  {ca.CreationDate.ToShortDateString()}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Category> categoriesList)
        {
            if (categoriesList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Category ca in categoriesList)
            {
                Console.WriteLine($"|  {ca.CategoryID}  |  {ca.CategoryName}  |  {ca.CategoryDescription}  |  {ca.CreationDate.ToShortDateString()}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetCategoryID()
        {
            Console.Write("\nEnter Category ID: ");
            int categoryID = int.Parse(Console.ReadLine());

            return categoryID;
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
                Console.Write("\nEnter category new Name: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.Write("\nEnter category new Description: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.Write("\nEnter category new Creation Date (dd-MM-yyyy): ");
                newAttribute = Console.ReadLine();
            }
            return newAttribute;
        }

        #endregion
    }
}
