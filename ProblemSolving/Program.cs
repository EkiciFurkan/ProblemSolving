﻿using System.Threading.Channels;

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

// https://www.hackerrank.com/challenges/magic-square-forming/problem?isFullScreen=true
public class FormingMagicSquareProblem : IProblem
{
    public void Solve()
    {
        var s = new List<List<int>>
        {
            new() { 4, 8, 2 },
            new() { 4, 5, 7 },
            new() { 6, 1, 6 }
        };

        Console.WriteLine(FormingMagicSquare(s));
    }

    private static int FormingMagicSquare(List<List<int>> s)
    {
        var magicSquares = new List<int[,]>
        {
            new[,] { { 4, 9, 2 }, { 3, 5, 7 }, { 8, 1, 6 } },
            new[,] { { 4, 3, 8 }, { 9, 5, 1 }, { 2, 7, 6 } },
            new[,] { { 2, 9, 4 }, { 7, 5, 3 }, { 6, 1, 8 } },
            new[,] { { 2, 7, 6 }, { 9, 5, 1 }, { 4, 3, 8 } },
            new[,] { { 8, 1, 6 }, { 3, 5, 7 }, { 4, 9, 2 } },
            new[,] { { 8, 3, 4 }, { 1, 5, 9 }, { 6, 7, 2 } },
            new[,] { { 6, 1, 8 }, { 7, 5, 3 }, { 2, 9, 4 } },
            new[,] { { 6, 7, 2 }, { 1, 5, 9 }, { 8, 3, 4 } }
        };

        var minCost = int.MaxValue;
        foreach (var magicSquare in magicSquares)
        {
            var cost = 0;
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    cost += Math.Abs(s[i][j] - magicSquare[i, j]);
                }
            }

            minCost = Math.Min(minCost, cost);
        }

        return minCost;
    }
}

// https://www.hackerrank.com/challenges/picking-numbers/problem?isFullScreen=true
public class PickingNumbersProblem : IProblem
{
    private readonly List<int> _s = [4, 6, 5, 3, 3, 1];

    public void Solve()
    {
        Console.WriteLine(PickingNumbers(_s));
    }

    private static int PickingNumbers(List<int> a)
    {
        var grouped = a.GroupBy(i => i).ToDictionary(j => j.Key, j => j.Count());
        var maxCount = 0;

        foreach (var key in grouped)
        {
            var countCurrent = grouped[key.Key];
            var countNext = grouped.ContainsKey(key.Key + 1) ? grouped[key.Key + 1] : 0;
            maxCount = Math.Max(maxCount, countCurrent + countNext);
        }

        return maxCount;
    }
}

// https://leetcode.com/problems/palindrome-number/
public class PalindromeNumberProblem : IProblem
{
    private const int X = 122;

    public void Solve()
    {
        Console.WriteLine(IsPalindrome(X));
    }

    private static bool IsPalindrome(int x)
    {
        if (x < 0)
        {
            return false;
        }

        var original = x.ToString();

        var charArray = original.ToCharArray();
        Array.Reverse(charArray);
        var reversed = new string(charArray);

        return reversed == original;
    }
}

// https://leetcode.com/problems/longest-common-prefix/description/
public class LongestCommonPrefixProblem : IProblem
{
    private readonly string[] _s = ["flower", "flow", "flight"];


    public void Solve()
    {
        Console.WriteLine(LongestCommonPrefix(_s));
    }

    private static string LongestCommonPrefix(string[] strs)
    {
        var result = "";
        var referenceItem = strs[0];

        for (var i = 0; i < referenceItem.Length; i++)
        {
            var currentChar = referenceItem[i];

            if (strs.All(word => word.Length > i && word[i] == currentChar))
            {
                result += currentChar;
            }
            else
            {
                break;
            }
        }

        return result;
    }
}

//https://leetcode.com/problems/3sum/
public class ThreeSumProblem : IProblem
{
    private readonly IList<int> _testData = [-1, 0, 1, 2, -1, -4];

