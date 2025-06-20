using GeneralInformation;
using GeneralInformation.Events;
using QuestionHandler.QuestionsModels;
using TesterApp.ServiceClasses;

namespace TesterApp
{
	public partial class TestNavigationForm : Form
	{
		private Dictionary<int, List<TextBox>> _questionsTable = new Dictionary<int, List<TextBox>>();

		public event EventHandler OnAnswerReceived;

		public TestNavigationForm()
		{
			InitializeComponent();

			ServicesHolder.Timer.OnTimerTick += OnTimerTick;
			ServicesHolder.Timer.OnTimeIsOver += OnTimeIsOver;
			ServicesHolder.QuestionFormCreator.OnAswerReceived += QuestionFormCreatorOnAswerReceived;
			ServicesHolder.QuestionFormCreator.OnAnotherQuestionSelected += QuestionFormCreatorOnSelectedAnotherQuestion;

			СonfigureСomponents();
		}

		private void СonfigureСomponents()
		{
			var testTime = ServicesHolder.Timer.RemainingTime;
			Text = $"Оставшееся время: {testTime}";

			var navigationTable = new List<TextBox>();

			var locationShift = 0;
			var locationX = 15;
			var indentByY = 15;
			var size = 34;

			_description.Location = new Point(locationX, indentByY);

			foreach (var question in ServicesHolder.QuestionsHolder.Questions)
			{
				if (question.Key == 46)
				{
					locationShift = 0;

					var locationShiftByY = size * 2 + 5;

					indentByY = 15 + locationShiftByY;
				}

				var questionTextBox = new TextBox { Text = question.Key.ToString() };
				questionTextBox.Font = new Font("Times New Roman", 14);
				questionTextBox.Size = new Size(size, size);
				questionTextBox.Location = new Point(locationX + locationShift, _description.Location.Y + _description.Size.Height + indentByY);
				questionTextBox.TextAlign = HorizontalAlignment.Center;
				questionTextBox.Click += QuestionTextBoxClick;
				questionTextBox.ReadOnly = true;
				questionTextBox.BackColor = Color.White;

				var answerStatus = new TextBox();
				answerStatus.Font = new Font("Times New Roman", 14);
				answerStatus.Size = new Size(size, size);
				answerStatus.Location = new Point(locationX + locationShift, questionTextBox.Location.Y + questionTextBox.Size.Height);
				answerStatus.TextAlign = HorizontalAlignment.Center;
				answerStatus.ReadOnly = true;

				if (CheckForAnswers(question.Value))
					answerStatus.BackColor = Color.Yellow;
				else
					answerStatus.BackColor = Color.White;

				locationShift += size;

				navigationTable.Add(questionTextBox);
				navigationTable.Add(answerStatus);

				_questionsTable.Add(question.Key, new List<TextBox> { questionTextBox, answerStatus });
			}

			this.MinimumSize = new Size(_description.Width + locationX * 3, 500);

			if (ServicesHolder.QuestionsHolder.Questions.Count > 50)
			{
				Size = new Size(2 * locationX + size * 46, 500);
			}
			else
			{
				Size = new Size(2 * locationX + locationShift + size, 500);
			}

			_finishTestButton.Location = new Point(this.Size.Width / 2 - _finishTestButton.Size.Width / 2, 390);
			_indicators.Location = new Point(15, _questionsTable.Last().Value[0].Location.Y + 70);
			_correctAnswer.Location = new Point(15, _questionsTable.Last().Value[0].Location.Y + 95);
			_wrongAnswer.Location = new Point(15, _questionsTable.Last().Value[0].Location.Y + 125);
			_correctAnswerLabel.Location = new Point(45, _questionsTable.Last().Value[0].Location.Y + 95);
			_wrongAnswerLabel.Location = new Point(45, _questionsTable.Last().Value[0].Location.Y + 125);

			var navigationTableArray = navigationTable.ToArray();

			this.Controls.AddRange(navigationTableArray);

			if (!ServicesHolder.TestCompletionController.TestCanBeContinued)
				ShowResults();
		}

		#region Events
		private void OnTimerTick(object? sender, EventArgs e)
		{
			var time = (TimerTickEvent)e;

			Text = $"Оставшееся время: {time.RemainingTime}";
		}

