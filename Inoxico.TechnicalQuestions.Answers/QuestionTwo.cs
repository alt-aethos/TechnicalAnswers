
namespace Inoxico.TechnicalQuestions.Answers
{
    public class QuestionTwo
    {
        public static int GetPitDepth(int[] points)
        {
            Pit[] pits = GetPits(points);
            int deepestPitLength = -1;

            foreach(Pit pit in pits)
            {
                deepestPitLength = pit.GetDepth();
            }
        }

        private static Pit[] GetPits(int[] points)
        {
            List<Pit> pits = new List<Pit>();

            //Variables to keep track of pit context
            bool counting = false;
            int highestPoint = 0;
            int lowestPoint = 0;


            for (int i = 0; i < points.Length - 1; i++)
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
                        pits.Add(new Pit(highestPoint, lowestPoint, point));
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

    public class Pit
    {
        public int P;
        public int Q;
        public int R;

        public Pit(int p, int q, int r)
        {
            P = p;
            Q = q;
            R = r;
        }

        public int GetDepth()
        {
            return Math.Abs(P - Q);
        }
    }
}
