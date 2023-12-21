/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/8/2023 11:42:11 AM </date>
 * <description></description>
 * 
 * */

using ProductCatalog.Interfaces;
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

    [Serializable]
    public class Category : ICategory, IComparable<Category>
    {
        #region Attributes

        /// <summary>
        /// Creation of the Category class atributes
        /// </summary>
        private int categoryID; // 
        private string categoryName; // 
        private string categoryDescription; // A brief description that provides more information about the content or purpose of the category.
        private DateTime creationDate; // The date the category was created.
        private int brandID; // 
        private bool visibilityStatus; // An indicator of whether the category is visible to users.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Category()
        {
            categoryID = 0;
            categoryName = string.Empty;
            categoryDescription = string.Empty;
            creationDate = DateTime.Now;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="categoryDescription"></param>
        /// <param name="creationDate"></param>
        /// <param name="visibilityStatus"></param>
        public Category(string categoryName, string categoryDescription, DateTime creationDate, bool visibilityStatus)
        {
            categoryID = 0;
            this.categoryName = categoryName;
            this.categoryDescription = categoryDescription;
            this.creationDate = creationDate;
            this.visibilityStatus = visibilityStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'categoryID' attribute
        /// </summary>
        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        /// <summary>
        /// Property related to the 'categoryName' attribute
        /// </summary>
        public string CategoryName
        {
            get { return categoryName; }
            set { categoryName = value; }
        }

        /// <summary>
        /// Property related to the 'categoryDescription' attribute
        /// </summary>
        public string CategoryDescription
        {
            get { return categoryDescription; }
            set { categoryDescription = value; }
        }

        /// <summary>
        /// Property related to the 'creationDate' attribute
        /// </summary>
        public DateTime CreationDate
        {
            get { return creationDate; } 
            set { creationDate = value; }
        }

        /// <summary>
        /// Property related to the 'brandID' attribute
        /// </summary>
        public int BrandID
        {
            get { return brandID; }
            set { brandID = value; }
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
        /// Creating/Rewriting this method, to be able to check whether two indicated Category are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Category left, Category right)
        {
            if ((left.CategoryID == right.CategoryID) && (left.CategoryName == right.CategoryName)
                && (left.CategoryDescription == right.CategoryDescription) && (left.CreationDate == right.CreationDate) 
                && (left.VisibilityStatus == right.VisibilityStatus))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Category are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Category left, Category right)
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
            return (String.Format("Category ID: {0} - Category Name: {1} - Category Description: {2} - Creation Date: {3}", 
                CategoryID.ToString(), CategoryName, CategoryDescription, CreationDate.ToString()));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Category)
            {
                Category category = (Category)obj;
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

        /// <summary>
        /// Method that orders based on the description of the category.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        public int CompareTo(Category category)
        {
            return this.CategoryDescription.CompareTo(category.CategoryDescription);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Category()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
