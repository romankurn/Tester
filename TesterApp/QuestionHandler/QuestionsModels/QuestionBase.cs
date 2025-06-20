using GeneralInformation;
using System.Text;

namespace QuestionHandler.QuestionsModels
{
	public abstract class QuestionBase
	{
		public QuestionTypes QuestionType { get; protected set; }

		public double UserPoints { get; protected set; }

		public int MaximumPoints { get; protected set; }

		public QuestionBase(QuestionTypes questionType)
		{
			QuestionType = questionType;
		}

		public abstract void CheckAnswer();

		protected abstract void GetMaximumPoints();

		public abstract void SetUserAnswer(List<int> userAnswer);

		public abstract List<string> ConvertQuestionToList();

		protected string OptionsListToString<TOption>(List<TOption> options)
		{
			if (options == null || options.Count == 0)
				return null;

			var str = new StringBuilder();

			foreach (var option in options)
			{
				str.Append($"{option}/");
			}
			str.Remove(str.Length - 1, 1);

			return str.ToString();
		}
	}
}
