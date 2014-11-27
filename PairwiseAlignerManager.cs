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

        public PairwiseAlignerManager(List<Sequence> sequences)
        {
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

        public void PairwiseAlignerManagerExecute(){
            foreach (PairwiseAligner pa in listOfAlignments)
            {
                pa.PairwiseAlignerExecute();
            }
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
    }
}
