using System;
using System.Collections.Generic;
 
class Solution
{
    public static List<string> WrapLines(string[] words, int maxLen)
    {
        List<string> lines = new List<string>();
        string currentLine = "";
        
        foreach (var word in words)
        {
            if (currentLine.Length == 0)
            {
                currentLine = word;
            }
            else
            {
                if (currentLine.Length + 1 + word.Length <= maxLen)
                {
                    currentLine += "-" + word;
                }
                else
                {
                    lines.Add(currentLine);
                    currentLine = word;
                }
            }
        }
        if (currentLine.Length > 0)
            lines.Add(currentLine);
 
        return lines;
    }
 
    static void Main(string[] args)
    {
        string[] words1 = { "The", "day", "began", "as", "still", "as", "the", "night", "abruptly", "lighted", "with", "brilliant", "flame" };
        string[] words2 = { "Hello" };
        string[] words3 = { "Hello", "Hello" };
        string[] words4 = { "Well", "Hello", "world" };
        string[] words5 = { "Hello", "HelloWorld", "Hello", "Hello" };
        string[] words6 = { "a", "b", "c", "d" };
 
        PrintResult(WrapLines(words1, 13));
        PrintResult(WrapLines(words1, 12));
        PrintResult(WrapLines(words1, 20));
        PrintResult(WrapLines(words2, 5));
        PrintResult(WrapLines(words2, 30));
        PrintResult(WrapLines(words3, 5));
        PrintResult(WrapLines(words4, 5));
        PrintResult(WrapLines(words5, 20));
        PrintResult(WrapLines(words6, 20));
        PrintResult(WrapLines(words6, 4));
        PrintResult(WrapLines(words6, 1));
    }
 
    static void PrintResult(List<string> lines)
    {
        foreach (var line in lines)
            Console.WriteLine(line);
        Console.WriteLine();
    }
}
 