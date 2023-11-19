using System.Numerics;

namespace TheMillionthFibonacciKata.WizarDiger;

public class Fibonacci
{
    public static BigInteger Fib(int n)
    {
        var myArr = new int[n];
        myArr[0] = 0;
        myArr[1] = 1;
        if (n == 0) return myArr[0];
        if (n == 1) return myArr[1];
            for (int i = 2; i < n; i++)
            {
                myArr[i] = myArr[i - 1] + myArr[i - 2];
            }
        return myArr[n - 1];
    }
}