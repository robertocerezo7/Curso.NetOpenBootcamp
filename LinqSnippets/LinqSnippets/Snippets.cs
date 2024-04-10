using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LinqSnippets
{
    public class Snippets
    {
        static public void BasicLinQ()
        {
            string[] cars =
            {
                "VW Golf",
                "VW California",
                "Audi A3",
                "Audi A5",
                "Fiat Punto",
                "Seat Ibiza",
                "Seat León",
            };

            //1. SELECT *
            var carList = from car in cars select car;

            foreach (var car in carList ) 
            {
                Console.WriteLine(car);
            }

            //SELECT WHERE car is Audi
            var audiList = from car in cars where car.Contains("Audi") select car;

            foreach (var audi in audiList)
            {
                Console.WriteLine(audi);
            }     
        }

        // Number Examples 
        static public void LinqNumbers() 
        {
        List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Each Number multipled by 3
            // take all numbers,but 9
            // Order numbers by ascending value

            var processedNumberList =
                numbers
                .Select(num => num * 3) // {3, 6, 9,...}
                .Where(num => num != 9) // {all but the 9}
                .OrderBy(num => num); // at the end, we order ascending
        }

        static public void SearchEamples() 
        {
        
            List<string> textList = new List<string>
            { 
                "a",
                "bx",
                "c",
                "d",
                "e",
                "cj",
                "f",
                "c"
            };


            // 1. First of all
            var firs = textList.First();

            // 2. First element that is "c"
            var cText = textList.First(text => text.Equals("c"));

            // 3. First element that contains "j"
            var jText = textList.First(text => text.Contains("j"));

            // 4. First element that contains "Z" or default
            var firstOrDefaultText = textList.FirstOrDefault(text => text.Contains("z"));

            // 5. First element that contains "Z" or default
            var lastOrDefaultText = textList.LastOrDefault(text => text.Contains("z"));

            // 5. Single Values
            var unqueText = textList.SingleOrDefault();


            int[] evenNumbers = { 0, 2, 4, 6, 8};
            int[] otherEvenNumbers = { 2, 6, 0};

            // Obtain {4,8}
            var myEvenNumbers = evenNumbers.Except(otherEvenNumbers);
        }


        static public void MultipleSelects() 
        {

            //SELECT MANY
            string[] myOpinions =
                {
                "Opinion 1, text 1",
                "Opinion 2, text 2",
                "Opinion 3, text 3"
            };

            var myOpinionSelections = myOpinions.SelectMany(opinion => opinion.Split(","));

            var enterprise = new[]
            {
                new Enterprise()
                {
                    Id = 1,
                    Name = "Enterprise 1",
                    Employees = new[]
                    {
                        new Employee() 
                        {
                        Id=1,
                        Name="Martin",
                        Email="martin@imaginagroup.com",
                        Salary = 3000
                        },

                        new Employee()
                        {
                        Id=2,
                        Name="Pepe",
                        Email="pepe@imaginagroup.com",
                        Salary = 1000
                        },

                        new Employee()
                        {
                        Id=3,
                        Name="Juanjo",
                        Email="juanjo@imaginagroup.com",
                        Salary = 2000
                        },
                    }
                },

                new Enterprise()
                {
                    Id = 2,
                    Name = "Enterprise 2",
                    Employees = new[]
                    {
                        new Employee()
                        {
                        Id=4,
                        Name="Ana",
                        Email="ana@imaginagroup.com",
                        Salary = 3000
                        },

                        new Employee()
                        {
                        Id=5,
                        Name="Maria",
                        Email="maria@imaginagroup.com",
                        Salary = 1500
                        },

                        new Employee()
                        {
                        Id=6,
                        Name="Tomas",
                        Email="tomas@imaginagroup.com",
                        Salary = 4000
                        },
                    }
                },
            };

            //Obtain all Employes
            var employeeList = enterprise.SelectMany(enterprises => enterprises.Employees);

            //Know if any list is empty
            bool hasEnterprises = enterprise.Any();

            bool hasEmployees = enterprise.Any(enterprise => enterprise.Employees.Any());

            // All enterprises at les has an employee with more than 1000€ of salary
            bool hasEmployeeWithSalaryMoreThan1000 = 
                enterprise.Any(enterprise=> 
                enterprise.Employees.Any(employee => employee.Salary > 1000));
        }


        static public void linqCollections()
        {
            var firstList = new List<string>() { "a", "b", "c"};
            var secondList = new List<string>() { "a", "c", "d" };

            //INNER JOIN
            var commonResult = from element in firstList
                               join secondElement in secondList 
                               on element equals secondElement
                               select new { element, secondElement };

            var commonResult2 = firstList.Join(
                secondList,
                element => element,
                secondElement => secondElement,
                (element, secondElement) => new {element, secondElement}
                );

            // OUTER JOIN - LEFT
            var leftOuterJoin = from element in firstList
                                join secondElement in secondList
                                on element equals secondElement
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where element != temporalElement
                                select new { Element = element };

            // OUTER JOIN - RIGHT
            var rightOuterJoin = from secondElement in secondList
                                join element in firstList
                                on secondElement equals element
                                into temporalList
                                from temporalElement in temporalList.DefaultIfEmpty()
                                where secondElement != temporalElement
                                select new { Element = secondElement };

            // UNION
            var unionList = leftOuterJoin.Union(rightOuterJoin);
        }

        static public void SkipTakeLinq()
        {

            var myList = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            //SKIP
            var skipTwoFirstValues = myList.Skip(2);
            var skipLastTwoValues = myList.SkipLast(2);
            var skipWhile = myList.SkipWhile(num => num < 4);

            //TAKE 
            var takeFirstValues = myList.Take(2);
            var takeLastTwoValues = myList.TakeLast(2);
            var takeWhile = myList.TakeWhile(num => num < 4);
        }
    }
}
