using FileHandler.Interfaces;

namespace FileHandler.Services
{
	public class FileCryptor : IFileCryptor, IDisposable
	{
		private readonly IFileProcessor _fileProcessor;
		private readonly ICryptor _cryptor;

		public FileCryptor(ICryptor cryptor, IFileProcessor fileProcessor)
		{
			_cryptor = cryptor ?? throw new ArgumentNullException(nameof(cryptor));
			_fileProcessor = fileProcessor ?? throw new ArgumentNullException(nameof(fileProcessor));
		}

		public async Task EncryptDataFromExistingFileAsync(string sourceFile, string targetFile)
		{
			var data = await _fileProcessor.ReadFileAsync(sourceFile);

			var encryptedData = (await _cryptor.EncryptAsync(data.SelectMany(x => x))).ToList();

			await _fileProcessor.WriteFileAsync(targetFile, encryptedData.Select(x => new List<string> { x }).ToList());
		}

		public async Task EncryptNewDataAsync(string targetFile, List<List<string>> data)
		{
			var encryptedData = (await _cryptor.EncryptAsync(data.SelectMany(x => x))).ToList();
			await _fileProcessor.WriteFileAsync(targetFile, encryptedData.Select(x => new List<string> { x }).ToList());
		}


		public async Task<List<List<string>>> DecryptFileAsync(string sourceFile)
		{
			var encryptedData = await _fileProcessor.ReadFileAsync(sourceFile);

			return (await _cryptor.DecryptAsync(encryptedData.SelectMany(x => x)))
				.Select(x => new List<string> { x })
				.ToList();
		}

		public void Dispose() => (_cryptor as IDisposable)?.Dispose();
	}
}
