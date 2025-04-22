using System.Text;

namespace Example02TextProcessor;

// Using delegates instead of interfaces
public class TextProcessor
{
    // Define delegate type for text processing strategies
    public delegate string TextProcessingStrategy(string input);

    // Strategy implementations as methods or lambda expressions
    public static string ToUpperCase(string input) => input.ToUpper();
    public static string RemoveSpaces(string input) => input.Replace(" ", "");
    public static string ReverseText(string input) => new string(input.Reverse().ToArray());
    public static string Disemvowel(string input)
    {
        var vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        return new string(input.Where(c => !vowels.Contains(c)).ToArray());
    }
    public static string SpongeBob(string input)
    {
        var result = new StringBuilder();
        bool upper = false;
        foreach (char c in input)
        {
            if (char.IsLetter(c))
            {
                result.Append(upper ? char.ToUpper(c) : char.ToLower(c));
                upper = !upper;
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
    public static string PigLatin(string input)
    {
        var words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Length > 0)
            {
                char firstLetter = words[i][0];
                if (char.IsUpper(firstLetter))
                {
                    words[i] = char.ToUpper(words[i][1]) + words[i].Substring(2).ToLower() + firstLetter.ToString().ToLower() + "ay";
                }
                else 
                {
                    words[i] = words[i].Substring(1) + firstLetter + "ay";
                }
            }
        }
        return string.Join(" ", words);
    }

    // Context method that accepts a strategy
    public string ProcessText(string input, TextProcessingStrategy strategy)
    {
        return strategy(input);
    }
}