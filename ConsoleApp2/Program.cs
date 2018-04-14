using System;
using System.Text;

namespace TitleCapitalizationTool
{
	internal  class  Program
	{
		public static void Main(string[] args)
		{
			string toCapitalize = "Enter title to capitalize: ";
			Console.Write(toCapitalize);
			Console.ForegroundColor = ConsoleColor.Red;
			char firstSymbol = ' ';
			while (firstSymbol == ' ' || firstSymbol == '\r')
			{
				firstSymbol = Console.ReadKey().KeyChar;
				if (firstSymbol == '\r')
				{
					Console.SetCursorPosition(27, 0);
				}
				else
				{
					Console.Write('\b');
				}
			}
			string title = firstSymbol.ToString();
			Console.Write(firstSymbol);
			title += Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			string capitalizedTitle = "Capitalized title: ";
			Console.Write(capitalizedTitle);
			Console.ForegroundColor = ConsoleColor.Green;
			title = title.Trim();
			title = title.ToLower();
			string[] arrayTitle = title.Split(' ');
			StringBuilder titleAdjustment = new StringBuilder();
			arrayTitle[0] = char.ToUpper(arrayTitle[0][0]).ToString() + arrayTitle[0].Remove(0, 1);
			arrayTitle[arrayTitle.Length - 1] = char.ToUpper(arrayTitle[arrayTitle.Length - 1][0]).ToString() + arrayTitle[arrayTitle.Length - 1].Remove(0, 1);
			string[] exception = { "a", "an", "and" , "at", "but" , "by" , "for", "in","nor", "of", "on", "or", "out", "so" , "the" , "to" , "up" , "yet", };
			bool result;
			for (int i = 0; i < arrayTitle.Length; ++i)
			{
				result = true;
				if (arrayTitle[i] != "")
				{
					for (int j = 0; j < exception.Length - 1; ++j)
					{
						if (arrayTitle[i] == exception[j])
						{
							result = false;
							break;
						}
					}
					if (result)
					{
						arrayTitle[i] = char.ToUpper(arrayTitle[i][0]).ToString() + arrayTitle[i].Remove(0, 1);
					}
					titleAdjustment.Append(arrayTitle[i]);
					titleAdjustment.Append(' ');
				}
			}
			StringBuilder newTitle = new StringBuilder();
			for (int i = 0, j = 0; i < titleAdjustment.Length; ++i, ++j)
			{
				if (titleAdjustment[i] == ',' && titleAdjustment[i - 1] == ' ' || titleAdjustment[i] == ':' && titleAdjustment[i - 1] == ' ' || titleAdjustment[i] == ';' && titleAdjustment[i - 1] == ' ' ||
					titleAdjustment[i] == '?' && titleAdjustment[i - 1] == ' ' || titleAdjustment[i] == '.' && titleAdjustment[i - 1] == ' ' || titleAdjustment[i] == '!' && titleAdjustment[i - 1] == ' ')
				{
					--j;
					titleAdjustment.Length += 1;
				}
				titleAdjustment[j] = titleAdjustment[i];
			}
			for (int i = 0; i < titleAdjustment.Length; ++i)
			{
				if (titleAdjustment[i] == ',' && titleAdjustment[i + 1] != ' ' || titleAdjustment[i] == ':' && titleAdjustment[i + 1] != ' ' || titleAdjustment[i] == ';' && titleAdjustment[i + 1] != ' ' ||
					 titleAdjustment[i] == '?' && titleAdjustment[i + 1] != ' ' || titleAdjustment[i] == '.' && titleAdjustment[i + 1] != ' ' || titleAdjustment[i] == '!' && titleAdjustment[i + 1] != ' ' && titleAdjustment[i + 1] != '!')
				{
					newTitle.Append(titleAdjustment[i]);
					newTitle.Append(' ');
				}
				else if (titleAdjustment[i] == '-' && titleAdjustment[i - 1] != ' ')
				{
					newTitle.Append(" - ");
					titleAdjustment[i + 1] = char.ToUpper(titleAdjustment[i + 1]);
				}
				else
				{
					newTitle.Append(titleAdjustment[i]);
				}
			}
			Console.WriteLine(newTitle);
			Console.ResetColor();
		}
	}
}