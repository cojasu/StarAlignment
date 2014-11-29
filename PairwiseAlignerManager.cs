using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public class PairwiseAlignerManager
    {
        public Dictionary<int, List<PairwiseAligner>> dictOfstrandNumAndMatchingAlignments = new Dictionary<int,List<PairwiseAligner>>();
        List<PairwiseAligner> listOfAlignments = new List<PairwiseAligner>();
        public int numberOfSequences = 0;
        public PairwiseAlignerManager(List<Sequence> sequences)
        {
            numberOfSequences = sequences.Count;
            foreach (Sequence seq in sequences)
            {
                for (int x = sequences.IndexOf(seq); x < sequences.Count; x++)
                {
                    if (!(sequences.IndexOf(seq) == x))
                    {
                        listOfAlignments.Add(new PairwiseAligner(seq, sequences[x]));
                    }
                }
            }

            foreach(PairwiseAligner alignment in listOfAlignments)
            {
                if (dictOfstrandNumAndMatchingAlignments.ContainsKey(alignment.getSequenceOne().number))
                {
                    dictOfstrandNumAndMatchingAlignments[alignment.getSequenceOne().number].Add(alignment);
                }
                else
                {
                    dictOfstrandNumAndMatchingAlignments.Add(alignment.getSequenceOne().number, new List<PairwiseAligner>());
                    dictOfstrandNumAndMatchingAlignments[alignment.getSequenceOne().number].Add(alignment);
                }
                if (dictOfstrandNumAndMatchingAlignments.ContainsKey(alignment.getSequenceTwo().number))
                {
                    dictOfstrandNumAndMatchingAlignments[alignment.getSequenceTwo().number].Add(alignment);
                }
                else
                {
                    dictOfstrandNumAndMatchingAlignments.Add(alignment.getSequenceTwo().number, new List<PairwiseAligner>());
                    dictOfstrandNumAndMatchingAlignments[alignment.getSequenceTwo().number].Add(alignment);
                }
            }
        }

        public void Execute(){
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                pa.Execute();
            }
        }

        public PairwiseAligner getAlignmentByNumbers(int x, int y)
        {
            string tempName1 = "S" + x + "S" + y;
            string tempName2 = "S" + y + "S" + x;
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                if (pa.name == tempName1){
                    return pa;
                }
                if (pa.name == tempName2)
                {
                    return pa;
                }
            }
            return null;
        }

        public void printHighestScorePairwiseAligner()
        {
            int index = 0;
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                if (pa.score > listOfAlignments[index].score)
                {
                    index = listOfAlignments.IndexOf(pa);
                }
            }
            Console.WriteLine("");
            Console.WriteLine("This is the best alignment out of all of the Pairwise Alignments");
            listOfAlignments[index].printAll();
        }

        public Sequence getSequenceByNumber(int x)
        {
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                if (pa.getSequenceOne().number == x)
                {
                    return pa.getSequenceOne();
                }

                if (pa.getSequenceTwo().number == x)
                {
                    return pa.getSequenceTwo();
                }
            }
            return null;
        }
        public PairwiseAligner getBestAlignment()
        {
            int index = 0;
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                if (pa.score > listOfAlignments[index].score)
                {
                    index = listOfAlignments.IndexOf(pa);
                }
            }

            return listOfAlignments[index];
        }

        public PairwiseAligner getFirstOccurenceOfAlignment(int x)
        {
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                if (pa.getSequenceOne().number == x)
                {
                    return pa;
                }

                if (pa.getSequenceTwo().number == x)
                {
                    return pa;
                }
            }
            return null;
        }

        private void printDictionary()
        {
            foreach (KeyValuePair<int, List<PairwiseAligner>> key in dictOfstrandNumAndMatchingAlignments)
            {
                Console.WriteLine(key.Key);
                foreach (PairwiseAligner pair in key.Value)
                {
                    Console.WriteLine(pair.getSequenceOne().number + " " + pair.getSequenceOne() + " " + pair.getSequenceTwo().number + " " + pair.getSequenceTwo());
                }
            }
        }
    }
}
