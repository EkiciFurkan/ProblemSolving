namespace ProblemSolving;

public interface IProblem
{
    void Solve();
}

public interface IMyTests
{
    void Solve();
}

public class GetTotalXProblem : IProblem
{
    private readonly List<int> _a = [2, 4];
    private readonly List<int> _b = [16, 32, 96];

    public void Solve()
    {
        var result = GetTotalX(_a, _b);
        Console.WriteLine($"GetTotalX Result: {result}");
    }

    private static int GetTotalX(List<int> a, List<int> b)
    {
        var count = 0;
        for (var i = a.Max(); i <= b.Min(); i++)
        {
            if (a.All(x => i % x == 0) && b.All(x => x % i == 0))
            {
                count++;
            }
        }

        return count;
    }
}

public class BreakingRecordProblem : IProblem
{
    private readonly List<int> _a = [10, 5, 20, 20, 4, 5, 2, 25, 1];

    public void Solve()
    {
        var result = BreakingRecords(_a);
        Console.WriteLine(string.Join(", ", result));
    }

    private static List<int> BreakingRecords(List<int> scores)
    {
        var min = scores[0];
        var minCount = 0;

        var max = scores[0];
        var maxCount = 0;

        foreach (var score in scores)
        {
            if (score < min)
            {
                min = score;
                minCount++;
            }

            // ReSharper disable once InvertIf
            if (score > max)
            {
                max = score;
                maxCount++;
            }
        }

        return [maxCount, minCount,];
    }
}

public class AlmostIncreasingSequenceProblem : IProblem
{
    private readonly List<int> _s = [1, 3, 2];

    public void Solve()
    {
        Console.WriteLine(AlmostIncreasingSequence(_s) == false ? "False" : "True");
    }

    private static bool AlmostIncreasingSequence(List<int> sequence)
    {
        var index = 0;

        for (var i = 1; i < sequence.Count; i++)
        {
            if (sequence[i] <= sequence[i - 1])
            {
                index++;

                if (i > 1 && i + 1 < sequence.Count && sequence[i] <= sequence[i - 2] &&
                    sequence[i + 1] <= sequence[i - 1])
                {
                    return false;
                }
            }

            if (index > 1)
            {
                return false;
            }
        }

        return true;
    }
}

// https://www.hackerrank.com/challenges/the-birthday-bar/problem
public class BirthdayProblem : IProblem
{
    private readonly List<int> _s = [4, 5, 4, 2, 4, 5, 2, 3, 2, 1, 1, 5, 4];

    private const int D = 15;

    private const int M = 4;


    public void Solve()
    {
        Console.WriteLine(Birthday(_s, D, M));
    }

    private static int Birthday(List<int> s, int d, int m)
    {
        return s.Where((_, i) => s.Skip(i).Take(m).Sum() == d).Count();

        // var count = 0;
        //
        // for (var i = 0; i < s.Count; i++)
        // {
        //     if (s.Skip(i).Take(m).Sum() == d)
        //     {
        //         count++;
        //     }
        // }
        //
        // return count;

        // There is another alternative; I'm not using it because this code isn't mine :)
        // return Enumerable.Range(0, s.Count - m + 1)
        //     .Count(i => s.Skip(i).Take(m).Sum() == d);
    }
}

// https://www.hackerrank.com/challenges/divisible-sum-pairs/problem?isFullScreen=true
public class DivisibleSumPairsProblem : IProblem
{
    private const int N = 6;

    private const int K = 3;

    private readonly List<int> _ar = [1, 3, 2, 6, 1, 2];


    public void Solve()
    {
        Console.WriteLine(DivisibleSumPairs(N, K, _ar));
    }

    private static int DivisibleSumPairs(int n, int k, List<int> ar)
    {
        var result = 0;
        for (var i = 0; i < ar.Count; i++)
        {
            for (var j = i + 1; j < ar.Count; j++)
            {
                if ((ar[i] + ar[j]) % k != 0) continue;
                result++;
            }
        }

        return result;
    }
}

// https://www.hackerrank.com/challenges/migratory-birds/problem?isFullScreen=true
public class MigratoryBirdsProblem : IProblem
{
    private readonly List<int> _ar = [1, 3, 3, 3, 3, 2, 6, 1, 2];

    public void Solve()
    {
        var result = MigratoryBirds(_ar);
        Console.WriteLine(result);
    }

    private static int MigratoryBirds(List<int> arr)
    {
        var result = arr.GroupBy(x => x)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Select(g => g.Key)
            .First();
        return result;
    }
}

// https://www.hackerrank.com/challenges/day-of-the-programmer/problem?isFullScreen=true
public class DayOfProgrammerProblem : IProblem
{
    private const int Year = 2017;

    public void Solve()
    {
        Console.WriteLine(DayOfProgrammer(Year));
    }

    private static string DayOfProgrammer(int year)
    {
        if (year == 1918)
        {
            return "26.09.1918";
        }

        var isJulianLeapYear = (year < 1918 && year % 4 == 0);
        var isGregorianLeapYear = (year > 1918 && (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0)));
        var isLeapYear = isJulianLeapYear || isGregorianLeapYear;

        return isLeapYear ? $"12.09.{year}" : $"13.09.{year}";
    }
}

