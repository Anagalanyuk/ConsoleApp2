using System;
using System.Text;

namespace TitleCapitalizationTool
{
	internal  class  Program
	{
		public static void Main(string[] args)
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
			StringBuilder titleadjustment = new StringBuilder();
			arraytitle[0] = char.ToUpper(arraytitle[0][0]).ToString() + arraytitle[0].Remove(0, 1);
			arraytitle[arraytitle.Length - 1] = char.ToUpper(arraytitle[arraytitle.Length - 1][0]).ToString() + arraytitle[arraytitle.Length - 1].Remove(0, 1);
			string[] exception = { "a", "an", "and" , "at", "but" , "by" , "for", "in","nor", "of", "on", "or", "out", "so" , "the" , "to" , "up" , "yet", };
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
							break;
						}
					}
					if (result)
					{
						arraytitle[i] = char.ToUpper(arraytitle[i][0]).ToString() + arraytitle[i].Remove(0, 1);
					}
					titleadjustment.Append(arraytitle[i]);
					titleadjustment.Append(' ');
				}
			}
			StringBuilder newtitle = new StringBuilder();
			for (int i = 0, j = 0; i < titleadjustment.Length; ++i, ++j)
			{
				if (titleadjustment[i] == ',' && titleadjustment[i - 1] == ' ' || titleadjustment[i] == ':' && titleadjustment[i - 1] == ' ' || titleadjustment[i] == ';' && titleadjustment[i - 1] == ' ' ||
					titleadjustment[i] == '?' && titleadjustment[i - 1] == ' ' || titleadjustment[i] == '.' && titleadjustment[i - 1] == ' ' || titleadjustment[i] == '!' && titleadjustment[i - 1] == ' ')
				{
					--j;
					titleadjustment.Length += 1;
				}
				titleadjustment[j] = titleadjustment[i];
			}
			for (int i = 0; i < titleadjustment.Length; ++i)
			{
				if (titleadjustment[i] == ',' && titleadjustment[i + 1] != ' ' || titleadjustment[i] == ':' && titleadjustment[i + 1] != ' ' || titleadjustment[i] == ';' && titleadjustment[i + 1] != ' ' ||
					 titleadjustment[i] == '?' && titleadjustment[i + 1] != ' ' || titleadjustment[i] == '.' && titleadjustment[i + 1] != ' ' || titleadjustment[i] == '!' && titleadjustment[i + 1] != ' ' && titleadjustment[i + 1] != '!')
				{
					newtitle.Append(titleadjustment[i]);
					newtitle.Append(' ');
				}
				else if (titleadjustment[i] == '-' && titleadjustment[i - 1] != ' ')
				{
					newtitle.Append(' ');
					newtitle.Append('-');
					newtitle.Append(' ');
					titleadjustment[i + 1] = char.ToUpper(titleadjustment[i + 1]);
				}
				else
				{
					newtitle.Append(titleadjustment[i]);
				}
			}
			Console.WriteLine(newtitle);
			Console.ResetColor();
		}
	}
}