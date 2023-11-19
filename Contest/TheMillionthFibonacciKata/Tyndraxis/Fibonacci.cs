using System.Numerics;

namespace TheMillionthFibonacciKata.Tyndraxis;

public class Fibonacci
{
    private const double Fi = 1.6180339887498948482;

    public static BigInteger Fib(int n)
    {
        return n switch
        {
            0 => 0,
            1 => 1,
            2 => 1,
            _ => new BigInteger((ulong) Math.Round(SolveFibonacci(n)))
        };
    }

    private static double SolveFibonacci(int n)
        => (Math.Pow(Fi, n) - Math.Pow(1 - Fi, n)) / Math.Sqrt(5);
}