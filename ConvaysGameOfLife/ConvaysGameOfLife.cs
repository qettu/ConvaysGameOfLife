/// @author Niilo Vertainen
/// @version 3.10.2025
/// <summary>
/// Conway's Game Of Life algorithm
/// </summary>

public class ConvaysGameOfLife
{
    /// <summary>
    /// Main program prints generation tables
    /// </summary>
    public static void Main()
    {
        int generations = 3;
        bool[,] table =
        {
            {false, false, false, false, false, false },
            {false, true,  false, true,  true,  false },
            {false, false, true,  true,  false, false },
            {false, true,  false, false, false, false },
            {false, true,  false, false, true,  false },
            {false, false, false, false, false, false }
        };
        PrintTable(table);
        int height = table.GetLength(0);
        int width = table.GetLength(1);
        bool[,] tableTemp = new bool[6, 6];
        bool[,] zeroTable = ZeroTable(width, height);
        
        for (int generation = 0; generation < generations; generation++)
        {
            for (int col = 1; col < width - 1; col++)
            {
                for (int row = 1; row < height - 1; row++)
                {
                    int neighbours = 0;
                    for (int x = col - 1; x <= col + 1; x++)
                    {
                        for (int y = row - 1; y <= row + 1; y++)
                        {
                            if (table[x, y])
                            {
                                neighbours += 1;
                            }
                        }
                    }

                    if (table[col, row])
                    {
                        if (neighbours <= 2) // Cell is its own neighbour
                        {
                            tableTemp[col, row] = false;
                        }
                        else if (neighbours >= 5)
                        {
                            tableTemp[col, row] = false;
                        }
                        else
                        {
                            tableTemp[col, row] = true;
                        }
                    }
                    else
                    {
                        if (neighbours == 3) // Tässä solu ei ole oma naapurinsa, koska sitä ei ole olemassa
                        {
                            tableTemp[col, row] = true;
                        }
                    }
                }
            }
            table = tableTemp;
            tableTemp = zeroTable;
            PrintTable(table);
        }
    }
    private static void PrintTable(bool[,] table){
        for (int a = 0; a < 6; a++)
        {
            for (int b = 0; b < 6; b++)
            {
                System.Console.Write(table[a, b] ? " M" : " -");
            }
            System.Console.Write("\n");
        }
        System.Console.Write("\n");
    }

    private static bool[,] ZeroTable(int width, int height)
    {
        bool[,] zeroTable = new bool[width, height];
        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                zeroTable[a, b] = false;
            }
        }

        return zeroTable;
    }
}