/*
 * <copyright file = "ClientsRules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 10:57:20 AM </date>
 * <description></description>
 * 
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

// External
using StaffClientSystem;
using StaffClientSystems;
using StaffClientSystemsE;

namespace StaffClientSystemR
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ClientsRules
    {
        #region Methods

        /// <summary>
        /// Method that returns the number of elements present in the clients list.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsClientIDAvailable(int clientID)
        {
            try
            {
                return Clients.IsClientIDAvailable(clientID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated client ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the clients list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Clients.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of clients present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the clients historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Clients.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of clients present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the client, whether it respects business rules.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertClient(Client client)
        {
            try
            {
                client.ClientID = Clients.ReturnIDNewClient();
                Clients.InsertClient(client);
                return true;
            }
            catch (ClientException CE)
            {
                throw new ClientException("\nFailure of Business Rules!" + "-" + CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new client!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the clients list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Client> ReturnClientsList()
        {
            try
            {
                return Clients.ReturnClientsList();
            }
            catch (ClientException CE)
            {
                throw new ClientException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the clients present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the clients list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Client> ReturnHistoric()
        {
            try
            {
                return Clients.ReturnHistoric();
            }
            catch (ClientException CE)
            {
                throw new ClientException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the clients historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool UpdateClient(int fieldToUpdate, string atribute, int clientID)
        {
            try
            {
                return Clients.UpdateClient(fieldToUpdate, atribute, clientID);
            }
            catch (ClientException CE)
            {
                throw new ClientException("\nFailure of Business Rules!" + "-" + CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated client!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function removes a client by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveClient(int clientID)
        {
            try
            {
                return Clients.RemoveClient(clientID);
            }
            catch (ClientException CE)
            {
                throw new ClientException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated client!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a client by passing its ID as a parameter, putting it back as an available client.
        /// </summary>
        /// <param name="productID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool RecoverClient(int clientID)
        {
            try
            {
                return Clients.RecoverClient(clientID);
            }
            catch (ClientException CE)
            {
                throw new ClientException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated client!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a client by passing its ID as a parameter.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteClient(int clientID)
        {
            try
            {
                return Clients.DeleteClient(clientID);
            }
            catch (ClientException CE)
            {
                throw new ClientException(CE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated client!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the clients data from a file into the clients list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadClientsDataBin(string fileName)
        {
            try
            {
                return Clients.LoadClientsDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing client data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to load client data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load clients data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the clients data from the clients list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveClientsDataBin(string fileName)
        {
            try
            {
                return Clients.SaveClientsDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing client data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save client data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to save the data in the file!" + E.Message);
            }
        }

        #endregion

        #endregion
    }
}
