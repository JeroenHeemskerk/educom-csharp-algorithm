// See https://aka.ms/new-console-template for more information
using System.Configuration.Assemblies;

namespace CsharpTutorials {
    class Program {
        static void Main(string[] args) {
            string message = "Hello world!!";
            Console.WriteLine(message);
        }

    class Student {
            private int id;

            //Using auto-implemented property to auto generate a private field
            //and provides accessors to read and write its value.
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int StudentId {
                get { return id; }

                set { 
                    if (value > 0) 
                        id = value; 
                }
            }

            //The following returns the sum of two numbers.
            public int Sum(int num1, int num2) {
                var total = num1 + num2;
                return total;
            }

            //doesn't return anything and doesn't have any parameters. hence return type = void.
            public void Greet() {
                Console.Write("Hello World!");
            }
        }

    }
}