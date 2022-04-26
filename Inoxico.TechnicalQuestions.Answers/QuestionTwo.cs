
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

            //Variables to keep track of pit context
            bool counting = false;
            int highestPoint = 0;
            int lowestPoint = 0;


            for (int i = 0; i < points.Length; i++)
            {
                if (points[i] < 0 && !counting)
                    continue;

                int point = points[i];
                if (!DetermineIncreasing(point,points[i+1]))
                {
                    //if we have not been counting and we have found that this is decreasing. start counting and add current point as the highest point
                    if (!counting)
                    {
                        highestPoint = point;
                        counting = true;
                        continue;
                    }

                    // if point is lower than current lowest. set this point as the new lowest
                    if (point < lowestPoint)
                        lowestPoint = point;
                }
                else
                {
                    if (counting && point >= 0)
                    {
                        //if we have been counting and the current point is above 0. stop counting and add values as current pit. Reset variables for future iterations
                        pits.Add(new Tuple<int, int, int>(highestPoint, lowestPoint, point));
                        counting = false;
                        highestPoint = point;
                        lowestPoint = 0;

                        i--; //Bring i back as there may be another pit directly after this pit
                        continue;
                    }
                }

            }
            return pits.ToArray();
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
