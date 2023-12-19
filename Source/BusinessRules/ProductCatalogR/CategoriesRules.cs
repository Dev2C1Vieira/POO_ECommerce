/*
 * <copyright file = "CategoriesRules.cs" company="IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/17/2023 10:21:09 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.Collections.Generic;
using System.IO;
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
    /// Created On: 12/17/2023 10:21:09 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class CategoriesRules
    {
        #region Methods

        /// <summary>
        /// Method that returns the number of elements present in the categories list.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsCategoryIDAvailable(int categoryID)
        {
            try
            {
                return Categories.IsCategoryIDAvailable(categoryID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated category ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Categories.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of categories present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the categories historic.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Categories.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of categories present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the category, whether it respects business rules.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertCategory(Category category)
        {
            try
            {
                category.CategoryID = Categories.ReturnIDNewCategory();
                Categories.InsertCategory(category);
                return true;
            }
            catch (CategoryException CE)
            {
                throw new CategoryException("\nFailure of Business Rules!" + "-" + CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new category!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Category> ReturnCategoriesList()
        {
            try
            {
                return Categories.ReturnCategoriesList();
            }
            catch (CategoryException CE)
            {
                throw new CategoryException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the categories present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Category> ReturnHistoric()
        {
            try
            {
                return Categories.ReturnHistoric();
            }
            catch (CategoryException CE)
            {
                throw new CategoryException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the categories historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool UpdateCategory(int fieldToUpdate, string atribute, int categoryID)
        {
            try
            {
                return Categories.UpdateCategory(fieldToUpdate, atribute, categoryID);
            }
            catch (CategoryException CE)
            {
                throw new CategoryException("\nFailure of Business Rules!" + "-" + CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated category!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function removes a category by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveCategory(int categoryID)
        {
            try
            {
                return Categories.RemoveCategory(categoryID);
            }
            catch (CategoryException CE)
            {
                throw new CategoryException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated category!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a product by passing its ID as a parameter, putting it back as an available category.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RecoverCategory(int categoryID)
        {
            try
            {
                return Categories.RecoverCategory(categoryID);
            }
            catch (CategoryException CE)
            {
                throw new CategoryException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated category!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a category by passing its ID as a parameter.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteCategory(int categoryID)
        {
            try
            {
                return Categories.DeleteCategory(categoryID);
            }
            catch (CategoryException CE)
            {
                throw new CategoryException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated category!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the categories data from a file into the categories list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadCategoriesDataBin()
        {
            try
            {
                return Categories.LoadCategoriesDataBin();
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing category data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save category data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load categories data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the categories data from the categories list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveCategoriesDataBin()
        {
            try
            {
                return Categories.SaveCategoriesDataBin();
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing category data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save category data!" + IOE.Message);
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
