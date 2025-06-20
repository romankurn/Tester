using QH = QuestionHandler.QuestionsHolder.QuestionsHolder;

namespace QuestionHandler.TestHandler
{
	public class InformationForSavingTest
	{
		public string StudentName { get; set; }

		public bool TestCanBeContinued { get; set; }

		public int StudentResult { get; set; }

		public int RemainingTime { get; set; }

		public QH QuestionsHolder { get; set; }
	}
}
