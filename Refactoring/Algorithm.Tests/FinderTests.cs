using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests
{
    public class FinderTests
    {
        [Fact]
        public void ReturnsEmptyResultsWhenGivenEmptyList()
        {
            var list = new List<Person>();
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Closest);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void ReturnsEmptyResultsWhenGivenOnePerson()
        {
            var list = new List<Person> { sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Closest);

            Assert.Null(result.YoungerPerson);
            Assert.Null(result.OlderPerson);
        }

        [Fact]
        public void ReturnsClosestTwoForTwoPeople()
        {
            var list = new List<Person> { sue, greg };
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Closest);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        [Fact]
        public void ReturnsFurthestTwoForTwoPeople()
        {
            var list = new List<Person> { greg, mike };
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Furthest);

            Assert.Same(greg, result.YoungerPerson);
            Assert.Same(mike, result.OlderPerson);
        }

        [Fact]
        public void ReturnsFurthestTwoForFourPeople()
        {
            var list = new List<Person> { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Furthest);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(sarah, result.OlderPerson);
        }

        [Fact]
        public void ReturnsClosestTwoForFourPeople()
        {
            var list = new List<Person> { greg, mike, sarah, sue };
            var finder = new Finder(list);

            var result = finder.Find(FinderType.Closest);

            Assert.Same(sue, result.YoungerPerson);
            Assert.Same(greg, result.OlderPerson);
        }

        private readonly Person sue = new Person { Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        private readonly Person greg = new Person { Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        private readonly Person sarah = new Person { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        private readonly Person mike = new Person { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}