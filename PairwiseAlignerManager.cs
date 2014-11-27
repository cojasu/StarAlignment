using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public class PairwiseAlignerManager
    {
        List<PairwiseAligner> listOfAlignments = new List<PairwiseAligner>();
        public int numberOfSequences = 0;
        public PairwiseAlignerManager(List<Sequence> sequences)
        {
            numberOfSequences = sequences.Count;
            foreach (Sequence seq in sequences)
            {
                Console.WriteLine(sequences.Count);
                for (int x = sequences.IndexOf(seq); x < sequences.Count; x++)
                {
                    if (!(sequences.IndexOf(seq) == x))
                    {
                        listOfAlignments.Add(new PairwiseAligner(seq, sequences[x]));
                    }
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
                Console.WriteLine("one: " + pa.getSequenceOne().number + " two: " + pa.getSequenceTwo().number);
            }
            Console.WriteLine("Int X: " + x);
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
    }
}
