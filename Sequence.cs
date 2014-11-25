using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarAlignment
{
    public class Sequence
    {
        public string strand;
        int number;

        public Sequence(string strand, int number)
        {
            this.number = number;
            this.strand = strand;
        }

    }
}
