using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TitleCapitalizationTool
{
	class Program
	{
		static void Main(string[] args)
		{
			string ToCapitalize = "Enter title to capitalize: ";
			Console.Write(ToCapitalize);
			Console.ForegroundColor = ConsoleColor.Red;
			char FirstSymbol = ' ';
			while (FirstSymbol == ' ' || FirstSymbol == '\r')
			{
				FirstSymbol = Console.ReadKey().KeyChar;
				if (FirstSymbol == '\r')
				{
					Console.SetCursorPosition(27, 0);
				}
				else
				{
					Console.Write('\b');
				}
			}
			string Title = FirstSymbol.ToString();
			Console.Write(FirstSymbol);
			Title += Console.ReadLine();
			Console.ForegroundColor = ConsoleColor.Gray;
			string CapitalizedTitle = "Capitalized title: ";
			Console.Write(CapitalizedTitle);
			Console.ForegroundColor = ConsoleColor.Green;
			Title = Title.Trim();
			Title = Title.ToLower();
			string[] ArrayTitle = Title.Split(' ');
			StringBuilder Temp = new StringBuilder();
			ArrayTitle[0] = char.ToUpper(ArrayTitle[0][0]).ToString() + ArrayTitle[0].Remove(0, 1);
			ArrayTitle[ArrayTitle.Length - 1] = char.ToUpper(ArrayTitle[ArrayTitle.Length - 1][0]).ToString() + ArrayTitle[ArrayTitle.Length - 1].Remove(0, 1); ;
			string[] exception = { "a", "an", "the", "and", "but", "for", "nor", "so", "yet", "at", "by", "in", "of", "on", "or", "out", "to", "up" };
			bool result;
			for (int i = 0; i < ArrayTitle.Length; ++i)
			{
				result = true;
				if (ArrayTitle[i] != "")
				{
					for (int j = 0; j < exception.Length - 1; ++j)
					{
						if (ArrayTitle[i] == exception[j])
						{
							result = false;
							j = exception.Length - 1;
						}
					}
					if (result == true)
					{
						ArrayTitle[i] = char.ToUpper(ArrayTitle[i][0]).ToString() + ArrayTitle[i].Remove(0, 1);
					}
					Temp.Append(ArrayTitle[i]);
					Temp.Append(' ');
				}
			}
			StringBuilder NewTitle = new StringBuilder();
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
					NewTitle.Append(Temp[i]);
					NewTitle.Append(' ');
				}
				else if (Temp[i] == '-' && Temp[i - 1] != ' ')
				{
					NewTitle.Append(' ');
					NewTitle.Append('-');
					NewTitle.Append(' ');
					Temp[i + 1] = char.ToUpper(Temp[i + 1]);
				}
				else
				{
					NewTitle.Append(Temp[i]);
				}
			}
			Console.WriteLine(NewTitle);
			Console.ResetColor();
		}
	}
}
