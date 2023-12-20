using System;

namespace StaffClientSystem.Interfaces
{
    public interface IClient
    {
        /// <summary>
        /// Creation of Properties
        /// </summary>
        int ClientID { get; set; }

        string Email { get; set; }

        bool VisibilityStatus { get; set; }

        /// <summary>
        /// Method that orders based on the cost of the client.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        int CompareTo(Client client);
    }
}
