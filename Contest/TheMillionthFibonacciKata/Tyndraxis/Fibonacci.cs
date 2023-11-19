using System.Numerics;

namespace TheMillionthFibonacciKata.Tyndraxis;

public class Fibonacci
{
    public static BigInteger Fib(int n)
    {
        return n switch
        {
            0 => 0,
            1 => 1,
            2 => 1,
            _ => SolveFibonacci(n)
        };
    }

    private static BigInteger SolveFibonacci(int n)
    {
        var firstPrevious = 1;
        var secondPrevious = 1;
        for (var i = 2; i < n; i++)
        {
            var next = firstPrevious + secondPrevious;
            firstPrevious = secondPrevious;
            secondPrevious = next;
        }

        return secondPrevious;
    }
}