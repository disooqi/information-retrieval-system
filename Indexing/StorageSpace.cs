using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Indexing
{
	/// <summary>
	/// Summary description for StorageSpace.
	/// </summary>
	public class StorageSpace
	{
		public StorageSpace()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		 public DiskFreeSpace GetDiskFreeSpace(string directoryName)
		{
			DiskFreeSpace result = new DiskFreeSpace();

			if(!GetDiskFreeSpaceEx(directoryName, ref result.FreeBytesAvailable,
				ref result.TotalBytes, ref result.TotalFreeBytes))
			{
				result.FreeBytesAvailable = 0;
				result.TotalBytes = 0;
				result.TotalFreeBytes = 0;
				//throw new Win32Exception(Marshal.GetLastWin32Error(), "Error retrieving free disk space");
			}
			return result;
		}

		public struct DiskFreeSpace
		{
			public long FreeBytesAvailable;
    
			public long TotalBytes;
    
			public long TotalFreeBytes;
		}

		[DllImport("kernel32.dll")]
		private static extern bool GetDiskFreeSpaceEx(string directoryName,
			ref long freeBytesAvailable,
			ref long totalBytes,
			ref long totalFreeBytes);

	}
}
