using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public class StandartQuestionReader : QuestionReaderBase
	{
		public StandartQuestionReader() : base(QuestionTypes.StandartQuestion)
		{
		}

		public override QuestionBase GetQuestion(List<string> questionList)
		{
			var questionText = questionList[1];

			var answerOptions = GetAnswerOptions(questionList[2]);

			var rightAnswer = GetRightOrUserAnswer(questionList[3]);

			if (questionList.Count == 5)
			{
				var UserAnswer = GetRightOrUserAnswer(questionList[4]);

				return new StandartQuestion(_questionType, questionText, answerOptions, rightAnswer, UserAnswer);
			}

			return new StandartQuestion(_questionType, questionText, answerOptions, rightAnswer);
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

		private List<int> GetRightOrUserAnswer(string rightAnswerSection)
		{
			var rightAnswersArray = rightAnswerSection.Split(Constants.OptionSeparator);

			var rightAnswersList = new List<int>();

			foreach (string rightAnswer in rightAnswersArray)
			{
				if (int.TryParse(rightAnswer, out int answer))
				{
					rightAnswersList.Add(answer);
				}
			}

			return rightAnswersList;
		}
	}
}
