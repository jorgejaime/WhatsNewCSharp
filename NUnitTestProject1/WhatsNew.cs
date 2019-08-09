using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WhatsNew;
using static System.Math;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }



        //C# 6

        [Test]
        public void Read_only_auto_properties_And_Expression_bodied_function_members()
        {
            var student = new Student("Mario","Perez");
            Assert.AreEqual(student.FullName, "Mario Perez");
        }

        [Test]
        public void Auto_property_initializer()
        {
            var student = new Student("Mario", "Perez");
            Assert.AreEqual(student.Grades.Contains(1.5d), true );
        }      

        [Test]
        public void Name_Of()
        {
            try
            {
                var student = new Student("Mario", null);    
            }
            catch (ArgumentException ex)
            {

                Assert.AreEqual(ex.ParamName, "lastName");                
            }
           
        }

        [Test]
        public void Null_conditional_operators()
        {
            var student = new Student(null, "Perez");
            Assert.AreEqual(Student.CheckName(student), "Unspecified");
        }

        [Test]
        public void String_interpolation()
        {
            var student = new Student("Maria", "Perez");
            Assert.AreEqual(student.GetGradePointPercentage(), "Name: Perez, Maria. G.P.A: 1.50");
        }

        [Test]
        public void Exception_filters()
        {
            var requestReturn = Request.MakeRequest().GetAwaiter().GetResult();
            Assert.AreEqual(requestReturn, "Site Moved");
        }

        [Test]
        public void MakeRequestAndLogFailures()
        {
            var requestReturn = Request.MakeRequestAndLogFailures().GetAwaiter().GetResult();
            Assert.AreEqual(requestReturn, "No connection could be made because the target machine actively refused it");
        }


        [Test]
        public void Initialize_associative_collections_using_indexers()
        {
            var request = new Request();
            Assert.AreEqual(request.WebErrors[404], "Page not Found.");
            Assert.AreEqual(request.WebErrors[302], "Page moved, but left a forwarding address.");
            Assert.AreEqual(request.WebErrors[500], "The web server can't come out to play today.");
        }

        [Test]
        public void Extension_Add_methods_in_collection_initializers()
        {
            var dic = new Dictionary<int, string> { 1, 4, 10 };
            Assert.AreEqual(dic[1], "Number 1");
            Assert.AreEqual(dic[4], "Number 4");
            Assert.AreEqual(dic[10], "Number 10");
        }
       




        //C# 7


        [Test]
        public void Out_Variables()
        {
            var numbrs = new Numbers();
            Assert.AreEqual(numbrs.ParseInt("16"), 16);
        }

        [Test]
        public void Expression_bodied_constructor()
        {
            var student = new Student("The New");
            Assert.AreEqual(student.Label, "The New");
        }

        [Test]
        public void Expression_bodied_get_set_accessors()
        {
            var student = new Student("The New")
            {
                Label = null
            };
            Assert.AreEqual(student.Label, "Default label");
        }

        [Test]
        public void Ref_Locals_And_Returns()
        {
            var arr = new int[,] { { 1, 2 }, { 3, 4 } };

            ref var numb = ref Numbers.Find(arr, x => x == 3);

            numb = 5;

            Assert.AreEqual(arr[1, 0], 5);
        }

        [Test]
        public void Throw_expressions()
        {
            try
            {
                var student = new Student("Mario", "Perez");
                student.AddGrades(null);
            }
            catch (ArgumentNullException ex)
            {

                Assert.AreEqual(ex.ParamName, "scores");
            }

        }

        [Test]
        public void Tuples()
        {
            (string, string) namedLetters = LettersTuples.NamedLetters();           
            Assert.AreEqual($"{namedLetters.Item1}, {namedLetters.Item2}", "a, b");
        }

        [Test]
        public void Tuples2()
        {
           
            (string Alpha, string Beta) namedLetters = LettersTuples.NamedLetters();   
            Assert.AreEqual($"{namedLetters.Alpha}, {namedLetters.Beta}", "a, b");
        }

        [Test]
        public void Tuples3()
        {         
            var alphabetStart = LettersTuples.AlphabetStart();
            Assert.AreEqual($"{alphabetStart.Alpha}, {alphabetStart.Beta}", "a, b");
        }

        public void Tuples4()
        {
            var (alpha, beta) = LettersTuples.AlphabetStart();
            Assert.AreEqual($"{alpha}, {beta}", "a, b");
        }

        [Test]
        public void Numeric_literal_syntax_improvements()
        {
            Assert.AreEqual(Numbers.Sixteen, 16);
            Assert.AreEqual(Numbers.GoldenRatio, 1.618033988749894848204586834365638117720309179M);
        }

        [Test]
        public void Pattern_matching()
        {
            var list = new List<object>
            {
                0, new List<int> {2,1}, 4,6 
            };

            var sum = Numbers.SumPositiveNumbers(list);
            Assert.AreEqual(sum, 13);
        }

        [Test]
        public void Pattern_matching2()
        {
           
            try
            {
                var list = new List<object>
                {
                    0, new List<int> {2,1}, 4,6, null
                };

                var sum = Numbers.SumPositiveNumbers(list);
            }
            catch (NullReferenceException ex)
            {

                Assert.AreEqual(ex.Message, "Null found in sequence");
            }

        }


        [Test]
        public void Discards()
        {         
            var (_, _, _, pop1, _, pop2) = LettersTuples.QueryCityDataForYears("New York City", 1960, 2010);
            Assert.AreEqual($"Population change, 1960 to 2010: {pop2 - pop1:N0}", "Population change, 1960 to 2010: 393,149");
        }
       

        [Test]
        public void Local_Functions()
        {
            
            var alpha = Numbers.AlphabetSubset('a', 'e').ToList();
            Assert.AreEqual(alpha[0], 'a' );
            Assert.AreEqual(alpha[1], 'b');
            Assert.AreEqual(alpha[2], 'c');
            Assert.AreEqual(alpha[3], 'd');
        }

        [Test]
        public void Generalized_async_return_types()
        {           
            Assert.AreEqual(Numbers.Func().GetAwaiter().GetResult(), 5);
        }
    }
}