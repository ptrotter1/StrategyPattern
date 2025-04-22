using Example02TextProcessor;

var processor = new TextProcessor();
var text = "Hello Strategy Pattern";
    
// Use different strategies
var upperCase = processor.ProcessText(text, TextProcessor.ToUpperCase);
var noSpaces = processor.ProcessText(text, TextProcessor.RemoveSpaces);
var reversed = processor.ProcessText(text, TextProcessor.ReverseText);
var disemvowel = processor.ProcessText(text, TextProcessor.Disemvowel);
var spongeBob = processor.ProcessText(text, TextProcessor.SpongeBob);
var pigLatin = processor.ProcessText(text, TextProcessor.PigLatin);

// Can also use lambda expressions as strategies
var lowerCase = processor.ProcessText(text, input => input.ToLower());

// Output results
Console.WriteLine("upperCase: " + upperCase); // Output: HELLO STRATEGY PATTERN
Console.WriteLine("noSpaces: " + noSpaces); // Output: HelloStrategyPattern
Console.WriteLine("reversed: " + reversed);
Console.WriteLine("disemvowel: " + disemvowel);
Console.WriteLine("spongeBob: " + spongeBob);
Console.WriteLine("pigLatin: " + pigLatin);
Console.WriteLine("lowerCase: " + lowerCase);