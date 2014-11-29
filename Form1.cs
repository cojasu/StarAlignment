﻿using System;
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
        STAR star;
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



        private void buttonDoAlignment_Click(object sender, EventArgs e)
        {
            int num = 0;
            foreach(Sequence seq in listBoxInput.Items){
                seq.number = num;
                sequences.Add(seq);
                num++;
            }
            star = new STAR(new PairwiseAlignerManager(sequences));
            star.Execute();

            foreach (Sequence seq in star.optimizedAlignments)
            {
                listBoxOutput.Items.Add(seq);
            }
        }

        #endregion
    }
}
