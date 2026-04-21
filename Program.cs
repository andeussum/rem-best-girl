using System;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

public static class Program
{

    public static void Main()
    {
         // Variables
        int side;
        side = 0;
        int x, y, selected_sides;
        x = 0;
        y = 0;
        selected_sides = -1;

        // Map Edge points Finder
        Console.WriteLine("Map Edge Points Finder v.0.0.1");

        while (true)
        {
            Console.WriteLine("Provide the x coordinate: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out x))
                break;
        }

        while (true)
        {
            Console.WriteLine("Provide the y coordinate: ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out y))
                break;
        }

        while (true)
        {
            Console.WriteLine("Select a map size: ");
            Console.WriteLine("0. 128x128 ");
            Console.WriteLine("1. 256x256 ");
            Console.WriteLine("2. 512x512 ");
            Console.WriteLine("3. 1024x1024 ");
            Console.WriteLine("4. 2048x2048 ");

            string? input = Console.ReadLine();

            if (int.TryParse(input, out selected_sides) &&
                selected_sides >= 0 && selected_sides <= 4)
            {
                break;
            }
        }

        if (selected_sides == 0)
        {
            side = 128;
        }
        if (selected_sides == 1)
        {
            side = 256;
        }
        else if (selected_sides == 2)
        {
            side = 512;
        }
        else if (selected_sides == 3)
        {
            side = 1024;
        }
        else if (selected_sides == 4)
        {
            side = 2048;
        }
        else
        {
            Console.WriteLine("Select a number.");
        }
    
        // OUTPUT
        // Block on the edge of the map finder lol
        // You are my sunshine my only sunshine you make me happy when skies are grey you never know dear how much I love you please don't take my sunshine away

        Console.WriteLine("X: " + x + ", " + "Y: " + y);
        Console.WriteLine("Map Size Length: " + side);

        int SoutheastXCenterPoint = CenterFinder(x, side);
        int SoutheastYCenterPoint = CenterFinder(y, side);

        Console.WriteLine("\nNorthwest(NW) block: " + (SoutheastXCenterPoint-1) + ", " + (SoutheastYCenterPoint-1));
        Console.WriteLine("\nNortheast(NS) block: " + (SoutheastXCenterPoint) + ", " + (SoutheastYCenterPoint-1));
        Console.WriteLine("\nSouthwest(SW) block: " + (SoutheastXCenterPoint-1) + ", " + (SoutheastYCenterPoint));
        Console.WriteLine("\nSoutheast(SE) block: " + (SoutheastXCenterPoint) + ", " + (SoutheastYCenterPoint));

        Console.WriteLine("\n");
        Console.WriteLine("      NW          NE");
        Console.WriteLine("===========================");
        Console.WriteLine("||  " + (SoutheastXCenterPoint-1) + ", " + (SoutheastYCenterPoint-1) + "  ||  " + (SoutheastXCenterPoint) + ", " + (SoutheastYCenterPoint-1) + "  ||");
        Console.WriteLine("===========================");
        Console.WriteLine("||  " + (SoutheastXCenterPoint-1) + ", " + (SoutheastYCenterPoint) + "  ||  " + (SoutheastXCenterPoint) + ", " + (SoutheastYCenterPoint) + "  ||");
        Console.WriteLine("===========================");
        Console.WriteLine("      SW          SE");


        int NortheastFormulaResult = CornerPointFinder(SoutheastXCenterPoint, side, true);
        int SoutheastFormulaResult = CornerPointFinder(SoutheastYCenterPoint, side, false);

        // Map Edge Points
        Console.WriteLine("======== All Four Edge Points ========");
        Console.WriteLine("Northwest: " + NortheastFormulaResult + ", " + NortheastFormulaResult);
        Console.WriteLine("Southwest: " + NortheastFormulaResult + ", " + SoutheastFormulaResult);
        Console.WriteLine("Northeast: " + SoutheastFormulaResult + ", " + NortheastFormulaResult);
        Console.WriteLine("Southeast: " + SoutheastFormulaResult + ", " + SoutheastFormulaResult);
    }
    public static int CenterFinder(int a, int side)
    {   
        // a is the coordinates (x or y)
        // Solving for the center blocks
        int HalfOfMapLength, RangeCoords, MapGridPosition, result;
        // Extra variables
        int SideSlash128;

        HalfOfMapLength = side / 2;

        RangeCoords = HalfOfMapLength + a; // This turns a -64 to 63 range into 0 to 127 range coordinates

        MapGridPosition = (int)Math.Floor((double)RangeCoords / side); // This gives the position of the imaginary map grid

        // Gives the result of side divided by 128
        SideSlash128 = side / 128;

        result = MapGridPosition * (side) + ((side/2) - 64); // Provides the northwest center block of the map

        return result;
    }
    public static int CornerPointFinder(int a, int side, bool IsItNorthEast)
    {
        // a is the coordinates (x or y)
        int NortheastFormula = a - (side / 2);
        int SoutheastFormula = (a + (side / 2)) - 1;

        if (IsItNorthEast)
        {
            return NortheastFormula;  
        }
        else
        {
            return SoutheastFormula;
        }
    }
}