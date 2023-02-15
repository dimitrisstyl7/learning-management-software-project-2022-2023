namespace Project_final_2022_2023.Classes
{
    internal class Question
    {
        public string QType { get; set; } //question type
        public string QText { get; set; } //question instruction
        public string QTip { get; set; } //question tip
        public List<string[]> QAnswers { get; set; } //possible answers
        public string[] QCorrectAns { get; set; } //correct answers
        public int QTime { get; set; } //question time (in seconds)
        public int QTimeRemaining { get; set; } //question remaining time (in seconds)
        public static double QTotalMarks { get; set; }
    }
}