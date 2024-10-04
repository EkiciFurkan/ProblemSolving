namespace ProblemSolving;

public interface IProblem
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
    private readonly List<int> _s = [1, 2, 1, 3, 2];

    private const int D = 3;

    private const int M = 2;


    public void Solve()
    {
        Console.WriteLine(Birthday(_s, D, M));
    }

    private static int Birthday(List<int> s, int d, int m)
    {
        var count = 0;

        for (var i = 0; i < s.Count - m; i++)
        {
            if (s.Skip(i).Take(m).Sum() == d)
            {
                count++;
            }
        }

        return count;

        // There is another alternative; I'm not using it because this code isn't mine :)
        // return Enumerable.Range(0, s.Count - m + 1)
        //     .Count(i => s.Skip(i).Take(m).Sum() == d);
    }
}

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
    
    private static int[] TwoSum(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }

        }
        
        return [];
    }
}

internal abstract class Program
{
    private static void Main()
    {
        var problems = new List<IProblem>
        {
            //new AlmostIncreasingSequenceProblem()
            //   new BirthdayProblem()
            new TwoSumProblem()
        };

        foreach (var problem in problems)
        {
            problem.Solve();
        }
    }
}