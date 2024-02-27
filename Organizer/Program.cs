using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Organizer
{
    public class Program
    {
        public static void Main(string[] _)
        {
            // Press <F5> to run this code, when "Hello World!" appears in a black box, remove the line below and write your code below.
            Console.WriteLine("Hoeveel elementen moet de lijst bevatten?");
            int count;
            while (!int.TryParse(Console.ReadLine(), out count) || count <= 0)
            {
                Console.WriteLine("Voer een geldig positief geheel getal in.");
            }

            List<int> numbers = GenerateRandomIntegers(count);

            //#######################

            //Creating instance of shifthighestsort
            ShiftHighestSort sorterShift = new ShiftHighestSort();

            //Create instance RotateSort
            RotateSort sorterRotate = new RotateSort();

            Console.WriteLine("Unsorted List:");
            ShowList("Example of list", numbers);
            
            //Sorting list using shifthighestsort
            List<int> sortedNumbers = sorterShift.Sort(numbers);

            //Timing and sorting using ShiftHighestSort
            Stopwatch shiftStopwatch = Stopwatch.StartNew();
            List<int> shiftSortedNumbers = sorterShift.Sort(numbers);
            shiftStopwatch.Stop();
            long shiftElapsedMilliseconds = shiftStopwatch.ElapsedMilliseconds;

            Console.WriteLine("\nSorted List:");
            ShowList("Example of (sorterShift) list", sortedNumbers);

            //Validate sorted numbers
            ValidateNumbers(sortedNumbers);

            //#######################

            //Sorting list using rotateSort
            List<int> sortedNumbers2 = sorterRotate.Sort(numbers);

            //Timing and sorting using RotateSort
            Stopwatch rotateStopwatch = Stopwatch.StartNew();
            List<int> rotateSortedNumbers = sorterRotate.Sort(numbers);
            rotateStopwatch.Stop();
            long rotateElapsedMilliseconds = rotateStopwatch.ElapsedMilliseconds;

            //Display unsorted list
            Console.WriteLine("Unsorted List: ");
            ShowList("Example of list", numbers);

            //Display sorted list
            Console.WriteLine("\nSorted List:");
            ShowList("Example of (sortedRotate) list", sortedNumbers2);

            // Print the elapsed time for each sorting algorithm
            Console.WriteLine($"\nTime taken to sort using ShiftHighestSort: {shiftElapsedMilliseconds} milliseconds");
            Console.WriteLine($"Time taken to sort using RotateSort: {rotateElapsedMilliseconds} milliseconds");

            //Validate sorted numbers. This doesnt exist yet in RotateSort class
            //ValidateNumbers(sortedNumbers);
        }

        // <summary>
        // Genereer een lijst van N willekeurige gehele getallen tussen -99 en 99
        // </summary>
        // <param name ="N">Het aantal willekeurige getallen dat gegenereerd meot worden.</param>
        // <returns>Een lijst van willekeurige gehele getallen.</returns>

        public static List<int> GenerateRandomIntegers(int N) {
            List<int> randomIntegers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < N; i++) {
                randomIntegers.Add(random.Next(-99,100));
            }

            return randomIntegers;
        }


        /* Example of a static function */

        /// <summary>
        /// Show the list in lines of 20 numbers each
        /// </summary>
        /// <param name="label">The label for this list</param>
        /// <param name="theList">The list to show</param>
        public static void ShowList(string label, List<int> theList) {
            int count = Math.Min(theList.Count,200);
            Console.WriteLine();
            Console.Write(label);
            Console.Write(':');
            for (int index = 0; index < count; index++)
            {
                if (index % 20 == 0 && index != 0) // when index can be divided by 20 exactly, start a new line
                {
                    Console.WriteLine();
                }
                Console.Write(string.Format("{0,3}, ", theList[index]));  // Show each number right aligned within 3 characters, with a comma and a space
            }
            Console.WriteLine();
        }

        public static void ValidateNumbers (List<int> sortedNumbers) {
            for (int i = 1; i < sortedNumbers.Count; i++) {
                if (sortedNumbers[i] < sortedNumbers [i - 1]) {
                    Console.WriteLine($"Fout: nummer op positie {i} ({sortedNumbers[i]} is kleiner dan het vorige nummer)");
                }
            }
            Console.WriteLine("Alle nummers zijn groter of gelijk aan het voorgaande nummer.");
        }
    }
}
