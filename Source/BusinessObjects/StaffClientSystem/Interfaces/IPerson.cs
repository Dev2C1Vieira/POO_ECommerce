using System;

namespace StaffClientSystem.Interfaces
{
    public interface IPerson
    {
        string Name { get; set; }

        string Gender { get; set; }

        DateTime DateOfBirth { get; set; }

        string PostalCode { get; set; }

        string Address { get; set; }

        int PhoneNumber { get; set; }
    }
}
