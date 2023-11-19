using System.Numerics;

namespace TheMillionthFibonacciKata.Tyndraxis;

public class Fibonacci
{
    private static readonly double firstFi = (1 + Math.Sqrt(5)) / 2;
    private static readonly double secondFi = (1 - Math.Sqrt(5)) / 2;

    public static BigInteger Fib(int n)
    {
        var modifier = n >= 0
            ? 1
            : n % 2 > 0
                ? -1
                : 1;
        var result = modifier * Math.Round(SolveFibonacci(n));
        return new BigInteger(result);
    }

    private static double SolveFibonacci(int n)
        => (Math.Pow(firstFi, n) - Math.Pow(secondFi, n)) / Math.Sqrt(5);
}