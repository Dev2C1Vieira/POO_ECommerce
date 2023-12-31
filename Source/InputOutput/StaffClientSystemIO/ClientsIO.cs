/*
 * <copyright file = "ClientsIO.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 11:21:11 AM </date>
 * <description></description>
 * 
 * */

using System;
using System.Globalization;
using System.Collections.Generic;

// External
using ECValidations;
using StaffClientSystem;
using StaffClientSystemsE;

namespace StaffClientSystemIO
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ClientsIO
    {
        #region Methods

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static Client GetNewClientInformation(Client client)
        {
            // Name
            Console.Write("\nEnter client Name: ");
            client.Name = Console.ReadLine();

            // Gender
            Console.Write("\nEnter client Gender: ");
            client.Gender = Console.ReadLine();

            // Date of Birth
            Console.Write("\nEnter client Date of Birth (dd-MM-yyyy): ");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            client.DateOfBirth = launchDate;

            // Potal Code
            Console.Write("\nEnter client Postal Code: ");
            string postalCode = Console.ReadLine();
            if (ECValidate.IsPostalCode(postalCode) == true)
                client.PostalCode = postalCode;
            else
                throw new ClientException("\nPostal Code format is incorrect ... Please try again!!!");

            // Address
            Console.Write("\nEnter client Address: ");
            client.Address = Console.ReadLine();

            // Phone Number
            Console.Write("\nEnter client Phone Number: ");
            string phoneNumber = Console.ReadLine();
            if (ECValidate.IsPhoneNumber(phoneNumber) == true)
                client.PhoneNumber = int.Parse(phoneNumber);
            else
                throw new ClientException("\nPhone Number format is incorrect ... Please try again!!!");

            // Email
            Console.Write("\nEnter client Email: ");
            string email = Console.ReadLine();
            if (ECValidate.IsValidEmail(email) == true)
                client.Email = email;
            else
                throw new ClientException("\nEmail format is incorrect ... Please try again!!!");

            client.VisibilityStatus = true;

            return client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientsList"></param>
        /// <returns></returns>
        public static bool ListClientsInformation(List<Client> clientsList)
        {
            if (clientsList.Count == 0)
            {
                Console.WriteLine("|     The clients list is empty!     |");
                return false;
            }
            foreach (Client c in clientsList)
            {
                Console.WriteLine($"|  {c.ClientID}  |  {c.Name}  |  {c.Gender}  |  {c.DateOfBirth.ToShortDateString()}  |" +
                    $"  {c.PostalCode}  |  {c.Address}  |  {c.PhoneNumber}  |  {c.Email}  ");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientsList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Client> clientsList)
        {
            if (clientsList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Client c in clientsList)
            {
                Console.WriteLine($"|  {c.ClientID}  |  {c.Name}  |  {c.Gender}  |  {c.DateOfBirth.ToShortDateString()}  |" +
                    $"  {c.PostalCode}  |  {c.Address}  |  {c.PhoneNumber}  |  {c.Email}  ");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetClientID()
        {
            Console.Write("\nEnter Client ID: ");
            int clientID = int.Parse(Console.ReadLine());

            return clientID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <returns></returns>
        public static string GetAttributeToUpdate(int fieldToUpdate)
        {
            string newAttribute = string.Empty;
            if (fieldToUpdate == 1)
            {
                Console.Write("\nEnter client new Name: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.Write("\nEnter client new Gender: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.Write("\nEnter client new Date of Birth (dd-MM-yyyy): ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 4)
            {
                Console.Write("\nEnter client new Postal Code: ");
                string postalCode = Console.ReadLine();
                if (ECValidate.IsPostalCode(newAttribute) == true)
                    newAttribute = postalCode;
                else
                    throw new ClientException("\nNew Postal Code format is incorrect ... Please try again!!!");
            }
            else if (fieldToUpdate == 5)
            {
                Console.Write("\nEnter client new Address: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 6)
            {
                Console.Write("\nEnter client new Phone Number: ");
                string phoneNumber = Console.ReadLine();
                if (ECValidate.IsPhoneNumber(phoneNumber) == true)
                    newAttribute = phoneNumber;
                else
                    throw new ClientException("\nNew Phone Number format is incorrect ... Please try again!!!");
            }
            else if (fieldToUpdate == 7)
            {
                Console.Write("\nEnter client new Email: ");
                string email = Console.ReadLine();
                if (ECValidate.IsValidEmail(email) == true)
                    newAttribute = email;
                else
                    throw new ClientException("\nNew Email format is incorrect ... Please try again!!!");
            }

            return newAttribute;
        }

        #endregion
    }
}
