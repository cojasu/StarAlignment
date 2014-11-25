using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    class PairwiseAligner
    {
        Sequence seq1;
        Sequence seq2;

        Sequence alignedSeq1;
        Sequence alignedSeq2;

        int match = 1;
        int mismatch = -1;
        int gap = -2;
        int score;

        public PairwiseAligner(Sequence seq1, Sequence seq2)
        {
            this.seq1 = seq1;
            this.seq2 = seq2;
        }
    }
}
