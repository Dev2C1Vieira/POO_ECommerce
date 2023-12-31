/*
 * <copyright file = "ClientsMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/19/2023 2:53:32 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.Collections.Generic;

// External
using StaffClientSystem;
using StaffClientSystemR;
using StaffClientSystemIO;
using StaffClientSystemsE;

namespace StaffClientSystemsM
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class ClientsMenu
    {
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        public static void Clear() { Console.Clear(); }

        /// <summary>
        /// 
        /// </summary>
        public static void Flushtdin() { while (Console.In.Peek() != -1 && Console.In.ReadLine() != null) { } }

        /// <summary>
        /// 
        /// </summary>
        public static void Pause()
        {
            Flushtdin();
            Console.WriteLine("\n\nPress ");
            Console.WriteLine("any key ");
            Console.WriteLine("to continue...");
            Console.ReadKey(true);
        }

        /// <summary>
        /// 
        /// </summary>
        public static void DisplayHistocicMenu()
        {
            List<Client> listingClients = new List<Client>();
            Console.WriteLine("\nTable containing the information of the clients historic.\n");
            // Table Construction
            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|  CODE  |  NAME  |  GENDER  |  DATE OF BIRTH  |  POSTAL CODE  |  ADDRESS  |  PHONE NUMBER  |  EMAIL  |");
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
            listingClients = ClientsRules.ReturnHistoric();
            ClientsIO.ListHistoric(listingClients);
            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {ClientsRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+----------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Clients Menu.        |");
            Console.WriteLine("+----------------------------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsFN"></param>
        /// <param name="categoriesFN"></param>
        /// <param name="brandsFN"></param>
        /// <param name="clientsFN"></param>
        /// <param name="employeesFN"></param>
        /// <param name="managersFN"></param>
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int clientID, op;
            bool result;

            while (true)
            {
                Clear();
                DisplayHistocicMenu();
                do
                {
                    Console.Write("\nChoose an Option: ");
                    op = int.Parse(Console.ReadLine());
                    if (op == 3)
                    {
                        Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                    }

                    if (op < 1 || op > 3)
                    {
                        Clear();
                        DisplayHistocicMenu();
                        Console.WriteLine("\n\n\tInvalid Option! [1/3]\n");
                    }
                    else
                    {
                        if (op == 1)
                        {
                            Console.WriteLine("\nLets Delete a Client!");

                            clientID = ClientsIO.GetClientID();

                            result = ClientsRules.DeleteClient(clientID);
                            if (result == true)
                                Console.WriteLine("\nClient was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the client!");

                            ClientsRules.SaveClientsDataBin(clientsFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Client!");

                            clientID = ClientsIO.GetClientID();

                            result = ClientsRules.RecoverClient(clientID);
                            if (result == true)
                                Console.WriteLine("\nClient was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the client!");

                            ClientsRules.SaveClientsDataBin(clientsFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsFN"></param>
        /// <param name="categoriesFN"></param>
        /// <param name="brandsFN"></param>
        /// <param name="clientsFN"></param>
        /// <param name="employeesFN"></param>
        /// <param name="managersFN"></param>
        /// <param name="stockFN"></param>
        /// <param name="salesFN"></param>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN,
            string employeesFN, string managersFN, string stockFN, string salesFN)
        {
            int op = 1, field, clientID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Clients Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing clients.            |");
                        Console.WriteLine("  |  2. Insert a new client.                  |");
                        Console.WriteLine("  |  3. Update client information.            |");
                        Console.WriteLine("  |  4. Remove a client.                      |");
                        Console.WriteLine("  |  5. Show clients historic.                |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Client> listingClients = new List<Client>();
                            Console.WriteLine("\nTable containing the information of the existing clients.\n");
                            // Table Construction
                            Console.WriteLine("\n+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  GENDER  |  DATE OF BIRTH  |  POSTAL CODE  |  ADDRESS  |  PHONE NUMBER  |  EMAIL  |");
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            listingClients = ClientsRules.ReturnClientsList();
                            ClientsIO.ListClientsInformation(listingClients);
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {ClientsRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Client!");

                            Client client = new Client();
                            client = ClientsIO.GetNewClientInformation(client);

                            result = ClientsRules.InsertClient(client);

                            if (result == true)
                                Console.WriteLine("\nNew client inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new client!");
                            }

                            ClientsRules.SaveClientsDataBin(clientsFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Client!");

                            clientID = ClientsIO.GetClientID();

                            if (ClientsRules.IsClientIDAvailable(clientID) == false)
                            {
                                Console.WriteLine("\nClient does not exist! ... Please enter an ID of an existing client.");
                                Pause();
                                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            }

                            Clear();

                            //
                            Console.WriteLine("\nChoose which field you want to change:");

                            Console.WriteLine("\n  +-------------------------------------------+");
                            Console.WriteLine("  |  1. Update client Name.                   |");
                            Console.WriteLine("  |  2. Update client Gender.                 |");
                            Console.WriteLine("  |  3. Update client Date of Birth.          |");
                            Console.WriteLine("  |  4. Update client Postal Code.            |");
                            Console.WriteLine("  |  5. Update client Address.                |");
                            Console.WriteLine("  |  6. Update client Phone Number.           |");
                            Console.WriteLine("  |  7. Update client Email.                  |");
                            Console.WriteLine("  |  8. Back!                                 |");
                            Console.WriteLine("  +-------------------------------------------+");
                            Console.Write("\nOption: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 8) { Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN); }

                            Clear();

                            string attribute = ClientsIO.GetAttributeToUpdate(field);

                            result = ClientsRules.UpdateClient(field, attribute, clientID);
                            if (result == true)
                                Console.WriteLine("\nClient was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the client!");

                            ClientsRules.SaveClientsDataBin(clientsFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Client!");

                            clientID = ClientsIO.GetClientID();

                            result = ClientsRules.RemoveClient(clientID);
                            if (result == true)
                                Console.WriteLine("\nClient was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the client!");

                            ClientsRules.SaveClientsDataBin(clientsFN);

                            Pause();
                            break;
                        case 5:
                            LoopDisplayHistocicMenu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                        case 6:
                            SCSMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
                            break;
                    }
                }
            }
            catch (ClientException CE)
            {
                Console.WriteLine(CE.Message);
                Pause();
            }
            catch (FormatException E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            catch (Exception E)
            {
                Console.WriteLine(E.Message);
                Pause();
            }
            finally
            {
                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN, stockFN, salesFN);
            }
        }

        #endregion
    }
}
