using System;
using System.Collections.Generic;
using Library.DataAccess;
using Library.Models;

namespace GenericsAndEventCombine
{
    class Program
    {
        static void Main(string[] args)
        {
            

            List<PersonModel> people = new List<PersonModel> {
            new PersonModel{FirstName="Bhagwati", LastName="Pokhrel", Email="bhagwatipokhrel@gmail.com"},
            new PersonModel { FirstName = "Nirjala", LastName = "DahalDamn", Email = "bhagwatipokhrel@gmail.com" },
            new PersonModel{FirstName="Tulasi", LastName="P.D", Email="bhagwatipokhrel@gmail.com"},
            new PersonModel{FirstName="Niraj", LastName="DahalHeck", Email="bhagwatipokhrel@gmail.com"}
            };

            DataAccess<PersonModel> personData = new DataAccess<PersonModel>();
            personData.BadWordsDetected += PersonData_BadWordsDetected;
            personData.SaveToCSV(people, @"C:\Users\tulshi\source\repos\GenericsAndEventCombineApp\Library.DataAccess\CsvFiles\people.csv");

            List<CarModel> car = new List<CarModel>
            {
                new CarModel{Manifacturer="Ford", Model="Figo"},
                new CarModel{Manifacturer="Toyota", Model="Highlander" },
                new CarModel{Manifacturer="Hyundai ", Model="Creta "}
            };

            DataAccess<CarModel> carData = new DataAccess<CarModel>();
            carData.BadWordsDetected += CarData_BadWordsDetected;
            carData.SaveToCSV(car,@"C:\Users\tulshi\source\repos\GenericsAndEventCombineApp\Library.DataAccess\CsvFiles\car.csv");

            //A list of objects and save it to a csv file
        }

        private static void CarData_BadWordsDetected(object sender, CarModel e)
        {
            Console.WriteLine($"Bad entry found for Manifacturer : {e.Manifacturer}, Model: {e.Model}");
        }

        private static void PersonData_BadWordsDetected(object sender, PersonModel e)
        {
            Console.WriteLine($"Bad entry found for Name: {e.FirstName} {e.LastName} , Email: {e.Email}");
        }
    }

    

    
    
}
