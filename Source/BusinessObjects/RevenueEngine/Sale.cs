/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 12:13:28 PM </date>
 * <description></description>
 * 
 * */

using ProductCatalog;
using RevenueEngine.Interfaces;
using System;
using System.Collections.Generic;


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
        private bool visibilityStatus;

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
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="dateSale"></param>
        /// <param name="productID"></param>
        /// <param name="clientID"></param>
        /// <param name="visibilityStatus"></param>
        public Sale(DateTime dateSale, int productID, int clientID, bool visibilityStatus)
        {
            saleID = 0;
            this.dateSale = dateSale;
            this.productID = productID;
            this.clientID = clientID;
            this.visibilityStatus = visibilityStatus;
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
        /// Property related to the 'visibilityStatus' attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; }
            set { visibilityStatus = value; }
        }

        #endregion

        #region Operators
        #endregion

        #region Overrides
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

        //Still in progress...
    }
}
