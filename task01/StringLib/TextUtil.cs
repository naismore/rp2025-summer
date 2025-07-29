using System.Text.RegularExpressions;

namespace StringLib;

public static class TextUtil
{
    public static List<string> SplitIntoWords(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return [];
        }

        // Регулярное выражение для поиска слов:
        // - Слово начинается и заканчивается на букву.
        // - Может содержать апострофы и дефисы внутри.
        // - Не содержит чисел или знаков препинания.
        const string pattern = @"\p{L}+(?:[\-\']\p{L}+)*";
        Regex regex = new(pattern, RegexOptions.Compiled);

        return regex.Matches(text)
            .Select(match => match.Value)
            .ToList();
    }

    public static string ReverseWordOrder(string text)
    {
        List<string> items = SplitIntoWords(text);
        items.Reverse();
        for (int i = 0; i < items.Count; i++)
        {
            Regex regex = new(@"[\p{P}]+");
            items[i] = regex.Replace(items[i], " ");
        }

        return string.Join(" ", items).Trim();
    }
}