
namespace Inoxico.TechnicalQuestions.Answers
{
    public class QuestionTwo
    {
        public static int GetPitDepth(int[] points)
        {
            
        }

        private static Tuple<int,int,int>[] GetPits(int[] points)
        {
            List<Tuple<int, int, int>> pits = new List<Tuple<int, int, int>>();

            bool counting = false;
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] > 0 && !counting)
                    continue;
                if(!DetermineIncreasing(points[i],points[i+1]))
                {
                    
                }

            }
        }

        private static bool DetermineIncreasing(int a, int b)
        {
            if (a < b)
                return true;
            else
                return false;
        }
    }
}
