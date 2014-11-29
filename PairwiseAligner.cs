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

        public int score;
 
        char[] sequence1;
        char[] sequence2;

        Sequence alignedSeq1 = new Sequence();
        Sequence alignedSeq2 = new Sequence();

        int match = 1;
        int mismatch = -1;
        int gap = -2;
        scoreDirectionPair[,] scoringMatrix;

        public string name;
        public PairwiseAligner(Sequence seq1, Sequence seq2)
        {
            this.seq1 = seq1;
            this.seq2 = seq2;
            alignedSeq1.number = seq1.number;
            alignedSeq2.number = seq2.number;
            sequence1 = (" " + seq1.strand).ToCharArray();
            sequence2 = (" " + seq2.strand).ToCharArray();
            scoringMatrix = new scoreDirectionPair[seq1.strand.Length + 1, seq2.strand.Length + 1];
            name = "S" + seq1.number + "S" + seq2.number;
        }

        public PairwiseAligner()
        {

        }
        public void Execute(){
            InitializeScoringMatrix();
            calculateMatrix();
            setAlignedSequences();
            setScore();
        }

        private void InitializeScoringMatrix()
        {
            for (int x = 0; x <= seq1.strand.Length; x++)
            {
                scoreDirectionPair tempsdp;
                tempsdp.score = x * (-2);
                tempsdp.direction = "-";
                scoringMatrix[x, 0] = tempsdp;
            }
            for (int x = 0; x <= seq2.strand.Length; x++)
            {
                scoreDirectionPair tempsdp;
                tempsdp.score = x * (-2);
                tempsdp.direction = "|";
                scoringMatrix[0, x] = tempsdp;
            }

            scoringMatrix[0, 0].direction = "U";
        }

        private void calculateMatrix()
        {
            for (int y = 1; y < sequence2.Length; y++)
            {
                for (int x = 1; x < sequence1.Length; x++)
                {
                    scoringMatrix[x,y] = calculateScoreAndDirection(x, y);
                    
                }
            }
        }

        private scoreDirectionPair calculateScoreAndDirection(int x, int y)
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
                tempsdp.direction = "-";
            }
            else if (tempsdp.score == top)
            {
                tempsdp.direction = "|";
            }
            else if (tempsdp.score == diagonal)
            {
                tempsdp.direction = "\\";
            }
            else
            {
                tempsdp.direction = "U";
            }

            return tempsdp;
            
        }

        private void setAlignedSequences()
        {
            string direction = "";
            int x = scoringMatrix.GetLength(0)-1;
            int y = scoringMatrix.GetLength(1)-1;
            while (direction != "U")
            {
                direction = scoringMatrix[x, y].direction;

                if (direction == "\\")
                {
                    alignedSeq1.strand += sequence1[x];
                    alignedSeq2.strand += sequence2[y];
                    x = x - 1;
                    y = y - 1;
                }
                else if (direction == "-")
                {
                    alignedSeq1.strand += sequence1[x];
                    alignedSeq2.strand += "_";
                    x = x - 1;
                }
                else if (direction == "|")
                {
                    alignedSeq1.strand += "_";
                    alignedSeq2.strand += sequence2[y];
                    y = y - 1;
                }
            }

            alignedSeq1.strand = Reverse(alignedSeq1.strand);
            alignedSeq2.strand = Reverse(alignedSeq2.strand);
        }

        public Sequence getSequenceOne(){
            return alignedSeq1;
        }

        public Sequence getSequenceTwo(){
            return alignedSeq2;
        }

        private string Reverse(string text)
        {
            if (text == null) return null;

            char[] array = text.ToCharArray();
            Array.Reverse(array);
            return new String(array);
        }

        private void setScore()
        {
            char[] tempSeq1 = alignedSeq1.strand.ToCharArray();
            char[] tempSeq2 = alignedSeq2.strand.ToCharArray();
            for (int x = 0; x < alignedSeq1.strand.Length; x++)
            {
                if (tempSeq1[x] == tempSeq2[x])
                {
                    score += 1;
                }
                else if (tempSeq1[x] == '_' || tempSeq2[x] == '_')
                {
                    score -= 2;
                }
                else
                {
                    score -= 1;
                }

            }
        }

        #region Printing

        public void printAll()
        {
            printScoringMatrixScore();
            printScoringMatrixDirection();
            printAlignedSequences();
            printScore();
        }

        private void printScoringMatrixScore()
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

        private void printScoringMatrixDirection()
        {
            Console.Write(" ");
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

        private void printAlignedSequences()
        {
            Console.WriteLine(alignedSeq1.strand);
            Console.WriteLine(alignedSeq2.strand);
        }

        private void printScore()
        {
            Console.WriteLine("Score for the alignment: " + score);
        }

        #endregion
    }
}
