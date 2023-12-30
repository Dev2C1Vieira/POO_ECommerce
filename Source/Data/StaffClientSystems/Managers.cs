/*
 * <copyright file = "Managers.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/20/2023 12:29:29 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.IO;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

// External
using StaffClientSystem.Staff;
using StaffClientSystemsE;

namespace StaffClientSystems
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 12/11/2023 10:38:57 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Managers
    {
        #region Attributes

        /// <summary>
        /// Creation of the Managers class atributes
        /// </summary>
        private static List<Manager> managersList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        static Managers()
        {
            managersList = new List<Manager>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'managersList' attribute
        /// </summary>
        public static List<Manager> ManagersList
        {
            get { return managersList; }
            set { managersList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given Manager already exists in the List.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static bool ExistManager(Manager manager)
        {
            if (ManagersList.Contains(manager))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given manager is visible or not.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        public static bool IsManagerAvailable(Manager manager)
        {
            if (manager.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two managers, indicated by parameter.
        /// </summary>
        /// <param name="manager1"></param>
        /// <param name="manager2"></param>
        /// <returns></returns>
        public static bool CompareManagers(Manager manager1, Manager manager2)
        {
            if (manager1.Equals(manager2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the managers list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsManagersListEmpty()
        {
            if (ManagersList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewManager()
        {
            if (IsManagersListEmpty() == true)
                return 1;

            Manager aux = ManagersList.Last();
            return aux.ManagerID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the managers list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Manager manager in ManagersList)
            {
                if (manager.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the managers historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Manager manager in ManagersList)
            {
                if (manager.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a manager that has the id indicated by the user.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        public static bool IsManagerIDAvailable(int managerID)
        {
            foreach (Manager manager in ManagersList)
            {
                if (manager.ManagerID == managerID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Manager, using its ID.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        public static Manager ReturnManagerFromID(int managerID)
        {
            Manager auxManager = new Manager();
            foreach (Manager manager in ManagersList)
            {
                if (manager.ManagerID == managerID)
                    auxManager = manager;
                else continue;
            }
            return auxManager;
        }

        /// <summary>
        /// This function inserts a employee passed as a List parameter.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static bool InsertManager(Manager manager)
        {
            if (ExistManager(manager) == true)
                throw new ManagerException("\nUnable to insert new manager ... Manager is already inserted!");

            ManagersList.Add(manager);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements manager in the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static List<Manager> ReturnManagerList()
        {
            List<Manager> listaAux = new List<Manager>();

            if (IsManagersListEmpty() == true)
                throw new ManagerException("\nThe managers list is empty!");

            foreach (Manager manager in ManagersList)
            {
                if (manager.VisibilityStatus == true)
                    listaAux.Add(manager);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static List<Manager> ReturnHistoric()
        {
            List<Manager> listaAux = new List<Manager>();

            if (IsManagersListEmpty() == true)
                throw new ManagerException("\nThe managers list is empty!");

            foreach (Manager manager in ManagersList)
            {
                if (manager.VisibilityStatus == false)
                    listaAux.Add(manager);
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
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool UpdateManager(int fieldToUpdate, string atribute, int managerID)
        {
            Manager manager = ReturnManagerFromID(managerID);
            if (ExistManager(manager) == false)
                throw new ManagerException("\nUnable to update manager ... Manager does not exist!");

            foreach (Manager m in ManagersList)
            {
                if (m.Equals(manager))
                {
                    if (fieldToUpdate == 1)
                    {
                        manager.Name = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        manager.Gender = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        manager.DateOfBirth = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                    else if (fieldToUpdate == 4)
                    {
                        manager.PostalCode = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 5)
                    {
                        manager.Address = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 6)
                    {
                        manager.PhoneNumber = int.Parse(atribute);
                        return true;
                    }
                    else if (fieldToUpdate == 7)
                    {
                        manager.JobTitle = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 8)
                    {
                        manager.WorkEmail = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 9)
                    {
                        manager.Password = atribute;
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function removes a manager by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static bool RemoveManager(int managerID)
        {
            if (ExistManager(ReturnManagerFromID(managerID)) == false)
                throw new ManagerException("\nUnable to remove manager ... Manager does not exist!");

            foreach (Manager manager in ManagersList)
            {
                if (manager.Equals(ReturnManagerFromID(managerID)))
                {
                    if (manager.VisibilityStatus == true)
                    {
                        manager.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new ManagerException("\nUnable to remove manager ... Manager has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a employee by passing its ID as a parameter, putting it back as an available employee.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool RecoverManager(int managerID)
        {
            if (ExistManager(ReturnManagerFromID(managerID)) == false)
                throw new ManagerException("\nUnable to recover manager ... Manager does not exist!");

            foreach (Manager manager in ManagersList)
            {
                if (manager.Equals(ReturnManagerFromID(managerID)))
                {
                    if (manager.VisibilityStatus == false)
                    {
                        manager.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new ManagerException("\nUnable to recover manager ... Manager hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a employee by passing its ID as a parameter.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static bool DeleteManager(int managerID)
        {
            if (ExistManager(ReturnManagerFromID(managerID)) == false)
                throw new ManagerException("\nUnable to delete manager ... Manager does not exist!");

            foreach (Manager manager in ManagersList)
            {
                if (manager.Equals(ReturnManagerFromID(managerID)))
                {
                    if (manager.VisibilityStatus == false)
                    {
                        ManagersList.Remove(manager);
                        return true;
                    }
                    else
                        throw new EmployeeException("\nUnable to delete manager ... Manager hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that allows the employee to login to its account!
        /// </summary>
        /// <param name="workEmail"></param>
        /// <param name="password"></param>
        /// <param name="managerName"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        public static bool LoginManager(string workEmail, string password, out string managerName)
        {
            if (IsManagersListEmpty() == true)
                throw new ManagerException("\nThere isn't any manager with that credentials. ... Managers list is empty!");

            foreach (Manager manager in ManagersList)
            {
                if ((manager.WorkEmail == workEmail) && (manager.Password == password) && (manager.VisibilityStatus == true))
                {
                    managerName = manager.Name;
                    return true;
                }
                else continue;
            }
            managerName = string.Empty;
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the managers data from a file into the managers list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadManagersDataBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Manager> loadedManagers = (List<Manager>)formatter.Deserialize(fileStream);

                    foreach (Manager manager in loadedManagers)
                    {
                        ManagersList.Add(manager);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the managers data from the managers list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool SaveManagersDataBin(string fileName)
        {
            // Creates a FileStream to write manager data to the file.
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, ManagersList);
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
