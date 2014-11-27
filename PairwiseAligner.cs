using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public class PairwiseAligner
    {
        Sequence seq1;
        Sequence seq2;

        char[] sequence1;
        char[] sequence2;

        Sequence alignedSeq1;
        Sequence alignedSeq2;

        int match = 1;
        int mismatch = -1;
        int gap = -2;
        int score;
        int[,] scoringMatrix;

        public PairwiseAligner(Sequence seq1, Sequence seq2)
        {
            this.seq1 = seq1;
            this.seq2 = seq2;
            sequence1 = (" " + seq1.strand).ToCharArray();
            sequence2 = (" " + seq2.strand).ToCharArray();
            scoringMatrix = new int[seq1.strand.Length + 1, seq2.strand.Length + 1];
        }

        public void InitializeScoringMatrix()
        {
            for (int x = 0; x < seq1.strand.Length; x++)
            {
                scoringMatrix[x, 0] = x * (-2);
            }
            for (int x = 0; x < seq2.strand.Length; x++)
            {
                scoringMatrix[0, x] = x * (-2);
            }
        }

        public void calculateMatrix()
        {
            for (int y = 1; y < sequence1.Length - 1; y++)
            {
                for (int x = 1; x < sequence2.Length - 1; x++)
                {
                    scoringMatrix[x,y] = getScore(x , y);
                }
            }
        }

        public int getScore(int x, int y)
        {
            int left;
            int up;
            int diagonal;
            bool ismatch;

            if (sequence1[x] == sequence2[y])
            {
                ismatch = true;
            }
            else
            {
                ismatch = false;
            }

            if (ismatch)
            {
                diagonal = scoringMatrix[x - 1, y - 1] + match;
            }
            else
            {
                diagonal = scoringMatrix[x - 1, y - 1] + mismatch;
            }
            left = scoringMatrix[x - 1,y] + gap;
            up = scoringMatrix[x, y - 1] + gap;
            List<int> intList = new List<int>() { left, up, diagonal };
            return intList.Max();
            
        }

        public void printScoringMatrix()
        {

            for (int x = 0; x < seq1.strand.Length; x++)
            {
                Console.Write("  " + sequence1[x] + " ");
            }
            Console.WriteLine("");
            for (int y = 0; y < seq2.strand.Length; y++)
            {
                Console.Write(sequence2[y]);
                for (int x = 0; x < seq1.strand.Length; x++)
                {
                    if (scoringMatrix[x, y] < 1 && scoringMatrix[x, y] > -10)
                    {
                        Console.Write("  [" + scoringMatrix[x, y] + "]");
                    }
                    else if (scoringMatrix[x, y] > -10)
                    {
                        Console.Write("    [" + scoringMatrix[x, y] +"]");
                    }
                    else
                    {

                        Console.Write(" [" + scoringMatrix[x, y] +"]");
                    }
                }
                Console.WriteLine("");
                
            }
        }
    }
}
