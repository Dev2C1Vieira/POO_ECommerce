/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:47:32 AM </date>
 * <description></description>
 * 
 * */

using System;

namespace ProductCatalog
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 11:47:32 AM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Products
    {
        #region Attributes

        /// <summary>
        /// 
        /// </summary>

        private int productID;
        private string productName;
        //private string productDescription; Caso queira utilizar!
        private double price;
        private DateTime launchDate;
        //private int stock;
        //private string category; para implementar depois quando tiver as classes devidamente implementadas. Provavelmente serao arrays!
        //private string brand;
        //private string promotions;

        private static int QtdProducts;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Products()
        {
            productID = -1;
            productName = "";
            price = -1.0;
            launchDate = DateTime.Now;
            QtdProducts = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="External_productID"></param>
        /// <param name="External_productName"></param>
        /// <param name="External_price"></param>
        /// <param name="External_launchDate"></param>
        public Products(int External_productID, string External_productName, double External_price, DateTime External_launchDate)
        {
            this.productID = External_productID;
            this.productName = External_productName;
            this.price = External_price;
            this.launchDate = External_launchDate;
            QtdProducts++;
        }

        #endregion

        #region Properties

        public int ProductID 
        { 
            get { return productID; } 
            set { productID = value; }
        }

        public string ProductName
        {
            get { return productName; } 
            set { productName = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public DateTime LauchDate
        {
            get { return launchDate; }
            set { launchDate = value; }
        }

        #endregion

        #region Overrides
        #endregion

        #region OtherMethods
        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
