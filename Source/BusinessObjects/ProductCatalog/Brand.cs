/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:29:21 AM </date>
 * <description></description>
 * 
 * */

using System;

namespace ProductCatalog
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 11:29:21 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class Brand : IComparable<Brand>
    {
        #region Attributes

        /// <summary>
        /// Creation of the Brand class atributes
        /// </summary>
        private int brandID; //
        private string brandName; //
        private string brandDescription; //
        private string originCountry; //
        private DateTime fundationDate; //
        private bool visibilityStatus; // An indicator of whether the brand is visible to users.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Brand()
        {
            brandID = 0;
            brandName = string.Empty;
            brandDescription = string.Empty;
            originCountry = string.Empty;
            fundationDate = DateTime.Now;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="brandName"></param>
        /// <param name="brandDescription"></param>
        /// <param name="originCountry"></param>
        /// <param name="fundationDate"></param>
        /// <param name="visibilityStatus"></param>
        public Brand(string brandName, string brandDescription, string originCountry, DateTime fundationDate, bool visibilityStatus)
        {
            brandID = 0;
            this.brandName = brandName;
            this.brandDescription = brandDescription;
            this.originCountry = originCountry;
            this.fundationDate = fundationDate;
            this.visibilityStatus = visibilityStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'brandID' attribute
        /// </summary>
        public int BrandID
        {
            get { return brandID; }
            set { brandID = value; }
        }

        /// <summary>
        /// Property related to the 'brandName' attribute
        /// </summary>
        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        /// <summary>
        /// Property related to the 'brandDescription' attribute
        /// </summary>
        public string BrandDescription
        {
            get { return brandDescription; }
            set { brandDescription = value; }
        }

        /// <summary>
        /// Property related to the 'originCountry' attribute
        /// </summary>
        public string OriginCountry
        {
            get { return originCountry; }
            set { originCountry = value; }
        }

        /// <summary>
        /// Property related to the 'fundationDate' attribute
        /// </summary>
        public DateTime FundationDate
        {
            get { return fundationDate; }
            set { fundationDate = value; }
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
        /// Creating/Rewriting this method, to be able to check whether two indicated Brand are the same
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Brand left, Brand right)
        {
            if ((left.BrandID == right.BrandID) && (left.BrandName == right.BrandName) 
                && (left.brandDescription == right.BrandDescription) && (left.OriginCountry == right.OriginCountry)
                && (left.FundationDate == right.FundationDate) && (left.VisibilityStatus == right.VisibilityStatus))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Bampaigns are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Brand left, Brand right)
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
            return (String.Format("Brand ID: {0} - Brand Name: {1} - Brand Description: {2} - Origin Country: {3}" +
                " - Fundation Date: {4} - Creation Date: {5}", 
                BrandID.ToString(), BrandName, BrandDescription, OriginCountry.ToString(), FundationDate.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Brand)
            {
                Brand brand = (Brand)obj;
                if (this == brand)
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
        public int CompareTo(Brand brand)
        {
            return this.FundationDate.CompareTo(brand.FundationDate);
        }

        #endregion

        #region Destructor
        #endregion

        #endregion

        //Still in progress...
    }
}
