using StaffClientSystem.Staff;
using System;

namespace StaffClientSystem.Interfaces
{
    public interface IManager
    {
        /// <summary>
        /// Creation of Properties
        /// </summary>
        int ManagerID { get; set; }

        string JobTitle { get; set; }

        string WorkEmail { get; set; }

        string Password { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the jobTitle of the manager.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        int CompareTo(Manager manager);
    }
}
