/*
 * <copyright file = "EmployeesRules.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/20/2023 6:12:21 PM </date>
 * <description></description>
 * 
 * */

using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization;

// External
using StaffClientSystems;
using StaffClientSystemsE;
using StaffClientSystem.Staff;

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
    public class EmployeesRules
    {
        #region Methods

        /// <summary>
        /// Method that returns the number of elements present in the employees list.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool IsEmployeeIDAvailable(int employeeID)
        {
            try
            {
                return Employees.IsEmployeeIDAvailable(employeeID);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to verify if the indicated employee ID is available!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int ReturnAmountListRecords()
        {
            try
            {
                return Employees.ReturnAmountListRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of employees present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns the number of elements present in the employees historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            try
            {
                return Employees.ReturnAmountHistoricRecords();
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to return the amount of employees present in the historic!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that checks, before inserting the employee, whether it respects business rules.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool InsertEmployee(Employee employee)
        {
            try
            {
                employee.EmployeeID = Employees.ReturnIDNewEmployee();
                Employees.InsertEmployee(employee);
                return true;
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException("\nFailure of Business Rules!" + "-" + EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to insert a new employee!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements present in the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Employee> ReturnEmployeesList()
        {
            try
            {
                return Employees.ReturnEmployeesList();
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException(EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to list the employees present in the list!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static List<Employee> ReturnHistoric()
        {
            try
            {
                return Employees.ReturnHistoric();
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException(EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to show the employees historic!" + "-" + E.Message);
            }
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
        /// <exception cref="Exception"></exception>
        public static bool UpdateEmployee(int fieldToUpdate, string atribute, int employeeID)
        {
            try
            {
                return Employees.UpdateEmployee(fieldToUpdate, atribute, employeeID);
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException("\nFailure of Business Rules!" + "-" + EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to update the indicated employee!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function removes a employee by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RemoveEmployee(int employeeID)
        {
            try
            {
                return Employees.RemoveEmployee(employeeID);
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException(EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to remove the indicated employee!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function recovers a employee by passing its ID as a parameter, putting it back as an available employee.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool RecoverEmployee(int employeeID)
        {
            try
            {
                return Employees.RecoverEmployee(employeeID);
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException(EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to recover the indicated employee!" + "-" + E.Message);
            }
        }

        /// <summary>
        /// This function deletes a employee by passing its ID as a parameter.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool DeleteEmployee(int employeeID)
        {
            try
            {
                return Employees.DeleteEmployee(employeeID);
            }
            catch (EmployeeException EE)
            {
                throw new EmployeeException(EE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nFailed to delete the indicated employee!" + "-" + E.Message);
            }
        }

        #region File Management

        /// <summary>
        /// Method that loads the employees data from a file into the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool LoadEmployeesDataBin(string fileName)
        {
            try
            {
                return Employees.LoadEmployeesDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing employee data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to load employee data!" + IOE.Message);
            }
            catch (Exception E)
            {
                throw new Exception("\nUnable to load employees data from file!" + E.Message);
            }
        }

        /// <summary>
        /// Method that saves the employees data from the employees list into a file.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="SerializationException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="Exception"></exception>
        public static bool SaveEmployeesDataBin(string fileName)
        {
            try
            {
                return Employees.SaveEmployeesDataBin(fileName);
            }
            catch (SerializationException SE)
            {
                throw new SerializationException("\nError serializing employee data!" + SE.Message);
            }
            catch (IOException IOE)
            {
                throw new IOException("\nIO error when trying to save employee data!" + IOE.Message);
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
