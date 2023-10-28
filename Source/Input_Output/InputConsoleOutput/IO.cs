/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 10/28/2023 8:01:25 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using BrandsDLL;
using CampaignsDLL;
using CategoriesDLL;
using ClientsDLL;
using GuaranteesDLL;
using ProductsDLL;
using SalesDLL;
using StocksDLL;

namespace InputConsoleOutput
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 10/28/2023 8:01:25 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class IO
    {
        #region Methods

        #region Constructors

        /// <summary>
        /// The default Constructor
        /// </summary>
        public IO() { }

        #endregion

        #region OtherMethods

        #region ClientsMethods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        public static void ShowClientInformation(Clients client)
        {
            if (client.Gender == 1)
                Console.WriteLine("\nName: {0}" + "\n" + "Gender: Male" + "\n" + "Address: {1}" + "\n" + 
                    "Phone Number: {2}" + "\n" + "Email Address: {3}", client.Name, 
                    client.Address, client.PhoneNumber.ToString(),client.EmailAddress);
            else
                Console.WriteLine("\nName: {0}" + "\n" + "Gender: Female" + "\n" + "Address: {1}" + "\n" +
                    "Phone Number: {2}" + "\n" + "Email Address: {3}", client.Name,
                    client.Address, client.PhoneNumber.ToString(), client.EmailAddress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client1"></param>
        /// <param name="client2"></param>
        /// <returns></returns>
        public static bool CompareClients(Clients client1, Clients client2)
        {
            if (client1.Equals(client2)) return (true);
            else return (false);
        }

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
