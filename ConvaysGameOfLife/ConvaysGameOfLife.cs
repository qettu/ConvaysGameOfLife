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

        int generations = 5;
        int height = table.GetLength(0);
        int width = table.GetLength(1);

        // Choose initialization tables
        bool[,] zeroTable = ZeroTable(width, height);
        bool[,] tableTemp = zeroTable;


        // TODO: move calculation of generations to own function
        // Calculate generations ("main"-function)
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

                    if (table[col, row]) // There cell is its own neighbour. Its value is "true"
                    {
                        if (neighbours <= 2)
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
                    else // Cell isn't its own neighbour, because cell is "false"
                    {
                        if (neighbours == 3)
                        {
                            tableTemp[col, row] = true;
                        }
                    }
                }
            }

            // Initializations for next round. Print result
            table = tableTemp;
            tableTemp = zeroTable;
            PrintTable(table);
        }
    }


    // Print table
    private static void PrintTable(bool[,] table)
    {
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


    // Table filled with zeros / falses
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


    // Initialize FULL TABLE with pattern of vertical stripes
    private static bool[,] VerticalStripesTable(int width, int height)
    {
        bool[,] verticalStripesTable = new bool[width, height];
        // To make state stable, we'll use pattern to borders too.
        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                if (a % 2 == 1)
                {
                    verticalStripesTable[a, b] = true;
                }
                else
                {
                    verticalStripesTable[a, b] = false;
                }
            }
        }

        return verticalStripesTable;
    }
    

    // Initialize TABLE BORDERS with pattern of vertical stripes
    private static bool[,] VerticalStripesBordersTable(int width, int height)
    {
        bool[,] verticalStripesBordersTable = ZeroTable(width, height);

        for (int a = 0; a < width; a++)
        {
            if (a % 2 == 1)
            {
                verticalStripesBordersTable[a, 0] = true;
                verticalStripesBordersTable[a, width-1] = true;
            }
            else
            {
                verticalStripesBordersTable[a, 0] = false;
                verticalStripesBordersTable[a, width-1] = false;
            }
        }
        if (width % 2 == 1)
        {
            for (int b = 0; b < height; b++)
            {
                verticalStripesBordersTable[width-1, b] = false;
                verticalStripesBordersTable[0, b] = false;
            }
        }
        else
        {
            for (int b = 0; b < height; b++)
            {
                verticalStripesBordersTable[width-1, b] = true;
                verticalStripesBordersTable[0, b] = false;
            }
        }

        return verticalStripesBordersTable;
    }
    
}