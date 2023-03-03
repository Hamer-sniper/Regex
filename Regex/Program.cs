using System.Text.RegularExpressions;

string s = "Пхвердов";

//Regex regex = new Regex(@"^А-Г, П");
Regex regex = new Regex(@"^[А-Г, П]\w*");

//string s = "Бык тупогуб, тупогубенький бычок, у быка губа бела была ступа";
//Regex regex = new Regex(@"туп(\w*)");


MatchCollection matches = regex.Matches(s);
if (matches.Count > 0)
{
    foreach (Match match in matches)
        Console.WriteLine(match.Value);
}
else
{
    Console.WriteLine("Совпадений не найдено");
}
Console.ReadKey();