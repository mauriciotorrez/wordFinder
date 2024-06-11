// See https://aka.ms/new-console-template for more information
using ConsoleApp3;

Console.WriteLine("Hello, World!");
List<string> matrix = new List<string>();
matrix.Add("abcdc");
matrix.Add("fgwio");
matrix.Add("chill");
matrix.Add("pqnsd");
matrix.Add("uvdxy");
matrix.Add("zzdxy");

var wordFinder = new WordFinder(matrix);

var words = new List<string>();
words.Add("cold");
words.Add("wind");
words.Add("snow");
words.Add("chill");

var result = wordFinder.Find(words);

Console.WriteLine("Hello1, World1!");
