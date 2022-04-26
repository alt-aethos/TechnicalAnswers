
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
            int highestPoint = 0;


            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] < 0 && !counting)
                    continue;

                int point = points[i];
                if (!DetermineIncreasing(point,points[i+1]))
                {
                    if (!counting)
                    {
                        highestPoint = point;
                        counting = true;
                        continue;
                    }
                }
                else
                {
                    if (counting && point >= 0)
                    {

                    }
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
