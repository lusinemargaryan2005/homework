//MatrixDiagonal
PrintMainDiagonal(8);

void PrintMainDiagonal(int matrixSize)
{
    char[,] mtx = new char[matrixSize, matrixSize];

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            mtx[i, j] = '*';

            if (i == j)
            {
                mtx[i, j] = '#';
            }

            if (i + j == matrixSize - 1)
            {
                mtx[i, j] = '~';
            }
        }
    }

    for (int i = 0; i < matrixSize; i++)
    {
        for (int j = 0; j < matrixSize; j++)
        {
            Console.Write(mtx[i, j] + " ");
        }
        Console.WriteLine();
    }

}

// CHess Rock
CheckRookMove(8, 3, 5, 7,2);

void CheckRookMove(int size, int startRow, int startCol, int endRow, int endCol)
{
    char[,] board = new char[size, size];
 
    bool canMove = (startRow == endRow || startCol == endCol);

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            board[i, j] = '.';

            if (i == startRow || j == startCol)
            {
                board[i, j] = '+';
            }

            if (i == startRow && j == startCol)
            {
                board[i, j] = 'S'; 
            }

            if (i == endRow && j == endCol)
            {
                board[i, j] = 'E';
            }
        }
    }

    for (int i = 0; i < size; i++)
    {
        for (int j = 0; j < size; j++)
        {
            Console.Write(board[i, j] + " ");
        }
        Console.WriteLine();
    }

    if (canMove)
    {
        Console.WriteLine("\n yes։");
    }
    else
    {
        Console.WriteLine("\n no");
    }
}
bool Knight(int x1, int y1, int x2, int y2)
{
    int[,] allowed =
    {
        { x1 + 2, y1 + 1 },
        { x1 + 2, y1 - 1 },
        { x1 - 2, y1 + 1 },
        { x1 - 2, y1 - 1 },
        { x1 + 1, y1 + 2 },
        { x1 + 1, y1 - 2 },
        { x1 - 1, y1 + 2 },
        { x1 - 1, y1 - 2 }
    };

    for (int i = 0; i < allowed.GetLength(0); i++)
    {
        if (allowed[i, 0] == x2 && allowed[i, 1] == y2)
        {
            return true;
        }
    }

    return false;
}

// Knight Shortest Path
var path = KnightShortestPath(0, 0, 3, 3);
Console.WriteLine($"qayleri qanak: {path.Count - 1}");
Console.WriteLine("Chanaparh:");
foreach (var (x, y) in path)
    Console.Write($"({x},{y}) ");

List<(int, int)> KnightShortestPath(int x1, int y1, int x2, int y2)
{
    int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
    int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

    var parent = new Dictionary<(int, int), (int, int)?>();
    parent[(x1, y1)] = null;

    var current = new List<(int, int)> { (x1, y1) };

    while (current.Count > 0)
    {
        var next = new List<(int, int)>();

        foreach (var (cx, cy) in current)
        {
            if (cx == x2 && cy == y2)
            {
                var path = new List<(int, int)>();
                (int, int)? node = (cx, cy);
                while (node != null)
                {
                    path.Add(node.Value);
                    node = parent[node.Value];
                }
                path.Reverse();
                return path;
            }

            for (int i = 0; i < 8; i++)
            {
                int nx = cx + dx[i];
                int ny = cy + dy[i];
                if (!parent.ContainsKey((nx, ny)))
                {
                    parent[(nx, ny)] = (cx, cy);
                    next.Add((nx, ny));
                }
            }
        }

        current = next;
    }

    return new List<(int, int)>();
}