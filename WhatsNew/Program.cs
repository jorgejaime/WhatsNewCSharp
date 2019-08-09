using System;
using System.Collections.Generic;

namespace WhatsNew
{
    class Program
    {
        static void Main(string[] args)
        {

            List<String> names = new List<String>();
            names.Add("Bruce");
            names.Add("Alfred");
            names.Add("Tim");
            names.Add("Richard");

            // Display the contents of the list using the Print method.
            names.ForEach(Print);

            // The following demonstrates the anonymous method feature of C#
            // to display the contents of the list to the console.
            names.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });

            names.ForEach(name =>
            {
                Console.WriteLine(name);
            });


            Action messageTarget = ShowWindowsMessage;

            Action messageTarget2 = () => { };

            Overloaded(messageTarget);

            Overloaded(DoSomething);

            Foo(() => () => 7L);
        }

        private static void Print(string s)
        {
            Console.WriteLine(s);
        }

        private static void ShowWindowsMessage()
        {
            Console.WriteLine("ShowWindowsMessage");
        }

        static void Overloaded(Action action)
        {
            action();                
            Console.WriteLine("overload with action called");
        }

        static void Overloaded(Func<int> function)
        {
            function();
            Console.WriteLine("overload with Func<int> called");
        }

        static int DoSomething()
        {
            Console.WriteLine(0);
            return 0;
        }

        static void Foo(Func<Func<long>> func) { }
        static void Foo(Func<Func<int>> func) { }
    }
}
