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
using ProductCatalog.Interfaces;

namespace ProductCatalog.Others
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:34:51 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Products : IProduct
    {
        #region Attributes

        /// <summary>
        /// 
        /// </summary>
        private static List<Product> productsList = new List<Product>(); //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        static Products()
        {
            productsList = new List<Product>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductsList
        {
            get { return productsList; }
            set { productsList = value; }
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods

        //
        public bool ExistProduct(Product product)
        {
            if (productsList.Exists(p => p.ProductID == product.ProductID))
                return true;
            return false;
        }

        public bool InsertProduct(Product product)
        {
            if (ExistProduct(product) == true)
            {
                productsList.Add(product);
                return (true);
            }
            return (false);

            //Still in progress...
        }

        public bool UpdateProduct(Product product)
        {
            return (false);

            //Still in progress...
        }

        public bool DeleteProduct(Product product)
        {
            return (false);

            //Still in progress...
        }

        #endregion

        #region Destructor
        #endregion

        #endregion

        //Still in progress...
    }
}
