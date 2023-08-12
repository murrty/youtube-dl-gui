/*
 * Developer    : Willy Kimura (WK).
 * Library      : BetterFolderBrowser.
 * License      : MIT.
 * modified by murrty
 */


using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

using BetterFolderBrowserNS.Editors;

namespace BetterFolderBrowserNS {
    /// <summary>
    /// A Windows Forms component that enhances the standard folder-browsing experience.
    /// </summary>
    [DefaultProperty("RootFolder")]
    [ToolboxBitmap(typeof(FolderBrowserDialog))]
    [Description("A .NET component library that delivers a better folder-browsing and selection experience.")]
    public class BetterFolderBrowser : CommonDialog {

        #region Designer
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent() {
            components = new System.ComponentModel.Container();
        }

        #endregion
        #endregion

        #region Constructors

        public BetterFolderBrowser() {
            InitializeComponent();
            _dialog = new() {
                AllowMultiselect = default,
                InitialDirectory = default,
                Title = default
            };
        }

        public BetterFolderBrowser(IContainer container) {
            container.Add(this);
            InitializeComponent();
            SetDefaults();
        }

        #endregion

        #region Fields

        private readonly Helpers.BetterFolderBrowserDialog _dialog;

        /// <summary>
        /// Used in creating a <see cref="UITypeEditor"/> service
        /// for extending its usage into the Properties window.
        /// Developers can use it where possible.
        /// </summary>
        internal IWindowsFormsEditorService editorService;

        #endregion

        #region Properties

        #region Browsable

        /// <summary>
        /// Gets or sets the folder dialog box title.
        /// </summary>
        [Category("Better Folder Browsing")]
        [Description("Sets the folder dialog box title.")]
        [DefaultValue("Please select a folder...")]
        public string Title {
            get => _dialog.Title;
            set => _dialog.Title = value;
        }

        /// <summary>
        /// Gets or sets the root folder where the browsing starts from.
        /// </summary>
        [Category("Better Folder Browsing")]
        [Editor(typeof(SelectedPathEditor), typeof(UITypeEditor))]
        [Description("Sets the root folder where the browsing starts from.")]
        [DefaultValue("")]
        public string RootFolder {
            get => _dialog.InitialDirectory;
            set => _dialog.InitialDirectory = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the 
        /// dialog box allows multiple folders to be selected.
        /// </summary>
        [Category("Better Folder Browsing")]
        [Description("Sets a value indicating whether the dialog " +
                     "box allows multiple folders to be selected.")]
        [DefaultValue(false)]
        public bool Multiselect {
            get => _dialog.AllowMultiselect;
            set => _dialog.AllowMultiselect = value;
        }

        #endregion

        #region Non-browsable

        /// <summary>
        /// Gets the folder-path selected by the user.
        /// </summary>
        [Browsable(false)]
        public string SelectedPath => _dialog.FileName;

        /// <summary>
        /// Gets the list of folder-paths selected by the user.
        /// </summary>
        [Browsable(false)]
        public string[] SelectedPaths => _dialog.FileNames;

        #endregion

        #endregion

        #region Methods

        #region Private

        private void SetDefaults() {
            _dialog.AllowMultiselect = false;
            _dialog.Title = "Please select a folder...";
            _dialog.InitialDirectory = "";
        }

        #endregion

        #region Public

        /// <summary>
        /// Runs a common dialog box with a default owner.
        /// </summary>
        public new DialogResult ShowDialog() => _dialog.ShowDialog(0) ? DialogResult.OK : DialogResult.Cancel;

        /// <summary>
        /// Runs a common dialog box with the specified owner.
        /// </summary>
        /// <param name="owner">
        /// Any object that implements <see cref="IWin32Window"/> that represents
        /// the top-level window that will own the modal dialog box.
        /// </param>
        public new DialogResult ShowDialog(IWin32Window owner) => _dialog.ShowDialog(owner.Handle) ? DialogResult.OK : DialogResult.Cancel;

        #endregion

        #region Overrides

        /// <summary>
        /// Specifies a common dialog box.
        /// </summary>
        /// <param name="hwndOwner">
        /// Any object that implements <see cref="IWin32Window"/> that represents
        /// the top-level window that will own the modal dialog box.
        /// </param>
        /// <returns></returns>
        protected override bool RunDialog(nint hwndOwner) => _dialog.ShowDialog(hwndOwner);

        /// <summary>
        /// Resets all properties to their default values.
        /// </summary>
        public override void Reset() => SetDefaults();

        #endregion

        #endregion
    }
}

namespace BetterFolderBrowserNS.Editors {
    /// <summary>
    /// Provides a custom <see cref="BetterFolderBrowser"/> UI Editor
    /// for browsing through folders via the Properties window. 
    /// This allows for the selection of a single folder.
    /// It's designed as a replacement for <see cref="FolderBrowserDialog"/>'s
    /// <see cref="UITypeEditor"/>.
    /// 
    /// <para>
    /// Example:
    /// <code>[Editor(typeof(BetterFolderBrowserPathEditor), typeof(UITypeEditor))]</code>
    /// </para>
    /// </summary>
    [DebuggerStepThrough]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectedPathEditor : UITypeEditor {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService editorService) {
                BetterFolderBrowser editor = new() {
                    editorService = editorService,
                    Multiselect = false
                };


                if (editor.ShowDialog() == DialogResult.OK)
                    value = editor.SelectedPath;
            }

