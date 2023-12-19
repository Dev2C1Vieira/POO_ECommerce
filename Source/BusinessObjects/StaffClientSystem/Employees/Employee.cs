/*
 * <copyright file = "Aula_1___Turno_2.cs" company = "IPCA">
 * Copyright (c) 2023 All Rights Reserved
 * </copyright>
 * <author> Pedro Vieira </author>
 * <date> 11/14/2023 9:49:39 PM </date>
 * <description></description>
 * 
 * */

using System;

namespace StaffClientSystem.Employees
{
    /// <summary>
    /// Purpose: [Write the purpose of the class!]
    /// Created By: Pedro Vieira
    /// Created On: 11/14/2023 9:49:39 PM
    /// Email: a25626@alunos.ipca.pt
    /// </summary>
    /// <remarks></remarks>
    /// <example></example>
    public class Employee : Person, IComparable<Employee>/*, IEmployee*/
    {
        #region Attributes

        private int employeeID;
        private string jobTitle;
        private string workEmail;
        private string password;
        private bool visibilityStatus; // An indicator of whether the employee is visible to users.

        #endregion

        #region Methods

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Employee()
        {
            employeeID = 0;
            Name = string.Empty;
            Gender = string.Empty;
            DateOfBirth = DateTime.Now;
            PostalCode = string.Empty;
            Address = string.Empty;
            PhoneNumber = 0;
            jobTitle = string.Empty;
            workEmail = string.Empty;
            password = string.Empty;
            visibilityStatus = false;
        }

        /// <summary>
        /// Constructor passed by parameters
        /// </summary>
        /// <param name="employeeID"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="birthdate"></param>
        /// <param name="postalCode"></param>
        /// <param name="address"></param>
        /// <param name="phone_number"></param>
        /// <param name="jobTitle"></param>
        /// <param name="workEmail"></param>
        /// <param name="password"></param>
        /// <param name="visibilityStatus"></param>
        public Employee(int employeeID, string name, string gender, DateTime birthdate, 
            string postalCode, string address, int phone_number, string jobTitle, 
            string workEmail, string password, bool visibilityStatus)
        {
            this.employeeID = employeeID;
            Name = name;
            Gender = gender;
            DateOfBirth = birthdate;
            PostalCode = postalCode;
            Address = address;
            PhoneNumber = phone_number;
            this.jobTitle = jobTitle;
            this.workEmail = workEmail;
            this.password = password;
            this.visibilityStatus = visibilityStatus;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Property related to the 'employeeID' attribute
        /// </summary>
        public int EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        /// <summary>
        /// Property related to the 'jobTitle' attribute
        /// </summary>
        public string JobTitle
        {
            get { return jobTitle; }
            set { jobTitle = value; }
        }

        /// <summary>
        /// Property related to the 'workEmail' attribute
        /// </summary>
        public string WorkEmail
        {
            get { return workEmail; }
            set { workEmail = value; }
        }

        /// <summary>
        /// Property related to the 'password' attribute
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        /// <summary>
        /// Property related to the 'visibilityStatus' attribute
        /// </summary>
        public bool VisibilityStatus
        {
            get { return visibilityStatus; }
            set { visibilityStatus = value; }
        }

        #endregion

        #region Operators

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Employees are the same.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Employee left, Employee right)
        {
            if ((left.EmployeeID == right.EmployeeID) && (left.Name == right.Name) && (left.Gender == right.Gender)
                && (left.DateOfBirth == right.DateOfBirth) && (left.PostalCode == right.PostalCode) && (left.Address == right.Address)
                && (left.PhoneNumber == right.PhoneNumber) && (left.JobTitle == right.JobTitle) && (left.WorkEmail == right.WorkEmail)
                && (left.Password == right.Password) && (left.VisibilityStatus == right.VisibilityStatus))
                return (true);
            return (false);
        }

        /// <summary>
        /// Creating/Rewriting this method, to be able to check whether two indicated Employees are different.
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Employee left, Employee right)
        {
            if (!(left == right)) return (true);
            return (false);
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Rewriting the ToString method, to be able to write on the console.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return (String.Format("Employee ID: {0} - Name: {1} - Gender: {2} - Date of Birth: {3}" +
                " - Postal Code: {4} - Address: {5} - Phone Number: {6} - Job Title: {7} - Work Email: {8} - Password: {9}",
                EmployeeID.ToString(), Name, Gender.ToString(), DateOfBirth.ToString(),
                PostalCode, Address, PhoneNumber.ToString(), JobTitle, WorkEmail, Password));
        }

        /// <summary>
        /// Rewriting the Equals method, to be able to compare 2 different objects.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj is Employee)
            {
                Employee employee = (Employee)obj;
                if (this == employee)
                    return (true);
            }
            return (false);
        }

        /// <summary>
        /// Rewriting the GetHashCode method, to ensure efficient access to elements.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region OtherMethods

        /// <summary>
        /// Method that orders based on the cost of the employee.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int CompareTo(Employee employee)
        {
            return this.JobTitle.CompareTo(employee.JobTitle);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Destructor that removes the object from the memory!
        /// </summary>
        ~Employee()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
