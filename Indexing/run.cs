using System;
using System.IO;

namespace Indexing
{
	/// <summary>
	/// Summary description for run.
	/// </summary>
	public class run
	{
		private StreamReader reader;
		private string curLine;
		private string filePath;
		public run(string path)
		{
			try
			{
				reader = new StreamReader(path);
				curLine = reader.ReadLine();
				filePath = path;
			}
			catch(Exception ee)
			{
				ee.Message.ToString();
			}
		}
		~run()
		{
			reader.Close();
			File.Delete(filePath);
		}

		public string currentLine
		{
			get
			{
				return curLine;
			}
		}

		public bool nextLine()
		{
			if((curLine=reader.ReadLine()) != null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool endOfFile()
		{
			if(curLine == null)
				return true;
			else
				return false;
		}
	}
}
