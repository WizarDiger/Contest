namespace Tyndraxis.SnailSortKata;

public class SnailSort
{
    public static int[] Snail(int[][] array)
    {
        if (array.Length == 0 || array[0].Length == 0)
        {
            return Array.Empty<int>();
        }
        var currentIndex = new Index(0, 0);
        var currentDirection = MoveDirection.Right;

        var visitedNumbers = new List<int>() {array[currentIndex.X][currentIndex.Y]};
        var visitedIndexes = new HashSet<Index> {currentIndex};
        var elementsCount = array.Sum(x => x.Length);
        while (visitedNumbers.Count < elementsCount)
        {
            var (wasMoved, nextDirection, nextIndex) = DoNextMove(currentIndex, currentDirection, visitedIndexes, array);
            if (wasMoved)
            {
                currentIndex = nextIndex;
                visitedNumbers.Add(array[currentIndex.X][currentIndex.Y]);
                continue;
            }

            currentDirection = nextDirection;
        }

        return visitedNumbers.ToArray();
    }

    private static (bool WasMoved, MoveDirection NextDirection, Index NextIndex) DoNextMove(
        Index currentIndex,
        MoveDirection currentDirection,
        HashSet<Index> visitedIndexes,
        int[][] array)
    {
        var nextIndex = currentDirection switch
        {
            MoveDirection.Right => currentIndex with {Y = currentIndex.Y + 1},
            MoveDirection.Bottom => currentIndex with {X = currentIndex.X + 1},
            MoveDirection.Left => currentIndex with {Y = currentIndex.Y - 1},
            MoveDirection.Top => currentIndex with {X = currentIndex.X - 1},
            _ => throw new ArgumentOutOfRangeException(nameof(currentDirection), currentDirection, null)
        };
        if (!visitedIndexes.Contains(nextIndex) && IsValidIndex(nextIndex, array.Length, array[0].Length))
        {
            visitedIndexes.Add(nextIndex);
            return (true, currentDirection, nextIndex);
        }

        var newDirection = currentDirection switch
        {
            MoveDirection.Right => MoveDirection.Bottom,
            MoveDirection.Bottom => MoveDirection.Left,
            MoveDirection.Left => MoveDirection.Top,
            MoveDirection.Top => MoveDirection.Right,
            _ => throw new ArgumentOutOfRangeException(nameof(currentDirection), currentDirection, null)
        };
        return (false, newDirection, currentIndex);
    }

    private static bool IsValidIndex(Index index, int xLength, int yLength)
        => index.X >= 0 && index.X < xLength && index.Y >= 0 && index.Y < yLength;

    private record struct Index(int X, int Y);

    private enum MoveDirection
    {
        Right = 0,
        Bottom = 1,
        Left = 2,
        Top = 3
    }
}