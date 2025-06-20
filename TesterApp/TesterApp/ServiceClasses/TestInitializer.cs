using QuestionHandler.QuestionReader;
using QuestionHandler.TestHandler;

namespace TesterApp.ServiceClasses
{
	public class TestInitializer
	{
		public InformationForLoadingTest InformationForLoadingTest { get; set; }

		public TestInitializer()
		{
			InformationForLoadingTest = new InformationForLoadingTest();
		}

		public TestInitializer(InformationForLoadingTest informationForLoadingTest)
		{
			InformationForLoadingTest = informationForLoadingTest;
		}

		public async Task InitializeTest()
		{
			foreach (var questionInfo in ServicesHolder.Config.InitialInformation.FilesInfo)
			{
				var initialInformationForCreatingTest = new InitialInformationForCreatingTest();

				var questionType = questionInfo.Value;

				var fileName = questionInfo.Key;

				var questionReader = ServicesHolder.QuestionReaderFactory.GetQuestionReader(questionType);

				var questionsLines = ServicesHolder.FileCryptor.DecryptFile(fileName.CryptedFileName);

				initialInformationForCreatingTest.QuestionsNumberPerTest = int.Parse(questionsLines[0][0]);

				foreach (var line in questionsLines.Skip(1))
				{
					var question = questionReader.GetQuestion(line);

					initialInformationForCreatingTest.AllQuestions.Add(question);
				}

				ServicesHolder.QuestionsHolder.CreateTest(initialInformationForCreatingTest);
			}
		}
	}
}
