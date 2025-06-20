using FileHandler;

namespace GeneralInformation.Info
{
	public class Config
	{
		private readonly string _configFileName = "CE7DCC30-47B9-4DF5-A92F-8F1BDC77273C.csv";

		private FileCryptor _fileCryptor;

		public InitialInformation InitialInformation { get; }

		public Config()
		{
			_fileCryptor = new FileCryptor();
			InitialInformation = GetConfiguration();
		}

		private InitialInformation GetConfiguration()
		{
			var initialInformation = new InitialInformation();

			var info = _fileCryptor.DecryptFile(_configFileName);

			initialInformation.LectureNumber = info[0][0];

			initialInformation.TestTime = int.Parse(info[1][0]);

			initialInformation.FilesInfo = new Dictionary<Filenames, QuestionTypes>();

			foreach (var line in info.Skip(2))
			{
				var questionType = (QuestionTypes)Enum.Parse(typeof(QuestionTypes), line[0]);

				var filenames = new Filenames { FileName = line[1], CryptedFileName = line[2] };

				initialInformation.FilesInfo.Add(filenames, questionType);
			}

			return initialInformation;
		}
	}
}
