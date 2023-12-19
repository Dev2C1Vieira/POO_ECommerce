/*
 * <copyright file = "BrandsRules.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/18/2023 7:04:55 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

// External
using ProductCatalog;
using ProductCatalogE;
using ProductCatalogs;

namespace ProductCatalogR
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/18/2023 7:04:55 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class BrandsRules
    {
        #region Methods

        /// <summary>
        /// Method that returns the number of elements present in the brand list.
        /// </summary>
        /// <returns></returns>
        public static bool IsBrandIDAvailable(int brandID)
        {
            try
            {
                return Brands.IsBrandIDAvailable(brandID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated brand ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the brand list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Brands.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of brands present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the products historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Brands.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of brands present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the brand, whether it respects business rules.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertBrand(Brand brand)
        {
            try
            {
                brand.BrandID = Brands.ReturnIDNewBrand();
                Brands.InsertBrand(brand);
                return true;
            }
            catch (BrandException BE)
            {
                throw new BrandException("\nFailure of Business Rules!" + "-" + BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new brand!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the brands list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Brand> ReturnBrandsList()
        {
            try
            {
                return Brands.ReturnBrandsList();
            }
            catch (BrandException BE)
            {
                throw new BrandException(BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the brands present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the brands list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Brand> ReturnHistoric()
        {
            try
            {
                return Brands.ReturnHistoric();
            }
            catch (BrandException BE)
            {
                throw new BrandException(BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the brands historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool UpdateBrand(int fieldToUpdate, string atribute, int brandID)
        {
            try
            {
                return Brands.UpdateBrand(fieldToUpdate, atribute, brandID);
            }
            catch (BrandException BE)
            {
                throw new BrandException("\nFailure of Business Rules!" + "-" + BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated brand!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function removes a brand by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveBrand(int brandID)
        {
            try
            {
                return Brands.RemoveBrand(brandID);
            }
            catch (BrandException BE)
            {
                throw new BrandException(BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated product!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a brand by passing its ID as a parameter, putting it back as an available brand.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RecoverBrand(int brandID)
        {
            try
            {
                return Brands.RecoverBrand(brandID);
            }
            catch (BrandException BE)
            {
                throw new BrandException(BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated brand!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a brand by passing its ID as a parameter.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteBrand(int brandID)
        {
            try
            {
                return Brands.DeleteBrand(brandID);
            }
            catch (BrandException BE)
            {
                throw new BrandException(BE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated brand!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the brands data from a file into the brands list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadBrandsDataBin()
        {
            try
            {
                return Brands.LoadBrandsDataBin();
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing brand data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save brand data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load brands data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the brands data from the brands list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveBrandsDataBin()
        {
            try
            {
                return Brands.SaveBrandsDataBin();
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing brand data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save brand data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to save the data in the file!" + E.Message);
            }
        }

        #endregion

        #endregion
    }
}