            return value;
        }
    }

    /// <summary>
    /// Provides a custom <see cref="BetterFolderBrowser"/> UI Editor
    /// for browsing through folders via the Properties window. 
    /// This allows for the selection of a single folder.
    /// It's designed as a replacement for <see cref="FolderBrowserDialog"/>'s
    /// <see cref="UITypeEditor"/>.
    /// 
    /// <para>
    /// Example:
    /// <code>[Editor(typeof(BetterFolderBrowserPathsEditor), typeof(UITypeEditor))]</code>
    /// </para>
    /// </summary>
    [DebuggerStepThrough]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SelectedPathsEditor : UITypeEditor {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value) {
            if (provider.GetService(typeof(IWindowsFormsEditorService)) is IWindowsFormsEditorService editorService) {
                BetterFolderBrowser editor = new() {
                    editorService = editorService,
                    Multiselect = true
                };


                if (editor.ShowDialog() == DialogResult.OK)
                    value = editor.SelectedPaths;
            }

            return value;
        }
    }
}

namespace BetterFolderBrowserNS.Helpers {
    /// <summary>
    /// This class is from the Front-End for Dosbox and is 
    /// used to present a 'vista' dialog box to select folders.
    /// http://code.google.com/p/fed/
    ///
    /// For example:
    /// ----------------------------------------------
    /// var r = new Reflector("System.Windows.Forms");
    /// </summary>
    public class Reflector {
        #region Fields

        private readonly string m_ns;
        private readonly Assembly m_asmb;

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new <see cref="Reflector"/> class object.
        /// </summary>
        /// <param name="ns">The namespace containing types to be used.</param>
        public Reflector(string ns) : this(ns, ns) { }

