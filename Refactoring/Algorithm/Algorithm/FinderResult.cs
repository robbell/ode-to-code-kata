using System;

namespace Algorithm
{
    public class FinderResult
    {
        public FinderResult()
        {}

        public FinderResult(Person firstPerson, Person secondPerson)
        {
            YoungerPerson = firstPerson.BirthDate < secondPerson.BirthDate ? firstPerson : secondPerson;
            OlderPerson = firstPerson.BirthDate > secondPerson.BirthDate ? firstPerson : secondPerson;
        }

        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }

        public TimeSpan AgeDifference
        {
            get { return OlderPerson.BirthDate - YoungerPerson.BirthDate; }
        }
    }
}