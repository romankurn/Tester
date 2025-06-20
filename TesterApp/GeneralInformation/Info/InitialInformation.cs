namespace GeneralInformation.Info
{
	public class InitialInformation
	{
		public string LectureNumber { get; set; }

		public int TestTime { get; set; }

		public Dictionary<Filenames, QuestionTypes> FilesInfo { get; set; }
	}
}