// https://www.hackerrank.com/challenges/bon-appetit/problem?isFullScreen=true
public class BonAppetitProblem : IProblem
{
    private readonly List<int> _ar = [3, 10, 2, 9];
    private const int K = 1;
    private const int B = 12;


    public void Solve()
    {
        BonAppetit(_ar, K, B);
    }

    private static void BonAppetit(List<int> bill, int k, int b)
    {
        var sumBill = (bill.Sum() - bill[k]) / 2;

        if (sumBill == b)
        {
            Console.WriteLine("Bon Appetit");
        }
        else
        {
            Console.WriteLine(b - sumBill);
        }
    }
}

// https://www.hackerrank.com/challenges/sock-merchant/problem?isFullScreen=true
public class SockMerchantProblem : IProblem
{
    private readonly List<int> _ar = [10, 20, 20, 10, 10, 30, 50, 10, 20];
    private const int K = 1;

    public void Solve()
    {
        SockMerchant(K, _ar);
    }

    private static int SockMerchant(int n, List<int> ar)
    {
        var elementCounts = ar.GroupBy(x => x)
            .ToDictionary(g => g.Key, g => g.Count());

        var result = elementCounts.Sum(element => element.Value / 2);

        Console.WriteLine(result);

        return result;
    }
}

// https://www.hackerrank.com/challenges/drawing-book/problem?isFullScreen=true
public class PageCountProblem : IProblem
{
    private const int N = 8;
    private const int P = 2;


    public void Solve()
    {
        Console.WriteLine(PageCount(N, P));
    }

    private static int PageCount(int n, int p)
    {
        if (p == 1 || p == n)
        {
            return 0;
        }

        var frontFlips = p / 2;
        var backFlips = n / 2 - p / 2;

        return Math.Min(frontFlips, backFlips);
    }
}

// https://www.hackerrank.com/challenges/counting-valleys/problem?isFullScreen=true
public class CountingValleysProblem : IProblem
{
    private const int S = 12;
    private const string P = "DDUUDDUDUUUD";


    public void Solve()
    {
        Console.WriteLine(CountingValleys(S, P));
    }

    private static int CountingValleys(int steps, string path)
    {
        var seaLevel = 0;
        var valleyCount = 0;

        foreach (var step in path)
        {
            switch (step)
            {
                case 'U':
                    seaLevel++;
                    break;
                case 'D':
                    seaLevel--;
                    break;
            }

            if (seaLevel == 0 && step == 'U')
            {
                valleyCount++;
            }
        }

        return valleyCount;
    }
}

// https://www.hackerrank.com/challenges/electronics-shop/problem?isFullScreen=true
public class GetMoneySpentProblem : IProblem
{
    private readonly int[] _k = [40, 50, 60];
    private readonly int[] _d = [5, 8, 12];
    private const int B = 60;


    public void Solve()
    {
        Console.WriteLine(GetMoneySpent(_k, _d, B));
    }

    private static int GetMoneySpent(int[] keyboards, int[] drives, int b)
    {
        if (b < drives.Min() + keyboards.Min())
        {
            return -1;
        }

        var sum = keyboards.SelectMany(x => drives.Select(y => x + y)).ToList();
        var maxUnderB = 0;

        foreach (var item in sum.Where(item => item <= b && item > maxUnderB))
        {
            maxUnderB = item;
        }

        return maxUnderB;
    }
}

// https://www.hackerrank.com/challenges/cats-and-a-mouse/problem?isFullScreen=true
public class CatAndMouseProblem : IProblem
{
    private const int X = 1;
    private const int Y = 3;
    private const int Z = 2;

    public void Solve()
    {
        Console.WriteLine(CatAndMouse(X, Y, Z));
    }

    private static string CatAndMouse(int x, int y, int z)
    {
        var distanceA = Math.Abs(x - z);
        var distanceB = Math.Abs(y - z);

        if (distanceA > distanceB)
        {
            return "Cat B";
        }

        return distanceA < distanceB ? "Cat A" : "Mouse C";
    }
}

//Test For Dictionary
public class DictionaryTest : IMyTests
{
    private readonly Dictionary<string, List<string>> _test = new();

    public void Solve()
    {
        _test.Add("test1", ["1", "2", "3"]);
        _test.Add("test2", ["4", "5", "6"]);
        _test.Add("test3", ["7", "8", "9"]);

        foreach (var (key, value) in _test)
        {
            Console.Write(key);
            foreach (var item in value)
            {
                Console.WriteLine($"\t{item}");
            }
        }
    }
}

internal abstract class Program
{
    private static void Main()
    {
        var problems = new List<IProblem>
        {
            // new AlmostIncreasingSequenceProblem()
            // new BirthdayProblem()
            // new TwoSumProblem()
            // new DivisibleSumPairsProblem()
            // new DayOfProgrammerProblem()
            // new BonAppetitProblem()
            // new SockMerchantProblem()
            // new PageCountProblem()
            // new CountingValleysProblem()
            // new GetMoneySpentProblem()
            new CatAndMouseProblem()
        };
        if (problems == null) throw new ArgumentNullException(nameof(problems));

        foreach (var problem in problems)
        {
            problem.Solve();
        }

        // Tests

        var tests = new List<IMyTests>
        {
            // new DictionaryTest()
        };
        if (tests == null) throw new ArgumentNullException(nameof(tests));

        foreach (var test in tests)
        {
            test.Solve();
        }
    }
}