/*
 * <copyright file = "EmployeesIO.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/20/2023 6:38:23 PM </date>
 * <description></description>
 * 
 * */

using StaffClientSystem;
using StaffClientSystem.Staff;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

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
    public class EmployeesIO
    {
        #region Methods

        /// <summary>
        /// Method that assigns the values ​​entered by the user to their respective attributes.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public static Employee GetNewEmployeeInformation(Employee employee)
        {
            Console.Write("\nEnter employee Name: ");
            employee.Name = Console.ReadLine();

            Console.Write("\nEnter employee Gender: ");
            employee.Gender = Console.ReadLine();

            Console.Write("\nEnter employee Date of Birth (dd-MM-yyyy): ");
            string launchDateInput = Console.ReadLine();

            // Convert the input string to a DateTime object
            DateTime launchDate = DateTime.ParseExact(launchDateInput, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            employee.DateOfBirth = launchDate;

            Console.Write("\nEnter employee Postal Code: ");
            employee.PostalCode = Console.ReadLine();

            Console.Write("\nEnter employee Address: ");
            employee.Address = Console.ReadLine();

            Console.Write("\nEnter employee Phone Number: ");
            employee.PhoneNumber = int.Parse(Console.ReadLine());

            Console.Write("\nEnter employee Job Title: ");
            employee.JobTitle = Console.ReadLine();

            Console.Write("\nEnter employee Work Email: ");
            employee.WorkEmail = Console.ReadLine();

            Console.Write("\nEnter employee Password: ");
            employee.Password = Console.ReadLine();

            employee.VisibilityStatus = true;

            return employee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeesList"></param>
        /// <returns></returns>
        public static bool ListEmployeesInformation(List<Employee> employeesList)
        {
            if (employeesList.Count == 0)
            {
                Console.WriteLine("|     The employees list is empty!     |");
                return false;
            }
            foreach (Employee e in employeesList)
            {
                Console.WriteLine($"|  {e.EmployeeID}  |  {e.Name}  |  {e.Gender}  |  {e.DateOfBirth.ToShortDateString()}  |" +
                    $"  {e.PostalCode}  |  {e.Address}  |  {e.PhoneNumber}  |  {e.JobTitle}  |  {e.WorkEmail}  |  {e.Password}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeesList"></param>
        /// <returns></returns>
        public static bool ListHistoric(List<Employee> employeesList)
        {
            if (employeesList.Count == 0)
            {
                Console.WriteLine("|     The historic is empty!     |");
                return false;
            }
            foreach (Employee e in employeesList)
            {
                Console.WriteLine($"|  {e.EmployeeID}  |  {e.Name}  |  {e.Gender}  |  {e.DateOfBirth.ToShortDateString()}  |" +
                    $"  {e.PostalCode}  |  {e.Address}  |  {e.PhoneNumber}  |  {e.JobTitle}  |  {e.WorkEmail}  |  {e.Password}  |");
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int GetEmployeeID()
        {
            Console.Write("\nEnter Employee ID: ");
            int employeeID = int.Parse(Console.ReadLine());

            return employeeID;
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
                Console.Write("\nEnter employee new Name: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 2)
            {
                Console.Write("\nEnter employee new Gender: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 3)
            {
                Console.Write("\nEnter employee new Date of Birth (dd-MM-yyyy): ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 4)
            {
                Console.Write("\nEnter employee new Postal Code: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 5)
            {
                Console.Write("\nEnter employee new Address: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 6)
            {
                Console.Write("\nEnter employee new Phone Number: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 7)
            {
                Console.Write("\nEnter employee new Job Title: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 8)
            {
                Console.Write("\nEnter employee new Work Email: ");
                newAttribute = Console.ReadLine();
            }
            else if (fieldToUpdate == 9)
            {
                Console.Write("\nEnter employee new Password: ");
                newAttribute = Console.ReadLine();
            }

            return newAttribute;
        }

        #endregion
    }
}
