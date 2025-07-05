using FileHandler.Interfaces;

namespace FileHandler.Services
{
	public class FileCryptor : IFileCryptor
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
			var columnLines = await _fileProcessor.ReadFileAsync(sourceFile);

			var encryptedColumnLines = new List<List<string>>();

			foreach (var line in columnLines)
			{
				var encodeLine = _cryptor.Encrypt(line);
				encryptedColumnLines.Add(encodeLine.ToList());
			}

			await _fileProcessor.WriteFileAsync(targetFile, encryptedColumnLines);
		}

		public async Task EncryptNewDataAsync(string targetFile, List<List<string>> data)
		{
			var encryptColumnLines = new List<List<string>>();

			foreach (var line in data)
			{
				var encryptLine = _cryptor.Encrypt(line);
				encryptColumnLines.Add(encryptLine.ToList());
			}

			await _fileProcessor.WriteFileAsync(targetFile, encryptColumnLines);
		}

		public async Task<List<List<string>>> DecryptFileAsync(string sourceFile)
		{

			var columnLines = await _fileProcessor.ReadFileAsync(sourceFile);

			var encryptColumnLines = new List<List<string>>();

			foreach (var line in columnLines)
			{
				var encodeLine = _cryptor.Decrypt(line);
				encryptColumnLines.Add(encodeLine.ToList());
			}

			return encryptColumnLines;
		}
	}
}
