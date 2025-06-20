using GeneralInformation;

namespace FileHandler
{
	public class FileProcessor
	{

		public List<List<string>> ReadFile(string fileName)
		{
			var columnsLine = new List<List<string>>();

			var lines = File.ReadAllLines(fileName);

			foreach (var line in lines.Skip(1))
			{
				var columns = line.Split(Constants.CellSeparator).ToList();

				columnsLine.Add(columns);
			}

			return columnsLine;
		}

		public void WriteFile(string fileName, List<List<string>> columnsLine)
		{
			var lines = new List<string>();

			lines.Add($"sep={Constants.CellSeparator}");

			foreach (var columns in columnsLine)
			{
				var line = string.Join(Constants.CellSeparator, columns);
				lines.Add(line);
			}

			File.WriteAllLines(fileName, lines);
		}

		public void WriteTestFile(string fileName, List<string> columnsLine)
		{
			File.WriteAllLines(fileName, columnsLine);

		}
	}
}
