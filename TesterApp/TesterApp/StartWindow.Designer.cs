namespace TesterApp
{
	partial class StartWindow
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartWindow));
			this._startButton = new System.Windows.Forms.Button();
			this._instruction = new System.Windows.Forms.Label();
			this._downloadButton = new System.Windows.Forms.Button();
			this._continueButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// _startButton
			// 
			this._startButton.Location = new System.Drawing.Point(408, 440);
			this._startButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this._startButton.Name = "_startButton";
			this._startButton.Size = new System.Drawing.Size(195, 38);
			this._startButton.TabIndex = 0;
			this._startButton.Text = "Начать";
			this._startButton.UseVisualStyleBackColor = true;
			this._startButton.Click += new System.EventHandler(this.OnStartButtonClick);
			// 
			// _instruction
			// 
			this._instruction.AutoSize = true;
			this._instruction.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this._instruction.Location = new System.Drawing.Point(15, 15);
			this._instruction.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
			this._instruction.MaximumSize = new System.Drawing.Size(1200, 0);
			this._instruction.Name = "_instruction";
			this._instruction.Size = new System.Drawing.Size(1193, 364);
			this._instruction.TabIndex = 1;
			this._instruction.Text = resources.GetString("_instruction.Text");
			this._instruction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// _downloadButton
			// 
			this._downloadButton.Location = new System.Drawing.Point(642, 440);
			this._downloadButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this._downloadButton.Name = "_downloadButton";
			this._downloadButton.Size = new System.Drawing.Size(195, 38);
			this._downloadButton.TabIndex = 2;
			this._downloadButton.Text = "Загрузить";
			this._downloadButton.UseVisualStyleBackColor = true;
			this._downloadButton.Click += new System.EventHandler(this.OnDownloadButtonClick);
			// 
			// _continueButton
			// 
			this._continueButton.Location = new System.Drawing.Point(530, 440);
			this._continueButton.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this._continueButton.Name = "_continueButton";
			this._continueButton.Size = new System.Drawing.Size(195, 38);
			this._continueButton.TabIndex = 3;
			this._continueButton.Text = "Продолжить";
			this._continueButton.UseVisualStyleBackColor = true;
			this._continueButton.Click += new System.EventHandler(this.OnContinueButtonClick);
			// 
			// StartWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 26F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1232, 503);
			this.Controls.Add(this._continueButton);
			this.Controls.Add(this._downloadButton);
			this.Controls.Add(this._instruction);
			this.Controls.Add(this._startButton);
			this.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
			this.Name = "StartWindow";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Контрольные вопросы по \"лекции Х\"";
			this.Load += new System.EventHandler(this.OnWindowLoaded);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button _startButton;
		private System.Windows.Forms.Label _instruction;
		private System.Windows.Forms.Button _downloadButton;
		private System.Windows.Forms.Button _continueButton;
	}
}