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

        private static int productID;
        private string productName;
        //private string productDescription; Caso queira utilizar!
        private double price;
        private DateTime launchDate;
        //private int stock;
        //private string category; para implementar depois quando tiver as classes devidamente implementadas. Provavelmente serao arrays!
        //private string brand;
        //private string promotions;

        private static int qtdProducts;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public Products()
        {
            productID = 0;
            productName = "";
            price = -1.0;
            launchDate = DateTime.Now;
            qtdProducts = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="External_productID"></param>
        /// <param name="External_productName"></param>
        /// <param name="External_price"></param>
        /// <param name="External_launchDate"></param>
        public Products(string productName, double price, DateTime launchDate)
        {
            productID++; // a way to create an auto increment field
            this.productName = productName;
            this.price = price;
            this.launchDate = launchDate;
            qtdProducts++;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the productID attribute
        /// </summary>
        public int ProductID 
        { 
            get { return productID; } 
            set { productID = value; }
        }

        /// <summary>
        /// Property related to the productName attribute
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        /// <summary>
        /// Property related to the price attribute
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Property related to the lauchDate attribute
        /// </summary>
        public DateTime LauchDate
        {
            get { return launchDate; }
            set { launchDate = value; }
        }

        /// <summary>
        /// Property related to the qtdProducts attribute
        /// </summary>
        public int QtdProducts
        {
            get { return qtdProducts; }
            set { qtdProducts = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Products left, Products right)
        {
            if ((left.ProductID == right.ProductID) && (left.ProductName == right.ProductName) 
                && (left.Price == right.Price) && (left.LauchDate == right.LauchDate)) 
                return (true);
            return (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Products left, Products right)
        {
            if (!(left == right)) return (true);
            return (false);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (String.Format("Product ID: {0} - Product Name: {1} - Price: {2} - Launch Date: {3}", 
                ProductID.ToString(), ProductName, Price.ToString(), LauchDate.ToString()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Products)
            {
                Products product = (Products)obj;
                if (this == product)
                    return (true);
            }
            return (false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region OtherMethods


        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
