using System.Numerics;

namespace TheMillionthFibonacciKata.WizarDiger;

public class Fibonacci
{
    public static BigInteger Fib(int n)
    {
        var myArr = new Int64[n];
        if (n == 0) return 0;
        myArr[0] = 1;
        if (n == 1) return 1;
        myArr[1] = 1;
            for (int i = 2; i < n; i++)
            {
                myArr[i] = myArr[i - 1] + myArr[i - 2];
            }
        return myArr[n - 1];
    }
}