    public void Solve()
    {
        var result = ThreeSum(_testData.ToArray());
        foreach (var triplet in result)
        {
            Console.WriteLine($"[{string.Join(", ", triplet)}]");
        }
    }

    private IList<IList<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);

        foreach (var item in nums)
        {
            Console.WriteLine(item);
        }

        return new List<IList<int>>();
    }
}

//https://leetcode.com/problems/valid-parentheses/
public class IsValidProblem : IProblem
{
    private const string V = "()[]";

    public void Solve()
    {
        Console.WriteLine(IsValid(V));
    }

    private static bool IsValid(string s)
    {
        List<string> isOpen = ["(", "[", "{"];
        List<string> isClosed = [")", "]", "}"];
        var stack = new Stack<string>();

        foreach (var item in s.ToCharArray())
        {
            var strItem = item.ToString();

            if (isOpen.Contains(strItem))
            {
                stack.Push(strItem);
            }
            else if (isClosed.Contains(strItem))
            {
                if (stack.Count == 0 || isOpen[isClosed.IndexOf(strItem)] != stack.Pop())
                {
                    return false;
                }
            }
        }

        return stack.Count == 0;
    }
}

//https://leetcode.com/problems/remove-duplicates-from-sorted-array/
public class RemoveDuplicatesProblem : IProblem
{
    private readonly int[] _nums = [1, 1, 2];

    public void Solve()
    {
        Console.WriteLine(RemoveDuplicates(_nums));
    }

    private static int RemoveDuplicates(int[] nums)
    {
        var i = 0;
        for (var j = 0; j < nums.Length; j++)
        {
            if (nums[i] == nums[j]) continue;
            i++;
            nums[i] = nums[j];
        }

        return i + 1;
    }
}

public class StrStrProblem : IProblem
{
    private const string Haystack = "sadbutsad";
    private const string Needle = "but";

    public void Solve()
    {
        Console.WriteLine(StrStr(Haystack, Needle));
    }


    private static int StrStr(string haystack, string needle)
    {
        if (haystack.Contains(needle)) return -1;
        return haystack.IndexOf(needle, StringComparison.Ordinal);
    }
}

// https://www.hackerrank.com/challenges/climbing-the-leaderboard/problem?isFullScreen=true
public class ClimbingLeaderboardProblem : IProblem
{
    private readonly List<int> _ranked = [100, 100, 50, 40, 40, 20, 10];
    private readonly List<int> _player = [5, 25, 50, 120];

    public void Solve()
    {
        var result = ClimbingLeaderboard(_ranked, _player);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }

    private static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)
    {
        var gropedRanked = ranked.GroupBy(x => x).Select(x => x.Key).ToList();

        for (var i = 0; i < gropedRanked.Count; i++)
        {
            for (var j = 0; j < player.Count; j++)
            {
            }
        }

        return [];
    }
}

// https://www.hackerrank.com/challenges/designer-pdf-viewer/problem?isFullScreen=true
public class DesignerPdfViewerProblem : IProblem
{
    private readonly List<int> _h = [1, 3, 1, 3, 1, 4, 1, 3, 2, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5];
    private const string Word = "abc";

    public void Solve()
    {
        Console.WriteLine(DesignerPdfViewer(_h, Word));
    }

    private static int DesignerPdfViewer(List<int> h, string word)
    {
        return word.Select(c => h[c - 'a']).Max() * word.Length;
    }
}

//https://leetcode.com/problems/divide-two-integers/description/
public class DivideProblem : IProblem
{
    private const int X = 10;
    private const int Y = 3;

    public void Solve()
    {
        Console.WriteLine(Divide(X, Y));
    }

    private static int Divide(int dividend, int divisor)
    {
        return 4;
    }
}

//https://leetcode.com/problems/search-insert-position/
public class SearchInsertProblem : IProblem
{
    private readonly int[] _nums = [1, 3, 5, 6];
    private const int Target = 2;

