using System;
using System.Collections.Generic;
using System.Text;

namespace Factory
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PersonFactory
    {
        private int personsCreated;

        public PersonFactory()
        {
            personsCreated=0;
        }

        public Person CreatePerson(string name)
        {
            Person person = new Person()
            {
                Name = name,
                Id = personsCreated++
            };

            return person;
        }
    }
}
