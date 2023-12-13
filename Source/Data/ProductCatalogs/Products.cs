/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:34:51 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;


//External
using ProductCatalog;
using ProductCatalogE;

namespace ProductCatalogs
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:51 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Products //: IProduct
    {
        #region Attributes

        /// <summary>
        /// Atributes creation
        /// </summary>
        private static string name; //
        private static List<Product> productsList; //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        static Products()
        {
            name = string.Empty;
            productsList = new List<Product>(); //
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public static string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Product> ProductsList
        {
            get { return productsList; }
            set { productsList = value; }
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// This function checks whether a given product already exists in the List.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool ExistProduct(Product product)
        {
            if (productsList.Contains(product))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given product is visible or not.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool IsProductAvailable(Product product)
        {
            if (product.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two Product, indicated by parameter.
        /// </summary>
        /// <param name="product1"></param>
        /// <param name="product2"></param>
        /// <returns></returns>
        public static bool CompareProducts(Product product1, Product product2)
        {
            if (product1.Equals(product2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the product list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsProductsListEmpty()
        {
            if (ProductsList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// This function inserts a product passed as a List parameter.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool InsertProduct(Product product)
        {
            if (ExistProduct(product) == true)
                throw new ProductException("\nUnable to insert new product ... Product is already inserted!");

            ProductsList.Add(product);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the product list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        public static List<Product> ReturnProductsList()
        {
            List<Product> listaAux = new List<Product>();

            if (IsProductsListEmpty() == true)
                throw new ProductException("\nThe product list is empty!");

            foreach (Product product in ProductsList)
            {
                listaAux.Add(product);
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns the number of elements present in the product list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Product product in ProductsList)
            {
                count++;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a product that has the id indicated by the user.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static bool IsProductIDAvailable(int productID)
        {
            foreach (Product product in ProductsList)
            {
                if (product.ProductID == productID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Product, using its ID.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        public static Product ReturnProductFromID(int productID)
        {
            Product auxProduct = new Product();
            foreach (Product product in ProductsList)
            {
                if (product.ProductID == productID)
                    auxProduct = product;
                else continue;
            }
            return auxProduct;
        }

        /// <summary>
        /// This function deletes a product by passing its ID as a parameter.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool DeleteProduct(int productID)
        {
            if (ExistProduct(ReturnProductFromID(productID)) == false)
                throw new ProductException("\nUnable to delete product ... Product does not exist!");

            foreach (Product product in ProductsList)
            {
                if (product.Equals(ReturnProductFromID(productID)))
                {
                    ProductsList.Remove(product);
                    return true;
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="ProductException"></exception>
        public static bool UpdateProduct(int fieldToUpdate, string atribute, int productID)
        {
            Product product = ReturnProductFromID(productID);
            if (ExistProduct(product) == false)
                throw new ProductException("\nUnable to update product ... Product does not exist!");

            foreach (Product p in ProductsList)
            {
                if (p.Equals(product))
                {
                    if (fieldToUpdate == 1)
                    {
                        product.ProductName = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        product.ProductDescription = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        product.Price = float.Parse(atribute);
                        return true;
                    }
                    else if (fieldToUpdate == 4)
                    {
                        product.LauchDate = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                    else if (fieldToUpdate == 5)
                    {
                        product.WarrantyDuration = int.Parse(atribute);
                        return true;
                    }
                    else if (fieldToUpdate == 6)
                    {
                        product.AmountInStock = int.Parse(atribute);
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region Destructor
        #endregion

        #endregion

        //Still in progress...
    }
}
