using System;
using System.Text;

namespace TitleCapitalizationTool
{
	internal class Program
	{
		public static StringBuilder HeaderEditor(string title)
		{
			title = title.Trim();
			title = title.ToLower();
			string[] arrayTitle = title.Split(' ');
			StringBuilder titleAdjustment = new StringBuilder();
			arrayTitle[0] = char.ToUpper(arrayTitle[0][0]).ToString() + arrayTitle[0].Remove(0, 1);
			arrayTitle[arrayTitle.Length - 1] = char.ToUpper(arrayTitle[arrayTitle.Length - 1][0]).ToString() + arrayTitle[arrayTitle.Length - 1].Remove(0, 1);
			string[] exceptions = { "a", "an", "and", "at", "but", "by", "for", "in", "nor", "of", "on", "or", "out", "so", "the", "to", "up", "yet" };
			for (int i = 0; i < arrayTitle.Length; ++i)
			{
				bool result = true;
				if (arrayTitle[i] != "")
				{
					for (int j = 0; j < exceptions.Length - 1; ++j)
					{
						if (arrayTitle[i] == exceptions[j])
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
			char[] punctuationMarks = { ',', ':', ';', '?', '.', '!', '-' };
			StringBuilder newTitle = new StringBuilder();
			for (int i = 0; i < titleAdjustment.Length - 1; ++i)
			{
				bool addSpace = false;
				for (int j = 0; j < punctuationMarks.Length; ++j)
				{
					if (titleAdjustment[i] == ' ' && titleAdjustment[i + 1] == punctuationMarks[j])
					{
						i += 1;
					}
					if (titleAdjustment[i] == punctuationMarks[j] && titleAdjustment[i + 1] != ' ')
					{
						addSpace = true;
					}
				}
				if (titleAdjustment[i] == '-')
				{
					newTitle.Append(' ');
				}
				newTitle.Append(titleAdjustment[i]);
				if (addSpace)
				{
					newTitle.Append(' ');
					newTitle.Append(titleAdjustment[i + 1].ToString().ToUpper());
					i += 1;
				}
			}
			return newTitle;
		}

		public static void Main(string[] args)
		{
			int coordinateCursorX = 27;
			int coordinateCursorY = 0;
			if (args.Length != 0)
			{
				for (int i = 0; i < args.Length; ++i)
				{
					Console.Write("Original Title: ");
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine(args[i]);
					Console.ResetColor();
					Console.Write("Capitalized Title: ");
					Console.ForegroundColor = ConsoleColor.Green;
					Console.Write(HeaderEditor(args[0]));
					Console.WriteLine();
					Console.ResetColor();
					Console.WriteLine();
				}
			}
			else
			{
				while (true)
				{
					string toCapitalize = "Enter title to capitalize: ";
					Console.Write(toCapitalize);
					Console.ForegroundColor = ConsoleColor.Red;
					string title = Console.ReadLine();
					while (title.Length == 0)
					{
						Console.SetCursorPosition(coordinateCursorX, coordinateCursorY);
						title = Console.ReadLine();
					}
					Console.ForegroundColor = ConsoleColor.Gray;
					string capitalizedTitle = "Capitalized title: ";
					Console.Write(capitalizedTitle);
					Console.ForegroundColor = ConsoleColor.Green;

					coordinateCursorY += 3;
					Console.WriteLine(HeaderEditor(title));
					Console.ResetColor();
					Console.WriteLine();
				}
			}
		}
	}
}