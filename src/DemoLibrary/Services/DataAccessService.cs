using DemoLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace DemoLibrary
{
    public static class DataAccessService
    {
        private static string personTextFile = "PersonText.txt";

        public static void AddNewPerson(PersonModel person)
        {
            List<PersonModel> people = GetAllPeople();

            AddPersonToPeopleList(people, person);

            List<string> lines = ConvertModelsToCSV(people);

            File.WriteAllLines(personTextFile, lines);
        }

        public static void AddPersonToPeopleList(List<PersonModel> people, PersonModel person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                throw new ArgumentException("You passed in an invalid parameter", nameof(person.FirstName));
            }

            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ArgumentException("You passed in an invalid parameter", nameof(person.LastName));
            }

            people.Add(person);
        }

        public static List<string> ConvertModelsToCSV(List<PersonModel> people)
        {
            var output = new List<string>();

            if (people is null)
            {
                throw new ArgumentException("You must provide a list of people.", nameof(people));
            }

            foreach (PersonModel user in people)
            {
                output.Add($"{user.FirstName},{user.LastName}");
            }

            return output;
        }

        public static List<PersonModel> GetAllPeople()
        {
            string[] content = File.ReadAllLines(personTextFile);

            var output = WriteTextFileContent(content);

            return output;
        }

        public static List<PersonModel> WriteTextFileContent(string[] content)
        {
            var person = new List<PersonModel>();

            foreach (string line in content)
            {
                string[] data = line.Split(',');
                person.Add(new PersonModel { FirstName = data[0], LastName = data[1] });
            }

            return person;
        }
    }
}
