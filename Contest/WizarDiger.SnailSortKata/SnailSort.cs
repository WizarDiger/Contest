using System;

namespace WizarDiger.SnailSortKata
{
    public class SnailSort
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
            new[]{245,299,751,779,933,45,795,198,141,679,891 },
            new[]{505,28,957,90,340,212,966,165,26,563,381 },
            new[]{460,862,965,825,26,967,932,174,873,413,826 },
            new[]{719,185,456,237,511,11,453,630,732,336,759 },
            new[]{709,462,722,280,11,873,621,796,412,495,469 },
            new[]{52,481,850,177,100,878,807,337,551,182,707 },
            new[]{615,348,392,888,329,387,875,571,289,685,311 },
            new[]{128,329,829,771,187,418,354,138,516,244,275 },
            new[]{669,942,837,383,985,942,720,194,724,17,378 },
            new[]{118,959,644,415,317,533,368,782,970,900,529 },
            new[]{724,12,996,717,410,996,58,808,244,517,859 }
            };


         
            
            var result = Snail(array);
            for(int i =0; i < result.Length; i++) 
            {
                Console.WriteLine(result[i]);
            }
            Console.WriteLine("Hello, World!");
        }
    }
}