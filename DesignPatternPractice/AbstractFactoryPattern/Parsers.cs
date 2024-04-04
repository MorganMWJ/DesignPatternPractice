namespace DesignPatternPractice.AbstractFactoryPattern;

internal interface IParser
{
    string Parse(string input);
}

internal class SnakeCaseParser : IParser
{
    public string Parse(string input)
    {
        var words = input.Split(' ');
        return string.Join('_', words);
    }
}

internal class PascalCaseParser : IParser
{
    public string Parse(string input)
    {
        var words = input.Split(' ');
        return string.Join('_', words.Select(word => Capitalise(word)));
    }

    private string Capitalise(string? word)
    {
        if (string.IsNullOrEmpty(word)) return "";

        return string.Concat(word.Take(1).ToString().ToUpper(), word.Skip(1));
    }
}
