﻿/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 12:13:28 PM </date>
 * <description></description>
 * 
 * */

using System;

// External
using RevenueEngine.Interfaces;

namespace RevenueEngine
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 12:13:28 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class Sale : IComparable<Sale>, ISale
    {
        #region Attributes

        /// <summary>
        /// Creation of the Sale class atributes
        /// </summary>
        private int saleID;
        private DateTime dateSale;
        private int productID;
        private int clientID;
        private int quantity;
        private bool visibilityStatus;
        private double totalPrice;

        //private List<Dictionary<Product, int>>
        // talvez uma implementacao, que me permita efetuar uma venda,
        // com mais que um produto e quantidades diferentes desse mesmo produto por venda.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Sale()
        {
            saleID = 0;
            dateSale = DateTime.Now;
            productID = 0;
            clientID = 0;
            quantity = 0;
            visibilityStatus = false;
            totalPrice = 0;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="saleID"></param>
        /// <param name="dateSale"></param>
        /// <param name="productID"></param>
        /// <param name="clientID"></param>
        /// <param name="quantity"></param>
        /// <param name="visibilityStatus"></param>
        public Sale(int saleID, DateTime dateSale, int productID, int clientID, int quantity, bool visibilityStatus)
        {
            this.saleID = saleID;
            this.dateSale = dateSale;
            this.productID = productID;
            this.clientID = clientID;
            this.quantity = quantity;
            this.visibilityStatus = visibilityStatus;
            totalPrice = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'saleID' attribute
        /// </summary>
        public int SaleID
        {
            get { return saleID; }
            set { saleID = value; }
        }

        /// <summary>
        /// Property related to the 'dateSale' attribute
        /// </summary>
        public DateTime DateSale
        {
            get { return dateSale; }
            set { dateSale = value; }
        }

        /// <summary>
        /// Property related to the 'productID' attribute
        /// </summary>
        public int ProductID
        {
            get { return productID; }
            set { productID = value; }
        }

        /// <summary>
        /// Property related to the 'clientID' attribute
        /// </summary>
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        /// <summary>
        /// Property related to the 'quantity' attribute
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        /// <summary>
        /// Property related to the 'visibilityStatus' attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; }
            set { visibilityStatus = value; }
        }

        /// <summary>
        /// Property related to the 'totalPrice' attribute
        /// </summary>
        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Sale are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Sale left, Sale right)
        {
            if ((left.SaleID == right.SaleID) && (left.DateSale == right.DateSale) 
                && (left.ProductID == right.ProductID) && (left.ClientID == right.ClientID) 
                && (left.Quantity == right.Quantity) && (left.VisibilityStatus == right.VisibilityStatus) 
                && (left.TotalPrice == right.TotalPrice))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Sale are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Sale left, Sale right)
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
            return (String.Format("Sale ID: {0} - Date Sale: {1} - Product ID: {2} " +
                "- Client ID: {3} - Quantidade: {4} - Total Price: {5}", SaleID.ToString(), DateSale.ToShortDateString(), 
                ProductID.ToString(), ClientID. ToString(), Quantity.ToString(), TotalPrice.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Sale sale)
            {
                if (this == sale)
                    return (true);
            }
            return false;
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
        /// Method that orders based on the DateSale of the sale.
        /// </summary>
        /// <param name="sale"></param>
        /// <returns></returns>
        public int CompareTo(Sale sale)
        {
            return this.DateSale.CompareTo(sale.DateSale);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Sale()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
