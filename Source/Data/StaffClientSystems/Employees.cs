/*
 * <copyright file = "Staff.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 10:33:34 PM </date>
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
using StaffClientSystem.Staff;
using StaffClientSystemsE;

namespace StaffClientSystems
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 10:33:34 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    public class Employees
    {
        #region Attributes

        /// <summary>
        /// Creation of the Employees class atributes
        /// </summary>
        private static List<Employee> employeesList;

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default Constructor
        /// </summary>
        static Employees()
        {
            employeesList = new List<Employee>();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'employeesList' attribute
        /// </summary>
        public static List<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; }
        }

        #endregion

        #region OtherMethods

        #region ManagingProductsMethods

        /// <summary>
        /// This function checks whether a given employee already exists in the List.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool ExistEmployee(Employee employee)
        {
            if (EmployeesList.Contains(employee))
                return true;
            return false;
        }

        /// <summary>
        /// This method verifies if the visibility status of the given employee is visible or not.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static bool IsEmployeeAvailable(Employee employee)
        {
            if (employee.VisibilityStatus == true) return (true);
            else return (false);
        }

        /// <summary>
        /// This method lists in the console the result of the comparison between two employees, indicated by parameter.
        /// </summary>
        /// <param name="employee1"></param>
        /// <param name="employee2"></param>
        /// <returns></returns>
        public static bool CompareEmployees(Employee employee1, Employee employee2)
        {
            if (employee1.Equals(employee2)) return (true);
            else return (false);
        }

        /// <summary>
        /// Method that checks whether the employees list is empty or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsEmployeesListEmpty()
        {
            if (EmployeesList.Count == 0)
                return true;
            else return (false);
        }

        /// <summary>
        /// An "Auto_Increment" type function, that is, it adds the id of 
        /// the last element in the list to the new element, incrementing by 1.
        /// </summary>
        /// <returns></returns>
        public static int ReturnIDNewEmployee()
        {
            if (IsEmployeesListEmpty() == true)
                return 1;

            Employee aux = EmployeesList.Last();
            return aux.EmployeeID + 1;
        }

        /// <summary>
        /// Method that returns the number of elements present in the employees list.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountListRecords()
        {
            int count = 0;
            foreach (Employee employee in EmployeesList)
            {
                if (employee.VisibilityStatus == true)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that returns the number of elements present in the employees historic.
        /// </summary>
        /// <returns></returns>
        public static int ReturnAmountHistoricRecords()
        {
            int count = 0;
            foreach (Employee employee in EmployeesList)
            {
                if (employee.VisibilityStatus == false)
                    count++;
                else continue;
            }
            return count;
        }

        /// <summary>
        /// Method that checks if there is a employee that has the id indicated by the user.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static bool IsEmployeeIDAvailable(int employeeID)
        {
            foreach (Employee employee in EmployeesList)
            {
                if (employee.EmployeeID == employeeID)
                    return true;
                else continue;
            }
            return false;
        }

        /// <summary>
        /// Method that returns an object of type Employee, using its ID.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        public static Employee ReturnEmployeeFromID(int employeeID)
        {
            Employee auxEmployee = new Employee();
            foreach (Employee employee in EmployeesList)
            {
                if (employee.EmployeeID == employeeID)
                    auxEmployee = employee;
                else continue;
            }
            return auxEmployee;
        }

        /// <summary>
        /// This function inserts a employee passed as a List parameter.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool InsertEmployee(Employee employee)
        {
            if (ExistEmployee(employee) == true)
                throw new EmployeeException("\nUnable to insert new employee ... Employee is already inserted!");

            EmployeesList.Add(employee);
            return true;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the elements employee in the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static List<Employee> ReturnEmployeesList()
        {
            List<Employee> listaAux = new List<Employee>();

            if (IsEmployeesListEmpty() == true)
                throw new EmployeeException("\nThe employees list is empty!");

            foreach (Employee employee in EmployeesList)
            {
                if (employee.VisibilityStatus == true)
                    listaAux.Add(employee);
                else continue;
            }
            return listaAux;
        }

        /// <summary>
        /// Method that returns an auxiliary list that contains the unavailable elements of the employees list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static List<Employee> ReturnHistoric()
        {
            List<Employee> listaAux = new List<Employee>();

            if (IsEmployeesListEmpty() == true)
                throw new EmployeeException("\nThe employee list is empty!");

            foreach (Employee employee in EmployeesList)
            {
                if (employee.VisibilityStatus == false)
                    listaAux.Add(employee);
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
        public static bool UpdateEmployee(int fieldToUpdate, string atribute, int employeeID)
        {
            Employee employee = ReturnEmployeeFromID(employeeID);
            if (ExistEmployee(employee) == false)
                throw new EmployeeException("\nUnable to update employee ... Employee does not exist!");

            foreach (Employee e in EmployeesList)
            {
                if (e.Equals(employee))
                {
                    if (fieldToUpdate == 1)
                    {
                        employee.Name = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 2)
                    {
                        employee.Gender = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 3)
                    {
                        employee.DateOfBirth = DateTime.ParseExact(atribute, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        return true;
                    }
                    else if (fieldToUpdate == 4)
                    {
                        employee.PostalCode = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 5)
                    {
                        employee.Address = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 6)
                    {
                        employee.PhoneNumber = int.Parse(atribute);
                        return true;
                    }
                    else if (fieldToUpdate == 7)
                    {
                        employee.JobTitle = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 8)
                    {
                        employee.WorkEmail = atribute;
                        return true;
                    }
                    else if (fieldToUpdate == 9)
                    {
                        employee.Password = atribute;
                        return true;
                    }
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function removes a employee by passing its ID as a parameter, putting it in a kind of historic.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool RemoveEmployee(int employeeID)
        {
            if (ExistEmployee(ReturnEmployeeFromID(employeeID)) == false)
                throw new EmployeeException("\nUnable to remove employee ... Employee does not exist!");

            foreach (Employee employee in EmployeesList)
            {
                if (employee.Equals(ReturnEmployeeFromID(employeeID)))
                {
                    if (employee.VisibilityStatus == true)
                    {
                        employee.VisibilityStatus = false;
                        return true;
                    }
                    else
                        throw new EmployeeException("\nUnable to remove employee ... Employee has already been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function recovers a employee by passing its ID as a parameter, putting it back as an available employee.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool RecoverEmployee(int employeeID)
        {
            if (ExistEmployee(ReturnEmployeeFromID(employeeID)) == false)
                throw new EmployeeException("\nUnable to recover employee ... Employee does not exist!");

            foreach (Employee employee in EmployeesList)
            {
                if (employee.Equals(ReturnEmployeeFromID(employeeID)))
                {
                    if (employee.VisibilityStatus == false)
                    {
                        employee.VisibilityStatus = true;
                        return true;
                    }
                    else
                        throw new EmployeeException("\nUnable to recover employee ... Employee hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        /// <summary>
        /// This function deletes a employee by passing its ID as a parameter.
        /// </summary>
        /// <param name="employeeID"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool DeleteEmployee(int employeeID)
        {
            if (ExistEmployee(ReturnEmployeeFromID(employeeID)) == false)
                throw new EmployeeException("\nUnable to delete employee ... Employee does not exist!");

            foreach (Employee employee in EmployeesList)
            {
                if (employee.Equals(ReturnEmployeeFromID(employeeID)))
                {
                    if (employee.VisibilityStatus == false)
                    {
                        EmployeesList.Remove(employee);
                        return true;
                    }
                    else
                        throw new EmployeeException("\nUnable to delete employee ... Employee hasn't been removed!");
                }
                else continue;
            }
            return false;
        }

        #endregion

        #region FileManagement

        /// <summary>
        /// Method that loads the employees data from a file into the employees list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static bool LoadEmployeesDataBin(string fileName)
        {
            if (File.Exists(fileName))
            {
                using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Employee> loadedEmployees = (List<Employee>)formatter.Deserialize(fileStream);

                    foreach (Employee employee in loadedEmployees)
                    {
                        EmployeesList.Add(employee);
                    }
                    return true;
                }
            }
            else
                throw new Exception("\nFile doesn't exist!");
        }

        /// <summary>
        /// Method that saves the employees data from the employees list into a file.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        /// <exception cref="EmployeeException"></exception>
        public static bool SaveClientsDataBin(string fileName)
        {
            if (IsEmployeesListEmpty() == true)
                throw new EmployeeException("\nThe employees list is empty!");

            // Creates a FileStream to write employee data to the file
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileStream, EmployeesList);
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
