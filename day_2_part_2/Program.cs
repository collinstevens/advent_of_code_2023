var input = await File.ReadAllLinesAsync("input.txt");

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

    List<int> reds = [];
    List<int> greens = [];
    List<int> blues = [];

    foreach (var game in games)
    {
        var redMatch = RedRegex.Match(game);
        if (redMatch.Success)
            reds.Add(int.Parse(redMatch.Groups[1].Value));

        var greenMatch = GreenRegex.Match(game);
        if (greenMatch.Success)
            greens.Add(int.Parse(greenMatch.Groups[1].Value));

        var blueMatch = BlueRegex.Match(game);
        if (blueMatch.Success)
            blues.Add(int.Parse(blueMatch.Groups[1].Value));
    }

    var red = reds.Max();
    var green = greens.Max();
    var blue = blues.Max();
    var power = red * green * blue;
    return power;
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
