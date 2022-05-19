using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public interface IPrototype<T>
    {
        T DeepCopy();
    }

    internal class PersonEDCI : IPrototype<PersonEDCI>
    {
        public string[] Names;
        public AddressEDCI Address;

        public PersonEDCI(string[] names, AddressEDCI address)
        {
            Address = address;
            Names = names;
        }

        public PersonEDCI DeepCopy()
        {
            return new PersonEDCI(Names, Address.DeepCopy());
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class AddressEDCI : IPrototype<AddressEDCI>
    {
        public string StreetName;
        public int houseNumber;

        public AddressEDCI(string streetName, int houseNumber)
        {
            StreetName = streetName;
            this.houseNumber = houseNumber;
        }

        public AddressEDCI DeepCopy()
        {
            return new AddressEDCI(StreetName, houseNumber);
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(houseNumber)}: {houseNumber}";
        }
    }
}
