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
            printAlignmentMatrix();
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

        private void printAlignmentMatrix()
        {
            for (int y = 0; y < alignmentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < alignmentMatrix.GetLength(1); x++)
                {
                    Console.Write(alignmentMatrix[x, y] + " ");
                }
                Console.WriteLine("");
            }
        }
        private void addBestSequencetoOptimizedList()
        {
            List<int> scores = new List<int>();
            int tempscore = 0;
            for (int y = 0; y < alignmentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < alignmentMatrix.GetLength(1); x++)
                {
                    tempscore += alignmentMatrix[x, y];
                }
                scores.Add(tempscore);
                tempscore = 0;
            }

            int bestIndex = scores.IndexOf(scores.Max());

            PairwiseAligner tempPA = pam.getFirstOccurenceOfAlignment(bestIndex);
            if (bestIndex == tempPA.getSequenceOne().number)
            {
                optimizedAlignments.Add(tempPA.getSequenceOne());
                optimizedAlignments.Add(tempPA.getSequenceTwo());
            }
            else
            {
                optimizedAlignments.Add(tempPA.getSequenceTwo());
                optimizedAlignments.Add(tempPA.getSequenceOne());
            }

            printStar();
        }

        private void constructStar()
        {
            foreach (KeyValuePair<int, List<PairwiseAligner>> entry in pam.dictOfstrandNumAndMatchingAlignments)
            {
                bool seqNeedsAdded = true;
                foreach (Sequence seq in optimizedAlignments)
                {
                    if (entry.Key == seq.number)
                    {
                        seqNeedsAdded = false;
                    }
                }
                if (seqNeedsAdded)
                {
                    PairwiseAligner tempPA = new PairwiseAligner();
                    foreach (PairwiseAligner pair in entry.Value)
                    {
                        if (optimizedAlignments[0].number == pair.getSequenceOne().number)
                        {
                            tempPA = pair;
                        }
                        else if (optimizedAlignments[0].number == pair.getSequenceTwo().number)
                        {
                            tempPA = pair;
                        }
                    }
                    if (optimizedAlignments[0].number == tempPA.getSequenceOne().number)
                    {
                        optimizedAlignments.Add(tempPA.getSequenceTwo());
                    }
                    else
                    {
                        optimizedAlignments.Add(tempPA.getSequenceOne());
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
