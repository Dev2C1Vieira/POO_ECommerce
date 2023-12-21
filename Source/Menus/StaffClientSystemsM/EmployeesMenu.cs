/*
 * <copyright file = "EmployeesMenu.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 12/20/2023 7:02:04 PM </date>
 * <description></description>
 * 
 * */

using StaffClientSystem;
using StaffClientSystem.Staff;
using StaffClientSystemIO;
using StaffClientSystemR;
using System;
using System.Collections.Generic;
using System.Diagnostics;

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
    public class EmployeesMenu
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
            List<Employee> listingEmployees = new List<Employee>();
            Console.WriteLine("\nTable containing the information of the employees historic.\n");
            // Table Construction
            Console.WriteLine("\n+-------------------------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|  CODE  |  NAME  |  GENDER  |  DATE OF BIRTH  |  POSTAL CODE  |  ADDRESS  |  PHONE NUMBER  |  JOB TITLE  |  WORK EMAIL  |  PASSWORD  |");
            Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------------+");
            listingEmployees = EmployeesRules.ReturnHistoric();
            EmployeesIO.ListHistoric(listingEmployees);
            Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------------+");
            Console.WriteLine($"\n\nTotal sum of accessible records: {EmployeesRules.ReturnAmountHistoricRecords()}");
            Console.WriteLine("\n+------------------------------------------------------------------------------------------------------+");
            Console.WriteLine("|         1. Delete a Record!         2. Recover a Record!         3. Return to Employees Menu.        |");
            Console.WriteLine("+------------------------------------------------------------------------------------------------------+");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productsFN"></param>
        /// <param name="categoriesFN"></param>
        /// <param name="brandsFN"></param>
        /// <param name="clientsFN"></param>
        /// <param name="employeesFN"></param>
        public static void LoopDisplayHistocicMenu(string productsFN, string categoriesFN, string brandsFN, string clientsFN, string employeesFN, string managersFN)
        {
            int employeeID, op;
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
                        Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
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
                            Console.WriteLine("\nLets Delete a Employee!");

                            employeeID = EmployeesIO.GetEmployeeID();

                            result = EmployeesRules.DeleteEmployee(employeeID);
                            if (result == true)
                                Console.WriteLine("\nEmployee was successfully deleted!");
                            else
                                Console.WriteLine("\nUnable to delete the employee!");

                            EmployeesRules.SaveEmployeesDataBin(employeesFN);

                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("\nLets Recover a Employee!");

                            employeeID = EmployeesIO.GetEmployeeID();

                            result = EmployeesRules.RecoverEmployee(employeeID);
                            if (result == true)
                                Console.WriteLine("\nEmployee was successfully recovered!");
                            else
                                Console.WriteLine("\nUnable to recover the employee!");

                            EmployeesRules.SaveEmployeesDataBin(employeesFN);

                            Pause();
                        }
                    }
                } while ((!(op == 1)) && (!(op == 2)));

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public static void Menu(string productsFN, string categoriesFN, string brandsFN, string clientsFN, string employeesFN, string managersFN)
        {
            int op = 1, field, employeeID;
            bool result;

            try
            {
                while (true)
                {
                    do
                    {
                        Clear();
                        Console.WriteLine("  --------- Welcome to Employees Managment Menu ---------\n");
                        if (op < 1 || op > 6)
                        {
                            Console.WriteLine("\n  Invalid Option! [1-6]\n");
                        }
                        Console.WriteLine("\n  +-------------------------------------------+");
                        Console.WriteLine("  |  1. List the existing employees.          |");
                        Console.WriteLine("  |  2. Insert a new employee.                |");
                        Console.WriteLine("  |  3. Update employee information.          |");
                        Console.WriteLine("  |  4. Remove a employee.                    |");
                        Console.WriteLine("  |  5. Show employees historic.              |");
                        Console.WriteLine("  |  6. Back!                                 |");
                        Console.WriteLine("  +-------------------------------------------+");
                        Console.Write("\nOption: ");
                        op = int.Parse(Console.ReadLine());
                    } while (op < 1 || op > 6);
                    Clear();
                    switch (op)
                    {
                        case 1:
                            List<Employee> listingEmployees = new List<Employee>();
                            Console.WriteLine("\nTable containing the information of the existing employees.\n");
                            // Table Construction
                            Console.WriteLine("\n+-------------------------------------------------------------------------------------------------------------------------------------+");
                            Console.WriteLine("|  CODE  |  NAME  |  GENDER  |  DATE OF BIRTH  |  POSTAL CODE  |  ADDRESS  |  PHONE NUMBER  |  JOB TITLE  |  WORK EMAIL  |  PASSWORD  |");
                            Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------------+");
                            listingEmployees = EmployeesRules.ReturnEmployeesList();
                            EmployeesIO.ListEmployeesInformation(listingEmployees);
                            Console.WriteLine("+-------------------------------------------------------------------------------------------------------------------------------------+");
                            Console.WriteLine($"\n\nTotal sum of accessible records: {EmployeesRules.ReturnAmountListRecords()}");
                            Pause();
                            break;
                        case 2:
                            Console.WriteLine("\nLets Insert new Employee!");

                            Employee employee = new Employee();
                            employee = EmployeesIO.GetNewEmployeeInformation(employee);

                            result = EmployeesRules.InsertEmployee(employee);

                            if (result == true)
                                Console.WriteLine("\nNew employee inserted successfully!");
                            else
                            {
                                Console.WriteLine("\nUnable to add new employee!");
                            }

                            EmployeesRules.SaveEmployeesDataBin(employeesFN);

                            Pause();
                            break;
                        case 3:
                            Console.WriteLine("\nLets Update a Employee!");

                            employeeID = EmployeesIO.GetEmployeeID();

                            if (EmployeesRules.IsEmployeeIDAvailable(employeeID) == false)
                            {
                                Console.WriteLine("\nEmployee does not exist! ... Please enter an ID of an existing employee.");
                                Pause();
                                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
                            }

                            Clear();

                            //
                            Console.WriteLine("\nChoose which field you want to change:");

                            Console.WriteLine("\n  +-------------------------------------------+");
                            Console.WriteLine("  |  1. Update employee Name.                 |");
                            Console.WriteLine("  |  2. Update employee Gender.               |");
                            Console.WriteLine("  |  3. Update employee Date of Birth.        |");
                            Console.WriteLine("  |  4. Update employee Postal Code.          |");
                            Console.WriteLine("  |  5. Update employee Address.              |");
                            Console.WriteLine("  |  6. Update employee Phone Number.         |");
                            Console.WriteLine("  |  7. Update employee Job Title.            |");
                            Console.WriteLine("  |  8. Update employee Work Email.           |");
                            Console.WriteLine("  |  9. Update employee Password.             |");
                            Console.WriteLine("  |  10. Back!                                |");
                            Console.WriteLine("  +-------------------------------------------+");
                            Console.Write("\nOption: ");
                            field = int.Parse(Console.ReadLine());

                            if (field == 10) { Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN); }

                            Clear();

                            string attribute = EmployeesIO.GetAttributeToUpdate(field);

                            result = EmployeesRules.UpdateEmployee(field, attribute, employeeID);
                            if (result == true)
                                Console.WriteLine("\nEmployee was successfully updated!");
                            else
                                Console.WriteLine("\nUnable to update the employee!");

                            EmployeesRules.SaveEmployeesDataBin(employeesFN);

                            Pause();
                            break;
                        case 4:
                            Console.WriteLine("\nLets Remove a Employee!");

                            employeeID = EmployeesIO.GetEmployeeID();

                            result = EmployeesRules.RemoveEmployee(employeeID);
                            if (result == true)
                                Console.WriteLine("\nEmployee was successfully removed!");
                            else
                                Console.WriteLine("\nUnable to remove the employee!");

                            EmployeesRules.SaveEmployeesDataBin(employeesFN);

                            Pause();
                            break;
                        case 5:
                            LoopDisplayHistocicMenu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
                            break;
                        case 6:
                            SCSMMenu.Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
                            break;
                    }
                }
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
                Menu(productsFN, categoriesFN, brandsFN, clientsFN, employeesFN, managersFN);
            }
        }

        #endregion
    }
}