    public void Solve()
    {
        Console.WriteLine(SearchInsert(_nums, Target));
    }

    private static int SearchInsert(int[] nums, int target)
    {
        var ifIndex = Array.IndexOf(nums, target);
        var index = nums.Count(t => target > t);

        return ifIndex != 1 ? index : ifIndex;
    }
}

// https://leetcode.com/problems/valid-sudoku/description/
public class IsValidSudokuProblem : IProblem
{
    private readonly char[][] _board =
    [
        ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
        ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
        ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
        ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
        ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
        ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
        ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
        ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
        ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ];

    public void Solve()
    {
        Console.WriteLine(IsValidSudoku(_board));
    }

    private static bool IsValidSudoku(char[][] board)
    {
        for (var i = 0; i < 9; i++)
        {
            var rowSet = new HashSet<char>();
            for (var j = 0; j < 9; j++)
            {
                var num = board[i][j];
                if (num != '.' && !rowSet.Add(num))
                {
                    return false;
                }
            }
        }

        for (var j = 0; j < 9; j++)
        {
            var colSet = new HashSet<char>();
            for (var i = 0; i < 9; i++)
            {
                var num = board[i][j];
                if (num != '.' && !colSet.Add(num))
                {
                    return false;
                }
            }
        }

        for (var row = 0; row < 9; row += 3)
        {
            for (var col = 0; col < 9; col += 3)
            {
                var boxSet = new HashSet<char>();
                for (var i = 0; i < 3; i++)
                {
                    for (var j = 0; j < 3; j++)
                    {
                        var num = board[row + i][col + j];
                        if (num != '.' && !boxSet.Add(num))
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}

//https://leetcode.com/problems/sudoku-solver/description/
public class SolverSudokuProblem : IProblem
{
    private readonly char[][] _board =
    [
        ['5', '3', '.', '.', '7', '.', '.', '.', '.'],
        ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
        ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
        ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
        ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
        ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
        ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
        ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
        ['.', '.', '.', '.', '8', '.', '.', '7', '9']
    ];

    public void Solve()
    {
        PrintBoard(_board);
    }

    private static void PrintBoard(char[][] board)
    {
        for (var i = 0; i < board.Length; i++)
        {
            for (var j = 0; j < board[i].Length; j++)
            {
                Console.Write(board[i][j] + " ");

                if ((j + 1) % 3 == 0 && j != board[i].Length - 1)
                {
                    Console.Write("| ");
                }
            }

            Console.WriteLine();

            if ((i + 1) % 3 == 0 && i != board.Length - 1)
            {
                Console.WriteLine("---------------------");
            }
        }
    }
}

// https://leetcode.com/problems/final-array-state-after-k-multiplication-operations-i/description/?envType=daily-question&envId=2024-12-16
public class GetFinalStateProblem : IProblem
{
    private readonly int[] _nums = [2,1,3,5,6];

    private const int OperationTime = 5;

    private const int Multiplier = 2;

    public void Solve()
    {
        foreach (var item in GetFinalState(_nums, OperationTime, Multiplier))
        {
            Console.WriteLine(item);
        }
    }

    private static int[] GetFinalState(int[] nums, int k, int multiplier)
    {
        for (var i = 0; i < k; i++)
        {
            var min = nums.Min();
            var minIndex = Array.IndexOf(nums, min);

            nums[minIndex] *= multiplier;
        }
        
        return nums;
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
            // new CatAndMouseProblem()
            // new PickingNumbersProblem()
            // new PalindromeNumberProblem()
            // new LongestCommonPrefixProblem()

            //new ThreeSumProblem()

            // new IsValidProblem()
            // new RemoveDuplicatesProblem()
            //new StrStrProblem()
            // new ClimbingLeaderboardProblem()
            // new DesignerPdfViewerProblem()
            // new DivideProblem()
            // new SearchInsertProblem()
            // new IsValidSudokuProblem()
            // new SolverSudokuProblem()
            new GetFinalStateProblem()
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