        /// <summary>
        /// Creates a new <see cref="Reflector"/> class object.
        /// </summary>
        /// <param name="an__1">
        /// A specific assembly name (used if the assembly name does not tie exactly with the namespace)
        /// </param>
        /// <param name="ns">The namespace containing types to be used.</param>
        public Reflector(string an__1, string ns) {
            m_ns = ns;
            m_asmb = null;

            AssemblyName[] s = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
            for (int i = 0; i < s.Length; i++) {
                if (s[i].FullName.StartsWith(an__1)) {
                    m_asmb = Assembly.Load(s[i]);
                    break;
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Return a Type instance for a type 'typeName'.
        /// </summary>
        /// <param name="typeName">The name of the type.</param>
        /// <returns>A type instance.</returns>
        public Type GetTypo(string typeName) {
            string[] names = typeName.Split('.');
            Type type = names.Length > 0 ? m_asmb.GetType((m_ns + Convert.ToString(".")) + names[0]) : null;

            for (int i = 1; i < names.Length; i++) {
                type = type.GetNestedType(names[i], BindingFlags.NonPublic);
            }

            return type;
        }

        /// <summary>
        /// Create a new object of a named type passing along any params.
        /// </summary>
        /// <param name="name">The name of the type to create.</param>
        /// <param name="parameters">An array of passed parameters.</param>
        /// <returns>An instantiated type.</returns>
        public object New(string name, params object[] parameters) {
            Type type = GetTypo(name);
            ConstructorInfo[] ctorInfos = type.GetConstructors();
            return ctorInfos.Length > 0 ? ctorInfos[0].Invoke(parameters) : null;
        }

        /// <summary>
        /// Calls method 'func' on object 'obj' passing parameters 'parameters'.
        /// </summary>
        /// <param name="obj">The object on which to excute function 'func'.</param>
        /// <param name="func">The function to execute.</param>
        /// <param name="parameters">The parameters to pass to function 'func'.</param>
        /// <returns>The result of the function invocation.</returns>
        public object Call(object obj, string func, params object[] parameters) {
            return Call2(obj, func, parameters);
        }

        /// <summary>
        /// Calls method 'func' on object 'obj' passing parameters 'parameters'.
        /// </summary>
        /// <param name="obj">The object on which to excute function 'func'.</param>
        /// <param name="func">The function to execute.</param>
        /// <param name="parameters">The parameters to pass to function 'func'.</param>
        /// <returns>The result of the function invocation.</returns>
        public object Call2(Object obj, string func, object[] parameters) {
            return CallAs2(obj.GetType(), obj, func, parameters);
        }

        /// <summary>
        /// Calls method 'func' on object 'obj' which is of type 'type' passing parameters 'parameters'.
        /// </summary>
        /// <param name="type">The type of 'obj'.</param>
        /// <param name="obj">The object on which to excute function 'func'.</param>
        /// <param name="func">The function to execute.</param>
        /// <param name="parameters">The parameters to pass to function 'func'.</param>
        /// <returns>The result of the function invocation.</returns>
        public object CallAs(Type type, object obj, string func, params object[] parameters) {
            return CallAs2(type, obj, func, parameters);
        }

        /// <summary>
        /// Calls method 'func' on object 'obj' which is of type 'type' passing parameters 'parameters'.
        /// </summary>
        /// <param name="type">The type of 'obj'.</param>
        /// <param name="obj">The object on which to excute function 'func'.</param>
        /// <param name="func">The function to execute.</param>
        /// <param name="parameters">The parameters to pass to function 'func'.</param>
        /// <returns>The result of the function invocation.</returns>
        public object CallAs2(Type type, object obj, string func, object[] parameters) {
            return type.GetMethod(func, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).Invoke(obj, parameters);
        }

        /// <summary>
        /// Returns the value of property 'prop' of object 'obj'.
        /// </summary>
        /// <param name="obj">The object containing 'prop'.</param>
        /// <param name="prop">The property name.</param>
        /// <returns>The property value.</returns>
        public object Get(Object obj, string prop) {
            return GetAs(obj.GetType(), obj, prop);
        }

        /// <summary>
        /// Returns the value of property 'prop' of object 'obj' which has type 'type'.
        /// </summary>
        /// <param name="type">The type of 'obj'.</param>
        /// <param name="obj">The object containing 'prop'.</param>
        /// <param name="prop">The property name.</param>
        /// <returns>The property value.</returns>
        public object GetAs(Type type, object obj, string prop) {
            return type.GetProperty(prop, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic).GetValue(obj, null);
        }

        /// <summary>
        /// Returns an enum value.
        /// </summary>
        /// <param name="typeName">The name of enum type.</param>
        /// <param name="name">The name of the value.</param>
        /// <returns>The enum value.</returns>
        public object GetEnum(string typeName, string name) {
            return GetTypo(typeName).GetField(name).GetValue(null);
        }

        #endregion
    }

    /// <summary>
    /// Wraps System.Windows.Forms.OpenFileDialog to make it present
    /// a vista-style dialog.
    /// </summary>
    public class BetterFolderBrowserDialog {
        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        public BetterFolderBrowserDialog() {
            ofd = new() {
                Filter = "Folders|" + "\n",
                AddExtension = false,
                CheckFileExists = false,
                DereferenceLinks = true,
                Multiselect = false
            };
        }

        static BetterFolderBrowserDialog() {
            IsWine = Process.GetProcessesByName("winlogon").Length < 1;
            IsVistaNT = Environment.OSVersion.Platform == PlatformID.Win32NT && Environment.OSVersion.Version.Major >= 6;
        }

        #endregion

        #region Fields

        private readonly OpenFileDialog ofd = null;
        private static readonly bool IsWine;
        private static readonly bool IsVistaNT;

        #endregion

        #region Properties

        /// <summary>
        /// Gets/Sets a value indicating whether to allow multi-selection of folders.
        /// </summary>
        /// <remarks></remarks>
        public bool AllowMultiselect {
            get => ofd.Multiselect;
            set => ofd.Multiselect = value;
        }

        /// <summary>
        /// Gets the list of selected folders as filenames.
        /// </summary>
        public string[] FileNames => ofd.FileNames;

        /// <summary>
        /// Gets/Sets the initial folder to be selected. A null value selects the current directory.
        /// </summary>
        public string InitialDirectory {
            get => ofd.InitialDirectory;
            set => ofd.InitialDirectory = (value == null || value.Length == 0) ? Environment.CurrentDirectory : value;
        }

        /// <summary>
        /// Gets/Sets the title to show in the dialog.
        /// </summary>
        public string Title {
            get => ofd.Title;
            set => ofd.Title = value ?? "Select a folder";
        }

        /// <summary>
        /// Gets the selected folder.
        /// </summary>
        public string FileName => ofd.FileName;

        #endregion

        #region Methods

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <returns>True if the user presses OK else false.</returns>
        public bool ShowDialog() => ShowDialog(0);

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="hWndOwner">Handle of the control to be parent.</param>
        /// <returns>True if the user presses OK else false.</returns>
        public bool ShowDialog(nint hWndOwner) {
            bool flag = false;

            if (!IsWine && IsVistaNT) {
                var r = new Reflector("System.Windows.Forms");

                uint num = 0;
                Type typeIFileDialog = r.GetTypo("FileDialogNative.IFileDialog");
                object dialog = r.Call(ofd, "CreateVistaDialog");
                r.Call(ofd, "OnBeforeVistaDialog", dialog);

                uint options = Convert.ToUInt32(r.CallAs(typeof(FileDialog), ofd, "GetOptions"));
                options |= Convert.ToUInt32(r.GetEnum("FileDialogNative.FOS", "FOS_PICKFOLDERS"));
                r.CallAs(typeIFileDialog, dialog, "SetOptions", options);

                object pfde = r.New("FileDialog.VistaDialogEvents", ofd);
                object[] parameters = new object[] { pfde, num };
                r.CallAs2(typeIFileDialog, dialog, "Advise", parameters);

                num = Convert.ToUInt32(parameters[1]);

                try {
                    flag = 0 == Convert.ToInt32(r.CallAs(typeIFileDialog, dialog, "Show", hWndOwner));
                }
                finally {
                    r.CallAs(typeIFileDialog, dialog, "Unadvise", num);
                    GC.KeepAlive(pfde);
                }
            }
            else {
                FolderBrowserDialog fbd = new() {
                    Description = this.Title,
                    SelectedPath = this.InitialDirectory,
                    ShowNewFolderButton = false
                };

                if (fbd.ShowDialog(new WindowWrapper(hWndOwner)) != DialogResult.OK) {
                    return false;
                }

                ofd.FileName = fbd.SelectedPath;
                flag = true;
            }

            return flag;
        }

        #endregion
    }

    /// <summary>
    /// Creates IWin32Window around an IntPtr.
    /// </summary>
    public class WindowWrapper : IWin32Window {

        #region Properties

        /// <summary>
        /// Original pointer.
        /// </summary>
        public nint Handle { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Provides a wrapper for <see cref="IWin32Window"/>.
        /// </summary>
        /// <param name="handle">Handle to wrap.</param>
        public WindowWrapper(nint handle) {
            Handle = handle;
        }

        #endregion

    }
}