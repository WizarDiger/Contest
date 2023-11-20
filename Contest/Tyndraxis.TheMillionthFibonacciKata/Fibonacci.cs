using System.Numerics;

namespace Tyndraxis.TheMillionthFibonacciKata;

public class Fibonacci
{
    private static readonly BigInteger[,] matrix = new BigInteger[,]
    {
        {0, 1},
        {1, 1}
    };

    private static readonly BigInteger[,] identityMatrix = new BigInteger[,]
    {
        {1, 0},
        {0, 1}
    };

    public static BigInteger Fib(int n)
    {
        var nAbs = Math.Abs(n);
        var result = identityMatrix;
        var bits = Convert.ToString(nAbs, 2);
        foreach (var bit in bits)
        {
            result = Multiply(result, result);
            if (bit == '1')
            {
                result = Multiply(result, matrix);
            }
        }

        var modifier = n >= 0 ? 1 : Math.Pow(-1, n + 1);
        return new BigInteger(modifier) * result[1, 0];
    }

    private static BigInteger[,] Multiply(BigInteger[,] matrix1, BigInteger[,] matrix2)
        => new[,]
        {
            {matrix1[0, 0] * matrix2[0, 0] + matrix1[0, 1] * matrix2[1, 0], matrix1[0, 0] * matrix2[0, 1] + matrix1[0, 1] * matrix2[1, 1]},
            {matrix1[1, 0] * matrix2[0, 0] + matrix1[1, 1] * matrix2[1, 0], matrix1[1, 0] * matrix2[0, 1] + matrix1[1, 1] * matrix2[1, 1]}
        };
}