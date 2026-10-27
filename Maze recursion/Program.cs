using System;
using System.Collections.Generic;

public class MazeAssignment
{
    public class RecursionMetrics
    {
        public int TotalCalls = 0;
        public int MaxStackDepth = 0;
        public int CurrentStackDepth = 0;
        public int PrunedBranches = 0;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("=== RECURSIVE MAZE GENERATOR & SOLVER ===");

        // 1. Get Grid Dimensions from User
        int rows = ReadOddDimension("Enter grid rows (Odd number, min 5): ");
        int cols = ReadOddDimension("Enter grid columns (Odd number, min 5): ");

        // 2. Get Max Steps from User
        int maxSteps = ReadMaxSteps(rows, cols);

        // 3. Generate & Display Maze
        Console.WriteLine($"\n=== GENERATING {rows}x{cols} MAZE ===");
        char[,] maze = GenerateMaze(rows, cols);
        PrintMaze(maze);

        // 4. Solve Maze
        RecursionMetrics metrics = new RecursionMetrics();
        List<string> currentPath = new List<string>();
        List<List<string>> allValidPaths = new List<List<string>>();
        bool[,] visited = new bool[rows, cols];

        Console.WriteLine($"\n=== SEARCHING FOR PATHS (MAX STEPS: {maxSteps}) ===");
        SolveBacktrack(maze, 0, 0, rows - 1, cols - 1, 0, maxSteps, visited, currentPath, allValidPaths, metrics);

        // 5. Print Metrics & Results
        Console.WriteLine("\n=== RESULTS ===");
        Console.WriteLine($"Total Unique Paths Found: {allValidPaths.Count}");
        Console.WriteLine($"Total Recursive Calls Made: {metrics.TotalCalls}");
        Console.WriteLine($"Max Call Stack Depth: {metrics.MaxStackDepth}");
        Console.WriteLine($"Pruned Branches (> {maxSteps} steps): {metrics.PrunedBranches}");
    }

    private static int ReadOddDimension(string prompt)
    {
        // TODO: Prompt user for input and validate integer input >= 5
        // TODO: Ensure input is an odd number (if even, adjust or re-prompt)
        return 0;
    }

    private static int ReadMaxSteps(int rows, int cols)
    {
        // TODO: Prompt user for max steps limit
        // TODO: Parse input and handle blank/default input (default to rows * cols)
        return 0;
    }

    public static char[,] GenerateMaze(int rows, int cols)
    {
        char[,] grid = new char[rows, cols];
        // 1. Fill grid with '#'
        // 2. Set (0,0) as 'S' and (rows-1, cols-1) as 'F'
        // 3. Call recursive carving helper starting at (0,0)
        // TODO: Complete implementation
        return grid;
    }

    public static void SolveBacktrack(
        char[,] grid,
        int r,
        int c,
        int exitR,
        int exitC,
        int steps,
        int maxSteps,
        bool[,] visited,
        List<string> currentPath,
        List<List<string>> allPaths,
        RecursionMetrics metrics)
    {
        // TODO: Update metrics (TotalCalls, CurrentStackDepth, MaxStackDepth)

        // TODO: Base Cases:
        // - Out of bounds check
        // - Hit wall '#' or already visited
        // - Prune if steps > maxSteps (Increment metrics.PrunedBranches)
        // - Reached Exit 'F': Save path clone to allPaths and unwind

        // TODO: Recursive Steps:
        // 1. Mark visited[r, c] = true
        // 2. Add current coordinate "(r, c)" to currentPath
        // 3. Make 4 recursive calls for UP, DOWN, LEFT, RIGHT
        // 4. UNMARK: Remove coordinate from currentPath
        // 5. UNMARK: Set visited[r, c] = false
        // 6. Decrement metrics.CurrentStackDepth before returning
    }

    public static void PrintMaze(char[,] grid)
    {
        for (int r = 0; r < grid.GetLength(0); r++)
        {
            for (int c = 0; c < grid.GetLength(1); c++)
            {
                Console.Write(grid[r, c] + " ");
            }
            Console.WriteLine();
        }
    }
}