var input = await File.ReadAllLinesAsync("input.txt");

var sum = 0;

foreach (var line in input)
    sum += GetNumber(line);

Console.WriteLine(sum);

static int GetNumber(string line)
{
    var enumerator = DigitRegex.EnumerateMatches(line);

    if (!enumerator.MoveNext())
        return 0;

    var first = (int)char.GetNumericValue(line[enumerator.Current.Index]);

    int lastIndex = enumerator.Current.Index;
    while (enumerator.MoveNext())
        lastIndex = enumerator.Current.Index;

    var last = (int)char.GetNumericValue(line[lastIndex]);

    var number = first * 10 + last;
    return number;
}

partial class Program
{
    public static readonly Regex DigitRegex = GeneratedDigitRegex();

    [GeneratedRegex(@"\d")]
    private static partial Regex GeneratedDigitRegex();
}
