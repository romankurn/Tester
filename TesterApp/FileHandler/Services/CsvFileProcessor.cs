using FileHandler.Exceptions;
using FileHandler.Interfaces;

namespace FileHandler.Services
{
	public class CsvFileProcessor : IFileProcessor
	{
		private readonly string _separator;

		public CsvFileProcessor(string separator)
		{
			_separator = separator ?? throw new ArgumentNullException(nameof(separator));
		}

		public async Task<List<List<string>>> ReadFileAsync(string fileName)
		{
			if (!File.Exists(fileName))
				throw new FileNotFoundException($"File not found: {fileName}");

			try
			{
				var columnsLine = new List<List<string>>();

				var lines = await File.ReadAllLinesAsync(fileName);

				foreach (var line in lines.Skip(1))
				{
					var columns = line.Split(_separator).ToList();

					columnsLine.Add(columns);
				}

				return columnsLine;
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				throw new IOException($"Failed to read file {fileName}", ex);
			}
		}

		public async Task WriteFileAsync(string fileName, List<List<string>> columnsLine)
		{
			try
			{
				var lines = new List<string>();

				lines.Add($"sep={_separator}");

				foreach (var columns in columnsLine)
				{
					var line = string.Join(_separator, columns);
					lines.Add(line);
				}

				await File.WriteAllLinesAsync(fileName, lines);
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				throw new FileHandlerException($"Failed to write file {fileName}", ex);
			}
		}

	}
}
