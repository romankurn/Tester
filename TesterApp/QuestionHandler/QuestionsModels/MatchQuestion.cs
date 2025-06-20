using GeneralInformation;

namespace QuestionHandler.QuestionsModels
{
	public class MatchQuestion : QuestionBase
	{
		public List<string> QuestionText { get; private set; }

		public List<string> AnswerOptions { get; private set; }

		public List<int> RightAnswer { get; private set; }

		public List<int> UserAnswer { get; set; }

		public MatchQuestion(QuestionTypes questionType, List<string> questionText, List<string> answerOptions, List<int> rightAnswer, List<int> userAnswer = null) : base(questionType)
		{
			QuestionText = questionText;
			AnswerOptions = answerOptions;
			RightAnswer = rightAnswer;
			UserAnswer = userAnswer;
			GetMaximumPoints();
		}

		public override void CheckAnswer()
		{
			if (UserAnswer == null)
			{
				UserPoints = 0;
				return;
			}

			if (RightAnswer.Count != UserAnswer.Count)
			{
				UserPoints = 0;
				return;
			}

			var result = 0.0;

			for (var questionNumber = 0; questionNumber < RightAnswer.Count; questionNumber++)
			{
				if (RightAnswer[questionNumber] == UserAnswer[questionNumber])
					result += 1;
			}

			UserPoints = result;
		}

		protected override void GetMaximumPoints()
		{
			MaximumPoints = RightAnswer.Count;
		}

		public override void SetUserAnswer(List<int> userAnswer)
		{
			if (UserAnswer == null)
				userAnswer = new List<int>();

			UserAnswer = userAnswer;

			CheckAnswer();
		}

		public override List<string> ConvertQuestionToList()
		{
			var questionList = new List<string>();

			questionList.Add(QuestionType.ToString());

			questionList.Add($"{OptionsListToString(QuestionText)}");

			questionList.Add($"{OptionsListToString(AnswerOptions)}");

			questionList.Add($"{OptionsListToString(RightAnswer)}");

			if (UserAnswer == null || UserAnswer.Count == 0)
			{
				questionList.Add("");
			}
			else
			{
				questionList.Add($"{OptionsListToString(UserAnswer)}");
			}
			return questionList;
		}
	}
}
