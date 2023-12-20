using StaffClientSystem.Staff;
using System;

namespace StaffClientSystem.Interfaces
{
    public interface IEmployee
    {
        /// <summary>
        /// Creation of Properties
        /// </summary>
        int EmployeeID { get; set; }

        string JobTitle { get; set; }

        string WorkEmail { get; set; }

        string Password { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the jobTitle of the employee.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        int CompareTo(Employee employee);
    }
}
