using System.Numerics;

namespace TheMillionthFibonacciKata.WizarDiger;

public class Fibonacci
{
    public static BigInteger Fib(int n)
    {

        var q1 = Math.Pow(1 + Math.Sqrt(5), n);
        var q2 = Math.Pow(1 - Math.Sqrt(5), n);
        var q3 = q1 - q2;
        var q4 = Math.Sqrt(5) * Math.Pow(2, n);
        BigInteger result = (BigInteger)(q3 / q4);

        if (n < 0)
        {
            var w1 = Math.Pow(1 + Math.Sqrt(5), n*(-1));
            var w2 = Math.Pow(1 - Math.Sqrt(5), n*(-1));
            var w3 = q1 - q2;
            var w4 = Math.Sqrt(5) * Math.Pow(2, n*(-1));

            result = (BigInteger)(Math.Pow(-1, n + 1) * w4);
        }
        return result;
    }
}