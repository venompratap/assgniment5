using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            Storage<int> intStorage = new Storage<int>();
            intStorage.Item = 42;
            Console.WriteLine($"Stored integer: {intStorage.Item}");

            // Test the Storage class with a string
            Storage<string> stringStorage = new Storage<string>();
            stringStorage.Item = "Hello, world!";
            Console.WriteLine($"Stored string: {stringStorage.Item}");

            // Test the Storage class with a double
            Storage<double> doubleStorage = new Storage<double>();
            doubleStorage.Item = 3.14;
            Console.WriteLine($"Stored double: {doubleStorage.Item}");
            Console.ReadLine();

            Console.WriteLine("Question 2");
            // Test the Pair class with an integer and a string
            Pair<int, string> pair1 = new Pair<int, string>(1, "One");
            pair1.PrintPair();

            // Test the Pair class with a string and a double
            Pair<string, double> pair2 = new Pair<string, double>("Pi", 3.14159);
            pair2.PrintPair();

            // Test the Pair class with different types
            Pair<bool, char> pair3 = new Pair<bool, char>(true, 'A');
            pair3.PrintPair();
            Console.ReadLine();

            Console.WriteLine("Question 3");
            // Test the Calculator class with integers
            Calculator<int> intCalculator = new Calculator<int>();
            Console.WriteLine("Integer Addition: " + intCalculator.Add(5, 3));
            Console.WriteLine("Integer Subtraction: " + intCalculator.Subtract(5, 3));
            Console.WriteLine("Integer Multiplication: " + intCalculator.Multiply(5, 3));
            Console.WriteLine("Integer Division: " + intCalculator.Divide(6, 2));

            // Test the Calculator class with doubles
            Calculator<double> doubleCalculator = new Calculator<double>();
            Console.WriteLine("Double Addition: " + doubleCalculator.Add(5.5, 3.2));
            Console.WriteLine("Double Subtraction: " + doubleCalculator.Subtract(5.5, 3.2));
            Console.WriteLine("Double Multiplication: " + doubleCalculator.Multiply(5.5, 3.2));
            Console.WriteLine("Double Division: " + doubleCalculator.Divide(5.5, 2.2));
            Console.ReadLine();

            Console.WriteLine("Question 4");
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Top element (using Pop): {stack.Pop()}");

            // Access elements using indexer
            Console.WriteLine($"Element at index 0: {stack[0]}");
            Console.WriteLine($"Element at index 1: {stack[1]}");

            try
            {
                Console.WriteLine($"Invalid index access: {stack[5]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

            Console.WriteLine("Question 5");
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");

            Console.WriteLine($"Front element (using Dequeue): {queue.Dequeue()}");

            // Access elements using indexer
            Console.WriteLine($"Element at index 0: {queue[0]}");
            Console.WriteLine($"Element at index 1: {queue[1]}");

            try
            {
                Console.WriteLine($"Invalid index access: {queue[5]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
        //Question 1
        public class Storage<T>
        {
            private T _item;

            public T Item
            {
                get { return _item; }
                set { _item = value; }
            }
        }
        //Question 2
        public class Pair<T1, T2>
        {
            public T1 First { get; set; }
            public T2 Second { get; set; }

            public Pair(T1 first, T2 second)
            {
                First = first;
                Second = second;
            }

            public void PrintPair()
            {
                Console.WriteLine($"First: {First}, Second: {Second}");
            }
        }
        // Question 3
        public class Calculator<T> where T : struct, IComparable<T>
        {
            public T Add(T a, T b)
            {
                return (dynamic)a + (dynamic)b;
            }

            public T Subtract(T a, T b)
            {
                return (dynamic)a - (dynamic)b;
            }

            public T Multiply(T a, T b)
            {
                return (dynamic)a * (dynamic)b;
            }

            public T Divide(T a, T b)
            {
                if ((dynamic)b == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return (dynamic)a / (dynamic)b;
            }
        }
        // Question 4
        public class Stack<T>
        {
            private List<T> _elements = new List<T>();

            public void Push(T item)
            {
                _elements.Add(item);
            }

            public T Pop()
            {
                if (_elements.Count == 0)
                    throw new InvalidOperationException("Stack is empty.");

                T item = _elements[1];
                _elements.RemoveAt(_elements.Count - 1);
                return item;
            }

            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= _elements.Count)
                        throw new IndexOutOfRangeException("Index out of range.");

                    return _elements[index];
                }
            }

            public int Count => _elements.Count;
        }
        // Question 5
        public class Queue<T>
        {
            private List<T> _elements = new List<T>();

            public void Enqueue(T item)
            {
                _elements.Add(item);
            }

            public T Dequeue()
            {
                if (_elements.Count == 0)
                    throw new InvalidOperationException("Queue is empty.");

                T item = _elements[0];
                _elements.RemoveAt(0);
                return item;
            }

            public T this[int index]
            {
                get
                {
                    if (index < 0 || index >= _elements.Count)
                        throw new IndexOutOfRangeException("Index out of range.");

                    return _elements[index];
                }
            }

            public int Count => _elements.Count;
        }
    }
}