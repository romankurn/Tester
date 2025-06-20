using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.TestHandler
{
	public class TestHandler : ITestHandler
	{
		public InformationForLoadingTest DownloadInformation(List<List<string>> uploadedInformation)
		{
			var studentName = uploadedInformation[0][0];

			var testContinuation = ConvertTestContinuationToBool(uploadedInformation[2][0]);

			var remainingTime = int.Parse(uploadedInformation[3][0]);

			var userPoints = double.Parse(uploadedInformation[4][0]);

			var maximumPoints = int.Parse(uploadedInformation[5][0]);

			var questoinKey = 1;

			var factory = new QuestionReaderFactory();

			var questions = new Dictionary<int, QuestionBase>();

			foreach (var questionLine in uploadedInformation.Skip(6))
			{
				var questionType = Enum.Parse<QuestionTypes>(questionLine[0]);

				var questionReader = factory.GetQuestionReader(questionType);

				var question = questionReader.GetQuestion(questionLine);

				questions.Add(questoinKey++, question);
			}

			return new InformationForLoadingTest { StudentName = studentName, TestCanBeContinued = testContinuation, RemainingTime = remainingTime, UserPoints = userPoints, MaximumPoints = maximumPoints, Questions = questions };
		}

		public List<List<string>> PrepareInformationForSavingText(InformationForSavingTest info)
		{
			var infoList = new List<List<string>>();

			var studentNameLine = new List<string> { info.StudentName };

			var studentResultLine = new List<string> { info.StudentResult.ToString() };

			var testContinuationLine = new List<string> { ConvertTestContinuationToString(info.TestCanBeContinued) };

			var remainingTimeLine = new List<string> { info.RemainingTime.ToString() };

			var userPointsLine = new List<string> { info.QuestionsHolder.StudentPoints.ToString() };

			var maximumPointsLine = new List<string> { info.QuestionsHolder.MaximumPoints.ToString() };

			infoList.Add(studentNameLine);

			infoList.Add(studentResultLine);

			infoList.Add(testContinuationLine);

			infoList.Add(remainingTimeLine);

			infoList.Add(userPointsLine);

			infoList.Add(maximumPointsLine);

			foreach (var question in info.QuestionsHolder.Questions.Values)
			{
				infoList.Add(question.ConvertQuestionToList());
			}

			return infoList;
		}

		private string ConvertTestContinuationToString(bool testContinuation)
		{
			if (testContinuation == true)
				return "1";
			else
				return "0";
		}

		private bool ConvertTestContinuationToBool(string testContinuation)
		{
			if (testContinuation == "1")
				return true;
			else
				return false;
		}
	}
}
