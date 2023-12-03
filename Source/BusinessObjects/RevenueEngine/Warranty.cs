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
    public class Warranty
    {
        #region Attributes

        /// <summary>
        /// Creation of the Warranty class atributes
        /// </summary>
        private int warrantyID; // A unique identifier for each collateral.
        private string warrantyDescription; // Product guarantee, satisfaction guarantee, low price guarantee, etc.
        private int warrantyType; // A brief description of the warranty terms.
        //private Product[] productsList; // A list of products associated with the warranty.
        private bool visibilityStatus; // An indicator of whether the warranty is visible to users.
        private int warrantyPeriod; // The duration of the warranty.
        private string warrantyCoverage; // Details about what the warranty covers.

        private static int qtdWarranty = 1; // 

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Warranty()
        {
            warrantyID = qtdWarranty;
            qtdWarranty++;
            warrantyDescription = string.Empty;
            warrantyType = -1;
            visibilityStatus = false;
            warrantyPeriod = -1;
            warrantyCoverage = string.Empty;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="warrantiesDescription"></param>
        /// <param name="warrantiesType"></param>
        /// <param name="warrantiesPeriod"></param>
        /// <param name="warrantiesCoverage"></param>
        public Warranty(string warrantiesDescription, int warrantiesType, bool visibilityStatus, int warrantiesPeriod, string warrantiesCoverage)
        {
            warrantyID = qtdWarranty;
            qtdWarranty++;
            this.warrantyDescription = warrantiesDescription;
            this.warrantyType = warrantiesType;
            this.visibilityStatus = visibilityStatus;
            this.warrantyPeriod = warrantiesPeriod;
            this.warrantyCoverage = warrantiesCoverage;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the warrantyID attribute
        /// </summary>
        public int WarrantyID
        {
            get { return warrantyID; }
            set { warrantyID = value;}
        }

        /// <summary>
        /// Property related to the warrantyDescription attribute
        /// </summary>
        public string WarrantyDescription
        {
            get { return warrantyDescription; } 
            set { warrantyDescription = value; }
        }

        /// <summary>
        /// Property related to the warrantyType attribute
        /// </summary>
        public int WarrantyType
        {
            get { return warrantyType; }
            set { warrantyType = value; }
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
        /// Property related to the warrantyPeriod attribute
        /// </summary>
        public int WarrantyPeriod
        {
            get { return warrantyPeriod; }
            set { warrantyPeriod = value; }
        }

        /// <summary>
        /// Property related to the warrantyCoverage attribute
        /// </summary>
        public string WarrantyCoverage
        {
            get { return warrantyCoverage; }
            set { warrantyCoverage = value; }
        }


        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Warranty are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Warranty left, Warranty right)
        {
            if ((left.WarrantyID == right.WarrantyID) && (left.WarrantyDescription == right.WarrantyDescription)
                && (left.WarrantyType == right.WarrantyType) && (left.VisibilityStatus == right.VisibilityStatus)
                && (left.WarrantyPeriod == right.WarrantyPeriod) && (left.WarrantyCoverage == right.WarrantyCoverage))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Warranty are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Warranty left, Warranty right)
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
            return (String.Format("Warranty ID: {0} - Warranty Description: {1} - Warranty Type: {2} - Visibility Status: {3}" +
                " - Warranty Period {4} - Warranty Coverage: {5}", WarrantyID.ToString(), WarrantyDescription, 
                WarrantyType.ToString(), VisibilityStatus.ToString(), WarrantyPeriod.ToString(), WarrantyCoverage));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Warranty)
            {
                Warranty warranty = (Warranty)obj;
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

        //Still in progress...
    }
}
