/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 9:48:57 PM </date>
 * <description></description>
 * 
 * */

using System;

namespace StaffClientSystem
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 9:48:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>

    [Serializable]
    public class Person
    {
        #region Attributes

        private string name;
        private string gender; //
        private DateTime dateOfBirth;
        private string postalCode;
        private string address;
        private int phoneNumber;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Person()
        {
            name = string.Empty;
            gender = string.Empty;
            dateOfBirth = DateTime.Now;
            postalCode = string.Empty;
            address = string.Empty;
            phoneNumber = 0;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="dateOfBirth"></param>
        /// <param name="postalCode"></param>
        /// <param name="address"></param>
        /// <param name="phoneNumber"></param>
        public Person(string name, string gender, DateTime dateOfBirth, string postalCode, string address, int phoneNumber)
        {
            this.name = name;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.postalCode = postalCode;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }


        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'name' attribute
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property related to the 'gender' attribute
        /// </summary>
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Property related to the 'dateOfBirth' attribute
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        /// <summary>
        /// Property related to the 'postalCode' attribute
        /// </summary>
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        /// <summary>
        /// Property related to the 'address' attribute
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Property related to the 'phoneNumber' attribute
        /// </summary>
        public int PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
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
