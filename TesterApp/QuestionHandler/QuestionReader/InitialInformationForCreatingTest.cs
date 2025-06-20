using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public class InitialInformationForCreatingTest
	{
		public List<QuestionBase> AllQuestions { get; set; }

		public int QuestionsNumberPerTest { get; set; }

		public InitialInformationForCreatingTest()
		{
			AllQuestions = new List<QuestionBase>();
		}
	}
}
