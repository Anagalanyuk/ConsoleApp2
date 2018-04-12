using System;
using System.Text;

namespace TitleCapitalizationTool
{
	class  Program
	{
		static void Main(string[] args)
		{
			string toсapitalize = "Enter title to capitalize: ";
			Console.Write(toсapitalize);
			Console.ForegroundColor = ConsoleColor.Red;
			char firstsymbol = ' ';
			while (firstsymbol == ' ' || firstsymbol == '\r')
			{
				firstsymbol = Console.ReadKey().KeyChar;
				if (firstsymbol == '\r')
				{
					Console.SetCursorPosition(27, 0);
				}
				else
				{
					Console.Write('\b');
				}
			}
			string title = firstsymbol.ToString();
			Console.Write(firstsymbol);
			title += Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			string capitalizedtitle = "Capitalized title: ";
			Console.Write(capitalizedtitle);
			Console.ForegroundColor = ConsoleColor.Green;
			title = title.Trim();
			title = title.ToLower();
			string[] arraytitle = title.Split(' ');
			StringBuilder Temp = new StringBuilder();
			arraytitle[0] = char.ToUpper(arraytitle[0][0]).ToString() + arraytitle[0].Remove(0, 1);
			arraytitle[arraytitle.Length - 1] = char.ToUpper(arraytitle[arraytitle.Length - 1][0]).ToString() + arraytitle[arraytitle.Length - 1].Remove(0, 1); ;
			string[] exception = { "a", "an", "the", "and", "but", "for", "nor", "so", "yet", "at", "by", "in", "of", "on", "or", "out", "to", "up" };
			bool result;
			for (int i = 0; i < arraytitle.Length; ++i)
			{
				result = true;
				if (arraytitle[i] != "")
				{
					for (int j = 0; j < exception.Length - 1; ++j)
					{
						if (arraytitle[i] == exception[j])
						{
							result = false;
							j = exception.Length - 1;
						}
					}
					if (result == true)
					{
						arraytitle[i] = char.ToUpper(arraytitle[i][0]).ToString() + arraytitle[i].Remove(0, 1);
					}
					Temp.Append(arraytitle[i]);
					Temp.Append(' ');
				}
			}
			StringBuilder newtitle = new StringBuilder();
			for (int i = 0, j = 0; i < Temp.Length; ++i, ++j)
			{
				if (Temp[i] == ',' && Temp[i - 1] == ' ' || Temp[i] == ':' && Temp[i - 1] == ' ' || Temp[i] == ';' && Temp[i - 1] == ' ' ||
					Temp[i] == '?' && Temp[i - 1] == ' ' || Temp[i] == '.' && Temp[i - 1] == ' ' || Temp[i] == '!' && Temp[i - 1] == ' ')
				{
					--j;
					Temp.Length += 1;
				}
				Temp[j] = Temp[i];
			}
			for (int i = 0; i < Temp.Length; ++i)
			{
				if (Temp[i] == ',' && Temp[i + 1] != ' ' || Temp[i] == ':' && Temp[i + 1] != ' ' || Temp[i] == ';' && Temp[i + 1] != ' ' ||
					 Temp[i] == '?' && Temp[i + 1] != ' ' || Temp[i] == '.' && Temp[i + 1] != ' ' || Temp[i] == '!' && Temp[i + 1] != ' ' && Temp[i + 1] != '!')
				{
					newtitle.Append(Temp[i]);
					newtitle.Append(' ');
				}
				else if (Temp[i] == '-' && Temp[i - 1] != ' ')
				{
					newtitle.Append(' ');
					newtitle.Append('-');
					newtitle.Append(' ');
					Temp[i + 1] = char.ToUpper(Temp[i + 1]);
				}
				else
				{
					newtitle.Append(Temp[i]);
				}
			}
			Console.WriteLine(newtitle);
			Console.ResetColor();
		}
	}
}
