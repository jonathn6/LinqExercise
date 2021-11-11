using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //Print the Sum and Average of numbers

            //The .SUM() and .Average() LINQ methods can execute on an array without any addition input or expression

            Console.WriteLine($"The sum of all the numbers in the array is {numbers.Sum()}");
            Console.WriteLine($"The average of all the numbers in the array is {numbers.Average()}");

            //Order numbers in ascending order and decsending order. Print each to console.

            //build a new array containing the contents of the number array in ascending order and print out the resulting array
            var ascendingArray = numbers.OrderBy(x=>x);

            Console.Write("The array in ascending order: ");
            foreach (var number in ascendingArray)
            {
                Console.Write($"[{number}]");
            }
            Console.WriteLine();

            //build a new array containing the contents of the number array in decending order and print out the resulting array
            var descendingArray = numbers.OrderByDescending(x => x);

            Console.Write("The array in descending order: ");
            foreach (var number in descendingArray)
            {
                Console.Write($"[{number}]");
            }
            Console.WriteLine();

            //Print to the console only the numbers greater than 6

            Console.Write("These are the numbers from the array that are greater than 6: ");
            var greaterThan6Array = numbers.Where(x => x > 6);
            foreach (var number in greaterThan6Array)
            {
                Console.Write($"{number}   ");
            }            
            Console.WriteLine();

            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            //use the ascending array defined above and print out 4 elements from that array

            Console.Write("Here are only 4 elements from the array sorted ascending: ");

            foreach (var number in ascendingArray.Take(4))
            {
                Console.Write($"{number}  ");
            }
            Console.WriteLine();

            //Change the value at index 4 to your age, then print the numbers in decsending order

            //Change the value of numbers[4] to 55, then create a new array sorted in decending order and the print out the resulting array
            numbers[4] = 55;
            var descendingArrayWithAge = numbers.OrderByDescending(x => x);

            Console.Write("The array, with my age, in descending order: ");
            foreach (var number in descendingArrayWithAge)
            {
                Console.Write($"[{number}]");
            }
            Console.WriteLine();


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var firstNameCorS = employees.Where(person => person.FirstName.ToLower().StartsWith("c") || person.FirstName.ToLower().StartsWith("s"));
            var nameAscending = firstNameCorS.OrderBy(person => person.FirstName);

            Console.WriteLine("Full name of employees who's first name starts with C or S in ascending order: ");
            foreach (var name in nameAscending)
            {
                Console.WriteLine($"{name.FullName}");
            }
            Console.WriteLine();


            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var over26 = employees.Where(person => person.Age>26).OrderBy(x => x.Age).ThenBy(fname => fname.FirstName);

            Console.WriteLine("These are the employees over 26, sorted by age then by firstname: ");
            foreach (var employee in over26)
            {
                Console.WriteLine($"{employee.FullName} - Age {employee.Age}");
            }
            Console.WriteLine();

            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var sumOfYears = employees.Where(person => person.Age>35 && person.YearsOfExperience<=10).Sum(person=>person.YearsOfExperience);
            Console.WriteLine($"The sum of the years of experience of employees over 35 with YOE <= 10 is {sumOfYears}");

            Console.WriteLine();


            //Add an employee to the end of the list without using employees.Add()

            var newEmployee = new Employee("Jonathan","Small", 55, 0);
            var newEmployeeList = employees.Append(newEmployee);

            Console.WriteLine("Here are all the employees with me added to the list.");
            foreach (var person in newEmployeeList)
            {
                Console.WriteLine(person.FullName);
            }
            Console.WriteLine();
            Console.ReadLine();

        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
