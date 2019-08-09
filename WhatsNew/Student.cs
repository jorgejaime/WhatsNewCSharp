using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static System.String;

namespace WhatsNew
{
    public class Student
    {
        //Read-only auto-properties
        public string FirstName { get; } 
        public string LastName { get; }

        //Expression-bodied function members
        public string FullName => $"{FirstName} {LastName}";

        //Auto-property initializer
        public ICollection<double> Grades { get; } = new List<double>() { 1.5d};

        public ICollection<double> Scores { get; set; } 

        private string label;

        // Expression-bodied get / set accessors.
        public string Label
        {
            get => label;
            set => this.label = value ?? "Default label";
        }

        // Expression-bodied constructor
        public Student(string label) => this.Label = label;

        // Expression-bodied finalizer
        ~Student() => Console.Error.WriteLine("Finalized!");

        //name of
        public Student(string firstName, string lastName)
        {
            
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: "Cannot be blank", paramName: nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
        }

        //Expression-bodied function members
        public override string ToString() => $"{LastName}, {FirstName}";

        //String interpolation
        public string GetGradePointPercentage() =>
            $"Name: {LastName}, {FirstName}. G.P.A: {Grades.Average():F2}";

        ///Null-conditional operators
        public static string CheckName(Student student)
        {
            return student?.FirstName ?? "Unspecified";

        }

        //out variables
        public decimal GetScore(string score)
        {
            if (decimal.TryParse(score, out decimal result))
                return result;
            else
                throw new ArgumentException(message: "Cannot be converted", paramName: nameof(score));
        }


        public void AddGrades(ICollection<double> scores)
        {
            this.Scores = scores ?? throw new ArgumentNullException(nameof(scores));
        }
    }
}
