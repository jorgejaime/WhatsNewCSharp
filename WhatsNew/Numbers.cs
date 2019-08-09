using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace WhatsNew
{
    public class Numbers
    {
        public const int Sixteen = 0b0001_0000;
        public const int ThirtyTwo = 0b0010_0000;
        public const int SixtyFour = 0b0100_0000;
        public const int OneHundredTwentyEight = 0b1000_0000;

        public const long BillionsAndBillions = 100_000_000_000;

        public const double AvogadroConstant = 6.022_140_857_747_474e23;

        public const decimal GoldenRatio = 1.618_033_988_749_894_848_204_586_834_365_638_117_720_309_179M;

        //out variables
        public int ParseInt(string input)
        {
            if (int.TryParse(input, out int result))
                return result;
            else
                throw new ArgumentException();
        }

        //Pattern matching
        public static int SumPositiveNumbers(IEnumerable<object> sequence)
        {
          
            int sum = 0;

            //if (0 is int count)
            //    sum += count;


            foreach (var i in sequence)
            {
                switch (i)
                {
                    case 0:
                        break;
                    case IEnumerable<int> childSequence:
                        {
                            foreach (var item in childSequence)
                                sum += (item > 0) ? item : 0;
                            break;
                        }
                    case int n when n > 0:
                        sum += n;
                        break;
                    case null:
                        throw new NullReferenceException("Null found in sequence");
                    default:
                        throw new InvalidOperationException("Unrecognized type");
                }
            }
            return sum;
        }

        //Ref locals and returns
        public static ref int Find(int[,] matrix, Func<int, bool> predicate)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    if (predicate(matrix[i, j]))
                        return ref matrix[i, j];
            throw new InvalidOperationException("Not found");
        }


        //Local functions
        public static IEnumerable<char> AlphabetSubset(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return alphabetSubsetImplementation();

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            async Task<string> longRunningWorkImplementation()
            {
                var interimResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {interimResult} and {secondResult}. Enjoy.";
            }
        }

        private Task<int> SecondStep(int index, string name)
        {
            return Task.FromResult<int>(0);
        }

        private Task<int> FirstWork(string address)
        {
            return Task.FromResult<int>(0);
        }

        //Generalized async return types
        public static async ValueTask<int> Func()
        {
            await Task.Delay(100);
            return 5;
        }

        public static async Task<int> Func2()
        {
            await Task.Delay(100);
            return 5;
        }

    }
}
