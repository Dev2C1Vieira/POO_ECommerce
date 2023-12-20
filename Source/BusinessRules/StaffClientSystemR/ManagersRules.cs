/*
 * <copyright file = "ManagersRules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/20/2023 6:12:34 PM </date>
 * <description></description>
 * 
 * */

using StaffClientSystem.Staff;
using StaffClientSystems;
using StaffClientSystemsE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

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
    public class ManagersRules
    {
        #region Methods

        /// <summary>
        /// Method that returns the number of elements present in the manager list.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsManagerIDAvailable(int managerID)
        {
            try
            {
                return Managers.IsManagerIDAvailable(managerID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated manager ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Managers.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of managers present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the managers historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Managers.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of managers present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the manager, whether it respects business rules.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertManager(Manager manager)
        {
            try
            {
                manager.ManagerID = Managers.ReturnIDNewManager();
                Managers.InsertManager(manager);
                return true;
            }
            catch (ManagerException ME)
            {
                throw new ManagerException("\nFailure of Business Rules!" + "-" + ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new manager!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Manager> ReturnManagersList()
        {
            try
            {
                return Managers.ReturnManagerList();
            }
            catch (ManagerException ME)
            {
                throw new ManagerException(ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the managers present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Manager> ReturnHistoric()
        {
            try
            {
                return Managers.ReturnHistoric();
            }
            catch (ManagerException ME)
            {
                throw new ManagerException(ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the managers historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that, depending on the field indicated to be changed, receives a 
        /// string and converts it to the data type that the attribute to be changed is.
        /// </summary>
        /// <param name="fieldToUpdate"></param>
        /// <param name="atribute"></param>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool UpdateManager(int fieldToUpdate, string atribute, int managerID)
        {
            try
            {
                return Managers.UpdateManager(fieldToUpdate, atribute, managerID);
            }
            catch (ManagerException ME)
            {
                throw new ManagerException("\nFailure of Business Rules!" + "-" + ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated manager!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function removes a manager by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveManager(int managerID)
        {
            try
            {
                return Managers.RemoveManager(managerID);
            }
            catch (ManagerException ME)
            {
                throw new ManagerException(ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated manager!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a manager by passing its ID as a parameter, putting it back as an available manager.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RecoverManager(int managerID)
        {
            try
            {
                return Managers.RecoverManager(managerID);
            }
            catch (ManagerException ME)
            {
                throw new ManagerException(ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated employee!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a manager by passing its ID as a parameter.
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        /// <exception cref="ManagerException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteManager(int managerID)
        {
            try
            {
                return Managers.DeleteManager(managerID);
            }
            catch (ManagerException ME)
            {
                throw new ManagerException(ME.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated manager!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the managers data from a file into the managers list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadManagersDataBin(string fileName)
        {
            try
            {
                return Managers.LoadManagersDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing manager data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to load manager data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load employees data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the managers data from the managers list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveManagersDataBin(string fileName)
        {
            try
            {
                return Managers.SaveManagersDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing manager data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save manager data!" + IOE.Message);
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
