/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 9:49:13 PM </date>
 * <description></description>
 * 
 * */

using System;
using StaffClientSystem.Interfaces;

namespace StaffClientSystem
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 9:49:13 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Client : Person, IClient
    {
        #region Attributes

        /// <summary>
        /// Creation of the Clients class atributes
        /// </summary>
        private int id; //
        private bool gender; //
        private DateTime birthdate; //
        private string address; //
        private int phone_number; //
        private string email_address; //

        private static int qtdClients = 1; //

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client()
        {
            id = qtdClients;// a way to create an auto increment field
            qtdClients++;
            name = string.Empty;
            gender = true;
            birthdate = DateTime.Now;
            address = string.Empty;
            phone_number = -1;
            email_address = string.Empty;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthdate"></param>
        /// <param name="address"></param>
        /// <param name="phone_number"></param>
        /// <param name="email_address"></param>
        public Client(string name, bool gender, DateTime birthdate,
            string address, int phone_number, string email_address)
        {
            id = qtdClients;
            qtdClients++;
            this.name = name;
            this.gender = gender;
            this.birthdate = birthdate;
            this.address = address;
            this.phone_number = phone_number;
            this.email_address = email_address;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the id attribute
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Property related to the name attribute
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Property related to the gender attribute
        /// </summary>
        public bool Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        /// <summary>
        /// Property related to the birthdate attribute
        /// </summary>
        public DateTime BirthDate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }

        /// <summary>
        /// Property related to the address attribute
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Property related to the phone_number attribute
        /// </summary>
        public int PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }

        /// <summary>
        /// Property related to the email_address attribute
        /// </summary>
        public string EmailAddress
        {
            get { return email_address; }
            set { email_address = value; }
        }

        /// <summary>
        /// Property related to the qtdClients attribute
        /// </summary>
        public int QtdClients
        {
            get { return qtdClients; }
            set { qtdClients = value; }
        }


        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Clients are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Client left, Client right)
        {
            if ((left.ID == right.ID) && (left.Name == right.Name) && (left.Gender == right.Gender) &&
                (left.BirthDate.Date == right.BirthDate.Date) && (left.Address == right.Address) &&
                (left.PhoneNumber == right.PhoneNumber) && (left.EmailAddress == right.EmailAddress))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Clients are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Client left, Client right)
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
            return (String.Format("ID: {0} - Name: {1} - Gender: {2} - Birth Date: {3} - " +
                "Address: {4} - Phone Number: {5} - Email Address: {6}", ID.ToString(), Name,
                Gender.ToString(), BirthDate.ToString(), Address, PhoneNumber.ToString(), EmailAddress));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Client)
            {
                Client client = (Client)obj;
                if (this == client)
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

        public void InsertClient(Client client)
        {
            //Still in progress...
        }

        #endregion

        #region Destructor
        #endregion

        #endregion

        //Still in progress...
    }
}
