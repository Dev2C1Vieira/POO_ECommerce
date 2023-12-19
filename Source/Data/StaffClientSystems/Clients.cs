/*
 * <copyright file = "Clients.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/15/2023 4:03:21 PM </date>
 * <description> [Write the description of the project!] </description>
 * 
 * */

using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

// External
using StaffClientSystem;
using StaffClientSystemsE;

namespace StaffClientSystems
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/15/2023 4:03:21 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Clients
    {
        #region Attributes

        /// <summary>
        /// Atributes creation
        /// </summary>
        private static List<Client> clientsList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        static Clients()
        {
            clientsList = new List<Client>();   
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'clientsList' attribute
        /// </summary>
        public static List<Client> ClientsList
        {
            get { return clientsList; }
            set { clientsList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given client already exists in the List.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool ExistClient(Client client)
        {
            if (ClientsList.Contains(client))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given client is visible or not.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public static bool IsClientAvailable(Client client)
        {
            if (client.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two clients, indicated by parameter.
        /// </summary>
        /// <param name="client1"></param>
        /// <param name="client2"></param>
        /// <returns></returns>
        public static bool CompareClients(Client client1, Client client2)
        {
            if (client1.Equals(client2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the clients list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsClientsListEmpty()
        {
            if (ClientsList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewClient()
        {
            if (IsClientsListEmpty() == true)
                return 1;

            Client aux = ClientsList.Last();
            return aux.ClientID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the clients list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Client client in ClientsList)
            {
                if (client.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the clients historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Client client in ClientsList)
            {
                if (client.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a client that has the id indicated by the user.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static bool IsClientIDAvailable(int clientID)
        {
            foreach (Client client in ClientsList)
            {
                if (client.ClientID == clientID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Client, using its ID.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        public static Client ReturnClientFromID(int clientID)
        {
            Client auxClient = new Client();
            foreach (Client client in ClientsList)
            {
                if (client.ClientID == clientID)
                    auxClient = client;
                else continue;
            }
            return auxClient;
        }

        /// <summary>
        /// This function inserts a client passed as a List parameter.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static bool InsertClient(Client client)
        {
            if (ExistClient(client) == true)
                throw new ClientException("\nUnable to insert new client ... Client is already inserted!");

            ClientsList.Add(client);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements client in the product list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static List<Client> ReturnClientsList()
        {
            List<Client> listaAux = new List<Client>();

            if (IsClientsListEmpty() == true)
                throw new ClientException("\nThe clients list is empty!");

            foreach (Client client in ClientsList)
            {
                if (client.VisibilityStatus == true)
                    listaAux.Add(client);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the clients list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static List<Client> ReturnHistoric()
        {
            List<Client> listaAux = new List<Client>();

            if (IsClientsListEmpty() == true)
                throw new ClientException("\nThe client list is empty!");

            foreach (Client client in ClientsList)
            {
                if (client.VisibilityStatus == false)
                    listaAux.Add(client);
                else continue;
            }
            return listaAux;
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
        public static bool UpdateClient(int fieldToUpdate, string atribute, int clientID)
        {
            Client client = ReturnClientFromID(clientID);
            if (ExistClient(client) == false)
                throw new ClientException("\nUnable to update client ... Client does not exist!");

            foreach (Client c in ClientsList)
            {
                if (c.Equals(client))
                {
                    if (fieldToUpdate == 1)
                    {
                        client.Name = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        client.Gender = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        client.DateOfBirth = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                    else if (fieldToUpdate == 4)
                    {
                        client.PostalCode = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 5)
                    {
                        client.Address = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 6)
                    {
                        client.PhoneNumber = int.Parse(atribute);
                        return true;
                    }
                    else if (fieldToUpdate == 7)
                    {
                        client.Email = atribute;
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function removes a product by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static bool RemoveClient(int clientID)
        {
            if (ExistClient(ReturnClientFromID(clientID)) == false)
                throw new ClientException("\nUnable to remove client ... Client does not exist!");

            foreach (Client client in ClientsList)
            {
                if (client.Equals(ReturnClientFromID(clientID)))
                {
                    if (client.VisibilityStatus == true)
                    {
                        client.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new ClientException("\nUnable to remove client ... Client has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a client by passing its ID as a parameter, putting it back as an available client.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static bool RecoverClient(int clientID)
        {
            if (ExistClient(ReturnClientFromID(clientID)) == false)
                throw new ClientException("\nUnable to recover client ... Client does not exist!");

            foreach (Client client in ClientsList)
            {
                if (client.Equals(ReturnClientFromID(clientID)))
                {
                    if (client.VisibilityStatus == false)
                    {
                        client.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new ClientException("\nUnable to recover client ... Client hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a client by passing its ID as a parameter.
        /// </summary>
        /// <param name="clientID"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static bool DeleteClient(int clientID)
        {
            if (ExistClient(ReturnClientFromID(clientID)) == false)
                throw new ClientException("\nUnable to delete client ... Client does not exist!");

            foreach (Client client in ClientsList)
            {
                if (client.Equals(ReturnClientFromID(clientID)))
                {
                    if (client.VisibilityStatus == false)
                    {
                        ClientsList.Remove(client);
                        return true;
                    }
                    else
                        throw new ClientException("\nUnable to delete client ... Client hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the clients data from a file into the clients list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadClientsDataBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Client> loadedClients = (List<Client>)formatter.Deserialize(fileStream);

                    foreach (Client client in loadedClients)
                    {
                        ClientsList.Add(client);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the clients data from the clients list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="ClientException"></exception>
        public static bool SaveClientsDataBin(string fileName)
        {
            if (IsClientsListEmpty() == true)
                throw new ClientException("\nThe clients list is empty!");

            // Cria um FileStream para gravar os dados dos clientes no arquivo
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, ClientsList);
            }
            return true;
        }

        #endregion

        #endregion

        #region Destructor
        #endregion

        #endregion
    }
}
