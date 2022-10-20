namespace Zero_OneKnapsack;

internal class Program
{
    static void Main(String[] args)
    {
        int n = 10;
        int c = 20;
        int[] v = new[] { 0, 4, 8, 9, 12, 12, 1, 8, 7, 5, 10 };
        int[] w = new[] { 0, 5, 8, 12, 5, 8, 15, 30, 9, 12, 1 };
        int result = KS(n, c, v, w,
            new int[n + 1, c + 1]);
        Console.WriteLine(result);
    }

    static int KS(int n, int c, int[] v, int[] w, int[,] memo)
    {
        if (memo[n, c] != 0) return memo[n, c];
        int result;
        if (n == 0 || c == 0)
        {
            result = 0;
        }
        else if (w[n] > c)
        {
            result = KS(n - 1, c, v, w, memo);
        }
        else
        {
            int temp1 = KS(n - 1, c, v, w, memo);
            int temp2 = KS(n - 1, c - w[n], v, w, memo) + v[n];
            result = Max(temp1, temp2);
        }

        memo[n, c] = result;
        return result;
    }

    static int Max(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}