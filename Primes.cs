using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Primes
{
    static class Prime
    {
        private static int Isqrt(int n) => (int)Math.Sqrt(n);
        public static Boolean isPrime(int n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            int sqrt = (int)(Isqrt(n));
            for(int i = 3; i <= sqrt; i+=2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static int[] primeFactor(int n)
        {
            int k = n;
            List<int> L = new List<int>();
            while(k != 1 && k % 2 == 0)
            {
                L.Add(2);
                k /= 2;
            }

            int sqrt = (int)(Isqrt(n));
            for (int p = 3; k != 1 && p <= sqrt; p += 2)
            {
                while (k != 1 && k % p == 0)
                {
                    L.Add(p);
                    k /= p;
                }
            }
            if (k != 1) L.Add(k);
            return L.ToArray();
        }
        public static int GCD(int m, int n)
        {
            if (n == 0) return m;
            else if (m < n) return GCD(n, m);
            else return GCD(n, m % n);
        }
        public static Boolean MutuallyPrime(int m, int n) => GCD(m, n) == 1;
        private static Complex CGamma(Complex X)
        {
            if ((Math.Abs(X.Imaginary) <= 1e-7) && (((int)X.Real) == X.Real) && X.Real < 0)
                throw new NotFiniteNumberException($"Gamma({X})");
            else
            {
                // Lanczos approximation:
                double[] P = {676.5203681218851 , -1259.1392167224028,
                              771.32342877765313, -176.61502916214059,
                              12.507343278686905, -0.13857109526572012,
                              9.9843695780195716e-6, 1.5056327351493116e-7
                             };
                Complex z = X;
                Complex y;
                if(z.Real < 0.5)
                {
                    y = Math.PI / (Complex.Sin(Math.PI * z) * CGamma(1 - z));
                }
                else
                {
                    z -= 1;
                    Complex x = 0.99999999999980993;
                    for(int i = 0; i < P.Length; i++)
                    {
                        x += P[i] / (z + i + 1);
                    }
                    Complex T = z + P.Length - 0.5;
                    y = Complex.Sqrt(2 * Math.PI) * Complex.Pow(T, z + 0.5) * Complex.Exp(-T) * x;
                }
                return y;
            }
        }
        public static Double Gamma(Double X)
        {
            return CGamma(X).Real;
        }
    }
}
