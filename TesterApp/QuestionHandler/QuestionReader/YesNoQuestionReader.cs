using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public class YesNoQuestionReader : QuestionReaderBase
	{
		public YesNoQuestionReader() : base(QuestionTypes.YesNoQuestion)
		{
		}

		public override QuestionBase GetQuestion(List<string> questionList)
		{
			var questionText = questionList[1];

			var rightAnswer = int.Parse(questionList[2]);

			if (questionList.Count == 4)
			{
				var userAnswer = int.Parse(questionList[3]);

				return new YesNoQuestion(_questionType, questionText, rightAnswer, userAnswer);
			}

			return new YesNoQuestion(_questionType, questionText, rightAnswer);
		}
	}
}
