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
        /// Creation of the Prroducts class atributes
        /// </summary>
        private int productID; //
        private string productName; //
        //private string productDescription; Caso queira utilizar!
        private double price; //
        private DateTime launchDate; //
        private bool visibilityStatus; // An indicator of whether the product is visible to users.
        //private int stock; //
        //private string category; // para implementar depois quando tiver as classes devidamente implementadas. Provavelmente serao arrays!
        //private string brand; //
        //private string promotions; //

        private static int qtdProducts = 1; //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Products()
        {
            productID = qtdProducts;
            qtdProducts++;
            productName = string.Empty;
            price = -1.0;
            launchDate = DateTime.Now;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="price"></param>
        /// <param name="launchDate"></param>
        public Products(string productName, double price, DateTime launchDate, bool visibilityStatus)
        {
            productID = qtdProducts;
            qtdProducts++;
            this.productName = productName;
            this.price = price;
            this.launchDate = launchDate;
            this.visibilityStatus = visibilityStatus;
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
        /// Property related to the visibilityStatus attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; } 
            set { visibilityStatus = value; }
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
        /// Creating/Rewriting this method, to be able to check whether two indicated Products are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Products left, Products right)
        {
            if ((left.ProductID == right.ProductID) && (left.ProductName == right.ProductName) && (left.Price == right.Price) 
                && (left.LauchDate == right.LauchDate) && (left.visibilityStatus == right.VisibilityStatus)) 
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Products are different.
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
        /// Rewriting the ToString method, to be able to write on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (String.Format("Product ID: {0} - Product Name: {1} - Price: {2} - Launch Date: {3} - Visibility Status: {4}", 
                ProductID.ToString(), ProductName, Price.ToString(), LauchDate.ToString(), VisibilityStatus.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
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
        /// Rewriting the GetHashCode method, to ensure efficient access to elements.
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
