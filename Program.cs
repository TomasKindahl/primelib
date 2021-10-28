using static Primes.Prime;
using System;

namespace primelib
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==== isPrime ====");
            for (int i = 2; i < 20; i++)
            {
                if (isPrime(i))
                    Console.WriteLine($"{i} is a prime");
                else
                    Console.WriteLine($"{i} is not a prime");
            }
            Console.WriteLine("==== primeFactor ====");
            for (int i = 350; i <= 370; i++)
            {
                int[] factor = primeFactor(i);
                Console.Write($"a{i} = 1");
                foreach (int f in factor)
                    Console.Write($"*{f}");
                Console.WriteLine();
            }
            Console.WriteLine("==== GCD ====");
            Console.Write("   ");
            for (int j = 2; j < 10; j++) Console.Write($"{j}  ");
            Console.WriteLine();
            for (int i = 2; i < 10; i++)
            {
                Console.Write($"{i}  ");
                for (int j = 2; j < 10; j++)
                {
                    Console.Write($"{GCD(i, j)}  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("==== MutuallyPrime ====");
            Console.Write("   ");
            for (int j = 2; j < 10; j++) Console.Write($"{j}  ");
            Console.WriteLine();
            for (int i = 2; i < 10; i++)
            {
                Console.Write($"{i}  ");
                for (int j = 2; j < 10; j++)
                {
                    if(MutuallyPrime(i,j))
                        Console.Write($"*  ");
                    else
                        Console.Write($"   ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("==== Gamma ====");
            Console.WriteLine($"Gamma(1) = {Gamma(1)}");
            Console.WriteLine($"Gamma(5) = {Gamma(5)}");
            Console.WriteLine($"Gamma(0.5) = {Gamma(0.5)}");
        }
    }
}
