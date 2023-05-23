double dT = 0.1;
double h = 0.1;
double x_0 = 0;
double x_n = 1;
double t_0 = 0;
double t_n = 1;


int x_nums = (int)((x_n - x_0) / h);


int N = (int)((t_n - t_0) / dT);
double[,] U = new double[N + 1, x_nums + 1];


for (int x_index = 0; x_index <= x_nums; x_index++)
    U[0, x_index] = Math.Pow(x_index * h, 2);



for (int n = 0; n < N - 1; n++)
{
    U[n + 1, 1] = 0;


    for (int j = 2; j <= x_nums; j++)
        U[n + 1, j] = (U[n, j] + dT / h * U[n + 1, j - 1] + (n + 1) * dT * (j - 1) * h);
    n++;
}
printU(U, x_0, h, dT, t_0);


static double GetValueByIndex(double start, double h, int index) => start + Convert.ToDouble(index) * h;




static void printU(double[,] U, double x_start, double h, double dT, double t_start)
{
    Console.WriteLine($"dT = {dT}; h = {h}");
    Console.BackgroundColor = ConsoleColor.Gray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.Write(String.Format("|{0, 6}|", "t\\x"));
    for (int i = 0; i < U.GetLength(1); i++)
        Console.Write(String.Format("{0, 8: 0.000}|", GetValueByIndex(x_start, h, i)));


    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;


    Console.WriteLine();
    for (int i = 0; i < U.GetLength(0); i++)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(String.Format("|{0, 5: 0.000}|", GetValueByIndex(t_start, dT, i)));
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
        for (int j = 0; j < U.GetLength(1); j++)
            Console.Write(String.Format("{0, 8: 0.000}|", U[i, j]));
        Console.WriteLine();
    }
}
