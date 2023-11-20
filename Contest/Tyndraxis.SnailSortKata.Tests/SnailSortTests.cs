using FluentAssertions;

namespace Tyndraxis.SnailSortKata.Tests;

public class SnailSortTests
{
    [TestCaseSource(nameof(SnailCases))]
    public void Snail(int[][] array, int[] expected)
    {
        var result = SnailSort.Snail(array);

        result.Should().BeEquivalentTo(expected);
    }

    private static IEnumerable<TestCaseData> SnailCases()
    {
        yield return new TestCaseData(
            Array.Empty<int[]>(),
            Array.Empty<int>()
        );
        yield return new TestCaseData(
            new[]
            {
                new[] {1}
            },
            new[] {1}
        );
        yield return new TestCaseData(
            new[]
            {
                new[] {1},
                new[] {2}
            },
            new[] {1, 2}
        );
        yield return new TestCaseData(
            new[]
            {
                new[] {1, 2},
            },
            new[] {1, 2}
        );
        yield return new TestCaseData(
            new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6}
            },
            new[] {1, 2, 3, 6, 5, 4}
        );
        yield return new TestCaseData(
            new[]
            {
                new[] {1, 2, 3},
                new[] {4, 5, 6},
                new[] {7, 8, 9}
            },
            new[] {1, 2, 3, 6, 9, 8, 7, 4, 5}
        );
    }
}