		private void OnTimeIsOver(object? sender, EventArgs e)
		{
			ShowResults();
		}

		private void QuestionFormCreatorOnAswerReceived(object? sender, EventArgs e)
		{
			var questionNumber = ((AnswerReceivedEvent)e).QuestionNumber;

			_questionsTable[questionNumber][1].BackColor = Color.Yellow;

			OnAnswerReceived?.Invoke(this, e);
		}


		private void QuestionFormCreatorOnSelectedAnotherQuestion(object? sender, EventArgs e)
		{
			var questionNumber = ((GoToAnotherQuestion)e).QuestionNumber;

			OpenQuestionForm(questionNumber);
		}
		#endregion

		private void QuestionTextBoxClick(object? sender, EventArgs e)
		{
			var button = (TextBox)sender;

			var questionNumber = int.Parse(button.Text);

			OpenQuestionForm(questionNumber);
		}

		private void OpenQuestionForm(int questionNumber)
		{
			if (questionNumber < 1 || questionNumber > ServicesHolder.QuestionsHolder.Questions.Count)
				return;

			ServicesHolder.QuestionFormCreator.CreateForm(questionNumber);
		}

		private void FinishTestButtonClick(object sender, EventArgs e)
		{
			var buttons = MessageBoxButtons.YesNo;
			var result = MessageBox.Show("Вы уверены?", "Завершить тест", buttons);

			if (result == DialogResult.No)
				return;

			ServicesHolder.Timer.OnTimerTick -= OnTimerTick;
			ServicesHolder.Timer.StopTimer();

			ShowResults();
		}

		private bool CheckForAnswers(QuestionBase question)
		{
			switch (question.QuestionType)
			{
				case (QuestionTypes.StandartQuestion):
					{
						var userAnswer = ((StandartQuestion)question).UserAnswer;

						if (userAnswer != null && userAnswer.Count != 0)
							return true;
						else
							return false;
					}
				case (QuestionTypes.YesNoQuestion):
					{
						if (((YesNoQuestion)question).UserAnswer != 0)
							return true;
						else
							return false;
					}
				case (QuestionTypes.AdvancedQuestion):
					{
						if (((AdvancedQuestion)question).UserAnswer != 0)
							return true;
						else
							return false;
					}
				case (QuestionTypes.MatchQuestion):// доработать!
					{
						if (((MatchQuestion)question).UserAnswer != null)
							return true;
						else
							return false;
					}
				default:
					return false;
			}
		}

		private void ShowResults()
		{
			_finishTestButton.Visible = false;
			_correctAnswer.Visible = false;
			_wrongAnswer.Visible = false;
			_correctAnswerLabel.Visible = false;
			_wrongAnswerLabel.Visible = false;
			Text = "Результаты выполнения теста";

			if (ServicesHolder.QuestionsHolder.StudentPoints == 0)
				ServicesHolder.QuestionsHolder.CalculateUserPoints();

			var questionNumber = 1;

			foreach (var answerStatus in _questionsTable.Values)
			{
				answerStatus[1].Text = ServicesHolder.QuestionsHolder.Questions[questionNumber++].UserPoints.ToString();
			}

			_description.Text = "Баллы, полученные за ответы на вопросы:";
			_indicators.Text = @$"За выполнение теста вы набрали {ServicesHolder.QuestionsHolder.StudentPoints} баллов из {ServicesHolder.QuestionsHolder.MaximumPoints} возможных.
			Ваша оценка {ServicesHolder.QuestionsHolder.StudentResult}.";

			_indicators.Location = new Point(15, _questionsTable.Last().Value[0].Location.Y + 70);

		}

		private void TestNavigationForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			ServicesHolder.Timer.OnTimerTick -= OnTimerTick;
			ServicesHolder.Timer.OnTimeIsOver -= OnTimeIsOver;
			ServicesHolder.QuestionFormCreator.OnAswerReceived -= QuestionFormCreatorOnAswerReceived;
			ServicesHolder.QuestionFormCreator.OnAnotherQuestionSelected -= QuestionFormCreatorOnSelectedAnotherQuestion;
		}
	}
}
