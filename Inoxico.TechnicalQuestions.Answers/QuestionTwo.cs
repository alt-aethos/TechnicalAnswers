
namespace Inoxico.TechnicalQuestions.Answers
{
    public class QuestionTwo
    {
        public static int GetPitDepth(int[] points)
        {

            if (points.Length > 1000000)
                throw new ArgumentException("You cannot use more than 1,000,000 points");
            if (points.Length <= 1)
                throw new ArgumentException("You must have at least 2 point");
            foreach (var point in points)
            {
                if (point > 1000000)
                    throw new ArgumentException("No points can be greater than 100,000,000");
                if (point < -1000000)
                    throw new ArgumentException("No points can be less than 100,000,000");
            }



            Pit[] pits = GetPits(points);
            int deepestPitLength = -1;
            int deepestDepth = 1000000;

            foreach(Pit pit in pits)
            {
                int pitDepth = pit.GetDepth();
                if (pit.Q < deepestDepth) // if current pit depth is deeper than last. replace it
                {
                    deepestPitLength = pitDepth; 
                    deepestDepth = pit.Q;
                }

            }
            return deepestPitLength;
        }

        private static Pit[] GetPits(int[] points)
        {
            List<Pit> pits = new List<Pit>();

            //Variables to keep track of pit context
            bool counting = false;
            int highestPoint = 0;
            int lowestPoint = 1000000;


            for (int i = 0; i < points.Length - 1; i++)
            {
                int point = points[i];
                int nextPoint = points[i + 1];

                if (point < 0 && !counting)
                    continue;

                if (!DetermineIncreasing(point,points[i+1]))
                {
                    //if we have not been counting and we have found that this is decreasing. start counting and add current point as the highest point
                    if (!counting)
                    {
                        highestPoint = point;
                        counting = true;
                    }

                    // if point is lower than current lowest. set this point as the new lowest
                    if (nextPoint < lowestPoint)
                        lowestPoint = nextPoint;
                }
                else
                {
                    if (counting)
                    {
                        //if we have been counting and the current point is above 0. stop counting and add values as current pit. Reset variables for future iterations
                        pits.Add(new Pit(highestPoint, lowestPoint, point));
                        counting = false;
                        highestPoint = point;
                        lowestPoint = 1000000;

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
            P = p; // Start of pit
            Q = q; // Deepest point of pit
            R = r; // End of pit
        }

        public int GetDepth()
        {
            return P - Q;
        }
    }
}
