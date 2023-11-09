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
using ClientsDLL;
using ProductCatalog;

namespace InputConsoleOutput
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

        #region ClientsMethods

        /// <summary>
        /// This method lists the indicated Client's information in the console.
        /// </summary>
        /// <param name="client"></param>
        public static void ShowClientInformation(Clients client)
        {
            if (client.Gender == true)
                Console.WriteLine("\nID: {0}" + "\n" + "Name: {1}" + "\n" + "Gender: Male" + "\n" +
                    "Birth Date: {2}" + "\n" + "Address: {3}" + "\n" + "Phone Number: {4}" + "\n" +
                    "Email Address: {5}", client.ID.ToString(), client.Name, client.BirthDate.ToString(),
                    client.Address, client.PhoneNumber.ToString(), client.EmailAddress);
            else
                Console.WriteLine("\nID: {0}" + "\n" + "Name: {1}" + "\n" + "Gender: Female" + "\n" +
                    "Birth Date: {2}" + "\n" + "Address: {3}" + "\n" + "Phone Number: {4}" + "\n" +
                    "Email Address: {5}", client.ID.ToString(), client.Name, client.BirthDate.ToString(),
                    client.Address, client.PhoneNumber.ToString(), client.EmailAddress);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two Clients, indicated by parameter.
        /// </summary>
        /// <param name="client1"></param>
        /// <param name="client2"></param>
        /// <returns></returns>
        public static bool CompareClients(Clients client1, Clients client2)
        {
            if (client1.Equals(client2)) return (true);
            else return (false);
        }

        #endregion

        #region ProductCatalogMethods

        #region ProductsMethods

        /// <summary>
        /// This method lists the indicated product's information in the console.
        /// </summary>
        /// <param name="product"></param>
        public static void ShowProductInformation(Products product)
        {
            Console.WriteLine("\nProduct ID: {0}" + "\n" + "Product Name: {1}" + "\n" + "Price: {2}" + "\n" +
                "Launch Date: {3}", product.ProductID.ToString(), product.ProductName,
                product.Price.ToString(), product.LauchDate.ToString());
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two Products, indicated by parameter.
        /// </summary>
        /// <param name="product1"></param>
        /// <param name="product2"></param>
        /// <returns></returns>
        public static bool CompareProducts(Products product1, Products product2)
        {
            if (product1.Equals(product2)) return (true);
            else return (false);
        }

        #endregion

        #region CategoriesMethods

        /// <summary>
        /// This method lists the indicated Category's information in the console.
        /// </summary>
        /// <param name="category"></param>
        public static void ShowCategoryInformation(Categories category)
        {
            if (category.VisibilityStatus == true)
                Console.WriteLine("\nCategory ID: {0}" + "\n" + "Category Name: {1}" + "\n" + "Visibility Status: {2}" + "\n" +
                "Creation Date: {3}" + "\n" + "Display Order: {4}", category.CategoryID.ToString(), category.CategoryName,
                category.VisibilityStatus.ToString(), category.CreationDate.ToString(), category.DisplayOrder.ToString());
            else
                Console.WriteLine("\nIt was not possible to list this category as its visibility status is unavailable.");
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two Categories, indicated by parameter.
        /// </summary>
        /// <param name="category1"></param>
        /// <param name="category2"></param>
        /// <returns></returns>
        public static bool CompareCategories(Categories category1, Categories category2)
        {
            if (category1.Equals(category2)) return (true);
            else return (false);
        }

        #endregion

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
