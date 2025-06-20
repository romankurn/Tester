using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public class AdvancedQuestionReader : QuestionReaderBase
	{
		public AdvancedQuestionReader() : base(QuestionTypes.AdvancedQuestion)
		{
		}

		public override QuestionBase GetQuestion(List<string> questionList)
		{
			var questionText = questionList[1];

			var answerOptions = GetAnswerOptions(questionList[2]);

			var rightAnswer = int.Parse(questionList[3]);

			return new AdvancedQuestion(_questionType, questionText, answerOptions, rightAnswer);
		}

		private List<string> GetAnswerOptions(string answerOptionsSection)
		{
			var answerOptionsArray = answerOptionsSection.Split(Constants.OptionSeparator);

			var answerOptionsList = new List<string>();

			foreach (string questionText in answerOptionsArray)
			{
				answerOptionsList.Add(questionText);
			}

			return answerOptionsList;
		}
	}
}
