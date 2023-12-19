/*
 * <copyright file = "BrandsIO.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/18/2023 7:56:37 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Globalization;
using System.Collections.Generic;

// External
using ProductCatalog;

namespace ProductCatalogIO
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/18/2023 7:56:37 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class BrandsIO
    {
        #region Methods

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static Brand GetNewBrandInformation(Brand brand)
        {
            Console.Write("\nEnter brand Name: ");
            brand.BrandName = Console.ReadLine();

            Console.Write("\nEnter product Description: ");
            brand.BrandDescription = Console.ReadLine();

            Console.Write("\nEnter product Origin Country: ");
            brand.OriginCountry = Console.ReadLine();

            Console.Write("\nEnter product Fundation Date (dd-MM-yyyy): ");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            brand.FundationDate = launchDate;

            brand.VisibilityStatus = true;

            return brand;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListBrandsInformation(List<Brand> brandsList)
        {
            if (brandsList.Count == 0)
            {
                Console.WriteLine("|     The brands list is empty!     |");
                return false;
            }
            foreach (Brand br in brandsList)
            {
                Console.WriteLine($"|  {br.BrandID}  |  {br.BrandName}  |  {br.BrandDescription}  |  {br.OriginCountry}  |  {br.FundationDate.ToShortDateString()}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Brand> brandsList)
        {
            if (brandsList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Brand br in brandsList)
            {
                Console.WriteLine($"|  {br.BrandID}  |  {br.BrandName}  |  {br.BrandDescription}  |  {br.OriginCountry}  |  {br.FundationDate.ToShortDateString()}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetBrandID()
        {
            Console.Write("\nEnter Brand ID: ");
            int brandID = int.Parse(Console.ReadLine());

            return brandID;
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
                Console.Write("\nEnter brand new Name: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.Write("\nEnter brand new Description: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.Write("\nEnter brand new origin Country: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 4)
            {
                Console.Write("\nEnter brand new Fundation Date (dd-MM-yyyy): ");
                newAttribute = Console.ReadLine();
            }

            return newAttribute;
        }

        #endregion
    }
}
