/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:42:11 AM </date>
 * <description></description>
 * 
 * */

using System;

namespace ProductCatalog
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/8/2023 11:42:11 AM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Categories
    {
        #region Attributes

        /// <summary>
        /// Creation of the Categories class atributes
        /// </summary>
        private int categoryID; // 
        private string categoryName; // 
        //private string categoryDescription; // A brief description that provides more information about the content or purpose of the category.
        //Categories categoryParent; // If the category system has a hierarchy, i can therefore include a reference to the 'Parent' category. Allowing the creation of subordinate categories.
        //Products[] productsList; // A list of products that belong to this category.
        private bool visibilityStatus; // An indicator of whether the category is visible to users.
        private DateTime creationDate; // The date the category was created.
        //private DateTime latestUpdate; // The date the category was last updated.
        private int displayOrder; // A number that determines the order in which categories are displayed to the user.

        private static int qtdCategories = 1; //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Categories()
        {
            categoryID = qtdCategories;
            qtdCategories++;
            categoryName = string.Empty;
            visibilityStatus = false;
            creationDate = DateTime.Now;
            displayOrder = -1;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="visibilityStatus"></param>
        /// <param name="creationDate"></param>
        /// <param name="displayOrder"></param>
        public Categories(string categoryName, bool visibilityStatus, DateTime creationDate, int displayOrder)
        {
            categoryID = qtdCategories;
            qtdCategories++;
            this.categoryName = categoryName;
            this.visibilityStatus = visibilityStatus;
            this.creationDate = creationDate;
            this.displayOrder = displayOrder;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the categoryID attribute
        /// </summary>
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        /// <summary>
        /// Property related to the categoryName attribute
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
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

        /// <summary>
        /// Property related to the displayOrder attribute
        /// </summary>
        public int DisplayOrder
        {
            get { return displayOrder; }
            set { displayOrder = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Categories are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Categories left, Categories right)
        {
            if ((left.CategoryID == right.CategoryID) && (left.CategoryName == right.CategoryName)
                && (left.VisibilityStatus == right.VisibilityStatus) && (left.CreationDate == right.CreationDate)
                && (left.DisplayOrder == right.DisplayOrder))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Categories are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Categories left, Categories right)
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
            return (String.Format("Category ID: {0} - Category Name: {1} - Visibility Status: {2} - Creation Date: {3} - Display Order: {4}", 
                CategoryID.ToString(), CategoryName, VisibilityStatus.ToString(), CreationDate.ToString(), DisplayOrder.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Categories)
            {
                Categories category = (Categories)obj;
                if (this == category)
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
