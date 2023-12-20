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

    [Serializable]
    public class Client : Person, IClient, IComparable<Client>
    {
        #region Attributes

        /// <summary>
        /// Creation of the Client class atributes
        /// </summary>
        private int clientID;
        private string email;
        private bool visibilityStatus; // An indicator of whether the client is visible to users.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Client()
        {
            clientID = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = DateTime.Now;
            PostalCode = string.Empty;
            Address = string.Empty;
            PhoneNumber = 0;
            email = string.Empty;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthdate"></param>
        /// <param name="postalCode"></param>
        /// <param name="address"></param>
        /// <param name="phone_number"></param>
        /// <param name="email"></param>
        /// <param name="visibilityStatus"></param>
        public Client(int clientID, string name, string gender, DateTime birthdate, 
            string postalCode, string address, int phone_number, string email, bool visibilityStatus)
        {
            this.clientID = clientID;
            Name = name;
            Gender = gender;
            DateOfBirth = birthdate;
            PostalCode = postalCode;
            Address = address;
            PhoneNumber = phone_number;
            this.email = email;
            this.visibilityStatus = visibilityStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'clientID' attribute
        /// </summary>
        public int ClientID
        {
            get { return clientID; }
            set { clientID = value; }
        }

        /// <summary>
        /// Property related to the 'email' attribute
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; }
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
        /// Creating/Rewriting this method, to be able to check whether two indicated Clients are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Client left, Client right)
        {
            if ((left.ClientID == right.ClientID) && (left.Name == right.Name) && (left.Gender == right.Gender)
                && (left.DateOfBirth == right.DateOfBirth) && (left.PostalCode == right.PostalCode) && (left.Address == right.Address)
                && (left.PhoneNumber == right.PhoneNumber) && (left.Email == right.Email) && (left.VisibilityStatus == right.VisibilityStatus))
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
            return (String.Format("Client ID: {0} - Name: {1} - Gender: {2} - Date of Birth: {3}" +
                " - Postal Code: {4} - Address: {5} - Phone Number: {6} - Email: {7}",
                ClientID.ToString(), Name, Gender.ToString(), DateOfBirth.ToString(), 
                PostalCode, Address, PhoneNumber.ToString(), Email));
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

        /// <summary>
        /// Method that orders based on the cost of the client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int CompareTo(Client client)
        {
            return this.PhoneNumber.CompareTo(client.PhoneNumber);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Client()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
