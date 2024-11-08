﻿/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:47:32 AM </date>
 * <description></description>
 * 
 * */

using System;

// External
using ProductCatalog.Interfaces;

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

    [Serializable]
    public class Product : IProduct, IComparable<Product>
    {
        #region Attributes

        /// <summary>
        /// Creation of the Product class atributes
        /// </summary>
        private int productID; //
        private string productName; //
        private string productDescription; //
        private double price; //
        private DateTime launchDate; //
        private int warrantyDuration; // 
        private bool visibilityStatus; // An indicator of whether the product is visible to users.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Product()
        {
            productID = 0;
            productName = string.Empty;
            productDescription = string.Empty;
            price = -1.0;
            launchDate = DateTime.Now;
            warrantyDuration = 0;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="productName"></param>
        /// <param name="productDescription"></param>
        /// <param name="price"></param>
        /// <param name="launchDate"></param>
        /// <param name="warrantyDuration"></param>
        /// <param name="visibilityStatus"></param>
        public Product(int productID, string productName, string productDescription, double price, DateTime launchDate,
            int warrantyDuration, bool visibilityStatus)
        {
            this.productID = productID;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
            this.launchDate = launchDate;
            this.warrantyDuration = warrantyDuration;
            this.visibilityStatus = visibilityStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'productID' attribute
        /// </summary>
        public int ProductID 
        { 
            get { return productID; } 
            set { productID = value; }
        }

        /// <summary>
        /// Property related to the 'productName' attribute
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        /// <summary>
        /// Property related to the 'productDescription' attribute
        /// </summary>
        public string ProductDescription
        {
            get { return productDescription; }
            set { productDescription = value; }
        }

        /// <summary>
        /// Property related to the 'price' attribute
        /// </summary>
        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        /// <summary>
        /// Property related to the 'lauchDate' attribute
        /// </summary>
        public DateTime LauchDate
        {
            get { return launchDate; }
            set { launchDate = value; }
        }

        /// <summary>
        /// Property related to the 'warrantyDuration' attribute
        /// </summary>
        public int WarrantyDuration
        {
            get { return warrantyDuration; }
            set { warrantyDuration = value; }
        }

        /// <summary>
        /// Property related to the 'visibilityStatus' attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; } 
            set { visibilityStatus = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Product are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Product left, Product right)
        {
            if ((left.ProductID == right.ProductID) && (left.ProductName == right.ProductName)
                && (left.ProductDescription == right.ProductDescription) && (left.Price == right.Price)
                && (left.LauchDate == right.LauchDate) && (left.WarrantyDuration == right.WarrantyDuration)
                && (left.visibilityStatus == right.VisibilityStatus)) 
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Product are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Product left, Product right)
        {
            if (!(left == right)) return (true);
            return (false);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Rewriting the ToString method, to be able to write on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (String.Format("Product ID: {0} - Product Name: {1} - Product Description: {2} " +
                "- Price: {3} - Launch Date: {4} - Warranty Duration: {5}" +
                " - Amount in Stock: {6} - Category ID: {7} - Brand ID: {8}", 
                ProductID.ToString(), ProductName, ProductDescription, Price.ToString(), 
                LauchDate.ToString(), WarrantyDuration.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Product product)
            {
                if (this == product)
                    return (true);
            }
            return (false);
        }

        /// <summary>
        /// Rewriting the GetHashCode method, to ensure efficient access to elements.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Method that orders based on the cost of the product.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public int CompareTo(Product product)
        {
            return this.Price.CompareTo(product.Price);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Product()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
