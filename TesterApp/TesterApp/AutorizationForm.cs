using GeneralInformation.Events;

namespace TesterApp
{
	public partial class AutorizationForm : Form
	{
		public event EventHandler OnStartButtonClicked;

		public AutorizationForm()
		{
			InitializeComponent();
			SetForm();
		}

		private void StartButtonClick(object sender, EventArgs e)
		{
			var fio = _fioTextBox.Text;

			if (fio == null || fio == "")
			{
				var message = "Для начала теста необходимо ввести ФИО.";
				MessageBox.Show(message);
				return;
			}

			OnStartButtonClicked?.Invoke(this, new FioEnteredEvent { Fio = fio });
			Close();
		}

		private void SetForm()
		{
			var width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.32);
			var height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.24);

			_discription.Location = new Point(Convert.ToInt32(width * 0.057), Convert.ToInt32(height * 0.097));
			_fioTextBox.Location = new Point(Convert.ToInt32(width * 0.057), Convert.ToInt32(height * 0.309));
			_startButton.Location = new Point(Convert.ToInt32(width / 2 - (_startButton.Size.Width / 2)), Convert.ToInt32(height * 0.56));

			this.MinimumSize = new Size(width, height);
			this.Size = new Size(width, height);
		}
	}
}
