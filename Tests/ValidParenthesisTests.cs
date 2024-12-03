namespace Tests;

public class ValidParenthesisTests
{
    // Read: https://leetcode.com/problems/valid-parentheses/description/
    [Theory]
    [InlineData("", true)]
    [InlineData("()", true)]
    [InlineData("(())", true)]
    [InlineData("(()(()))", true)]
    [InlineData("()[()]", true)]
    [InlineData("{}", true)]
    [InlineData("({[]({[]})})()[]{}", true)]
    [InlineData("[]", true)]
    [InlineData("(", false)]
    [InlineData(")", false)]
    [InlineData("())", false)]
    [InlineData("[(", false)]
    [InlineData("[)", false)]
    [InlineData("(])", false)]
    public void Test(string input, bool expected) =>
        Assert.Equal(expected, IsValid(input));

    private bool IsValid(string input)
    {
        var pairs = new Dictionary<char, char>
        {
            ['('] = ')',
            ['['] = ']',
            ['{'] = '}'
        };

        var expected = new Stack<char>();
        
        // O(n)
        foreach (var chr in input)
        {
            if (pairs.TryGetValue(chr, out var endChr))
            {
                expected.Push(endChr);
                continue;
            }

            if (!expected.Any() || chr != expected.Pop())
                return false;
        }

        return !expected.Any();
    }
}