using System.Numerics;
using FluentAssertions;
using FluentAssertions.Extensions;
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
    public void Fib_BigNumber_CompletedFast()
    {
        var act = () => Task.FromResult(Fibonacci.Fib(2_000_000));

        act.ExecutionTime().Should().BeLessThanOrEqualTo(1.Seconds());
    }

    private static IEnumerable<TestCaseData> FibCases()
    {
        yield return new TestCaseData(0, new BigInteger(0));
        yield return new TestCaseData(1, new BigInteger(1));
        yield return new TestCaseData(2, new BigInteger(1));
        yield return new TestCaseData(3, new BigInteger(2));
        yield return new TestCaseData(5, new BigInteger(5));
        yield return new TestCaseData(10, new BigInteger(55));
        yield return new TestCaseData(25, new BigInteger(75025));
        yield return new TestCaseData(35, new BigInteger(9227465));
        yield return new TestCaseData(50, new BigInteger(12586269025));
    }
}