using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
	[DllImport("user32.dll")]
	public static extern int MessageBox(IntPtr Hwnd, string text, string caption, uint type);

	[DllImport("user32.dll")]
	private static extern int SetWindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);

	[DllImport("user32.dll")]
	static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, uint Flags);


	[DllImport("user32.dll")]
	private static extern IntPtr GetActiveWindow();

	private struct MARGINS
	{
		public int cxLeftWidth;
		public int cxRightWidth;
		public int cyTopHeight;
		public int cyBottomHeight;
	}

	[DllImport("Dwmapi.dll")]
	private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

	const int GWL_EXSTYLE = -20;

	const uint WS_EX_LAYERED = 0x00080000;
	const uint WS_EX_TRANSPARENT = 0x00000020;

	static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);

	public void Start()
	{
		//MessageBox(new IntPtr(0), "Hello World!", "Hello Dio", 0);
#if !UNITY_EDITOR
		IntPtr hWnd = GetActiveWindow();

		//transparent background
		MARGINS margins = new MARGINS { cxLeftWidth = -1 };
		DwmExtendFrameIntoClientArea(hWnd, ref margins);

		//click through 
		//SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

		//always on top
		//SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 0);
#endif
	}
}
