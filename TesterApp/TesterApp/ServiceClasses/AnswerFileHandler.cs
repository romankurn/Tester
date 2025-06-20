using QuestionHandler.TestHandler;

namespace TesterApp.ServiceClasses
{
	public class AnswerFileHandler
	{
		private TestHandler _testHandler;

		public AnswerFileHandler()
		{
			_testHandler = new TestHandler();
		}

		public async Task SaveTest(string studentFio)
		{
			var informationForSavingTest = new InformationForSavingTest { QuestionsHolder = ServicesHolder.QuestionsHolder, RemainingTime = ServicesHolder.Timer.RemainingSeconds, StudentName = studentFio, StudentResult = ServicesHolder.QuestionsHolder.StudentResult, TestCanBeContinued = ServicesHolder.TestCompletionController.TestCanBeContinued };

			var testInfo = _testHandler.PrepareInformationForSavingText(informationForSavingTest);

			ServicesHolder.FileCryptor.EncryptTestFile($"Результаты теста {ServicesHolder.Config.InitialInformation.LectureNumber}.csv", testInfo);
		}

		public InformationForLoadingTest GetInformationForLoadingTest()
		{
			var testList = ServicesHolder.FileCryptor.DecryptFile($"Результаты теста {ServicesHolder.Config.InitialInformation.LectureNumber}.csv");

			var loadInfo = _testHandler.DownloadInformation(testList);

			return loadInfo;
		}
	}
}
