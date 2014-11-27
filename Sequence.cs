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

        public Sequence(string strand)
        {
            this.strand = strand;
        }

        public Sequence()
        {
            this.strand = "";
        }
        public override string ToString()
        {
            return strand;
        }
    }
}
