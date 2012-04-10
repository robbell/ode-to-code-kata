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
            var tr = new List<FinderResult>();

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
                    r.D = r.OlderPerson.BirthDate - r.YoungerPerson.BirthDate;
                    tr.Add(r);
                }
            }

            if(tr.Count < 1)
            {
                return new FinderResult();
            }

            FinderResult answer = tr[0];
            foreach(var result in tr)
            {
                switch(finderType)
                {
                    case FinderType.Closest:
                        if(result.D < answer.D)
                        {
                            answer = result;
                        }
                        break;

                    case FinderType.Furthest:
                        if(result.D > answer.D)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
    }
}