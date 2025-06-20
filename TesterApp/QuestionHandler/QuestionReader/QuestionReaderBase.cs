using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public abstract class QuestionReaderBase
	{
		protected readonly QuestionTypes _questionType;

		public QuestionReaderBase(QuestionTypes questionType)
		{
			_questionType = questionType;
		}

		public abstract QuestionBase GetQuestion(List<string> questionList);
	}
}
