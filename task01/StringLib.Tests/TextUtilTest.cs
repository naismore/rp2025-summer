using System.Runtime.InteropServices;

using StringLib;

namespace StringLib.Tests;

public class TextUtilTest
{
    [Theory]
    [MemberData(nameof(SplitIntoWordParams))]
    public void Can_split_into_words(string input, string[] expected)
    {
        List<string> result = TextUtil.SplitIntoWords(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [MemberData(nameof(ReverseWordOrderParams))]
    public void Can_reverse_word_order(string input, string expected)
    {
        string result = TextUtil.ReverseWordOrder(input);
        Assert.Equal(expected, result);
    }

    public static TheoryData<string, string[]> SplitIntoWordParams()
    {
        return new TheoryData<string, string[]>
        {
            // Апостроф считается частью слова
            { "Can't do that", ["Can't", "do", "that"] },

            // Буква "Ё" считается частью слова
            { "Ёжик в тумане", ["Ёжик", "в", "тумане"] },
            { "Уж замуж невтерпёж", ["Уж", "замуж", "невтерпёж"] },

            // Дефис в середине считается частью слова
            { "Что-нибудь хорошее", ["Что-нибудь", "хорошее"] },
            { "mother-in-law's", ["mother-in-law's"] },
            { "up-to-date", ["up-to-date"] },
            { "Привет-пока", ["Привет-пока"] },

            // Слова из одной буквы допускаются
            { "Ну и о чём речь?", ["Ну", "и", "о", "чём", "речь"] },

            // Смена регистра не мешает разделению на слова
            { "HeLLo WoRLd", ["HeLLo", "WoRLd"] },
            { "UpperCamelCase or lowerCamelCase?", ["UpperCamelCase", "or", "lowerCamelCase"] },

            // Цифры не считаются частью слова
            { "word123", ["word"] },
            { "123word", ["word"] },
            { "word123abc", ["word", "abc"] },

            // Знаки препинания не считаются частью слова
            { "C# is awesome", ["C", "is", "awesome"] },
            { "Hello, мир!", ["Hello", "мир"] },
            { "Много   пробелов", ["Много", "пробелов"] },

            // Пустые строки, пробелы, знаки препинания
            { null!, [] },
            { "", [] },
            { "   \t\n", [] },
            { "!@#$%^&*() 12345", [] },
            { "\"", [] },

            // Пограничные случаи с апострофами и дефисами
            { "-привет", ["привет"] },
            { "привет-", ["привет"] },
            { "'hello", ["hello"] },
            { "hello'", ["hello"] },
            { "--привет--", ["привет"] },
            { "''hello''", ["hello"] },
            { "'a-b'", ["a-b"] },
            { "--", [] },
            { "'", [] },
        };
    }

    public static TheoryData<string, string> ReverseWordOrderParams()
    {
        return new TheoryData<string, string>
        {
            // Пустая строка
            { "", "" },

            // Одно слово на русском и английском
            { "Hello", "Hello" },
            { "Привет", "Привет" },

            // Несколько слов на русском и английском
            { "The quick brown fox jumps over the lazy dog.", "dog lazy the over jumps fox brown quick The" },
            { "Съешь же ещё этих мягких французских булок, да выпей чаю.", "чаю выпей да булок французских мягких этих ещё же Съешь" },

            // Слова с апострофами и дефисами
            { "Can't — это одно word", "word one это Can't" },
            { "Какой-нибудь — это одно слово", "слово одно это Какой-нибудь" },

            // Обработка знаков препинания
            { "зелёный,чёрный", "чёрный зелёный" },
            { "punctuation before the end.", "end the before punctuation" },

            // Несколько знаков препинания
            { "mixed with other words!?;", "words other with mixed" },

            // Сохранение регистра
            { "the Quick Brown Fox jumps over THE LAZY DOG", "DOG LAZY THE over jumps Fox Brown Quick the" },

            // Краевые случаи

            // Пробелы в начале и конце строки
            { "  word  ", "word" },
            { "  one two  ", "two one" },

            // Несколько пробелов между словами
            { "one  two   three", "three two one" },

            // Строка только из пробелов и знаков препинания
            { "   ,, ... !!  ", "" },

            // Эмодзи
            { "😊 word", "word 😊" },
        };
    }
}