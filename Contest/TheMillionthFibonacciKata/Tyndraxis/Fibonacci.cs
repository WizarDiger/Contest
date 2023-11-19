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
            _ => Solve(n)
        };
    }

    private static BigInteger Solve(int n)
    {
        var fibonacciNumbers = new BigInteger[n];
        fibonacciNumbers[0] = 1;
        fibonacciNumbers[1] = 1;
        for (var i = 2; i < n; i++)
        {
            var next = fibonacciNumbers[i - 1] + fibonacciNumbers[i - 2];
            fibonacciNumbers[i] = next;
        }

        return fibonacciNumbers.Last();
    }
}