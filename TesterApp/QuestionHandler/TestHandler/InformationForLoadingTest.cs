using QuestionHandler.QuestionsModels;

namespace QuestionHandler.TestHandler
{
	public class InformationForLoadingTest
	{
		public string StudentName { get; set; }

		public bool TestCanBeContinued { get; set; }

		public int RemainingTime { get; set; }

		public double UserPoints { get; set; }

		public int MaximumPoints { get; set; }

		public Dictionary<int, QuestionBase> Questions { get; set; }
	}
}
