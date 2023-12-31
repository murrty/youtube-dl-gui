using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE1006:Naming Styles")]
[assembly: SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "<Pending>")]

[assembly: SuppressMessage("Roslynator", "RCS1135:Declare enum member with zero value (when enum has FlagsAttribute).", Justification = "Invalid", Scope = "type", Target = "~T:murrty.controls.ScrollInfoMask")]
[assembly: SuppressMessage("Roslynator", "RCS1135:Declare enum member with zero value (when enum has FlagsAttribute)", Justification = "Invalid", Scope = "type", Target = "~T:murrty.controls.ProgressState")]
[assembly: SuppressMessage("Roslynator", "RCS1191:Declare enum value as combination of names", Justification = "Ugly")]

[assembly: SuppressMessage("Roslynator", "RCS1110:Declare type inside namespace.", Justification = "<Pending>", Scope = "type", Target = "~T:Extensions")]

[assembly: SuppressMessage("Roslynator", "RCS1194:Implement exception constructors", Justification = "<Pending>", Scope = "type", Target = "~T:youtube_dl_gui.DownloadException")]
[assembly: SuppressMessage("Roslynator", "RCS1194:Implement exception constructors", Justification = "<Pending>", Scope = "type", Target = "~T:youtube_dl_gui.ExtractOnlyException")]
[assembly: SuppressMessage("Roslynator", "RCS1194:Implement exception constructors", Justification = "<Pending>", Scope = "type", Target = "~T:youtube_dl_gui.InvalidDownloadProviderException")]
