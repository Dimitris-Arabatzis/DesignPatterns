using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{

    public interface IDeepCopyable<T> 
        where T : new()
    {
        void CopyTo(T target);
        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class AddressPI : IDeepCopyable<AddressPI>
    {
        public string StreetName;
        public int houseNumber;

        public AddressPI()
        {
            
        }

        public AddressPI(string streetName, int houseNumber)
        {
            StreetName = streetName;
            this.houseNumber = houseNumber;
        }

        public void CopyTo(AddressPI target)
        {
            target.StreetName = StreetName;
            target.houseNumber = houseNumber;
        }


        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(houseNumber)}: {houseNumber}";
        }
    }

    public class PersonPI : IDeepCopyable<PersonPI>
    {
        public string[] Names;
        public AddressPI Address;

        public PersonPI()
        {

        }

        public PersonPI(string[] names, AddressPI address)
        {
            Address = address;
            Names = names;
        }

        public void CopyTo(PersonPI target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }

        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }
    }

    public class EmployeePI : PersonPI, IDeepCopyable<EmployeePI>
    {
        public int Salary;

        public EmployeePI()
        {

        }

        public EmployeePI(string[] names, AddressPI address, int salary) : base(names, address)
        {
            Salary = salary;
        }

        public void CopyTo(EmployeePI target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item)
            where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
            where T : PersonPI, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }
}
