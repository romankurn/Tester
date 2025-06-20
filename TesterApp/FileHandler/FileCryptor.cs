namespace FileHandler
{
	public class FileCryptor
	{
		private FileProcessor _fileProcessor;
		private Cryptor _cryptor;

		public FileCryptor()
		{
			_fileProcessor = new FileProcessor();
			_cryptor = new Cryptor();
		}

		public void EncryptFile(string fileName, string encryptFileName)
		{
			var columnLines = _fileProcessor.ReadFile(fileName);

			var encodeColumnLines = new List<List<string>>();

			foreach (var line in columnLines)
			{
				var encodeLine = _cryptor.Encrypt(line);
				encodeColumnLines.Add(encodeLine.ToList());
			}

			_fileProcessor.WriteFile(encryptFileName, encodeColumnLines);
		}

		public void EncryptTestFile(string fileName, List<List<string>> testInformation)
		{
			var encodeColumnLines = new List<List<string>>();

			foreach (var line in testInformation)
			{
				var encodeLine = _cryptor.Encrypt(line);
				encodeColumnLines.Add(encodeLine.ToList());
			}

			_fileProcessor.WriteFile(fileName, encodeColumnLines);
		}

		public List<List<string>> DecryptFile(string encryptFileName)
		{
			var columnLines = _fileProcessor.ReadFile(encryptFileName);

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
