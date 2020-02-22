//===================================================================
//Copyright (C) 2010 Scott Wisniewski
//
//Permission is hereby granted, free of charge, to any person obtaining a copy of
//this software and associated documentation files (the "Software"), to deal in
//the Software without restriction, including without limitation the rights to
//use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies
//of the Software, and to permit persons to whom the Software is furnished to do
//so, subject to the following conditions:

//The above copyright notice and this permission notice shall be included in all
//copies or substantial portions of the Software.

//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//SOFTWARE.
//===================================================================

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace youtube_dl_gui {
    internal class OpenFileOrFolderDialog : CommonDialog {
        private int m_cancelWidth;
        private int m_selectWidth;
        private int m_buttonGap;
        private IntPtr m_hWnd;

        private bool m_useCurrentDir;
        private string m_currentFolder;
        private bool m_suppressSelectionChange;
        private bool m_hasDirChangeFired;

        private readonly InteropUtil.SUBCLASSPROC m_openFileSubClassDelegate;
        private readonly InteropUtil.WndProc m_hookDelegate;
        private readonly InteropUtil.SUBCLASSPROC m_defViewSubClassDelegate;

        private delegate void CalcPosDelegate(OpenFileOrFolderDialog @this, int baseRight, out int right, out int width);

        private static readonly Dictionary<int, CalcPosDelegate> m_calcPosMap =
            new Dictionary<int, CalcPosDelegate>
            {
                {
                    InteropUtil.ID_CUSTOM_CANCEL, 
                    (OpenFileOrFolderDialog @this, int baseRight, out int right, out int width) =>
                    {
                        right = baseRight;
                        width = @this.m_cancelWidth;
                    }
                },
                {
                    InteropUtil.ID_SELECT, 
                    (OpenFileOrFolderDialog @this, int baseRight, out int right, out int width) =>
                    {
                        right = baseRight - (@this.m_cancelWidth + @this.m_buttonGap);
                        width = @this.m_selectWidth;
                    }
                }
            };

        public string Path { get; set; }
        public string Title { get; set; }
        public bool ShowReadOnly { get; set; }
        public bool AcceptFiles { get; set; }
        public string FileNameLabel { get; set; }

        public OpenFileOrFolderDialog() {

            m_openFileSubClassDelegate = OpenFileSubClass;
            m_hookDelegate = HookProc;
            m_defViewSubClassDelegate = DefViewSubClass;
            Path = null;
            Title = null;
            m_useCurrentDir = false;
            AcceptFiles = true;
            m_currentFolder = null;
            m_useCurrentDir = false;
            m_cancelWidth = 0;
            m_selectWidth = 0;
            m_buttonGap = 0;
            m_hWnd = IntPtr.Zero;
        }

        public override void Reset() {
            Path = null;
            Title = null;
            m_useCurrentDir = false;
            AcceptFiles = true;
            m_currentFolder = null;
            m_useCurrentDir = false;
            m_cancelWidth = 0;
            m_selectWidth = 0;
            m_buttonGap = 0;
            m_hWnd = IntPtr.Zero;
        }

        protected override bool RunDialog(IntPtr hwndOwner) {
            Util.Assume(Marshal.SystemDefaultCharSize == 2, "The character size should be 2");

            var nativeBuffer = Marshal.AllocCoTaskMem(InteropUtil.NumberOfFileChars * 2);
            IntPtr filterBuffer = IntPtr.Zero;

            try {
                var openFileName = new InteropUtil.OpenFileName();
                openFileName.Initialize();
                openFileName.hwndOwner = hwndOwner;

                var chars = new char[InteropUtil.NumberOfFileChars];

                try {
                    if (File.Exists(Path)) {
                        if (AcceptFiles) {
                            var fileName = System.IO.Path.GetFileName(Path);
                            var length = Math.Min(fileName.Length, InteropUtil.NumberOfFileChars);
                            fileName.CopyTo(0, chars, 0, length);
                            openFileName.lpstrInitialDir = System.IO.Path.GetDirectoryName(Path);
                        }
                        else {
                            openFileName.lpstrInitialDir = System.IO.Path.GetDirectoryName(Path);
                        }
                    }
                    else if (Directory.Exists(Path)) {
                        openFileName.lpstrInitialDir = Path;
                    }
                    else {
                        //the path does not exist.
                        //We don't just want to throw it away, however.
                        //The initial path we get is most likely provided by the user in some way.
                        //It could be what they typed into a text box before clicking a browse button,
                        //or it could be a value they had entered previously that used to be valid, but now no longer exists.
                        //In any case, we don't want to throw out the user's text. So, we find the first parent 
                        //directory of Path that exists on disk.
                        //We will set the initial directory to that path, and then set the initial file to
                        //the rest of the path. The user will get an error if the click "OK"m saying that the selected path
                        //doesn't exist, but that's ok. If we didn't do this, and showed the path, if they clicked
                        //OK without making changes we would actually change the selected path, which would be bad.
                        //This way, if the users want's to change the folder, he actually has to change something.
                        string pathToShow;
                        InitializePathDNE(Path, out openFileName.lpstrInitialDir, out pathToShow);
                        pathToShow = pathToShow ?? "";
                        var length = Math.Min(pathToShow.Length, InteropUtil.NumberOfFileChars);
                        pathToShow.CopyTo(0, chars, 0, length);
                    }
                }
                catch {
                }

                Marshal.Copy(chars, 0, nativeBuffer, chars.Length);

                openFileName.lpstrFile = nativeBuffer;

                if (!AcceptFiles) {
                    var str = string.Format("Folders\0*.{0}-{1}\0\0", Guid.NewGuid().ToString("N"), Guid.NewGuid().ToString("N"));
                    filterBuffer = openFileName.lpstrFilter = Marshal.StringToCoTaskMemUni(str);
                }
                else {
                    openFileName.lpstrFilter = IntPtr.Zero;
                }

                openFileName.nMaxCustFilter = 0;
                openFileName.nFilterIndex = 0;
                openFileName.nMaxFile = InteropUtil.NumberOfFileChars;
                openFileName.nMaxFileTitle = 0;
                openFileName.lpstrTitle = Title;
                openFileName.lpfnHook = m_hookDelegate;
                openFileName.templateID = InteropUtil.IDD_CustomOpenDialog;
                openFileName.hInstance = Marshal.GetHINSTANCE(typeof(OpenFileOrFolderDialog).Module);

                openFileName.Flags =
                    InteropUtil.OFN_DONTADDTORECENT |
                    InteropUtil.OFN_ENABLEHOOK |
                    InteropUtil.OFN_ENABLESIZING |
                    InteropUtil.OFN_NOTESTFILECREATE |
                    InteropUtil.OFN_EXPLORER |
                    InteropUtil.OFN_FILEMUSTEXIST |
                    InteropUtil.OFN_PATHMUSTEXIST |
                    InteropUtil.OFN_NODEREFERENCELINKS |
                    InteropUtil.OFN_ENABLETEMPLATE |
                    (ShowReadOnly ? 0 : InteropUtil.OFN_HIDEREADONLY);

                m_useCurrentDir = false;

                var ret = InteropUtil.GetOpenFileNameW(ref openFileName);
                //var extErrpr = InteropUtil.CommDlgExtendedError();
                //InteropUtil.CheckForWin32Error();

                if (m_useCurrentDir) {
                    Path = m_currentFolder;
                    return true;
                }
                else if (ret) {
                    Marshal.Copy(nativeBuffer, chars, 0, chars.Length);
                    var firstZeroTerm = ((IList)chars).IndexOf('\0');
                    if (firstZeroTerm >= 0 && firstZeroTerm <= chars.Length - 1) {
                        Path = new string(chars, 0, firstZeroTerm);
                    }
                }
                return ret;
            }
            finally {
                Marshal.FreeCoTaskMem(nativeBuffer);
                if (filterBuffer != IntPtr.Zero) {
                    Marshal.FreeCoTaskMem(filterBuffer);
                }
            }
        }

        private static void InitializePathDNE(string path, out string existingParent, out string initialFileNameText) {
            var stack = new Stack<string>();
            existingParent = System.IO.Path.GetDirectoryName(path);
            stack.Push(System.IO.Path.GetFileName(path));

            while (!string.IsNullOrEmpty(existingParent) && !Directory.Exists(existingParent)) {
                stack.Push(existingParent);
                existingParent = System.IO.Path.GetDirectoryName(existingParent);
            }

            var builder = new StringBuilder();
            bool first = true;
            while (stack.Count > 0) {
                if (!first) {
                    builder.Append(System.IO.Path.PathSeparator);
                }
                else {
                    first = false;
                }
                builder.Append(stack.Pop());
            }
            initialFileNameText = builder.ToString();
        }


        protected override IntPtr HookProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lparam) {
            switch (unchecked((uint)msg)) {
                case InteropUtil.WM_INITDIALOG: {
                        InitDialog(hWnd);
                        break;
                    }
                case InteropUtil.WM_NOTIFY: {
                        var notifyData = (InteropUtil.OFNOTIFY)Marshal.PtrToStructure(lparam, typeof(InteropUtil.OFNOTIFY));
                        var results = ProcessNotifyMessage(hWnd, notifyData);
                        if (results != 0) {
                            hWnd.SetWindowLongW(InteropUtil.DWL_MSGRESULT, results);
                            return (IntPtr)results;
                        }
                        break;
                    }
                case InteropUtil.WM_SIZE: {
                        ResizeCustomControl(hWnd);
                        break;
                    }
                case InteropUtil.WM_COMMAND: {
                        unchecked {
                            var hParent = hWnd.GetParent().AssumeNonZero();
                            var code = HIGH((uint)wParam);
                            var id = LOW((uint)wParam);
                            if (code == InteropUtil.BN_CLICKED) {
                                switch (id) {
                                    case InteropUtil.ID_CUSTOM_CANCEL: {
                                            //The user clicked our custom cancel button. Close the dialog.
                                            hParent.SendMessage(InteropUtil.WM_CLOSE, 0, 0);
                                            break;
                                        }
                                    case InteropUtil.ID_SELECT: {
                                            var hFileName = hParent.GetDlgItem(InteropUtil.ID_FileNameCombo);
                                            var currentText = (hFileName.GetWindowTextW() ?? "").Trim();
                                            if (currentText == "" && !String.IsNullOrEmpty(m_currentFolder)) {
                                                //there's not text in the box, so the user must want to select the current folder.
                                                m_useCurrentDir = true;
                                                hParent.SendMessage(InteropUtil.WM_CLOSE, 0, 0);
                                                break;
                                            }
                                            else if (System.IO.Path.IsPathRooted(currentText)) {
                                                if (Directory.Exists(currentText)) {
                                                    //the contents of the text box are a rooted path, that points to an existing directory.
                                                    //we interpret that to mean that the user wants to select that directory.
                                                    m_useCurrentDir = true;
                                                    m_currentFolder = currentText;
                                                    hParent.SendMessage(InteropUtil.WM_CLOSE, 0, 0);
                                                    break;
                                                }
                                            }
                                            else if (!String.IsNullOrEmpty(m_currentFolder) && currentText != "") {
                                                var combined = System.IO.Path.Combine(m_currentFolder, currentText);
                                                if (Directory.Exists(combined)) {
                                                    //the contents of the text box are a relative path, that points to a 
                                                    //an existing directory. We interpret the users intent to mean that they wanted
                                                    //to select the existing path.
                                                    m_useCurrentDir = true;
                                                    m_currentFolder = combined;
                                                    hParent.SendMessage(InteropUtil.WM_CLOSE, 0, 0);
                                                    break;
                                                }
                                            }

                                            //The user has not selected an existing folder.
                                            //So we translate a click of our "Select" button into the OK button and forward the request to the
                                            //open file dialog.
                                            hParent.SendMessage
                                            (
                                                InteropUtil.WM_COMMAND,
                                                (InteropUtil.BN_CLICKED << 16) | InteropUtil.IDOK,
                                                unchecked((uint)hParent.GetDlgItem(InteropUtil.IDOK))
                                            );
                                            break;
                                        }
                                }
                            }
                        }
                        break;
                    }
            }
            return base.HookProc(hWnd, msg, wParam, lparam);
        }

        private void InitDialog(IntPtr hWnd) {
            m_hWnd = hWnd;

            var hParent = hWnd.GetParent().AssumeNonZero();
            hParent.SetWindowSubclass(m_openFileSubClassDelegate, 0, 0);

            //disable and hide the filter combo box
            var hFilterCombo = hParent.GetDlgItem(InteropUtil.ID_FilterCombo).AssumeNonZero();
            hFilterCombo.EnableWindow(false);
            hParent.SendMessage(InteropUtil.CDM_HIDECONTROL, InteropUtil.ID_FilterCombo, 0);
            hParent.SendMessage(InteropUtil.CDM_HIDECONTROL, InteropUtil.ID_FilterLabel, 0);

            //update the file name label
            var hFileNameLabel = hParent.GetDlgItem(InteropUtil.ID_FileNameLabel).AssumeNonZero();

            if (FileNameLabel != "") {
                hFileNameLabel.SendMessageString(InteropUtil.WM_SETTEXT, 0, FileNameLabel);
            }

            //find the button controls in the parent
            var hOkButton = hParent.GetDlgItem(InteropUtil.IDOK).AssumeNonZero();
            var hCancelButton = hParent.GetDlgItem(InteropUtil.IDCANCEL).AssumeNonZero();

            //We don't want the accelerator keys for the ok and cancel buttons to work, because
            //they are not shown on the dialog. However, we still want the buttons enabled
            //so that "esc" and "enter" have the behavior they used to. So, we just
            //clear out their text instead.
            hOkButton.SetWindowTextW("");
            hCancelButton.SetWindowTextW("");

            //find our button controls
            var hSelectButton = hWnd.GetDlgItem(InteropUtil.ID_SELECT).AssumeNonZero();
            var hCustomCancelButton = hWnd.GetDlgItem(InteropUtil.ID_CUSTOM_CANCEL).AssumeNonZero();

            //copy the font from the parent's buttons
            hSelectButton.LoadFontFrom(hOkButton);
            hCustomCancelButton.LoadFontFrom(hCancelButton);

            var cancelLoc = hCancelButton.GetWindowPlacement();

            //hide the ok and cancel buttons
            hParent.SendMessage(InteropUtil.CDM_HIDECONTROL, InteropUtil.IDOK, 0);
            hParent.SendMessage(InteropUtil.CDM_HIDECONTROL, InteropUtil.IDCANCEL, 0);

            //expand the file name combo to take up the space left by the OK and cancel buttons.
            var hFileName = hParent.GetDlgItem(InteropUtil.ID_FileNameCombo).AssumeNonZero();
            var fileNameLoc = hFileName.GetWindowPlacement();
            fileNameLoc.Right = hOkButton.GetWindowPlacement().Right;
            hFileName.SetWindowPlacement(ref fileNameLoc);

            var parentLoc = hParent.GetWindowPlacement();

            //subtract the height of the missing cancel button
            parentLoc.Bottom -= (cancelLoc.Bottom - cancelLoc.Top);
            hParent.SetWindowPlacement(ref parentLoc);

            //move the select and custom cancel buttons to the right hand side of the window:

            var selectLoc = hSelectButton.GetWindowPlacement();
            var customCancelLoc = hCustomCancelButton.GetWindowPlacement();
            m_cancelWidth = customCancelLoc.Right - customCancelLoc.Left;
            m_selectWidth = selectLoc.Right - selectLoc.Left;
            m_buttonGap = customCancelLoc.Left - selectLoc.Right;

            var ctrlLoc = hWnd.GetWindowPlacement();
            ctrlLoc.Right = fileNameLoc.Right;

            //ResizeCustomControl(hWnd, fileNameLoc.Right, hCustomCancelButton, hSelectButton);
            ResizeCustomControl(hWnd);
        }

        private void ResizeCustomControl(IntPtr hWnd) {
            if (hWnd == m_hWnd) {
                var hSelectButton = hWnd.AssumeNonZero().GetDlgItem(InteropUtil.ID_SELECT).AssumeNonZero();
                var hOkButton = hWnd.AssumeNonZero().GetDlgItem(InteropUtil.ID_CUSTOM_CANCEL).AssumeNonZero();

                var hParent = hWnd.GetParent().AssumeNonZero();
                var fileName = hParent.GetDlgItem(InteropUtil.ID_FileNameCombo).AssumeNonZero();

                /*var right = fileName.GetWindowPlacement().Right;
                var top = hSelectButton.GetWindowPlacement().Top;*/

                var rect = new InteropUtil.RECT();
                var selectRect = hSelectButton.GetWindowPlacement();

                rect.top = selectRect.Top;
                rect.bottom = selectRect.Bottom;
                rect.right = fileName.GetWindowPlacement().Right;
                rect.left = rect.right - (m_cancelWidth + m_buttonGap + m_selectWidth);

                ResizeCustomControl(hWnd, rect, hOkButton, hSelectButton);
            }
        }

        private void ResizeCustomControl(IntPtr hWnd, InteropUtil.RECT rect, params IntPtr[] buttons) {
            Util.Assume(buttons != null && buttons.Length > 0);

            hWnd.AssumeNonZero();

            var wndLoc = hWnd.GetWindowPlacement();

            wndLoc.Right = rect.right;
            hWnd.SetWindowPlacement(ref wndLoc);

            foreach (var hBtn in buttons) {
                int btnRight, btnWidth;

                m_calcPosMap[hBtn.GetDlgCtrlID()](this, rect.right, out btnRight, out btnWidth);

                PositionButton(hBtn, btnRight, btnWidth);
            }

            //see bug # 844
            //We clip hWnd to only draw in the rectangle around our custom buttons.
            //When we supply a custom dialog template to GetOpenFileName(), it adds 
            //an extra HWND to the open file dialog, and then sticks all the controls 
            //in the dialog //template inside the HWND. It then resizes the control 
            //to stretch from the top of the open file dialog to the bottom of the 
            //window, extending the bottom of the window large enough to include the 
            //additional height of the dialog template. This ends up sticking our custom
            //buttons at the bottom of the window, which is what we want.
            //
            //However, the fact that the parent window extends from the top of the open 
            //file dialog was causing some painting problems on Windows XP SP 3 systems. 
            //Basically, because the window was covering the predefined controls on the 
            //open file dialog, they were not getting painted. This results in a blank 
            //window. I tried setting an extended WS_EX_TRANSPARENT style on the dialog, 
            //but that didn't help.
            //
            //So, to fix the problem I setup a window region for the synthetic HWND. 
            //This clips the drawing of the window to only within the region containing
            //the custom buttons, and thus avoids the problem.
            //
            //I'm not sure why this wasn't an issue on Vista. 
            var hRgn = InteropUtil.CreateRectRgnIndirect(ref rect);
            try {
                if (hWnd.SetWindowRgn(hRgn, true) == 0) {
                    //setting the region failed, so we need to delete the region we created above.
                    hRgn.DeleteObject();
                }
            }
            catch {

                if (hRgn != IntPtr.Zero) {
                    hRgn.DeleteObject();
                }
            }
        }

        private void PositionButton(IntPtr hWnd, int right, int width) {
            hWnd.AssumeNonZero();
            var id = hWnd.GetDlgCtrlID();

            //hWnd.BringWindowToTop();

            var buttonLoc = hWnd.GetWindowPlacement();

            buttonLoc.Right = right;
            buttonLoc.Left = buttonLoc.Right - width;
            hWnd.SetWindowPlacement(ref buttonLoc);
            hWnd.InvalidateRect(IntPtr.Zero, true);

        }

        private int ProcessNotifyMessage(IntPtr hWnd, InteropUtil.OFNOTIFY notifyData) {
            switch (notifyData.hdr_code) {
                case InteropUtil.CDN_FOLDERCHANGE: {
                        var newFolder = GetTextFromCommonDialog(hWnd.GetParent().AssumeNonZero(), InteropUtil.CDM_GETFOLDERPATH);
                        if (m_currentFolder != null && newFolder != null && newFolder.PathContains(m_currentFolder)) {
                            m_suppressSelectionChange = true;
                        }
                        m_currentFolder = newFolder;
                        var fileNameCombo = hWnd.GetParent().AssumeNonZero().GetDlgItem(InteropUtil.ID_FileNameCombo).AssumeNonZero();
                        if (m_hasDirChangeFired) {
                            fileNameCombo.SetWindowTextW("");
                        }
                        m_hasDirChangeFired = true;
                        break;
                    }
                case InteropUtil.CDN_FILEOK: {
                        if (!AcceptFiles) {
                            return 1;
                        }
                        break;
                    }
                case InteropUtil.CDN_INITDONE: {
                        var hParent = hWnd.GetParent();
                        var hFile = hParent.AssumeNonZero().GetDlgItem(InteropUtil.ID_FileNameCombo).AssumeNonZero();
                        hFile.SetFocus();
                        break;
                    }
            }

            return 0;
        }


        private string GetTextFromCommonDialog(IntPtr hWnd, uint msg) {
            string str = null;
            var buffer = Marshal.AllocCoTaskMem(2 * InteropUtil.NumberOfFileChars);
            try {
                hWnd.SendMessage(msg, InteropUtil.NumberOfFileChars, unchecked((uint)buffer));
                var chars = new char[InteropUtil.NumberOfFileChars];
                Marshal.Copy(buffer, chars, 0, chars.Length);
                var firstZeroTerm = ((IList)chars).IndexOf('\0');

                if (firstZeroTerm >= 0 && firstZeroTerm <= chars.Length - 1) {
                    str = new string(chars, 0, firstZeroTerm);
                }

            }
            finally {
                Marshal.FreeCoTaskMem(buffer);
            }
            return str;
        }

        private int DefViewSubClass
        (
            IntPtr hWnd,
            uint uMsg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr uIdSubclass,
            uint dwRefData
        ) {
            if (uMsg == InteropUtil.WM_NOTIFY) {
                var header = (InteropUtil.NMHDR)Marshal.PtrToStructure(lParam, typeof(InteropUtil.NMHDR));
                if (header.code == InteropUtil.LVN_ITEMCHANGED && header.hwndFrom != IntPtr.Zero && header.idFrom == 1) {
                    var nmListView = (InteropUtil.NMLISTVIEW)Marshal.PtrToStructure(lParam, typeof(InteropUtil.NMLISTVIEW));
                    var oldSelected = (nmListView.uOldState & InteropUtil.LVIS_SELECTED) != 0;
                    var newSelected = (nmListView.uNewState & InteropUtil.LVIS_SELECTED) != 0;
                    if (!oldSelected && newSelected) {
                        if (!m_suppressSelectionChange) {
                            //the item went from not selected to being selected    
                            //so we want to look and see if the selected item is a folder, and if so
                            //change the text of the item box to be the item on the folder. But, before we do that
                            //we want to make sure that the box isn't currently focused.
                            var hParent = hWnd.GetParent();
                            var hFNCombo = hParent.GetDlgItem(InteropUtil.ID_FileNameCombo);
                            var hFNEditBox = hParent.GetDlgItem(InteropUtil.ID_FileNameTextBox);
                            var hFocus = InteropUtil.GetFocus();

                            if
                            (
                                (hFNCombo == IntPtr.Zero || hFNCombo != hFocus) &&
                                (hFNEditBox == IntPtr.Zero || hFNEditBox != hFocus)
                            ) {
                                SetFileNameToSelectedItem(header.hwndFrom, hFNCombo, nmListView.iItem);
                            }
                        }
                        m_suppressSelectionChange = false;
                    }
                }
            }
            return hWnd.DefSubclassProc(uMsg, wParam, lParam);
        }

        private void SetFileNameToSelectedItem(IntPtr hListView, IntPtr hFNCombo, int selectedIndex) {
            if (selectedIndex >= 0) {
                var lvitem = new InteropUtil.LVITEM();
                lvitem.mask = InteropUtil.LVIF_TEXT;
                var nativeBuffer = Marshal.AllocCoTaskMem(InteropUtil.NumberOfFileChars * 2);
                for (int i = 0; i < InteropUtil.NumberOfFileChars; ++i) {
                    Marshal.WriteInt16(nativeBuffer, i * 2, '\0');
                }
                string name;

                try {
                    Marshal.WriteInt16(nativeBuffer, 0);
                    lvitem.pszText = nativeBuffer;
                    lvitem.cchTextMax = InteropUtil.NumberOfFileChars;
                    var length = hListView.SendListViewMessage(InteropUtil.LVM_GETITEMTEXT, (uint)selectedIndex, ref lvitem);
                    name = Marshal.PtrToStringUni(lvitem.pszText, (int)length);
                }
                finally {
                    Marshal.FreeCoTaskMem(nativeBuffer);
                }

                if (name != null && m_currentFolder != null) {
                    try {
                        var path = System.IO.Path.Combine(m_currentFolder, name);
                        if (Directory.Exists(path)) {
                            hFNCombo.SetWindowTextW(name);
                        }
                    }
                    catch (Exception) {
                    }

                }
            }
        }

        private int OpenFileSubClass
        (
            IntPtr hWnd,
            uint uMsg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr uIdSubclass,
            uint dwRefData
        ) {
            switch (uMsg) {
                case InteropUtil.WM_PARENTNOTIFY: {
                        unchecked {
                            var id = lParam.GetDlgCtrlID();

                            if (LOW((uint)wParam) == InteropUtil.WM_CREATE && (id == InteropUtil.ID_FileList || id == 0)) {
                                lParam.SetWindowSubclass(m_defViewSubClassDelegate, 0, 0);
                            }
                        }
                        break;
                    }
            }
            return hWnd.DefSubclassProc(uMsg, wParam, lParam);
        }

        private static uint LOW(uint x) {
            return x & 0xFFFF;
        }

        private static uint HIGH(uint x) {
            return (x & 0xFFFF0000) >> 16;
        }

    }

    internal static class InteropUtil {
        [StructLayout(LayoutKind.Sequential)]
        public struct OpenFileName {
            public int lStructSize;
            public IntPtr hwndOwner;
            public IntPtr hInstance;
            public IntPtr lpstrFilter;
            public IntPtr lpstrCustomFilter;
            public int nMaxCustFilter;
            public int nFilterIndex;
            public IntPtr lpstrFile;
            public int nMaxFile;
            public IntPtr lpstrFileTitle;
            public int nMaxFileTitle;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpstrInitialDir;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpstrTitle;
            public int Flags;
            public short nFileOffset;
            public short nFileExtension;
            public string lpstrDefExt;
            public IntPtr lCustData;
            public WndProc lpfnHook;
            public int templateID;
            public IntPtr pvReserved;
            public int dwReserved;
            public int FlagsEx;

            public void Initialize() {
                lStructSize = Marshal.SizeOf(typeof(OpenFileName));
                lpstrCustomFilter = IntPtr.Zero;
                lpstrFileTitle = IntPtr.Zero;
                lCustData = IntPtr.Zero;
                pvReserved = IntPtr.Zero;
            }
        }

        public delegate IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [StructLayout(LayoutKind.Sequential)]
        public struct OFNOTIFY {
            public IntPtr hdr_hwndFrom;
            public IntPtr hdr_idFrom;
            public uint hdr_code;
            public IntPtr lpOFN;
            public IntPtr pszFile;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NMLISTVIEW {
            public NMHDR hdr;
            public int iItem;
            public int iSubItem;
            public uint uNewState;
            public uint uOldState;
            public uint uChanged;
            public Point ptAction;
            public int lParam;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWPLACEMENT {
            public static WINDOWPLACEMENT New() {
                return
                    new WINDOWPLACEMENT {
                        length = ((uint)Marshal.SizeOf(typeof(WINDOWPLACEMENT)))
                    };
            }

            public uint length;
            public uint flags;
            public uint showCmd;
            public Point ptMinPosition;
            public Point ptMaxPosition;
            public RECT rcNormalPosition;

            public int Left {
                get { return rcNormalPosition.left; }
                set { rcNormalPosition.left = value; }
            }

            public int Top {
                get { return rcNormalPosition.top; }
                set { rcNormalPosition.top = value; }
            }

            public int Right {
                get { return rcNormalPosition.right; }
                set { rcNormalPosition.right = value; }
            }

            public int Bottom {
                get { return rcNormalPosition.bottom; }
                set { rcNormalPosition.bottom = value; }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Point {

            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT {


            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        public delegate int SUBCLASSPROC
        (
            IntPtr hWnd,
            uint uMsg,
            IntPtr wParam,
            IntPtr lParam,
            IntPtr uIdSubclass,
            uint dwRefData
        );

        [StructLayout(LayoutKind.Sequential)]
        public struct NMHDR {
            public IntPtr hwndFrom;
            public uint idFrom;
            public uint code;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LVITEM {
            public uint mask;
            public int iItem;
            public int iSubItem;
            public uint state;
            public uint stateMask;
            public IntPtr pszText;
            public int cchTextMax;
            public int iImage;
            public int lParam;
            public int iIndent;
            public int iGroupId;
            public uint cColumns;
            public IntPtr puColumns;
            public IntPtr piColFmt;
            public int iGroup;
        }

        [DllImport("comctl32.dll", EntryPoint = "SetWindowSubclass")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowSubclass
        (
            this IntPtr hWnd,
            SUBCLASSPROC pfnSubclass,
            uint uIdSubclass,
            uint dwRefData
        );


        [DllImport("comctl32.dll", EntryPoint = "DefSubclassProc")]
        public static extern int DefSubclassProc
        (
            this IntPtr hWnd,
            uint uMsg,
            IntPtr wParam,
            IntPtr lParam
        );

        [DllImport("comdlg32.dll", EntryPoint = "GetOpenFileNameW")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetOpenFileNameW(ref OpenFileName openFileNameInfo);

        [DllImport("kernel32.dll", EntryPoint = "GetLastError")]
        public static extern uint GetLastError();

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern uint SendMessage
        (
            [In] this IntPtr hWnd,
            uint Msg,
            uint wParam,
            uint lParam
        );

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern uint SendListViewMessage
        (
            [In] this IntPtr hWnd,
            uint Msg,
            uint wParam,
            ref LVITEM lParam
        );

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern uint SendMessageString
        (
            [In] this IntPtr hWnd,
            uint Msg,
            uint wParam,
            [MarshalAs(UnmanagedType.LPWStr)]
            string str
        );

        [DllImport("user32.dll", EntryPoint = "GetDlgItem")]
        public static extern IntPtr GetDlgItem
        (
            [In] this IntPtr hDlg,
            int nIDDlgItem
        );

        [DllImport("user32.dll", EntryPoint = "GetWindowTextW")]
        public static extern int GetWindowTextW
        (
            [In] this IntPtr hWnd,
            [
                Out,
                MarshalAs(UnmanagedType.LPWStr)
            ] 
            StringBuilder lpString,
            int nMaxCount
        );

        public static string GetWindowTextW(this IntPtr hWnd) {
            var builder = new StringBuilder(NumberOfFileChars);
            if (hWnd.GetWindowTextW(builder, builder.Capacity) > 0) {
                return builder.ToString();
            }
            return "";
        }

        [DllImport("user32.dll", EntryPoint = "GetParent")]
        public static extern IntPtr GetParent([In] this IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "EnableWindow")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool EnableWindow([In] this IntPtr hWnd, [MarshalAs(UnmanagedType.Bool)] bool bEnable);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongW")]
        public static extern int SetWindowLongW
        (
            [In] this IntPtr hWnd,
            int nIndex,
            int dwNewLong
        );

        [DllImport("user32.dll", EntryPoint = "SetWindowTextW")]
        public static extern bool SetWindowTextW
        (
            [In] this IntPtr hWnd,
            [In] [MarshalAs(UnmanagedType.LPWStr)] 
            string lpString
        );

        [DllImport("user32.dll", EntryPoint = "GetFocus")]
        public static extern IntPtr GetFocus();

        [DllImport("user32.dll", EntryPoint = "GetDlgCtrlID")]
        public static extern int GetDlgCtrlID([In] this IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetFocus")]
        public static extern IntPtr SetFocus([In] this IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "SetWindowPlacement")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPlacement
        (
            [In] this IntPtr hWnd,
            [In] ref WINDOWPLACEMENT lpwndpl
        );

        [DllImport("user32.dll", EntryPoint = "InvalidateRect")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect
        (
            [In] this IntPtr hWnd,
            IntPtr lpRect,
            [MarshalAs(UnmanagedType.Bool)] bool bErase
        );


        public static void LoadFontFrom(this IntPtr hWndDest, IntPtr hWndSrc) {
            hWndDest.AssumeNonZero();
            hWndSrc.AssumeNonZero();

            var hFont = (IntPtr)unchecked((int)SendMessage(hWndSrc, WM_GETFONT, 0, 0));
            hFont.AssumeNonZero();

            SendMessage(hWndDest, WM_SETFONT, (uint)hFont, 0);
        }

        public static WINDOWPLACEMENT GetWindowPlacement(this IntPtr hwnd) {
            WINDOWPLACEMENT ret = WINDOWPLACEMENT.New();

            if (!hwnd.GetWindowPlacement(ref ret)) {
                CheckForWin32Error();
            }
            return ret;
        }

        [DllImport("user32.dll", EntryPoint = "GetWindowPlacement")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement
        (
            [In] this IntPtr hWnd,
            ref WINDOWPLACEMENT lpwndpl
        );

        public static void CheckForWin32Error() {
            var error = GetLastError();
            if (error != 0) {
                throw new Win32Exception(unchecked((int)error));
            }
        }

        [DllImport("gdi32.dll", EntryPoint = "CreateRectRgnIndirect")]
        public static extern IntPtr CreateRectRgnIndirect
        (
            [In] ref RECT lpRect
        );

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject
        (
            [In] this IntPtr hObject
        );

        [DllImport("user32.dll", EntryPoint = "SetWindowRgn")]
        public static extern int SetWindowRgn
        (
            [In] this IntPtr hWnd,
            [In] IntPtr hRgn,
            [MarshalAs(UnmanagedType.Bool)] bool bRedraw
        );

        //What follows here are a bunch of magic constants needed for
        //windows message passing. One could make an argument that it would be
        //more "C#ish" to package these all up into enum types, and then to
        //create appropriate overloads of the "extern" functions that take in 
        //enum types.
        //
        //However, I wanted to keep the calls to API functions as close to
        //the documentation as possible. That way if you look at the stuff and wonder 
        //"what the hell is this" you can just look it up in MSDN and get an answer. 
        //I did make some things extension methods, to improve readability, but otherwise 
        //the code pretty much looks like it would if it were written in C. 

        //===========================================================
        //Open File Name flag constants
        public const int OFN_NODEREFERENCELINKS = 0x00100000;
        public const int OFN_NOTESTFILECREATE = 0x00010000;
        public const int OFN_DONTADDTORECENT = 0x02000000;
        public const int OFN_ENABLETEMPLATE = 0x00000040;
        public const int OFN_PATHMUSTEXIST = 0x00000800;
        public const int OFN_FILEMUSTEXIST = 0x00001000;
        public const int OFN_HIDEREADONLY = 0x00000004;
        public const int OFN_ENABLESIZING = 0x00800000;
        public const int OFN_ENABLEHOOK = 0x00000020;
        public const int OFN_EXPLORER = 0x00080000;
        //===========================================================

        //===========================================================
        //List View flags
        public const int LVIF_TEXT = 0x00000001;
        public const int LVIS_SELECTED = 0x0002;
        //===========================================================

        //===========================================================
        //Common Dialog notifications
        public const uint CDN_FOLDERCHANGE = (CDN_FIRST - 2);
        public const uint CDN_INITDONE = (CDN_FIRST - 0);
        public const uint CDN_FILEOK = (CDN_FIRST - 5);
        public const uint CDN_FIRST = unchecked(0u - 601u);
        //===========================================================

        //===========================================================
        //button notifications
        public const int BN_CLICKED = 0;
        //===========================================================

        //===========================================================
        //List View Notifications
        public const uint LVN_FIRST = unchecked(0U - 100U);
        public const uint LVN_ITEMCHANGED = (LVN_FIRST - 1);
        //===========================================================

        //===========================================================
        //Common Dialog Messages
        public const uint CDM_FIRST = WM_USER + 100;
        public const uint CDM_HIDECONTROL = CDM_FIRST + 0x0005;
        public const uint CDM_GETFOLDERPATH = CDM_FIRST + 0x0002;
        //===========================================================

        //===========================================================
        //Windows Messages
        public const uint WM_CREATE = 0x0001;
        public const uint WM_USER = 0x0400;
        public const uint WM_NOTIFY = 0x4E;
        public const uint WM_INITDIALOG = 0x0110;
        public const uint WM_SETFONT = 0x0030;
        public const uint WM_GETFONT = 0x0031;
        public const uint WM_SIZE = 0x0005;
        public const uint WM_COMMAND = 0x0111;
        public const uint WM_SETTEXT = 0x000C;
        public const uint WM_PARENTNOTIFY = 0x0210;
        public const uint WM_CLOSE = 0x0010;
        //===========================================================

        //===========================================================
        //List View Messages
        public const uint LVM_FIRST = 0x1000;
        public const uint LVM_GETITEMTEXT = LVM_FIRST + 115;
        //===========================================================

        public const int DWL_MSGRESULT = 0;

        //Control id's for common dialog box controls
        //see http://msdn.microsoft.com/en-us/library/ms646960.aspx#_win32_Explorer_Style_Control_Identifiers
        //for a complete list.
        public const int stc2 = 0x0441;
        public const int cmb1 = 0x0470;
        public const int stc3 = 0x0442;
        public const int edt1 = 0x0480;
        public const int cmb13 = 0x047c;
        public const int lst2 = 0x0461;
        public const int IDOK = 1;
        public const int IDCANCEL = 2;
        //control aliases that actually make sense....
        public const int ID_FilterCombo = cmb1;
        public const int ID_FilterLabel = stc2;
        public const int ID_FileNameLabel = stc3;
        public const int ID_FileNameTextBox = edt1;
        public const int ID_FileNameCombo = cmb13;
        public const int ID_FileList = lst2;

        //NOTE:
        //These constants are also defined in resource.h
        //Please don't update the value without changing the values there as well.
        public const int IDD_CustomOpenDialog = 101;
        public const int ID_SELECT = 1001;
        public const int ID_CUSTOM_CANCEL = 1002;

        public const int NumberOfFileChars = 8192;
    }
    internal static class Util {
        public static void Assume
        (
            bool condition,
            string message
        ) {
            if (!condition) {
                throw new InternalErrorException(message);
            }
        }


        public static T AssumeNotNull<T>
        (
            this T item
        ) where T : class {
            Assume(item != null, "Unexpected null value!");
            return item;
        }

        public static void Assume
        (
            bool condition
        ) {
            Assume(condition, "The condition should not be false!");
        }

        public static IntPtr AssumeNonZero
        (
            this IntPtr item
        ) {
            Assume(item != IntPtr.Zero);
            return item;
        }

        public static bool PathContains(this string parent, string child) {
            parent.AssumeNotNull();
            child.AssumeNotNull();

            if (!parent.EndsWith("\\")) {
                parent = parent + "\\";
            }

            return
                child.StartsWith(parent, StringComparison.OrdinalIgnoreCase) ||
                parent.TrimEnd('\\').Equals(child, StringComparison.OrdinalIgnoreCase);
        }
    }
    public class InternalErrorException : Exception {
        public InternalErrorException(string message)
            : base(message) {
        }
    }
}