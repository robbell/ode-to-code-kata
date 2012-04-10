﻿using System;

namespace Algorithm
{
    public class FinderResult
    {
        public Person YoungerPerson { get; set; }
        public Person OlderPerson { get; set; }

        public TimeSpan AgeDifference
        {
            get { return OlderPerson.BirthDate - YoungerPerson.BirthDate; }
        }
    }
}