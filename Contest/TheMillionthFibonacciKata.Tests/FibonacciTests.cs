using System.Numerics;
using FluentAssertions;
using TheMillionthFibonacciKata.Tyndraxis;

namespace TheMillionthFibonacciKata.Tests;

public class FibonacciTests
{
    [TestCaseSource(nameof(FibCases))]
    public void Fib(int n, BigInteger expected)
    {
        var result = Fibonacci.Fib(n);

        result.Should().Be(expected);
    }

    [Test]
    public void Fib_BigNumber_ShouldNotThrow()
    {
        var act = () => Fibonacci.Fib(2_000_000);

        act.Should().NotThrow();
    }

    private static IEnumerable<TestCaseData> FibCases()
    {
        yield return new TestCaseData(0, new BigInteger(0));
        yield return new TestCaseData(1, new BigInteger(1));
        yield return new TestCaseData(2, new BigInteger(1));
        yield return new TestCaseData(3, new BigInteger(2));
        yield return new TestCaseData(5, new BigInteger(5));
        yield return new TestCaseData(10, new BigInteger(55));
    }
}