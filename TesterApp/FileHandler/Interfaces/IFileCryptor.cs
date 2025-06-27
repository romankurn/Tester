namespace FileHandler.Interfaces
{
	public interface IFileCryptor
	{
		Task EncryptDataFromExistingFileAsync(string sourceFile, string targetFile);

		Task EncryptNewDataAsync(string targetFile, List<List<string>> data);

		Task<List<List<string>>> DecryptFileAsync(string sourceFile);
	}
}
