    /*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:34:43 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;


// External
using ProductCatalog;
using ProductCatalogE;

namespace ProductCatalogs
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:43 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Categories /*: ICategory*/
    {
        #region Attributes

        /// <summary>
        /// Atributes creation
        /// </summary>
        private static List<Category> categoriesList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        static Categories()
        {
            categoriesList = new List<Category>(); 
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'categoriesList' attribute
        /// </summary>
        public static List<Category> CategoriesList
        {
            get { return categoriesList; }
            set { categoriesList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given category already exists in the List.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool ExistCategory(Category category)
        {
            if (CategoriesList.Contains(category))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given category is visible or not.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public static bool IsCategoryAvailable(Category category)
        {
            if (category.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two categories, indicated by parameter.
        /// </summary>
        /// <param name="category1"></param>
        /// <param name="category2"></param>
        /// <returns></returns>
        public static bool CompareCategories(Category category1, Category category2)
        {
            if (category1.Equals(category2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the Categories list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsCategoriesListEmpty()
        {
            if (CategoriesList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewCategory()
        {
            if (IsCategoriesListEmpty() == true)
                return 1;

            Category aux = CategoriesList.Last();
            return aux.CategoryID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the product list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Category category in CategoriesList)
            {
                if (category.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the categories historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Category category in CategoriesList)
            {
                if (category.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a category that has the id indicated by the user.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static bool IsCategoryIDAvailable(int categoryID)
        {
            foreach (Category category in CategoriesList)
            {
                if (category.CategoryID == categoryID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Category, using its ID.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static Category ReturnCategoryFromID(int categoryID)
        {
            Category auxCategory = new Category();
            foreach (Category category in CategoriesList)
            {
                if (category.CategoryID == categoryID)
                    auxCategory = category;
                else continue;
            }
            return auxCategory;
        }

        /// <summary>
        /// This function inserts a category passed as a List parameter.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static bool InsertCategory(Category category)
        {
            if (ExistCategory(category) == true)
                throw new CategoryException("\nUnable to insert new category ... Category is already inserted!");

            CategoriesList.Add(category);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static List<Category> ReturnCategoriesList()
        {
            List<Category> listaAux = new List<Category>();

            if (IsCategoriesListEmpty() == true)
                throw new CategoryException("\nThe category list is empty!");

            foreach (Category category in CategoriesList)
            {
                if (category.VisibilityStatus == true)
                    listaAux.Add(category);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the categories list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static List<Category> ReturnHistoric()
        {
            List<Category> listaAux = new List<Category>();

            if (IsCategoriesListEmpty() == true)
                throw new CategoryException("\nThe category list is empty!");

            foreach (Category category in CategoriesList)
            {
                if (category.VisibilityStatus == false)
                    listaAux.Add(category);
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
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static bool UpdateCategory(int fieldToUpdate, string atribute, int categoryID)
        {
            Category category = ReturnCategoryFromID(categoryID);
            if (ExistCategory(category) == false)
                throw new CategoryException("\nUnable to update category ... Category does not exist!");

            foreach (Category c in CategoriesList)
            {
                if (c.Equals(category))
                {
                    if (fieldToUpdate == 1)
                    {
                        category.CategoryName = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        category.CategoryDescription = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        category.CreationDate = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function removes a category by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static bool RemoveCategory(int categoryID)
        {
            if (ExistCategory(ReturnCategoryFromID(categoryID)) == false)
                throw new CategoryException("\nUnable to remove category ... Category does not exist!");

            foreach (Category category in CategoriesList)
            {
                if (category.Equals(ReturnCategoryFromID(categoryID)))
                {
                    if (category.VisibilityStatus == true)
                    {
                        category.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new CategoryException("\nUnable to remove category ... Category has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a product by passing its ID as a parameter, putting it back as an available category.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static bool RecoverCategory(int categoryID)
        {
            if (ExistCategory(ReturnCategoryFromID(categoryID)) == false)
                throw new CategoryException("\nUnable to recover category ... Category does not exist!");

            foreach (Category category in CategoriesList)
            {
                if (category.Equals(ReturnCategoryFromID(categoryID)))
                {
                    if (category.VisibilityStatus == false)
                    {
                        category.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new CategoryException("\nUnable to recover category ... Category hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a category by passing its ID as a parameter.
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        /// <exception cref="CategoryException"></exception>
        public static bool DeleteCategory(int categoryID)
        {
            if (ExistCategory(ReturnCategoryFromID(categoryID)) == false)
                throw new CategoryException("\nUnable to delete category ... Category does not exist!");

            foreach (Category category in CategoriesList)
            {
                if (category.Equals(ReturnCategoryFromID(categoryID)))
                {
                    if (category.VisibilityStatus == false)
                    {
                        CategoriesList.Remove(category);
                        return true;
                    }
                    else
                        throw new CategoryException("\nUnable to delete category ... Category hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadCategoriesDataBin()
        {
            string fileName = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";
            //string fileName = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Category> loadedCategories = (List<Category>)formatter.Deserialize(fileStream);

                    foreach (Category category in loadedCategories)
                    {
                        CategoriesList.Add(category);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the categories data from the categories list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        public static bool SaveCategoriesDataBin()
        {
            string fileName = "C:\\Users\\pedro\\OneDrive\\Ambiente de Trabalho\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";
            //string fileName = "C:\\Users\\pedro\\Desktop\\Projeto_POO_25626\\Source\\Files\\ProductCatalog\\CategoriesList.bin";
            if (IsCategoriesListEmpty() == true)
                throw new ProductException("\nThe product list is empty!");

            // Cria um FileStream para gravar os dados dos produtos no arquivo
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, CategoriesList);
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
