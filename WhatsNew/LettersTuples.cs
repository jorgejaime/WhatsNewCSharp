﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsNew
{
    public class LettersTuples
    {
        public static (string, string) NamedLetters()
        {
            return ("a", "b");
        }

        public static (string Alpha, string Beta) AlphabetStart()
        {
            var alphabetStart = (Alpha: "a", Beta: "b");
            return alphabetStart;
        }


        //Discards
        public static (string, double, int, int, int, int) QueryCityDataForYears(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "New York City")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
    }
}

