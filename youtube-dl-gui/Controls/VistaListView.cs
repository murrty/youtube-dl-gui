using System.Windows.Forms;

namespace youtube_dl_gui.Controls {
    class VistaListView : ListView {
        private bool UseVistaStyle = true;

        public VistaListView() {
            this.View = View.Details;
        }

        public bool EnableVistaView {
            get { return this.UseVistaStyle; }
            set {
                this.UseVistaStyle = value;
                if (value) {
                    NativeMethods.SetWindowTheme(this.Handle, "eplorer", null);
                }
                else {
                    NativeMethods.SetWindowTheme(this.Handle, null, null);
                }
            }
        }
    }
}
