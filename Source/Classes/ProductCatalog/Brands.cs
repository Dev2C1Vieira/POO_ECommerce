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
    public class Brands
    {
        #region Attributes

        /// <summary>
        /// Creation of the Brands class atributes
        /// </summary>
        private int brandID; //
        private string brandName; //
        //private string brandDescription; //
        //Categories[] categoriesList; //
        private string originCountry; //
        private DateTime fundationDate; //
        private bool visibilityStatus; // An indicator of whether the brand is visible to users.
        private DateTime creationDate; //

        private static int qtdBrands = 1; //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Brands()
        {
            brandID = qtdBrands;
            qtdBrands++;
            brandName = string.Empty;
            originCountry = string.Empty;
            fundationDate = DateTime.Now;
            visibilityStatus = false;
            creationDate = DateTime.Now;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="brandName"></param>
        /// <param name="originCountry"></param>
        /// <param name="fundationDate"></param>
        /// <param name="visibilityStatus"></param>
        /// <param name="creationDate"></param>
        public Brands(string brandName, string originCountry, DateTime fundationDate, bool visibilityStatus, DateTime creationDate)
        {
            brandID = qtdBrands;
            qtdBrands++;
            this.brandName = brandName;
            this.originCountry = originCountry;
            this.fundationDate = fundationDate;
            this.visibilityStatus = visibilityStatus;
            this.creationDate = creationDate;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the brandID attribute
        /// </summary>
        public int BrandID
        {
            get { return brandID; }
            set { brandID = value; }
        }

        /// <summary>
        /// Property related to the brandName attribute
        /// </summary>
        public string BrandName
        {
            get { return brandName; }
            set { brandName = value; }
        }

        /// <summary>
        /// Property related to the originCountry attribute
        /// </summary>
        public string OriginCountry
        {
            get { return originCountry; }
            set { originCountry = value; }
        }

        /// <summary>
        /// Property related to the fundationDate attribute
        /// </summary>
        public DateTime FundationDate
        {
            get { return fundationDate; }
            set { fundationDate = value; }
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
        /// Property related to the creationDate attribute
        /// </summary>
        public DateTime CreationDate 
        { 
            get { return creationDate; } 
            set { creationDate = value; } 
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Brands are the same
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Brands left, Brands right)
        {
            if ((left.BrandID == right.BrandID) && (left.BrandName == right.BrandName) && 
                (left.OriginCountry == right.OriginCountry) && (left.FundationDate == right.FundationDate) && 
                (left.VisibilityStatus == right.VisibilityStatus) && (left.CreationDate == right.CreationDate))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Bampaigns are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Brands left, Brands right)
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
            return (String.Format("Brand ID: {0} - Brand Name: {1} - Origin Country: {2} - Fundation Date: {3} - " +
                "Visibility Status: {4} - Creation Date: {5}", BrandID.ToString(), BrandName, OriginCountry.ToString(), 
                FundationDate.ToString(), VisibilityStatus.ToString(), CreationDate.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Brands)
            {
                Brands brand = (Brands)obj;
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
        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
