namespace FileHandler.Interfaces
{
	public interface IFileProcessor
	{
		Task<List<List<string>>> ReadFileAsync(string fileName);

		Task WriteFileAsync(string fileName, List<List<string>> data, bool includeHeader = true);
	}
}
