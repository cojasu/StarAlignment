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
        public List<Sequence> optimizedAlignments = new List<Sequence>();
        int[,] alignmentMatrix;

        public STAR(PairwiseAlignerManager pam)
        {
            this.pam = pam;
            alignmentMatrix = new int[pam.numberOfSequences, pam.numberOfSequences];
        }

        public void Execute()
        {
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
                        break;
                    }
                }
                if (seqNeedsAdded)
                {

                    PairwiseAligner tempPA = new PairwiseAligner();
                    foreach (PairwiseAligner pair in entry.Value)
                    {
                        if (optimizedAlignments[0].number == pair.getSequenceOne().number || optimizedAlignments[0].number == pair.getSequenceTwo().number)
                        {
                            tempPA = pair;
                            break;
                        }
                    }

                    char[] initialMaster;

                    Sequence tempSeq;
                    Sequence compareSeq;
                    initialMaster = optimizedAlignments[0].strand.ToCharArray();
                    if (optimizedAlignments[0].number == tempPA.getSequenceOne().number)
                    {
                        tempSeq = tempPA.getSequenceTwo();
                        compareSeq = tempPA.getSequenceOne();
                    }
                    else if (optimizedAlignments[0].number == tempPA.getSequenceTwo().number)
                    {

                        tempSeq = tempPA.getSequenceOne();
                        compareSeq = tempPA.getSequenceTwo();
                    }
                    else
                    {
                        tempSeq = null;
                        compareSeq = null;
                        Console.WriteLine("Error");
                    }
                    string tempString = new string(initialMaster);
                    int x = 0;
                    while (compareSeq.strand != tempString)
                    {
                        if (tempString == compareSeq.strand)
                        {
                            break;
                        }
                        if (x >= tempString.Count())
                        {
                            foreach (Sequence seq in optimizedAlignments)
                            {
                                seq.strand = seq.strand.Insert(x, "_");
                            }
                            tempString = optimizedAlignments[0].strand;
                        }
                        if (x >= compareSeq.strand.Count())
                        {
                            compareSeq.strand = compareSeq.strand.Insert(x, "_");
                            tempSeq.strand = tempSeq.strand.Insert(x, "_");
                        }
                        if (!(tempString.ToCharArray()[x].Equals(compareSeq.strand.ToCharArray()[x])))
                        {
                            if (!(tempString.ToCharArray()[x].Equals('_')))
                            {

                                foreach (Sequence seq in optimizedAlignments)
                                {
                                    seq.strand = seq.strand.Insert(x, "_");
                                }
                            }
                            else
                            {
                                compareSeq.strand = compareSeq.strand.Insert(x, "_");
                                tempSeq.strand = tempSeq.strand.Insert(x, "_");

                            }
                        }
                        tempString = optimizedAlignments[0].strand;

                        x++;
                    }
                    optimizedAlignments.Add(tempSeq);
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
