namespace TesterApp
{
	partial class AutorizationForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this._startButton = new System.Windows.Forms.Button();
			this._discription = new System.Windows.Forms.Label();
			this._fioTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// _startButton
			// 
			this._startButton.Location = new System.Drawing.Point(162, 145);
			this._startButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this._startButton.Name = "_startButton";
			this._startButton.Size = new System.Drawing.Size(224, 38);
			this._startButton.TabIndex = 0;
			this._startButton.Text = "Начать тест";
			this._startButton.UseVisualStyleBackColor = true;
			this._startButton.Click += new System.EventHandler(this.StartButtonClick);
			// 
			// _discription
			// 
			this._discription.AutoSize = true;
			this._discription.Location = new System.Drawing.Point(35, 25);
			this._discription.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this._discription.Name = "_discription";
			this._discription.Size = new System.Drawing.Size(208, 26);
			this._discription.TabIndex = 1;
			this._discription.Text = "Введите ваше ФИО:";
			// 
			// _fioTextBox
			// 
			this._fioTextBox.Location = new System.Drawing.Point(35, 80);
			this._fioTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this._fioTextBox.Name = "_fioTextBox";
			this._fioTextBox.Size = new System.Drawing.Size(516, 34);
			this._fioTextBox.TabIndex = 2;
			// 
			// AutorizationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(596, 212);
			this.Controls.Add(this._fioTextBox);
			this.Controls.Add(this._discription);
			this.Controls.Add(this._startButton);
			this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "AutorizationForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Авторизация";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _startButton;
		private System.Windows.Forms.Label _discription;
		private System.Windows.Forms.TextBox _fioTextBox;
	}
}