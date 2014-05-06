using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Indexing;
using TextOperations;
namespace InformationRetrievalSystem
{
    public partial class SysInterface : Form
    {
        public SysInterface()
        {
            InitializeComponent();
        }

        private void SysInterface_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Docbutton_Click(object sender, EventArgs e)
        {
            if (Docbutton.BackColor == DefaultBackColor)
                Docbutton.BackColor = Color.BurlyWood;
            else
            {
                Docbutton.BackColor = DefaultBackColor;
                structure_button.BackColor = DefaultBackColor;
                accent_button.BackColor = DefaultBackColor;
                indexing_button.BackColor = DefaultBackColor;
                Stopwords_button.BackColor = DefaultBackColor;
                noun_button.BackColor = DefaultBackColor;
                stemming_button.BackColor = DefaultBackColor;
            }
        }

        private void structure_button_Click(object sender, EventArgs e)
        {
            if (Docbutton.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Documents");
            }
            else{
                if (structure_button.BackColor == DefaultBackColor)
                    structure_button.BackColor = Color.BurlyWood;
                else
                    structure_button.BackColor = DefaultBackColor;
            }

        }

        private void accent_button_Click(object sender, EventArgs e)
        {
            if (Docbutton.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Documents");
            }
            else
            {
                if (accent_button.BackColor == DefaultBackColor)
                    accent_button.BackColor = Color.BurlyWood;
                else
                {
                    accent_button.BackColor = DefaultBackColor;
                    Stopwords_button.BackColor = DefaultBackColor;
                    noun_button.BackColor = DefaultBackColor;
                    stemming_button.BackColor = DefaultBackColor;
                }
            }
        }

        private void Stopwords_button_Click(object sender, EventArgs e)
        {
            if (accent_button.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Accents ...");                
            }
            else
            {
                if (Stopwords_button.BackColor == DefaultBackColor)
                    Stopwords_button.BackColor = Color.BurlyWood;
                else
                {
                    Stopwords_button.BackColor = DefaultBackColor;
                    noun_button.BackColor = DefaultBackColor;
                    stemming_button.BackColor = DefaultBackColor;
                }
            }
        }

        private void noun_button_Click(object sender, EventArgs e)
        {
            if (Stopwords_button.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Stopword ...");
            }
            else
            {
                if (noun_button.BackColor == DefaultBackColor)
                    noun_button.BackColor = Color.BurlyWood;
                else
                    noun_button.BackColor = DefaultBackColor;
            }

        }

        private void stemming_button_Click(object sender, EventArgs e)
        {
            if (Stopwords_button.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Stopword ..."); 
            }
            else
            {
                if (stemming_button.BackColor == DefaultBackColor)
                    stemming_button.BackColor = Color.BurlyWood;
                else
                    stemming_button.BackColor = DefaultBackColor;
            }
        }

        private void indexing_button_Click(object sender, EventArgs e)
        {
            if(Docbutton.BackColor == DefaultBackColor)
            {
                MessageBox.Show("Choose Documents ...");
            }
            else{
                if (indexing_button.BackColor == DefaultBackColor)
                {
                    indexing_button.BackColor = Color.BurlyWood;
                    ArrayList DocPaths = new ArrayList();
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc0.txt");

                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc1.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc2.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc3.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc4.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc5.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc6.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc7.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc8.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc9.txt");
                    DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc10.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc11.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc12.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc13.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc14.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc15.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc16.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc17.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc18.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc19.txt");
                    //DocPaths.Add(@"D:\Work\Goals\Master\Software\InformationRetrievalSystem\Database\doc20.txt");

                    TextProcessing TP = new TextProcessing(checkBox2.Checked, Stopwords_button.BackColor == Color.BurlyWood, noun_button.BackColor == Color.BurlyWood, stemming_button.BackColor == Color.BurlyWood, true);
                    //TextProcessing TP = new TextProcessing();
                    //you may path file with special format to prevent any one else from treating it.
                    InvertedFile IF = new InvertedFile(TP.Docs_Text_Processing(DocPaths.GetEnumerator()), checkBox5.Checked);
                    IF.createIndex();
                }
                else
                    indexing_button.BackColor = DefaultBackColor;
            }
        }

    }
}