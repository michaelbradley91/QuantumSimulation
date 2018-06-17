using System;
using System.Linq;
using System.Numerics;

namespace QuantumSimulation
{
    public static class ComplexHelpers
    {
        public static (Complex, Complex) Normalise(Complex complex1, Complex complex2)
        {
            var results = Normalise(new[] { complex1, complex2 });
            return (results[0], results[1]);
        }

        public static Complex[] Normalise(Complex[] complexNumbers)
        {
            var length = GetLength(complexNumbers);
            return complexNumbers.Select(c => c / length).ToArray();
        }

        public static double GetLength(params Complex[] complexNumbers)
        {
            var sum = complexNumbers.Sum(c => c.Magnitude * c.Magnitude);
            return Math.Sqrt(sum);
        }
    }
}
