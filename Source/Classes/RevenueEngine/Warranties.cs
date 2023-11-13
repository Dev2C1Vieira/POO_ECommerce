/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:59:04 AM </date>
 * <description></description>
 * 
 * */

using System;
using ProductCatalog;

namespace RevenueEngine
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 11:59:04 AM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Warranties
    {
        #region Attributes

        /// <summary>
        /// Creation of the Warranties class atributes
        /// </summary>
        private int warrantiesID; // A unique identifier for each collateral.
        private string warrantiesDescription; // Product guarantee, satisfaction guarantee, low price guarantee, etc.
        private int warrantiesType; // A brief description of the warranty terms.
        //private Products[] productsList; // A list of products associated with the warranty.
        private bool visibilityStatus; // An indicator of whether the warranty is visible to users.
        private int warrantiesPeriod; // The duration of the warranty.
        private string warrantiesCoverage; // Details about what the warranty covers.

        private static int qtdWarranties = 1; // 

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Warranties()
        {
            warrantiesID = qtdWarranties;
            qtdWarranties++;
            warrantiesDescription = string.Empty;
            warrantiesType = -1;
            visibilityStatus = false;
            warrantiesPeriod = -1;
            warrantiesCoverage = string.Empty;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="warrantiesDescription"></param>
        /// <param name="warrantiesType"></param>
        /// <param name="warrantiesPeriod"></param>
        /// <param name="warrantiesCoverage"></param>
        public Warranties(string warrantiesDescription, int warrantiesType, bool visibilityStatus, int warrantiesPeriod, string warrantiesCoverage)
        {
            warrantiesID = qtdWarranties;
            qtdWarranties++;
            this.warrantiesDescription = warrantiesDescription;
            this.warrantiesType = warrantiesType;
            this.visibilityStatus = visibilityStatus;
            this.warrantiesPeriod = warrantiesPeriod;
            this.warrantiesCoverage = warrantiesCoverage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the warrantiesID attribute
        /// </summary>
        public int WarrantiesID
        {
            get { return warrantiesID; }
            set { warrantiesID = value;}
        }

        /// <summary>
        /// Property related to the warrantiesDescription attribute
        /// </summary>
        public string WarrantiesDescription
        {
            get { return warrantiesDescription; } 
            set { warrantiesDescription = value; }
        }

        /// <summary>
        /// Property related to the warrantiesType attribute
        /// </summary>
        public int WarrantiesType
        {
            get { return warrantiesType; }
            set { warrantiesType = value; }
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
        /// Property related to the warrantiesPeriod attribute
        /// </summary>
        public int WarrantiesPeriod
        {
            get { return warrantiesPeriod; }
            set { warrantiesPeriod = value; }
        }

        /// <summary>
        /// Property related to the warrantiesCoverage attribute
        /// </summary>
        public string WarrantiesCoverage
        {
            get { return warrantiesCoverage; }
            set { warrantiesCoverage = value; }
        }


        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Warranties are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Warranties left, Warranties right)
        {
            if ((left.WarrantiesID == right.WarrantiesID) && (left.WarrantiesDescription == right.WarrantiesDescription)
                && (left.WarrantiesType == right.WarrantiesType) && (left.VisibilityStatus == right.VisibilityStatus)
                && (left.WarrantiesPeriod == right.WarrantiesPeriod) && (left.WarrantiesCoverage == right.WarrantiesCoverage))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Warranties are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Warranties left, Warranties right)
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
            return (String.Format("Warranties ID: {0} - Warranties Description: {1} - Warranties Type: {2} - Visibility Status: {3}" +
                " - Warranties Period {4} - Warranties Coverage: {5}", WarrantiesID.ToString(), WarrantiesDescription, 
                WarrantiesType.ToString(), VisibilityStatus.ToString(), WarrantiesPeriod.ToString(), WarrantiesCoverage));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Warranties)
            {
                Warranties warranty = (Warranties)obj;
                if (this == warranty)
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
