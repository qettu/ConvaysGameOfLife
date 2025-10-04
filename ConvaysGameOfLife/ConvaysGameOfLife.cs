/// @author Niilo Vertainen
/// @version 3.10.2025
/// <summary>
/// Convay's Game Of Life algorithm
/// </summary>
///
/// TODO: Change int to bool
public class ConvaysGameOfLife
{
    /// <summary>
    /// Main program prints generation tables
    /// </summary>
    public static void Main()
    {
        int generaatiot = 3;
        int[,] taulukko =
        {
            {0, 0, 0, 0, 0, 0 },
            {0, 1, 0, 1, 1, 0 },
            {0, 0, 1, 1, 0, 0 },
            {0, 1, 0, 0, 0, 0 },
            {0, 1, 0, 0, 1, 0 },
            {0, 0, 0, 0, 0, 0 }
        };
        TulostaTaulukko(taulukko);
        int height = taulukko.GetLength(0);
        int width = taulukko.GetLength(1);
        int[,] taulukkoTemp = new int[6, 6];
        int[,] nollaTaulukko = NollaTaulukko(width, height);
        
        for (int generaatio = 0; generaatio < generaatiot; generaatio++)
        {
            for (int sarake = 1; sarake < width - 1; sarake++)
            {
                for (int rivi = 1; rivi < height - 1; rivi++)
                {
                    int naapurit = 0;
                    for (int x = sarake - 1; x <= sarake + 1; x++)
                    {
                        for (int y = rivi - 1; y <= rivi + 1; y++)
                        {
                            naapurit += taulukko[x, y];
                        }
                    }

                    if (taulukko[sarake, rivi] == 1)
                    {
                        if (naapurit <= 2) // Tässä solu lasketaan itse naapurikseen, joten nostetaan rajaa 1 -> 2
                        {
                            taulukkoTemp[sarake, rivi] = 0;
                        }
                        else if (naapurit >= 5)
                        {
                            taulukkoTemp[sarake, rivi] = 0;
                        }
                        else
                        {
                            taulukkoTemp[sarake, rivi] = 1;
                        }
                    }
                    else
                    {
                        if (naapurit == 3) // Tässä solu ei ole oma naapurinsa, koska sitä ei ole olemassa
                        {
                            taulukkoTemp[sarake, rivi] = 1;
                        }
                    }
                }
            }
            taulukko = taulukkoTemp;
            taulukkoTemp = nollaTaulukko;
            TulostaTaulukko(taulukko);
        }
    }
    private static void TulostaTaulukko(int[,] taulukko){
        for (int a = 0; a < 6; a++)
        {
            for (int b = 0; b < 6; b++)
            {
                System.Console.Write(taulukko[a, b] == 1 ? " M" : " -");
            }
            System.Console.Write("\n");
        }
        System.Console.Write("\n");
    }

    private static int[,] NollaTaulukko(int width, int height)
    {
        int[,] table = new int[width, height];
        for (int a = 0; a < width; a++)
        {
            for (int b = 0; b < height; b++)
            {
                table[a, b] = 0;
            }
        }

        TulostaTaulukko(table);
        return table;
    }
}