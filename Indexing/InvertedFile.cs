using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DBManagerModule;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace Indexing
{
    public class InvertedFile
    {
        #region data
        private long numberOfLinesInFile = 0;        
        IndexAccess NDXAcc = new IndexAccess();
        Step2File file2;
        private MEMORYSTATUSEX stat = new MEMORYSTATUSEX();
        string indexDirPath = string.Empty; 
        private int runCount = 0;
        ArrayList documentsPaths = new ArrayList();
        ArrayList runPaths = new ArrayList();
        ArrayList runFile = new ArrayList();
        private bool termPositionRequired = false;
        #endregion

        public InvertedFile(ArrayList docPaths, bool isTermPosRequired)
        {
            termPositionRequired = isTermPosRequired;
            indexDirPath = NDXAcc.getIndexDirPath();
            file2 = new Step2File(termPositionRequired);
            documentsPaths.AddRange(docPaths);
        }     
        public void createIndex()
        {
            try
            {
                //sorting terms
                Step1(documentsPaths);

                //Agregate terms in same Documents
                Step2(indexDirPath + "\\step2.txt");

                //Agregate terms in the whole corpus
                Step3(indexDirPath + "\\step3.txt");
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 01:\n" + ee.Message);
            }
        }
        #region Step1 : of index
        private void Step1(ArrayList documentsPaths)// Sort tokens in Documents
        {
            try
            {
                MergeSort(documentsPaths);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 02:\n" + ee.Message);
            }
        }
        private bool isEmpty(ArrayList AL)
        {
            if (AL.Count == 0)
                return true;
            else
                return false;
        }
        private run getSmallestRun(ArrayList runs)
        {
            try
            {
                run small = (run)runs[0];
                for (int i = 1; i < runs.Count; i++)
                {
                    if (tokenToBeProcessed(small.currentLine).CompareTo(tokenToBeProcessed(((run)runs[i]).currentLine)) > 0)
                    {
                        small = (run)runs[i];
                    }
                }
                return small;
            }
            catch (ThreadAbortException te)
            { return null; }
            catch (Exception ee)
            {
                MessageBox.Show("error# 8" + ee.Message);
                return null;
            }
        }
        private void removeNullObj(ArrayList AL)
        {
            foreach (run r in AL)
            {
                if (r.currentLine == null)
                {
                    AL.Remove(r);
                    break;
                }
            }
        }
        #endregion
        #region Step2 : of index
        private void Step2(string sourcePath)
        {
            try
            {
                string destPath = indexDirPath + "\\step3.txt";
                if (!File.Exists(destPath))
                {
                    StreamReader reader = new StreamReader(sourcePath);
                    ArrayList term_Position = new ArrayList();
                    string firstLine = string.Empty;
                    string nextLine = string.Empty;
                    int termFrequency = 1;
                    long countOfLines = 0, countOfAddedFile = 0;
                    firstLine = reader.ReadLine();

                    term_Position.Add(firstLine.Substring(firstLine.IndexOf(':')+1));
                    using (StreamWriter sw = new StreamWriter(destPath, false, Encoding.Unicode))
                    {
                        while (firstLine != null)
                        {
                            countOfLines++;
                            if ((nextLine = reader.ReadLine()) == null)
                                nextLine = "x:";
                            if (firstLine.Substring(0, firstLine.IndexOf(':')).Equals(nextLine.Substring(0, nextLine.IndexOf(':'))))
                            {
                                termFrequency++;
                                term_Position.Add(nextLine.Substring(firstLine.IndexOf(':')+1));                                
                            }
                            else
                            {
                                string terms_Postions_in_Docs = "[";
                                term_Position.Sort();
                                for (int k = 0; k < term_Position.Count; k++)
                                {
                                    terms_Postions_in_Docs += term_Position[k];
                                    if (k != term_Position.Count - 1)
                                        terms_Postions_in_Docs += ",";
                                }
                                    //foreach (string str in term_Position)
                                    //{
                                    //    terms_Postions_in_Docs += str + ",";
                                    //}
                                terms_Postions_in_Docs += "]";
                                sw.WriteLine(firstLine.Substring(0,firstLine.IndexOf(':')) + "," + termFrequency.ToString()+terms_Postions_in_Docs);
                                if (nextLine == "x:")
                                    break;
                                termFrequency = 1;
                                
                                firstLine = nextLine;
                                countOfAddedFile++;
                                term_Position.Clear();
                                term_Position.Add(firstLine.Substring(firstLine.IndexOf(':')+1));
                            }
                        }
                        numberOfLinesInFile = countOfAddedFile;
                        reader.Close();
                        File.Delete(sourcePath);
                    }
                }// if file exist end
                GarbageCollection();
            }// try end
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 09:\n" + ee.Message);
            }
        }
        #endregion
        #region Step3 : of index
        private void Step3(string sourcePath)
        {
            try
            {
                string destPath = indexDirPath + "\\dictionary.txt";
                if (!File.Exists(destPath))
                {
                    StreamReader reader = new StreamReader(sourcePath);
                    string firstToken = string.Empty;
                    string firstLine = string.Empty;
                    string nextLine = string.Empty;
                    string formatedLine = string.Empty;

                    firstLine = reader.ReadLine();
                    long collectionFrequency = getTermFrequency(firstLine), countOfLines = 0;
                    string postingList = getDocID(firstLine) + "," + getTermFrequency(firstLine) + getListOfPositions(firstLine) + ";";
                    using (StreamWriter sw = new StreamWriter(destPath, false, Encoding.Unicode))
                    {
                        while (firstLine != null)
                        {
                            firstToken = tokenToBeProcessed(firstLine);
                            countOfLines++;
                            if (firstToken.Equals(tokenToBeProcessed(nextLine = reader.ReadLine())))
                            {
                                postingList += getDocID(nextLine) + "," + getTermFrequency(nextLine) + getListOfPositions(nextLine) + ";";
                                collectionFrequency += getTermFrequency(nextLine);
                            }
                            else
                            {
                                formatedLine = "\"" + firstToken + "\":" + collectionFrequency.ToString() + ";" + postingList;
                                sw.WriteLine(formatedLine);
                                if (nextLine != null)
                                {
                                    postingList = getDocID(nextLine) + "," + getTermFrequency(nextLine) + getListOfPositions(nextLine) + ";";
                                    collectionFrequency = getTermFrequency(nextLine);
                                }
                                firstLine = nextLine;
                            }
                        }
                        reader.Close();
                        File.Delete(sourcePath);
                    }
                }// if file exist end
                GarbageCollection();
            }// try end
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 10:\n" + ee.Message);
            }
        }

        private long getTermFrequency(string line)
        {
            try
            {
                line = line.Substring(0,line.IndexOf('['));
                return long.Parse(line.Substring(line.LastIndexOf(',') + 1, line.Length - (line.LastIndexOf(',') + 1)));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 11:\n" + ee.Message);
                return -1;
            }
        }
        private string getListOfPositions(string line)
        {
            try
            {
                return line.Substring(line.IndexOf('['), (line.IndexOf(']') - (line.IndexOf('[')))+1);
                //return long.Parse(line.Substring(line.LastIndexOf(',') + 1, line.Length - (line.LastIndexOf(',') + 1)));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 12:\n" + ee.Message);
                return "[]";
            }
        }

        private string getDocID(string line)
        {
            try
            {
                line = line.Substring(0, line.IndexOf('['));
                return line.Substring(line.IndexOf(',') + 1, line.LastIndexOf(',') - (line.IndexOf(',') + 1));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 13:\n" + ee.Message);
                return "-1";
            }
        }

        private string tokenToBeProcessed(string line)
        {
            try
            {
                if (line == null)
                    return line;
                else
                    return line.Substring(line.IndexOf('\"') + 1, line.LastIndexOf('\"') - (line.IndexOf('\"') + 1));
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 14:\n" + ee.Message);
                return "";
            }
        }

        #endregion       
        
        
        #region Merge Sorting
        private void MergeSort(ArrayList documentsPaths)//list of Documents to sort
        {
            try
            {
                CreateRuns(documentsPaths);
                Merge_Runs_into_One_File(runCount);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 03:\n" + ee.Message);
            }

        }
        private void CreateRuns(ArrayList DocPaths)
        {
            try
            {
                int previousNo = 0, currentNo = 0;
                if (termPositionRequired)
                {
                    for (int j = 1; j <= DocPaths.Count; j++)
                    {
                        int token_Position = 1;
                        string token = string.Empty;

                        using (StreamReader DocStream = new StreamReader(DocPaths[j - 1].ToString()))
                        {
                            while ((token = DocStream.ReadLine()) != null)
                            {
                                runFile.Add("\"" + token + "\"," + j + ":" + (token_Position++) + "");
                                if ((currentNo++) >= (previousNo + 300))
                                {
                                    createARun(false);
                                    previousNo = currentNo;
                                }
                            }
                        }

                    }
                }
                else
                {
                    for (int j = 1; j <= DocPaths.Count; j++)
                    {
                        string token = string.Empty;
                        using (StreamReader DocStream = new StreamReader(DocPaths[j - 1].ToString()))
                        {
                            while ((token = DocStream.ReadLine()) != null)
                            {
                                runFile.Add("\"" + token + "\"," + j);
                                if ((currentNo++) >= (previousNo + 300))
                                {
                                    createARun(false);
                                    previousNo = currentNo;
                                }
                            }
                        }
                    }
                }
                createARun(true);
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 04:\n" + ee.Message);
            }
        }        
        private void createARun(bool isNoMoreDoc)
        {
            try
            {
                if (!isMemoryEmpty() || isNoMoreDoc)
                {
                    IComparer termComp = new lineComparer(file2);
                    runFile.Sort(termComp);
                    string path = indexDirPath + "\\run" + (++runCount).ToString() + ".txt";
                    NDXAcc.writingOnFile(runFile, path);
                    runFile.Clear();
                    GarbageCollection();
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 05:\n" + ee.Message);
            }
        }        
        private bool isMemoryEmpty()
        {
            try
            {
                stat.Init();
                NativeMethods.GlobalMemoryStatusEx(ref stat);
                if (stat.ullAvailPhys > 55000000)
                    return true;
                else
                    return false;
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 06:\n" + ee.Message);
                return false;
            }
        }
        private void GarbageCollection()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 07:\n" + ee.Message);
            }
        }
        private void Merge_Runs_into_One_File(int runFileNum)
        {
            try
            {

                long totalLength = 0;
                long destFileLength = 0;
                int threshold = 1000;
                if (!file2.isExist())
                {
                    ArrayList listOfRuns = new ArrayList();
                    for (int i = 1; i <= runFileNum; i++)
                    {
                        string str = string.Concat(indexDirPath, "\\run", (i), ".txt");
                        totalLength += (new FileInfo(str)).Length;
                        listOfRuns.Add((new run(str)));
                    }
                    using (StreamWriter SW = file2.StreamWriterFile2())
                    {
                        while (!isEmpty(listOfRuns))
                        {
                            run smallerObj = getSmallestRun(listOfRuns);
                            SW.WriteLine(smallerObj.currentLine);
                            smallerObj.nextLine();
                            removeNullObj(listOfRuns);

                            if (numberOfLinesInFile++ > threshold)
                            {
                                threshold += 8000;
                                destFileLength = file2.destFile2Length();
                            }
                        }
                    }
                }//if file exist
                GarbageCollection();
            }//end of try
            catch (Exception ee)
            {
                MessageBox.Show("Namespace: Indexing; \nClass: InvertedFile; \nerror# 08:\n" + ee.Message);
            }
        }
        #endregion
    }
    
}
