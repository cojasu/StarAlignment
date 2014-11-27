using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public struct scoreDirectionPair
    {
        public int score;
        public string direction;
    }
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
        scoreDirectionPair[,] scoringMatrix;

        public PairwiseAligner(Sequence seq1, Sequence seq2)
        {
            this.seq1 = seq1;
            this.seq2 = seq2;
            sequence1 = (" " + seq1.strand).ToCharArray();
            sequence2 = (" " + seq2.strand).ToCharArray();
            scoringMatrix = new scoreDirectionPair[seq1.strand.Length + 1, seq2.strand.Length + 1];
        }

        public void InitializeScoringMatrix()
        {
            for (int x = 0; x <= seq1.strand.Length; x++)
            {
                scoreDirectionPair tempsdp;
                tempsdp.score = x * (-2);
                tempsdp.direction = "L";
                scoringMatrix[x, 0] = tempsdp;
            }
            for (int x = 0; x <= seq2.strand.Length; x++)
            {
                scoreDirectionPair tempsdp;
                tempsdp.score = x * (-2);
                tempsdp.direction = "T";
                scoringMatrix[0, x] = tempsdp;
            }

            scoringMatrix[0, 0].direction = "U";
        }

        public void calculateMatrix()
        {
            for (int y = 1; y < sequence2.Length; y++)
            {
                for (int x = 1; x < sequence1.Length; x++)
                {
                    scoringMatrix[x,y] = calculateScoreAndDirection(x, y);
                    
                }
                Console.WriteLine("Y: " + y);
            }
        }

        public scoreDirectionPair calculateScoreAndDirection(int x, int y)
        {
            int left;
            int top;
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
                diagonal = scoringMatrix[x - 1, y - 1].score + match;
            }
            else
            {
                diagonal = scoringMatrix[x - 1, y - 1].score + mismatch;
            }
            left = scoringMatrix[x - 1,y].score + gap;
            top = scoringMatrix[x, y - 1].score + gap;
            List<int> intList = new List<int>() { left, top, diagonal };
            scoreDirectionPair tempsdp;
            tempsdp.score = intList.Max();

            if (tempsdp.score == left)
            {
                tempsdp.direction = "L";
            }
            else if (tempsdp.score == top)
            {
                tempsdp.direction = "T";
            }
            else if (tempsdp.score == diagonal)
            {
                tempsdp.direction = "D";
            }
            else
            {
                tempsdp.direction = "U";
            }

            return tempsdp;
            
        }

        public void printScoringMatrixScore()
        {

            for (int x = 0; x <= seq1.strand.Length; x++)
            {
                Console.Write("  " + sequence1[x] + " ");
            }
            Console.WriteLine("");
            for (int y = 0; y <= seq2.strand.Length; y++)
            {
                Console.Write(sequence2[y]);
                for (int x = 0; x <= seq1.strand.Length; x++)
                {
                    if (scoringMatrix[x, y].score < 1 && scoringMatrix[x, y].score > -10)
                    {
                        Console.Write("  [" + scoringMatrix[x, y].score + "]");
                    }
                    else if (scoringMatrix[x, y].score > -10)
                    {
                        Console.Write("    [" + scoringMatrix[x, y].score +"]");
                    }
                    else
                    {

                        Console.Write(" [" + scoringMatrix[x, y].score +"]");
                    }
                }
                Console.WriteLine("");
            }
        }

        public void printScoringMatrixDirection()
        {
            for (int x = 0; x <= seq1.strand.Length; x++)
            {
                Console.Write(" " + sequence1[x]);
            }
            Console.WriteLine("");
            for (int y = 0; y <= seq2.strand.Length; y++)
            {
                Console.Write(sequence2[y]);
                for (int x = 0; x <= seq1.strand.Length; x++)
                {
                    Console.Write(" " + scoringMatrix[x, y].direction);
                }
                Console.WriteLine("");
            }
        }
    }
}
