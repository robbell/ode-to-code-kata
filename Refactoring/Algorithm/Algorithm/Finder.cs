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

            return pairs.Any() ? FindPair(pairs, finderType) : new FinderResult();
        }

        private FinderResult FindPair(IEnumerable<FinderResult> pairs, FinderType finderType)
        {
            var orderedPairs = pairs.OrderBy(r => r.AgeDifference);

            return finderType == FinderType.Closest ? orderedPairs.First() : orderedPairs.Last();
        }

        private IEnumerable<FinderResult> GetDistinctPairs()
        {
            for (var personCount = 0; personCount < people.Count - 1; personCount++)
            {
                for(var comparisonCount = personCount + 1; comparisonCount < people.Count; comparisonCount++)
                {
                    yield return new FinderResult(people[personCount], people[comparisonCount]);
                }
            }
        }
    }
}