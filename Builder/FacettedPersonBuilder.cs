using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public class Person
    {
        //address
        public string StreetAddress, PostCode, City;

        //employment
        public string CompanyName, Position;
        public int AnnualIncome;

        public override string ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(PostCode)}: {PostCode}, {nameof(CompanyName)}: {CompanyName},{nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }

    public class PersonFaccettedBuilder // facade
    {
        //reference!
        protected Person person = new Person();

        public PersonJobBuilder Works() => new PersonJobBuilder(person);

        public PersonAddressBuilder Lives() => new PersonAddressBuilder(person);

        public Person Build() => person;
    }


    public class PersonAddressBuilder : PersonFaccettedBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.person = person;
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostCode(string postCode)
        {
            person.PostCode = postCode;
            return this;
        }

        public PersonAddressBuilder In(string city)
        {
            person.City = city;
            return this;
        }

    }


    public class PersonJobBuilder : PersonFaccettedBuilder
    {
        public PersonJobBuilder(Person person)
        {
            this.person = person;
        }

        public PersonJobBuilder At(string companyName)
        {
            person.CompanyName = companyName;
            return this;
        }

        public PersonJobBuilder AsA(string position)
        {
            person.Position = position;
            return this;
        }

        public PersonJobBuilder Earning(int amount)
        {
            person.AnnualIncome = amount;
            return this;
        }

    }

}
