using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StarAlignment
{
    public partial class Form1 : Form
    {
        List<Sequence> sequences = new List<Sequence>();
        List<PairwiseAligner> pairwiseAlignments = new List<PairwiseAligner>();

        public Form1()
        {
            InitializeComponent();

        }
        #region Non-GUI related functions

        void addSequenceToList(String[] sequenceSource)
        {
            foreach (string seq in sequenceSource)
            {
                if (strandLegal(seq))
                {
                    Sequence addingSequence = new Sequence(seq);
                    sequences.Add(addingSequence);
                    listBoxInput.Items.Add(new Sequence(seq));
                }
            }
        }

        bool strandLegal(string strand)
        {
            foreach (char c in strand)
            {
                if (c != 'G' && c != 'A' && c != 'C' && c != 'T')
                {
                    return false;
                }
            }
            return true;
        }
        #endregion


        #region GUI related functions
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                string[] filelines = File.ReadAllLines(filename);
                addSequenceToList(filelines);
            }
        }

        #endregion

        private void buttonDoAlignment_Click(object sender, EventArgs e)
        {
            pairwiseAlignments.Add(new PairwiseAligner(sequences[0], sequences[1]));
            pairwiseAlignments[0].InitializeScoringMatrix();
            pairwiseAlignments[0].printScoringMatrix();
        }

    }
}
