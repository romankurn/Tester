using GeneralInformation.Events;
using QuestionHandler.QuestionsModels;
using TesterApp.ServiceClasses;

namespace TesterApp.QuestionForms
{
	public partial class StandartQuestionForm : Form
	{
		private List<CheckBox> _standartQuestionCheckBoxes = new List<CheckBox>();

		private StandartQuestion _question;

		private int _questionNumber;

		public event EventHandler OnReplyButtonClick;

		public event EventHandler OnNavigationButtonClick;

		public StandartQuestionForm(int questionNumber)
		{
			InitializeComponent();

			_question = (StandartQuestion)ServicesHolder.QuestionsHolder.Questions[questionNumber];
			_questionNumber = questionNumber;

			SetForm();
		}

		private void SetForm()
		{
			var locatiopnShift = 0;
			var answerOptionNumber = 1;

			foreach (var answer in _question.AnswerOptions)
			{
				var answerCheckBox = new CheckBox { Text = answer };

				if (!ServicesHolder.TestCompletionController.TestCanBeContinued)
					answerCheckBox.Enabled = false;

				answerCheckBox.Size = new Size(1200, 30);

				answerCheckBox.Location = new Point(15, _questionText.Location.Y + _questionText.Size.Height * 2 + 10 + locatiopnShift);
				_standartQuestionCheckBoxes.Add(answerCheckBox);

				answerCheckBox.Font = new Font("Times New Roman", 14);

				locatiopnShift += 30;

				if (_question.UserAnswer != null)
				{
					if (_question.UserAnswer.Contains(answerOptionNumber))
					{
						answerCheckBox.Checked = true;
					}

					answerOptionNumber++;
				}
			}

			_questionText.Text = _question.QuestionText;

			this.Text = $"Блок А. Вопрос №{_questionNumber}";

			_replyButton.Location = new Point(Size.Width / 2 - _replyButton.Width / 2, Convert.ToInt32(Size.Height * 0.85));
			_backButton.Location = new Point(_replyButton.Location.X - 15 - _backButton.Width, _replyButton.Location.Y);
			_nextButton.Location = new Point(_replyButton.Location.X + 15 + _replyButton.Width, _replyButton.Location.Y);

			if (!ServicesHolder.TestCompletionController.TestCanBeContinued)
				_replyButton.Enabled = false;

			if (_questionNumber == 1)
				_backButton.Enabled = false;

			if (_questionNumber >= ServicesHolder.QuestionsHolder.Questions.Count)
				_nextButton.Enabled = false;

			this.Controls.AddRange(_standartQuestionCheckBoxes.ToArray());
		}

		private void ReplyButtonClick(object sender, System.EventArgs e)
		{
			var answer = new List<int>();

			for (var optionNamber = 0; optionNamber < _standartQuestionCheckBoxes.Count; optionNamber++)
			{
				if (_standartQuestionCheckBoxes[optionNamber].Checked)
					answer.Add(optionNamber + 1);
			}

			ServicesHolder.QuestionsHolder.Questions[_questionNumber].SetUserAnswer(answer);

			OnReplyButtonClick?.Invoke(this, new AnswerReceivedEvent { QuestionNumber = _questionNumber });

			OnNavigationButtonClick?.Invoke(this, new GoToAnotherQuestion { QuestionNumber = _questionNumber + 1 });

			this.Close();
		}

		private void BackButtonClick(object sender, EventArgs e)
		{
			OnNavigationButtonClick?.Invoke(this, new GoToAnotherQuestion { QuestionNumber = _questionNumber - 1 });

			Close();
		}

		private void NextButtonClick(object sender, EventArgs e)
		{
			OnNavigationButtonClick?.Invoke(this, new GoToAnotherQuestion { QuestionNumber = _questionNumber + 1 });

			Close();
		}
	}
}
