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
        PairwiseAlignerManager pam;
        List<Sequence> sequences = new List<Sequence>();

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
            foreach(Sequence seq in listBoxInput.Items){
                sequences.Add(seq);

                Console.WriteLine("Adding Strand: " + seq.strand);
            }

            foreach (Sequence seq in sequences)
            {
                Console.WriteLine(seq.strand);
            }
            pam = new PairwiseAlignerManager(sequences);
            pam.PairwiseAlignerManagerExecute();
            pam.printHighestScorePairwiseAligner();
        }

    }
}
