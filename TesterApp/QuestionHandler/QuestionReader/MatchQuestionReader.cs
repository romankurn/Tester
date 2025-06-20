using GeneralInformation;
using QuestionHandler.QuestionsModels;

namespace QuestionHandler.QuestionReader
{
	public class MatchQuestionReader : QuestionReaderBase
	{
		public MatchQuestionReader() : base(QuestionTypes.MatchQuestion)
		{
		}

		public override QuestionBase GetQuestion(List<string> questionList)
		{
			var questionText = GetQuestionText(questionList[1]);

			var answerOptions = GetAnswerOptions(questionList[2]);

			var rightAnswer = GetRightOrUserAnswer(questionList[3]);

			if (questionList.Count == 5)
			{
				var userAnswer = GetRightOrUserAnswer(questionList[4]);

				return new MatchQuestion(_questionType, questionText, answerOptions, rightAnswer, userAnswer);
			}

			return new MatchQuestion(_questionType, questionText, answerOptions, rightAnswer);
		}

		private List<string> GetQuestionText(string questionTextSection)
		{
			var questionTextArray = questionTextSection.Split(Constants.OptionSeparator);

			var questionTextList = new List<string>();

			foreach (string questionText in questionTextArray)
			{
				questionTextList.Add(questionText);
			}

			return questionTextList;
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
				if (int.TryParse(rightAnswer, out var result))
				{
					rightAnswersList.Add(Convert.ToInt32(result));
					continue;
				}

				rightAnswersList.Add(0);
			}

			return rightAnswersList;
		}
	}
}
