var input = await File.ReadAllLinesAsync("input.txt");
var words = new string[]
    {
        "one",
        "two",
        "three",
        "four",
        "five",
        "six",
        "seven",
        "eight",
        "nine",
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9"
    };

var sum = 0;

foreach (var line in input)
    sum += GetNumber(line);

Console.WriteLine(sum);

int GetNumber(string line)
{
    (int Index, string Word)? firstMatch = null;
    (int Index, string Word)? lastMatch = null;
    foreach (var word in words)
    {
        var first = line.IndexOf(word);
        var last = line.LastIndexOf(word);

        if (first != -1 && (firstMatch is null || first < firstMatch.Value.Index))
            firstMatch = (first, word);

        if (last != -1 && (lastMatch is null || last > lastMatch.Value.Index))
            lastMatch = (last, word);
    }

    if (firstMatch is null || lastMatch is null) return 0;

    var firstNumber = ConvertWordToDigit(firstMatch.Value.Word);
    var lastNumber = ConvertWordToDigit(lastMatch.Value.Word);

    return firstNumber * 10 + lastNumber;
}

static int ConvertWordToDigit(ReadOnlySpan<char> word) => word switch
{
    "one" => 1,
    "two" => 2,
    "three" => 3,
    "four" => 4,
    "five" => 5,
    "six" => 6,
    "seven" => 7,
    "eight" => 8,
    "nine" => 9,
    "1" => 1,
    "2" => 2,
    "3" => 3,
    "4" => 4,
    "5" => 5,
    "6" => 6,
    "7" => 7,
    "8" => 8,
    "9" => 9,
    _ => throw new NotImplementedException()
};
