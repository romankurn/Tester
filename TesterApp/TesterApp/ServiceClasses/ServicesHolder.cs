using FileHandler;
using GeneralInformation.Info;
using QuestionHandler;
using QuestionHandler.QuestionsHolder;
using TesterApp.ServiceClasses.QuestionFormCreators;

namespace TesterApp.ServiceClasses
{
	public static class ServicesHolder
	{
		public static Config Config { get; private set; }

		public static FileCryptor FileCryptor { get; private set; }

		public static QuestionReaderFactory QuestionReaderFactory { get; private set; }

		public static TestTimer Timer { get; private set; }

		public static TestCompletionController TestCompletionController { get; private set; }

		public static QuestionsHolder QuestionsHolder { get; set; }

		public static QuestionFormCreator QuestionFormCreator { get; private set; }

		public static AnswerFileHandler AnswerFileHandler { get; private set; }

		static ServicesHolder()
		{
			Config = new Config();
			FileCryptor = new FileCryptor();
			QuestionReaderFactory = new QuestionReaderFactory();
			Timer = new TestTimer();
			TestCompletionController = new TestCompletionController();
			QuestionsHolder = new QuestionsHolder();
			QuestionFormCreator = new QuestionFormCreator();
			AnswerFileHandler = new AnswerFileHandler();
		}
	}
}
