using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> people;

        public Finder(List<Person> people)
        {
            this.people = people;
        }

        public FinderResult Find(FinderType finderType)
        {
            var pairs = GetDistinctPairs();

            return pairs.Any() ? GetResult(pairs, finderType) : new FinderResult();
        }

        private FinderResult GetResult(IEnumerable<FinderResult> results, FinderType finderType)
        {
            var result = new FinderResult();

            switch (finderType)
            {
                case FinderType.Closest:
                    result = results.OrderBy(r => r.AgeDifference).FirstOrDefault();
                    break;

                case FinderType.Furthest:
                    result = results.OrderBy(r => r.AgeDifference).LastOrDefault();
                    break;
            }

            return result;
        }

        private IEnumerable<FinderResult> GetDistinctPairs()
        {
            for (var personCount = 0; personCount < people.Count - 1; personCount++)
            {
                for(var comparisonCount = personCount + 1; comparisonCount < people.Count; comparisonCount++)
                {
                    yield return BuildPair(people[personCount], people[comparisonCount]);
                }
            }
        }

        private FinderResult BuildPair(Person firstPerson, Person secondPerson)
        {
            return new FinderResult
                       {
                           OlderPerson = firstPerson.BirthDate > secondPerson.BirthDate ? firstPerson : secondPerson,
                           YoungerPerson = firstPerson.BirthDate < secondPerson.BirthDate ? firstPerson : secondPerson
                       };
        }
    }
}