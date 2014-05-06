using System;
using System.Collections;
using System.IO;
using DBManagerModule;


namespace Indexing
{
	/// <summary>
	/// Summary description for CustomComparer.
	/// </summary>
	public class lineComparer : IComparer  
	{        
        Step2File S2F;
        public lineComparer(Step2File S2FObj)
        {
            S2F = S2FObj;
        }
		int IComparer.Compare( Object x, Object y )  
		{
            string strX = S2F.extract_Token_from_Line(x.ToString());
            string strY = S2F.extract_Token_from_Line(y.ToString());
            if (Comparer.DefaultInvariant.Compare(strX, strY) == 0)
			{
                return (S2F.extract_Doc_ID_from_Line(x.ToString()) - S2F.extract_Doc_ID_from_Line(y.ToString()));
			}
			else
			{
                return Comparer.DefaultInvariant.Compare(strX, strY);
			}
		}




	}

	/*public class runComparer : IComparer  
	{

		int IComparer.Compare( Object x, Object y )  
		{
			string strX = tokenToBeProcessed(((run)x).currentLine);
			string strY = tokenToBeProcessed(((run)y).currentLine);
            if (Comparer.DefaultInvariant.Compare(strX, strY) == 0)
			{
				return(docID(((run)x).currentLine.ToString())-docID(((run)y).currentLine.ToString()));
			}
			else
			{
                return (Comparer.DefaultInvariant.Compare(strX, strY));
			}
		}
        
		private string tokenToBeProcessed(string line)
		{
			return line.Substring(line.IndexOf('\"')+1,line.LastIndexOf('\"')-(line.IndexOf('\"')+1));
		}

		private int docID(string line)
		{
			return int.Parse(line.Substring(line.IndexOf(',')+1,line.Length-(line.IndexOf(',')+1)));
		}


	}*/

}
