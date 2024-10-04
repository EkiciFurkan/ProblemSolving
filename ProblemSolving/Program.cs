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

// For Test
public class TwoSumProblem : IProblem
{
    private readonly int[] _s = [2, 7, 11, 15];

    private const int D = 9;


    public void Solve()
    {
        var result = TwoSum(_s, D);
        foreach (var num in result)
        {
            Console.WriteLine(num);
        }
    }

    // Some Test
    private static int[] TwoSum(int[] nums, int target)
    {
        // for (var i = 0; i < nums.Length; i++)
        // {
        //     for (var j = i + 1; j < nums.Length; j++)
        //     {
        //         if (nums[i] + nums[j] == target)
        //         {
        //             return [i, j];
        //         }
        //     }
        //
        // }
        //
        // return [];

        var map = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var complement = target - nums[i];
            if (map.TryGetValue(complement, out var value))
            {
                return [value, i];
            }

            map[nums[i]] = i;
        }

        return [];
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