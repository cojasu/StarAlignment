using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public class STAR
    {
        PairwiseAlignerManager pam;
        List<Sequence> optimizedAlignments = new List<Sequence>();
        int[,] alignmentMatrix;

        public STAR(PairwiseAlignerManager pam)
        {
            this.pam = pam;
            alignmentMatrix = new int[pam.numberOfSequences,pam.numberOfSequences];
        }

        public void Execute(){
            pam.Execute();
            initializeAlignmentMatrix();
            addBestSequencetoOptimizedList();
            constructStar();
            printStar();
        }

        private void initializeAlignmentMatrix()
        {
            for (int x = 0; x < alignmentMatrix.GetLength(0); x++)
            {
                for (int y = 0; y < alignmentMatrix.GetLength(1); y++)
                {
                    if (!(x == y))
                    {
                        alignmentMatrix[x, y] = pam.getAlignmentByNumbers(x, y).score;
                    }
                }
            }
        }

        private void addBestSequencetoOptimizedList()
        {
            int x = 0;
            int y = 1;
            List<int> rowScores = new List<int>();
            int tempScore = 0;
            int index = 0;
            for (int i = 0; i < alignmentMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < alignmentMatrix.GetLength(1); j++)
                {
                    if (!(i==j))
                    {
                        Console.WriteLine("Score: " + tempScore);
                        tempScore += alignmentMatrix[i,j];
                    }
                    
                }
                rowScores.Add(tempScore);
                tempScore = 0;
            }

            tempScore = rowScores[0];
            foreach (int score in rowScores)
            {

                if (score > tempScore)
                {
                    tempScore = score;
                    index = rowScores.IndexOf(score);
                }
            }

            optimizedAlignments.Add(pam.getSequenceByNumber(index));

        }

        private void constructStar()
        {
            for (int x = 0; x < pam.numberOfSequences; x++)
            {
                if (x != optimizedAlignments[0].number)
                {
                    optimizedAlignments.Add(pam.getAlignmentByNumbers(optimizedAlignments[0].number, x).getSequenceTwo());
                }
            }

            foreach (Sequence seq in optimizedAlignments)
            {
                for (int x = optimizedAlignments.IndexOf(seq); x < optimizedAlignments.Count; x++)
                {
                    if (seq.strand.Length != optimizedAlignments[x].strand.Length)
                    {
                        if (seq.strand.Length > optimizedAlignments[x].strand.Length)
                        {
                            int difference = seq.strand.Length - optimizedAlignments[x].strand.Length;
                            for (int y = difference; y > 0; y--){
                                optimizedAlignments[x].strand += "_";
                            }
                        }
                        else if (seq.strand.Length < optimizedAlignments[x].strand.Length)
                        {
                            int difference = optimizedAlignments[x].strand.Length - seq.strand.Length;
                            for (int y = difference; y > 0; y--)
                            {
                                seq.strand += "_";
                            }
                        }
                    }
                }
            }
        }

        private void printStar()
        {
            Console.WriteLine("Optimized STAR alignment");
            foreach (Sequence seq in optimizedAlignments)
            {
                Console.WriteLine(seq.strand);
            }
        }
        
    }
}
