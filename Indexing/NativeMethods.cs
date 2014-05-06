using System;
using System.Runtime.InteropServices;

namespace Indexing
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	internal struct MEMORYSTATUSEX
	{
		internal int dwLength;
		internal int dwMemoryLoad;
		internal long ullTotalPhys;
		internal long ullAvailPhys;
		internal long ullTotalPageFile;
		internal long ullAvailPageFile;
		internal long ullTotalVirtual;
		internal long ullAvailVirtual;
		internal long ullAvailExtendedVirtual;

		internal void Init()
		{
			dwLength = Marshal.SizeOf(typeof(MEMORYSTATUSEX));
		}
	}


	internal sealed class NativeMethods
	{
		private NativeMethods() { }

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal extern static int
			GlobalMemoryStatusEx(ref MEMORYSTATUSEX memoryStatusEx);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal extern static IntPtr VirtualAlloc(IntPtr ptr, int size, int type, int protect);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		internal extern static bool VirtualFree(IntPtr ptr, int size, int type);

	}
}
