
namespace Inoxico.TechnicalQuestions.Answers
{
    public class QuestionOne
    {
        public static int GetLongestSentance(string s)
        {
            if (s.Length < 1)
                throw new ArgumentException("string cannot be less than 1");
            else if (s.Length > 100)
                throw new ArgumentException("string cannot be greater than 100");

            string[] stentances = s.Split('.');

            int longestWordLength = 0;

            foreach (string stentance in stentances)
            {
                int currentWordLength = 0;
                string[] words = stentance.Split(' ');
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                        currentWordLength++;
                }
            }



            return longestWordLength;
        }
    }
}




