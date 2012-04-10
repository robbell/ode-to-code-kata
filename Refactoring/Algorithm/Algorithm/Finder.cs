using System.Collections.Generic;

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
            var comparisons = GetAgeComparisons();

            if(comparisons.Count < 1)
            {
                return new FinderResult();
            }

            return GetResult(comparisons, finderType);
        }

        private FinderResult GetResult(IList<FinderResult> results, FinderType finderType)
        {
            var answer = results[0];

            foreach(var result in results)
            {
                switch(finderType)
                {
                    case FinderType.Closest:
                        if(result.AgeDifference < answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;

                    case FinderType.Furthest:
                        if(result.AgeDifference > answer.AgeDifference)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }

        private List<FinderResult> GetAgeComparisons()
        {
            var results = new List<FinderResult>();

            for(var i = 0; i < people.Count - 1; i++)
            {
                for(var j = i + 1; j < people.Count; j++)
                {
                    var r = new FinderResult();
                    if(people[i].BirthDate < people[j].BirthDate)
                    {
                        r.YoungerPerson = people[i];
                        r.OlderPerson = people[j];
                    }
                    else
                    {
                        r.YoungerPerson = people[j];
                        r.OlderPerson = people[i];
                    }
                    r.AgeDifference = r.OlderPerson.BirthDate - r.YoungerPerson.BirthDate;
                    results.Add(r);
                }
            }
            return results;
        }
    }
}