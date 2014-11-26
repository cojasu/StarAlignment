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
            scoringMatrix = new int[seq1.strand.Length + 1, seq2.strand.Length + 1];
        }

        public void InitializeScoringMatrix()
        {
            for (int x = 0; x < seq1.strand.Length; x++)
            {
                scoringMatrix[x, 0] = x * (-2);
            }
        }

        public void printScoringMatrix()
        {
            for (int x = 0; x < seq1.strand.Length; x++)
            {
                for (int y = 0; y < seq2.strand.Length; y++)
                {
                    Console.Write(scoringMatrix[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}
