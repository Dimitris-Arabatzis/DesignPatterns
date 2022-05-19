using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    internal class PersonCC
    {
        public string[] Names;
        public AddressCC Address;

        public PersonCC(string[] names, AddressCC address)
        {
            Address = address;
            Names = names;
        }

        public PersonCC(PersonCC other)
        {
            Names = other.Names;
            Address = new AddressCC(other.Address);
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class AddressCC
    {
        public string StreetName;
        public int houseNumber;

        public AddressCC(AddressCC other)
        {
            this.StreetName = other.StreetName;
            this.houseNumber = other.houseNumber;
        }

        public AddressCC(string streetName, int houseNumber)
        {
            StreetName = streetName;
            this.houseNumber = houseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(houseNumber)}: {houseNumber}";
        }
    }
}
