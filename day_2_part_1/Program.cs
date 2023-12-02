var input = await File.ReadAllLinesAsync("input.txt");
var MAX_RED = 12;
var MAX_GREEN = 13;
var MAX_BLUE = 14;

var sum = 0;

foreach (var line in input)
    sum += ParseGame(line);

Console.WriteLine(sum);

int ParseGame(string line)
{
    //Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
    var parts = line.Split(": ");
    var id = int.Parse(parts[0].Substring(4));
    var games = parts[1].Split("; ");

    foreach (var game in games)
    {
        var redMatch = RedRegex.Match(game);
        if (redMatch.Success && int.Parse(redMatch.Groups[1].Value) > MAX_RED)
            return 0;

        var greenMatch = GreenRegex.Match(game);
        if (greenMatch.Success && int.Parse(greenMatch.Groups[1].Value) > MAX_GREEN)
            return 0;

        var blueMatch = BlueRegex.Match(game);
        if (blueMatch.Success && int.Parse(blueMatch.Groups[1].Value) > MAX_BLUE)
            return 0;
    }

    return id;
}

partial class Program
{
    public static readonly Regex GameIdRegex = GeneratedGameIdRegex();

    public static readonly Regex RedRegex = GeneratedRedRegex();

    public static readonly Regex GreenRegex = GeneratedGreenRegex();

    public static readonly Regex BlueRegex = GeneratedBlueRegex();

    [GeneratedRegex(@"Game (\d+)")]
    private static partial Regex GeneratedGameIdRegex();

    [GeneratedRegex(@"(\d+) red")]
    private static partial Regex GeneratedRedRegex();

    [GeneratedRegex(@"(\d+) green")]
    private static partial Regex GeneratedGreenRegex();

    [GeneratedRegex(@"(\d+) blue")]
    private static partial Regex GeneratedBlueRegex();
}
