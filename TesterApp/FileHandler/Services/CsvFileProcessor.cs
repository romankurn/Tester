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
				var lines = await File.ReadAllLinesAsync(fileName);
				return lines
					.Skip(1)
					.Select(line => line.Split(new[] { _separator }, StringSplitOptions.None).ToList())
					.ToList();
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				throw new FileHandlerException($"Failed to read file {fileName}", ex);
			}
		}

		public async Task WriteFileAsync(string fileName, List<List<string>> data, bool includeHeader = true)
		{
			try
			{
				var lines = new List<string>();
				if (includeHeader)
					lines.Add($"sep={_separator}");

				lines.AddRange(data.Select(columns => string.Join(_separator, columns)));
				await File.WriteAllLinesAsync(fileName, lines);
			}
			catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
			{
				throw new FileHandlerException($"Failed to write file {fileName}", ex);
			}
		}
	}
}
