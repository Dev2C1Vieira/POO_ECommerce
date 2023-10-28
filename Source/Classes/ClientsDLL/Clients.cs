/*
 * <copyright file = "Clients.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 26/10/2023 - 20:30:13 </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;

namespace ClientsDLL
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 26/10/2023 - 20:30:13
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Clients
    {
        #region Attributes

        /// <summary>
        /// Creation of the Clients class atributes
        /// </summary>
        private string name;
        private DateTime birth_date;
        private int gender;
        private string address;
        private int phone_number;
        private string email_address;

        private static int Qtd_Clients;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Clients()
        {
            name = "";
            gender = -1;
            address = "";
            phone_number = -1;
            email_address = "";
            Qtd_Clients = 0;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="External_name"></param>
        /// <param name="External_gender"></param>
        /// <param name="External_address"></param>
        /// <param name="External_phone_number"></param>
        /// <param name="External_email_address"></param>
        public Clients(string External_name, int External_gender, string External_address,
            int External_phone_number, string External_email_address)
        {
            this.name = External_name;
            this.gender = External_gender;
            this.address = External_address;
            this.phone_number = External_phone_number;
            this.email_address = External_email_address;
        }

        #endregion

        #region Properties
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
        public int Gender
        {
            get { return gender; }
            set { gender = value; }
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

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Clients left, Clients right) 
        {
            if ((left.Name == right.Name) && (left.Gender == right.Gender) 
                && (left.Address == right.Address) && (left.PhoneNumber == right.PhoneNumber) 
                && (left.EmailAddress == right.EmailAddress)) return (true);
            return (false);

        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Clients left, Clients right)
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
            return (String.Format("Name: {0} - Gender: {1} - Address: {2} - Phone Number: {3} " +
                "- Email Address: {4}", Name, Gender.ToString(), Address, PhoneNumber.ToString(), EmailAddress));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Clients)
            {
                Clients client = (Clients)obj;
                if (this == client)
                    return (true);
            }
            return (false);
        }

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
