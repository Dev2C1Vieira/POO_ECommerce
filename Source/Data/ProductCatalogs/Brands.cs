/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:34:30 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

// External
using ProductCatalog;
using ProductCatalogE;
using System.Linq;

namespace ProductCatalogs
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:30 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Brands
    {
        #region Attributes

        /// <summary>
        /// Creation of the Brand class atributes
        /// </summary>
        private static List<Brand> brandsList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        static Brands()
        {
            brandsList = new List<Brand>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'brandsList' attribute
        /// </summary>
        public static List<Brand> BrandsList
        {
            get { return brandsList; }
            set { brandsList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given brand already exists in the List.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static bool ExistBrand(Brand brand)
        {
            if (BrandsList.Contains(brand))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given brand is visible or not.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static bool IsBrandAvailable(Brand brand)
        {
            if (brand.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two brands, indicated by parameter.
        /// </summary>
        /// <param name="brand1"></param>
        /// <param name="brand2"></param>
        /// <returns></returns>
        public static bool CompareBrands(Brand brand1, Brand brand2)
        {
            if (brand1.Equals(brand2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the brand list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsBrandsListEmpty()
        {
            if (BrandsList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewBrand()
        {
            if (IsBrandsListEmpty() == true)
                return 1;

            Brand aux = BrandsList.Last();
            return aux.BrandID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the brands list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Brand brand in BrandsList)
            {
                if (brand.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the brands historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Brand brand in BrandsList)
            {
                if (brand.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a brand that has the id indicated by the user.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        public static bool IsBrandIDAvailable(int brandID)
        {
            foreach (Brand brand in BrandsList)
            {
                if (brand.BrandID == brandID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Brand, using its ID.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        public static Brand ReturnBrandFromID(int brandID)
        {
            Brand auxBrand = new Brand();
            foreach (Brand brand in BrandsList)
            {
                if (brand.BrandID == brandID)
                    auxBrand = brand;
                else continue;
            }
            return auxBrand;
        }

        /// <summary>
        /// This function inserts a brand passed as a List parameter.
        /// </summary>
        /// <param name="brand"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static bool InsertBrand(Brand brand)
        {
            if (ExistBrand(brand) == true)
                throw new BrandException("\nUnable to insert new brand ... Brand is already inserted!");

            BrandsList.Add(brand);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the brand list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static List<Brand> ReturnBrandsList()
        {
            List<Brand> listaAux = new List<Brand>();

            if (IsBrandsListEmpty() == true)
                throw new BrandException("\nThe brands list is empty!");

            foreach (Brand brand in BrandsList)
            {
                if (brand.VisibilityStatus == true)
                    listaAux.Add(brand);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the brands list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static List<Brand> ReturnHistoric()
        {
            List<Brand> listaAux = new List<Brand>();

            if (IsBrandsListEmpty() == true)
                throw new BrandException("\nThe brands list is empty!");

            foreach (Brand brand in BrandsList)
            {
                if (brand.VisibilityStatus == false)
                    listaAux.Add(brand);
                else continue;
            }
            return listaAux;
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
        public static bool UpdateBrand(int fieldToUpdate, string atribute, int brandID)
        {
            Brand brand = ReturnBrandFromID(brandID);
            if (ExistBrand(brand) == false)
                throw new BrandException("\nUnable to update brand ... Brand does not exist!");

            foreach (Brand b in BrandsList)
            {
                if (b.Equals(brandID))
                {
                    if (fieldToUpdate == 1)
                    {
                        brand.BrandName = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        brand.BrandDescription = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        brand.OriginCountry = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 4)
                    {
                        brand.FundationDate = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function removes a brand by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static bool RemoveBrand(int brandID)
        {
            if (ExistBrand(ReturnBrandFromID(brandID)) == false)
                throw new BrandException("\nUnable to remove brand ... Brand does not exist!");

            foreach (Brand brand in BrandsList)
            {
                if (brand.Equals(ReturnBrandFromID(brandID)))
                {
                    if (brand.VisibilityStatus == true)
                    {
                        brand.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new BrandException("\nUnable to remove brand ... Brand has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a brand by passing its ID as a parameter, putting it back as an available brand.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static bool RecoverBrand(int brandID)
        {
            if (ExistBrand(ReturnBrandFromID(brandID)) == false)
                throw new BrandException("\nUnable to recover brand ... Brand does not exist!");

            foreach (Brand brand in BrandsList)
            {
                if (brand.Equals(ReturnBrandFromID(brandID)))
                {
                    if (brand.VisibilityStatus == false)
                    {
                        brand.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new BrandException("\nUnable to recover brand ... Brand hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a brand by passing its ID as a parameter.
        /// </summary>
        /// <param name="brandID"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static bool DeleteBrand(int brandID)
        {
            if (ExistBrand(ReturnBrandFromID(brandID)) == false)
                throw new BrandException("\nUnable to remove brand ... Brand does not exist!");

            foreach (Brand brand in BrandsList)
            {
                if (brand.Equals(ReturnBrandFromID(brandID)))
                {
                    if (brand.VisibilityStatus == false)
                    {
                        BrandsList.Remove(brand);
                        return true;
                    }
                    else
                        throw new BrandException("\nUnable to delete brand ... Brand hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the brands data from a file into the brands list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadBrandsDataBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Brand> loadedBrands = (List<Brand>)formatter.Deserialize(fileStream);

                    foreach (Brand brand in loadedBrands)
                    {
                        BrandsList.Add(brand);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the brands data from the brands list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="BrandException"></exception>
        public static bool SaveBrandsDataBin(string fileName)
        {
            // Creates a FileStream to write brand data to the file.
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, BrandsList);
            }
            return true;
        }

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
