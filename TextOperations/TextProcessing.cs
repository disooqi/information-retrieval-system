using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using DBManagerModule;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace TextOperations
{
    /*
     * Defintion:
     *      Logical View of the Document: they are the words that represent the logic or the context of
     *      the document. These words can be extracted directly from the text or specified by a specialist.
     * 
     * Types Of Documents Logical View:
     *  1- A full text logical view:representing a document by its full set of words.
     *  2- Removing stopwords
     *  3- Stemming
     *  4- The identification of noun groups which eliminates adjectives, adverbs and verbs
     *  5- comression might be employed
     */
        
    public class TextProcessing
    {
        IndexAccess NDXAcc = new IndexAccess();
        TokenizationProcess TokenProc = new TokenizationProcess();
        Case_Folding CFold = new Case_Folding();
        Stop_List stopWList = new Stop_List();
        Stemming StemProc = new Stemming();
        bool provideCaseFolding = false, provideStopWord = false, provideNounGroup = false, provideStemming = false, provideLemmatization = false;
        string indexDirPath = @"D:\Work\Goals\Master\Software\InformationRetrievalSystem\INDEX";
        string stopWordList_File_Path = @"D:\Work\Goals\Master\Software\InformationRetrievalSystem\TextOperations\stopWords.txt";
        
        // Path of TXT file that contains the Path for temporary files
        string temporaryFiles = Path.GetTempPath(); 
        ArrayList Doc_Paths_After_TextProcessing = new ArrayList();
        public TextProcessing(bool isCaseFolding, bool isStopWord, bool isNounGroup, bool isStemming, bool isLemmatization)
        {

            if((provideStopWord = isStopWord)== true)
                stopWList.get_General_Stop_List(stopWordList_File_Path);
            provideCaseFolding = isCaseFolding;
            provideStopWord = isStopWord;   
            provideNounGroup = isNounGroup;
            provideStemming = isStemming;
            provideLemmatization = isLemmatization;
            

        }

        public TextProcessing()
        {
            stopWList.get_General_Stop_List(stopWordList_File_Path);
        }

        public ArrayList Docs_Text_Processing(IEnumerator DocumentPaths)
        {
            try
            {
                DocumentPaths.Reset();
                int docID = 1;
                while (DocumentPaths.MoveNext())
                {
                    try
                    {
                        //the next step hasn't to be her
                        NDXAcc.givingIdForDoc(indexDirPath, docID, DocumentPaths.Current.ToString());
                        Doc_Paths_After_TextProcessing.Add(Text_Proccessing_for_An_Individual_Document(DocumentPaths.Current.ToString(), docID));
                        docID++;
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("error# Indexing.1: " + ee.Message);                       
                    }
                }
                return Doc_Paths_After_TextProcessing;
            }
            catch (Exception ee)
            {
                MessageBox.Show("error# namespace: TextOperations \n class: TextProcessing\n Function#: 2 : \n " + ee.Message);
                return null;
            }   
           
             /* Case-Folding
             * stop-List
             * Stemming
             * Lemmatization
             * */
        }
        public string Text_Proccessing_for_An_Individual_Document(string DocPath, int docID)
        {
            try
            {
                string extensionString = Path.GetExtension(DocPath).ToLower();
                string someText;
                switch (extensionString)
                {
                    case ".txt":

                        StreamReader DocStream = new StreamReader(DocPath);
                        using (StreamWriter ResultDoc = new StreamWriter(temporaryFiles + "\\doc" + docID + ".txt"))
                        {
                            //Doc_Paths_After_Tokenization.Add(temporaryFiles + "\\doc" + docID + ".txt");
                            while ((someText = DocStream.ReadLine()) != null)
                            {
                                ArrayList tokens = GenericTextProcessing(someText);
                                foreach (string tok in tokens)
                                {
                                    ResultDoc.WriteLine(tok);
                                }
                            }
                        }
                        DocStream.Close();
                        break;
                    //case ".pdf":
                    //    PdfReader reader = new PdfReader(DocPath);
                    //    for (int page = 1; page <= reader.NumberOfPages; page++)
                    //    {
                    //        someText = pdfObj.ExtractTextFromPDFBytes(reader.GetPageContent(page));
                    //        ArrayList tokens = lineTokenization(someText);
                    //        linguisticProcessing(tokens, docID);
                    //    }
                    //   reader.Close();
                    //   break;

                }
                return temporaryFiles + "\\doc" + docID + ".txt";
            }
            catch (Exception ee)
            {
                MessageBox.Show("error# Indexing.3" + ee.Message);
                return string.Empty;
            }

        }

        public ArrayList query_Text_Processing(string query)
        {
            return GenericTextProcessing(query);
        }
        
        private ArrayList GenericTextProcessing(string text_Line)
        {
            ArrayList terms = new ArrayList();
            
            terms = TokenProc.lineTokenization(text_Line);
            if (provideCaseFolding)
            CFold.CaseFolding(terms);
            if(provideStopWord)
            stopWList.remove_General_Stop_List(terms);           
            if(provideStemming)
            StemProc.Stem(terms);
            return terms;

        }
    }
    public class TokenizationProcess
    {        
        public ArrayList lineTokenization(string line)
        {
            try
            {
                ArrayList DocTokens = new ArrayList();
                char[] delimiter = new char[45];
                delimiter[0] = ' ';
                delimiter[1] = ',';
                delimiter[2] = '\n';
                delimiter[3] = '\r';
                delimiter[4] = ';';
                delimiter[5] = ':';
                delimiter[6] = '.';//U.S.A
                delimiter[7] = '(';
                delimiter[8] = ')';
                delimiter[9] = '|';
                delimiter[10] = '[';
                delimiter[11] = ']';
                delimiter[12] = '+';
                delimiter[13] = '-';
                delimiter[14] = '*';
                delimiter[15] = '=';
                delimiter[16] = '{';
                delimiter[17] = '<';
                delimiter[18] = '>';
                delimiter[19] = '\'';
                delimiter[20] = '\"';
                delimiter[21] = '}';
                delimiter[22] = '	';
                delimiter[23] = '@';
                delimiter[24] = '!';
                delimiter[25] = '?';
                delimiter[26] = '\\';
                delimiter[27] = '/';
                delimiter[28] = '$';
                delimiter[29] = '#';
                delimiter[30] = '%';
                delimiter[31] = '&';
                delimiter[32] = '^';
                delimiter[33] = '_';
                delimiter[34] = '~';
                delimiter[35] = '';
                delimiter[36] = '�';
                delimiter[37] = '';
                delimiter[38] = '';
                delimiter[39] = '';
                delimiter[40] = '';
                delimiter[41] = '';
                delimiter[42] = '';
                delimiter[43] = '';
                delimiter[44] = '`';
                //line = line.Replace(". "," ");
                //line = line.Replace(".\r"," ");
                DocTokens.AddRange(line.Split(delimiter));
                //DocTokens.Sort();
                int n = DocTokens.Count;
                for (int i = n - 1; i >= 0; i--)
                {
                    if (DocTokens[i].Equals(""))
                    {
                        DocTokens.Remove("");
                    }
                }
                return DocTokens;
            }
            catch (Exception ee)
            {
                MessageBox.Show("error# namespace: TextOperations \n class: TokenizationProcess\n Function#: 1 : \n " + ee.Message);
                return null;
            }
        }
    }
    public class Case_Folding
    {
        public void CaseFolding(ArrayList DocTokens)
        {
            try
            {
               //ArrayList TokensAfterCaseFolding = new ArrayList();
                for (int i = 0; i < DocTokens.Count; i++ )
                {
                    DocTokens[i] = DocTokens[i].ToString().ToLower();
                }
                //foreach (string s in DocTokens)
                //{
                //    TokensAfterCaseFolding.Add(s.ToLower());
                //}
                //return TokensAfterCaseFolding;
            }
            catch (Exception ee)
            {
                MessageBox.Show("CaseFolding: " + ee.Message);
            }
        } 
    }
    public class Stop_List
    {
        private string general_Stop_List_Path = string.Empty;
        private ArrayList general_Stop_List = new ArrayList();
        private ArrayList domain_Specific_Stop_List = new ArrayList();
        IndexAccess NDXAcc = new IndexAccess();

        public Stop_List()
        {
        }
        public void get_General_Stop_List(string userGeneralStopListFilePath)
        {
            try
            {
                general_Stop_List_Path = userGeneralStopListFilePath;
                using (StreamReader stopWordStream = new StreamReader(general_Stop_List_Path))
                {
                    string stopWord = string.Empty;
                    while ((stopWord = stopWordStream.ReadLine()) != null)
                    {
                        general_Stop_List.Add(stopWord);
                    }
                }
            }
            catch (Exception x)
            {
                MessageBox.Show("error# namespace: TextOperations \n class: Stop_List\n Function#: 2 : \n " + x.Message);
            }
        }
        public void get_Domain_Specific_Stop_List(string userDomainSpecificStopListFilePath)
        {

        }
        public void remove_General_Stop_List(ArrayList tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if (general_Stop_List.Contains(tokens[i].ToString()))
                {
                    tokens.Remove(tokens[i--]);
                }
            }

            //read from file
            //using (StreamReader SR = new StreamReader(fileToBeProcessed_Path))
            //{
            //    using (StreamWriter SW = new StreamWriter("C:\\xxx.txt"))
            //    {
            //        string token = string.Empty;
            //        while ((token = SR.ReadLine()) != null)
            //        {
            //            //if not stop word
            //            if (!general_Stop_List.Contains(token))
            //            {
            //                SW.WriteLine(token);
            //                //      write it to a new file
            //            }
            //        }
            //    }
            //}
            
            //
        }
        public void remove_Domain_Specific_Stop_List(string fileToBeProcessed_Path)
        {
        }



    }
    public class Stemming
    {
        private char[] each_word;
        private int i_end, /* offset to end of stemmed word */
            j, k;
        public Stemming()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public override string ToString()
        {
            return new String(each_word, 0, i_end);
        }
        /* cons(i) is true <=> each_word[i] is a consonant. */
        private bool cons(int i)
        {
            switch (each_word[i])
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u': return false;
                case 'y': return (i == 0) ? true : !cons(i - 1);
                default: return true;
            }
        }

        private int m()
        {
            int n = 0;
            int i = 0;
            while (true)
            {
                if (i > j) return n;
                if (!cons(i)) break; i++;
            }
            i++;
            while (true)
            {
                while (true)
                {
                    if (i > j) return n;
                    if (cons(i)) break;
                    i++;
                }
                i++;
                n++;
                while (true)
                {
                    if (i > j) return n;
                    if (!cons(i)) break;
                    i++;
                }
                i++;
            }
        }

        /* vowelinstem() is true <=> 0,...j contains a vowel */
        private bool vowelinstem()
        {
            int i;
            for (i = 0; i <= j; i++)
                if (!cons(i))
                    return true;
            return false;
        }
        /* doublec(j) is true <=> j,(j-1) contain a double consonant. */
        private bool doublec(int j)
        {
            if (j < 1)
                return false;
            if (each_word[j] != each_word[j - 1])
                return false;
            return cons(j);
        }
        /* cvc(i) is true <=> i-2,i-1,i has the form consonant - vowel - consonant
           and also if the second c is not w,x or y. this is used when trying to
           restore an e at the end of a short word. e.g.

              cav(e), lov(e), hop(e), crim(e), but
              snow, box, tray.

        */
        private bool cvc(int i)
        {
            if (i < 2 || !cons(i) || cons(i - 1) || !cons(i - 2))
                return false;
            int ch = each_word[i];
            if (ch == 'w' || ch == 'x' || ch == 'y')
                return false;
            return true;
        }

        private bool ends(String s)
        {
            int l = s.Length;
            int o = k - l + 1;
            if (o < 0)
                return false;
            char[] sc = s.ToCharArray();
            for (int i = 0; i < l; i++)
                if (each_word[o + i] != sc[i])
                    return false;
            j = k - l;
            return true;
        }
        /* setto(s) sets (j+1),...k to the characters in the string s, readjusting
           k. */
        private void setto(String s)
        {
            int l = s.Length;
            int o = j + 1;
            char[] sc = s.ToCharArray();
            for (int i = 0; i < l; i++)
                each_word[o + i] = sc[i];
            k = j + l;
        }

        /* r(s) is used further down. */
        private void r(String s)
        {
            if (m() > 0)
                setto(s);
        }
        /* step1() gets rid of plurals and -ed or -ing. e.g.
               caresses  ->  caress
               ponies    ->  poni
               ties      ->  ti
               caress    ->  caress
               cats      ->  cat

               feed      ->  feed
               agreed    ->  agree
               disabled  ->  disable

               matting   ->  mat
               mating    ->  mate
               meeting   ->  meet
               milling   ->  mill
               messing   ->  mess

               meetings  ->  meet

        */

        private void step1()
        {
            if (each_word[k] == 's')
            {
                if (ends("sses"))
                    k -= 2;
                else if (ends("ies"))
                    setto("i");
                else if (each_word[k - 1] != 's')
                    k--;
            }
            if (ends("eed"))
            {
                if (m() > 0)
                    k--;
            }
            else if ((ends("ed") || ends("ing")) && vowelinstem())
            {
                k = j;
                if (ends("at"))
                    setto("ate");
                else if (ends("bl"))
                    setto("ble");
                else if (ends("iz"))
                    setto("ize");
                else if (doublec(k))
                {
                    k--;
                    int ch = each_word[k];
                    if (ch == 'l' || ch == 's' || ch == 'z')
                        k++;
                }
                else if (m() == 1 && cvc(k)) setto("e");
            }
        }

        /* step2() turns terminal y to i when there is another vowel in the stem. */
        private void step2()
        {
            if (ends("y") && vowelinstem())
                each_word[k] = 'i';
        }

        /* step3() maps double suffices to single ones. so -ization ( = -ize plus
           -ation) maps to -ize etc. note that the string before the suffix must give
           m() > 0. */
        private void step3()
        {
            if (k == 0)
                return;

            switch (each_word[k - 1])
            {
                case 'a':
                    if (ends("ational")) { r("ate"); break; }
                    if (ends("tional")) { r("tion"); break; }
                    break;
                case 'c':
                    if (ends("enci")) { r("ence"); break; }
                    if (ends("anci")) { r("ance"); break; }
                    break;
                case 'e':
                    if (ends("izer")) { r("ize"); break; }
                    break;
                case 'l':
                    if (ends("bli")) { r("ble"); break; }
                    if (ends("alli")) { r("al"); break; }
                    if (ends("entli")) { r("ent"); break; }
                    if (ends("eli")) { r("e"); break; }
                    if (ends("ousli")) { r("ous"); break; }
                    break;
                case 'o':
                    if (ends("ization")) { r("ize"); break; }
                    if (ends("ation")) { r("ate"); break; }
                    if (ends("ator")) { r("ate"); break; }
                    break;
                case 's':
                    if (ends("alism")) { r("al"); break; }
                    if (ends("iveness")) { r("ive"); break; }
                    if (ends("fulness")) { r("ful"); break; }
                    if (ends("ousness")) { r("ous"); break; }
                    break;
                case 't':
                    if (ends("aliti")) { r("al"); break; }
                    if (ends("iviti")) { r("ive"); break; }
                    if (ends("biliti")) { r("ble"); break; }
                    break;
                case 'g':
                    if (ends("logi")) { r("log"); break; }
                    break;
                default:
                    break;
            }
        }

        /* step4() deals with -ic-, -full, -ness etc. similar strategy to step3. */
        private void step4()
        {
            switch (each_word[k])
            {
                case 'e':
                    if (ends("icate")) { r("ic"); break; }
                    if (ends("ative")) { r(""); break; }
                    if (ends("alize")) { r("al"); break; }
                    break;
                case 'i':
                    if (ends("iciti")) { r("ic"); break; }
                    break;
                case 'l':
                    if (ends("ical")) { r("ic"); break; }
                    if (ends("ful")) { r(""); break; }
                    break;
                case 's':
                    if (ends("ness")) { r(""); break; }
                    break;
            }
        }

        /* step5() takes off -ant, -ence etc., in context <c>vcvc<v>. */
        private void step5()
        {
            if (k == 0)
                return;

            switch (each_word[k - 1])
            {
                case 'a':
                    if (ends("al")) break; return;
                case 'c':
                    if (ends("ance")) break;
                    if (ends("ence")) break; return;
                case 'e':
                    if (ends("er")) break; return;
                case 'i':
                    if (ends("ic")) break; return;
                case 'l':
                    if (ends("able")) break;
                    if (ends("ible")) break; return;
                case 'n':
                    if (ends("ant")) break;
                    if (ends("ement")) break;
                    if (ends("ment")) break;
                    /* element etc. not stripped before the m */
                    if (ends("ent")) break; return;
                case 'o':
                    if (ends("ion") && j >= 0 && (each_word[j] == 's' || each_word[j] == 't')) break;

                    if (ends("ou")) break; return;
                /* takes care of -ous */
                case 's':
                    if (ends("ism")) break; return;
                case 't':
                    if (ends("ate")) break;
                    if (ends("iti")) break; return;
                case 'u':
                    if (ends("ous")) break; return;
                case 'v':
                    if (ends("ive")) break; return;
                case 'z':
                    if (ends("ize")) break; return;
                default:
                    return;
            }
            if (m() > 1)
                k = j;
        }

        /* step6() removes a final -e if m() > 1. */
        private void step6()
        {
            j = k;

            if (each_word[k] == 'e')
            {
                int a = m();
                if (a > 1 || a == 1 && !cvc(k - 1))
                    k--;
            }
            if (each_word[k] == 'l' && doublec(k) && m() > 1)
                k--;
        }
        public void Stem(ArrayList tokens)
        {
            for (int i = 0; i< tokens.Count ; i++)
            {
                each_word = tokens[i].ToString().ToCharArray();
                int sizeofchar = each_word.Length - 1;
                k = sizeofchar;
                if (k > 1)
                {
                    step1();
                    step2();
                    step3();
                    step4();
                    step5();
                    step6();
                }
                i_end = k + 1;
                sizeofchar = 0;
                tokens[i] = this.ToString();
            }
            //foreach (string s in tokens)
            //{
            //    each_word = s.ToCharArray();
            //    ;
            //    stemmedTokens.Add(this.ToString());
                
            //}
        }
    }
    public class Lemmatization
    { }

}
