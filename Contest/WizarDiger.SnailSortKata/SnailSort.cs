using System;

namespace WizarDiger.SnailSortKata
{
    internal class SnailSort
    {

        public static int[] Snail(int[][] array)
        {
            if (array.GetLength(0) == 0)
            {
                return Array.Empty<int>();
            }
           
            if (array.GetLength(0) == 1 && array[0].GetLength(0) == 1)
            {
                return new int[1] { array[1][1] };
            }

            var hashSet = new HashSet<string>();
            var x = 0;
            var y = 0;
            var currentState = "right";
            var doubleDimensionalArray = new int[array.GetLength(0),array[1].GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array[1].GetLength(0); j++)
                {
                    doubleDimensionalArray[i,j] = array[i][j];
                }
            }
            
            var result = new int[doubleDimensionalArray.Length];
            for (int i = 0; i < doubleDimensionalArray.Length; i++)
            {
                var currentPair = $"{x}+{y}";
                if (currentState == "right")
                {
                    var checkNextPair = $"{x}+{y + 1}";
                    if ((y + 1) >= doubleDimensionalArray.GetLength(1) || hashSet.Contains(checkNextPair))
                    {
                        currentState = "down";
                        result[i] = array[x][y];
                        hashSet.Add(currentPair);
                        x++;
                        continue;
                    }
                    else
                    {
                        result[i] = array[x][y];
                        y++;
                        hashSet.Add(currentPair);
                        continue;
                    }
                }
                if (currentState == "down")
                {
                    var checkNextPair = $"{x+1}+{y}";
                    if ((x + 1) >= doubleDimensionalArray.GetLength(1) || hashSet.Contains(checkNextPair))
                    {
                        currentState = "left";
                        result[i] = array[x][y];
                        hashSet.Add(currentPair);
                        y--;
                        continue;
                    }
                    else
                    {
                        result[i] = array[x][y];
                        x++;
                        hashSet.Add(currentPair);
                        continue;
                    }
                }
                if (currentState == "left")
                {
                    var checkNextPair = $"{x}+{y-1}";
                    if ((y - 1) < 0 || hashSet.Contains(checkNextPair))
                    {
                        currentState = "up";
                        result[i] = array[x][y];
                        hashSet.Add(currentPair);
                        x--;
                        continue;
                    }
                    else
                    {
                        result[i] = array[x][y];
                        y--;
                        hashSet.Add(currentPair);
                        continue;
                    }
                }
                if (currentState == "up")
                {
                    var checkNextPair = $"{x - 1}+{y}";
                    if ((x - 1) < 0 || hashSet.Contains(checkNextPair))
                    {
                        currentState = "right";
                        result[i] = array[x][y];
                        hashSet.Add(currentPair);
                        y++;
                        continue;
                    }
                    else
                    {
                        result[i] = array[x][y];
                        x--;
                        hashSet.Add(currentPair);
                        continue;
                    }
                }
                
                // enjoy
            }
            return result;
        }
        private static void Main(string[] args)
        {
            int[][] array =
            {
              new []{1, 2, 3},
           new []{4, 5, 6},
           new []{7, 8, 9}
            };


            int[][] array1 =
          {
              Array.Empty<int> (),
              Array.Empty<int> ()
            };
            
            var result = Snail(array1);
            for(int i =0; i < result.Length; i++) 
            {
                Console.WriteLine(result[i]);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}